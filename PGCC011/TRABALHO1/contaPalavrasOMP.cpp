// Programa C++ para calcular a frequ�ncia
// de cada palavra na string dada
#include <bits/stdc++.h>
#include <locale>
#include <omp.h>

using namespace std;

// Fun��o para imprimir a frequ�ncia de cada palavra
std::map<std::string, int> mapearPalavras(string linha, map<string, int> M){
	// String para armazenar a palavra
	string palavra = "";
	char c;
	for (int i = 0; i < linha.size(); i++){
		c=tolower(linha[i]);
    	// Verifique se o caractere atual
        // �  um espa�o em branco ent�o
        // significa que temos uma palavra
		if (c == ' '){
			if (palavra.size()>1)
			{
				// Se a palavra atual
	            // n�o for encontrado, insira
	            // palavra atual com frequ�ncia 1
				if (M.find(palavra) == M.end())
				{
					M.insert(make_pair(palavra, 1));
					palavra = "";
				}
				// atualiza a frequ�cia
				else
				{
					M[palavra]++;
					palavra = "";
				}
			}
			else{
				palavra = "";
			}
		}
        // Se o caractere atual for uma das op��es abaixo,adicionar na palavra     
        if((c>=97 && c<=122)||(c>=-32 && c<=-1))
		{//Aqui temos os numerais dos caracteres de letras e acentua��es na tabela ASCII
           palavra += c;            
        }
                   
	}
	if (palavra.size()>1)
	{
		// Armazenando a �ltima palavra da string
		if (M.find(palavra) == M.end())
			M.insert(make_pair(palavra, 1));
		// Atualiza a frequencia 
		else
			M[palavra]++;
		return M;
	}
	else
	{
		return M;
	}
}

std::multimap<int, string> sort(map<string, int>& M){
  
    //Declara um multimap para realizar a ordena��o
    multimap<int, string> MM;
  
    // Insere cada par (chave-valor) do
    // mapa M no multimap MM como um par (valor-chave)
    for (auto& it : M) {
        MM.insert({ it.second, it.first });
    }
  
    return MM;
}

// fun��o principal
int main(){
	setlocale(LC_ALL,"Portuguese");
	omp_set_num_threads(4); // determina o n�mero de threads
	//printf("%d", omp_get_num_threads());
	map<string, int> Mapas[4];
	map<string, int> MapaJunto;
	multimap<int, string> MapaOrdenado;
  	FILE *arq;
  	char Linha[1000];
  	char *result;
  	int i;
  	int qntValores;
  	// Abre um arquivo TEXTO para LEITURA
  	arq = fopen("arquivo.txt", "rt");
  	// Se houve erro na abertura
  	if (arq == NULL){
     	printf("Problemas na abertura do arquivo\n");
     	return 0;
  	}
  	
  	
  	#pragma omp parallel
	{
	  	while (!feof(arq))
		{
			// L� uma linha 
			result = fgets(Linha, 1000, arq);  // o 'fgets' l� at� 999 caracteres ou at� o '\n'
			if (result)
			{
		    	// Se foi poss�vel ler
	      		Mapas[omp_get_thread_num()] = mapearPalavras(result, Mapas[omp_get_thread_num()]);
			}
  	    }
	}
   
	fclose(arq);

	for(i=0; i<4; i++){
		for (auto& it : Mapas[i]) 
		{
			if (MapaJunto.find(it.first) == MapaJunto.end())
			{
        		MapaJunto.insert({ it.first, it.second });
			}
			else
			{
				MapaJunto[it.first]+=it.second;
			}
		}
	}	

	MapaOrdenado=sort(MapaJunto);
	qntValores= 20; //PERSONALIZAR QUANTIDADE DE VALORES A SEREM IMPRESSOS
    	
    // Gerar Arquivo de Sa�da:
  	std::multimap<int,string>::reverse_iterator rit;
  	rit=MapaOrdenado.rbegin();
  	freopen("resultadoOMP.txt","w",stdout);
  	for (i=0; i<qntValores; i++)
	{
    	//Garante que qntValores n�o � maior que quantidade de palavras no arquivo
		if(MapaOrdenado.size()<=(unsigned)i)
		{
        	break;
    	}
		else
		{
			//imprime a quantidade de palavras e a palavra
    		std::cout << rit->first << " => " << rit->second << '\n';
    		++rit;
    	}
  	}	
	return 0;
}
