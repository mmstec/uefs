/*
 *------------------------------------------------------------------------------------------
 * Programa C++ para calcular a frequência de palavras em um arquivo texto.
 * Nome: contaPalavrasGPU.cpp
 * Versão: serial
 *------------------------------------------------------------------------------------------
 * Autores:
 *    	Luciano   		<lucianoamjunior@gmail.com>
 *    	Marcos Morais 	<marcosmoraisjr@yahoo.com.br>
 * 		State University of Feira de Santana 
 * 		Feira de Santana - BA, Brazil
 * 		PGCC011 - Self-Performance Computing
 * 		Professor Angelo Amâncio Duarte 
 * 		PhD in Computer Science, UAB, Spain
 *------------------------------------------------------------------------------------------
 * Instruções para compilar e rodar com openCL no windows:
  * 		executar o arquivo: compilar.bat
 *------------------------------------------------------------------------------------------
 * Este programa é um software livre; você pode redistribuí-lo e / ou modificá-lo
 * sob os termos da GNU General Public License conforme publicada pela
 * Free Software Foundation; seja a versão 2 da Licença, ou 
 * qualquer versão posterior, desde que cite os autores.
 *------------------------------------------------------------------------------------------
*/
#include <bits/stdc++.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <vector>

#ifdef __APPLE__
#include <OpenCL/opencl.h>
#else
#include <CL/opencl.h>
#endif
#define ARRAY_LENGTH 1000
#define MEM_SIZE (128)
#define MAX_SOURCE_SIZE (0x100000)

#include "err_code.h"
#define MAX_WORD_LENGTH 30

typedef struct word{
	char palavra[MAX_WORD_LENGTH];
	int tamanho;
};

std::vector<std::string> vetPalavras;

void pegaPalavras(std::string linha){
	// String para armazenar a palavra
	std::string palavra = "";
	char c;
	for (int i = 0; (unsigned)i < linha.size(); i++){
		c=tolower(linha[i]);
    	// Verifique se o caractere atual
        // Ã©  um espaÃ§o em branco entÃ£o
        // significa que temos uma palavra
		if (c == ' '){
			if (palavra.size()>1 && palavra.size()<=MAX_WORD_LENGTH-1){
				// Se a palavra atual
	            // não for encontrado, insira
	            // palavra atual com frequência 1
				vetPalavras.push_back(palavra);
				palavra="";
			}
			else{
				palavra = "";
			}
		}
        // Se o caractere atual for uma das opções abaixo,adicionar na palavra     
        if((c>=97 && c<=122)||(c>=-32 && c<=-1)){//Aqui temos os numerais dos caracteres de letras e acentuaÃ§Ãµes na tabela ASCII
           palavra += c;            
        }
                   
	}
	if (palavra.size()>1 && palavra.size()<=MAX_WORD_LENGTH-1){
		// Armazenando a última palavra da string
		vetPalavras.push_back(palavra);
		palavra="";
	}
}

int main(int argc, char** argv)
{
	setlocale(LC_ALL,"Portuguese");
	if(argc != 3) {
		printf("\nSintaxe: ",argv[0]," arquivo.txt resultado.txt \n\n");
		return 1;
    }
	
	/* Variáveis para armazenamento de referências a objetos OpenCL */
	cl_char string[10240] = {0};
	cl_platform_id platformId;
	cl_device_id deviceId;
	cl_context context;
	cl_command_queue queue;
	cl_program program;
	cl_kernel kernel;
	
	cl_mem bufSend;
	cl_mem bufReturn;
	
	/* Variáveis diversas da aplicação */
	word* hostSend;
	word* hostReturn;
	
	size_t globalSize[1] = { ARRAY_LENGTH };
	int i = 0;
	int numPalavras = 0;
	char *result;
	char Linha[1000];

	/************************************/
	/* Código-fonte do kernel do arquivo*/
	FILE *fp;
    char fileName[] = "kernelPalavras.cl";
    char *source_str;
    size_t source_size;
	/* Carregue o código-fonte contendo o kernel */
    fp = fopen(fileName, "r");
        if (!fp) {
			fprintf(stderr, "Falha ao carregar o kernel.\n");
			exit(1);
    }
    source_str = (char*)malloc(MAX_SOURCE_SIZE);
    source_size = fread(source_str, 1, MAX_SOURCE_SIZE, fp);
    fclose(fp);
	/************************************/
	
	/* Obtenção de identificadores de plataforma e dispositivo. Será solicitada uma GPU. */
	clGetPlatformIDs(1, &platformId, NULL);
	clGetDeviceIDs(platformId, CL_DEVICE_TYPE_GPU,
	1, &deviceId, NULL);
	
	/* Criação do contexto */
	context = clCreateContext(0, 1, &deviceId,
	NULL, NULL, NULL);

	/* Criação da fila de comandos para o dispositivo encontrado */
	queue = clCreateCommandQueue(context, deviceId,
	0, NULL);
	
	/* Criação do objeto de programa a partir do código-fonte armazenado na string source */
	//program = clCreateProgramWithSource(context, 1, &source, NULL, NULL);
	program = clCreateProgramWithSource(context, 1, (const char **)&source_str,(const size_t *)&source_size, NULL);
	
	/* Compilação do programa para todos os dispositivos do contexto */
	clBuildProgram(program, 0, NULL, NULL, NULL, NULL);
	
	/* Obtenção de um kernel a partir do programa compilado */
	kernel = clCreateKernel(program, "contaPalavras", NULL);
	
	/* Alocação e inicialização dos arrays no hospedeiro */
	
	/**********************************************/
	/* lendo arquivo texto */
	printf("\nlendo arquivo e populando vetor de palavras\n");
	FILE *arq;
	arq = fopen(argv[1], "rt");
  	
	// Se houve erro na abertura
  	if (arq == NULL){
     	printf("Problemas na abertura do arquivo\n");
     	return 0;
  	}
  	
  	while (!feof(arq)){
	  // o 'fgets' lê até 1000 caracteres ou até o '\n'
	  result = fgets(Linha, 1000, arq);
      if (result){  // Se foi possível ler
		  pegaPalavras(result);
	  }
  	}
  	fclose(arq);
  	
  	//for (int i = 0; i < vetPalavras.size(); i++)
   //     std::cout <<vetPalavras[i]<< "\n";
	
	numPalavras=vetPalavras.size();
	hostSend = (word*) malloc(numPalavras*sizeof(word));
	hostReturn = (word*) malloc(numPalavras*sizeof(word));
	
	for(int i = 0; i < numPalavras; i++ ){
		for(int j = 0; j < vetPalavras[i].size(); j++ ){ 
			hostSend[i].palavra[j]=vetPalavras[i][j]+'\0';
		}
		hostSend[i].tamanho = vetPalavras[i].size()+1;
	}
	
	//printf("\nTESTANDO\n\n");
	//for(int x = 0; x < vetPalavras.size(); x++ ){ 
	//	printf("palavra:%s tamanho: %d\n",hostSend[x].palavra,hostSend[x].tamanho);
	//}
	
	
	/* Criação dos objetos de memória para comunicação com a memória global do dispositivo encontrado */	
	bufSend = clCreateBuffer(context, CL_MEM_READ_ONLY,
	numPalavras * sizeof(word), NULL, NULL);
	bufReturn = clCreateBuffer(context, CL_MEM_READ_WRITE,
	numPalavras * sizeof(word), NULL, NULL);
	

	
	/* Transferência dos arrays de entrada para a memória do dispositivo */
	clEnqueueWriteBuffer(queue, bufSend, CL_TRUE, 0,
	numPalavras * sizeof(word), hostSend, 0,
	NULL, NULL);
	
	/* Configuração dos argumentos do kernel */
	clSetKernelArg(kernel, 0, sizeof(cl_mem), &bufSend);
	clSetKernelArg(kernel, 1, sizeof(cl_mem), &bufReturn);	
	
	/* Envio do kernel para execução no dispositivo */
	clEnqueueNDRangeKernel(queue, kernel, 1, NULL,
	globalSize, NULL, 0, NULL, NULL);
	
	/* Sincronização (bloqueia hospedeiro até término da execução do kernel */
	clFinish(queue);
	
	/* Transferência dos resultados da computação para a memória do hospedeiro */
	clEnqueueReadBuffer(queue, bufReturn, CL_TRUE, 0,
	numPalavras * sizeof(word), hostReturn, 0,
	NULL, NULL);
	
	
	/* Impressão dos resultados na saída padrão */	
	printf("----------------------------------");
	printf("\nENVIO DE PALAVRAS");
	printf("\nTAMANHO    | PALAVRA");
	printf("\n-----------+----------------------\n");
	for(int x = 0; x < vetPalavras.size(); x++ ){ 
		printf("%4d       | %s \n",hostSend[x].tamanho,hostSend[x].palavra);
	}
	printf("-----------+----------------------");
	
	
	printf("\n\n----------------------------------");
	printf("\nCOMPUTANDO PALAVRAS NA GPU");
	printf("\nFREQUENCIA | PALAVRAS AGRUPADAS");
	printf("\n-----------+----------------------\n");
	for(int x = 0; x < vetPalavras.size(); x++ ){ 
		printf("%4d       | %s \n", hostReturn[x].tamanho, hostReturn[x].palavra);
	}
	printf("-----------+----------------------\n\n");
	
	
	/* Liberação de recursos e encerramento da aplicação */
	clReleaseMemObject(bufSend);
	clReleaseMemObject(bufReturn);
	clReleaseKernel(kernel);
	clReleaseProgram(program);
	clReleaseCommandQueue(queue);
	clReleaseContext(context);
	free(hostSend);
	free(hostReturn);
	 
	return 0;
}
