# Contador de Frequência de Palavras OpenCL

## 🎁 Sobre

Este projeto tem como objetivo principal atender a uma demanda avaliativa na disciplina PGCC011 (Computação de Alto Desempenho) do Programa de Pós-Graduação em Ciências da Computação (stricto sensu) da Universidade Estadual de Feira de Santana. Para tanto, o presente projeto deve contribuir na verificação do comportamento da escalabilidade de códigos seriais nas linguagens C, bem como as possíveis razões para as diferenças (ou não) de desempenho. Desta forma, foram desenvolvidos os códigos serial e paralelo na linguagem de programação C++ para cômputo da frequência de palavras em arquivos textos.

## 🚀 Começando

Os Arquivos necessários e todas as orientações para uso deste projeto, estão neste repositório.

### 📋 Pré-requisitos para compilação

Recomendamos que o sistema operacional e os pacotes, descritos acima, estejam na versão mais recente possível.

Siga os passos abaixo:

```
1. Crie uma pasta na raiz do seu sistema operacional.
2. Baixe os arquivos deste projeto na pasta criada.
3. Seus arquivos estão prontos para uso.
```

Abaixo, orientações de compilação:

### ⚙️ Executando

**Como executar**

Basta abrir o .bat. É importante alterar esse .bat de acordo com seu hardware, x32 ou x64, além disso, as bibliotecas e cabeçalhos do .bat são os da AMD e o usuário terá que alterar para referenciá-los de acordo com o hardware.

## 📦 Arquivos

1. Algoritmo serial em C++
```
contaPalavras.cpp 
```
2. Versão paralelizada do item 1, em C++, usando OpenCL
```
contaPalavrasOpenCL.cpp
```


## 🛠️ Construído em

* [C++](http://www.bloodshed.net/devcpp.html) 

## ✒️ Autores

<table>
  <tr>
    <td align="center"><a href="https://github.com/lamjunioor"><img style="border-radius: 15px 50px 30px 5px;" src="https://avatars.githubusercontent.com/u/42066765?v=4" width="100px;" alt=""/><br /><sub><b>Luciano Júnior</b></sub></a><br /> Documentação/Desenvolvimento</td>
    <td align="center"><a href="https://github.com/mmstec"><img style="border-radius: 15px 50px 30px 5px;" src="https://avatars.githubusercontent.com/u/26969915?v=4" width="100px;" alt=""/><br /><sub><b>Marcos Morais</b></sub></a><br />Documentação/Desenvolvimento</a></td>
  </tr>
</table>

## 🎁 Instituição de Ensino

* [UEFS - Universidade Estadual de Feira de Santana](https://www.uefs.br/) <br />
* [PGCC - Pós-Graduação em Ciências da Computação](https://pgcc.uefs.br/home) <br />
* PGCC011 - Computação de Alto Desempenho <br />
* Professor - [Angelo Amâncio Duarte](https://pgcc.uefs.br/sobre/docentes/angeloduarte) <br /> 

## 🚀 Citação

```
@MISC{contapalavras,
    author = {Luciano Junior, Marcos Morais},
    title = {{Contador de Frequencia de Palavras em MPI}},
    howpublished = "\url{https://github.com/mmstec/PGCC011-TB2}",
    year = {2021},
  }
```
## 📄 Licença

Este projeto está sob a licença - veja o arquivo [LICENSE.md](https://github.com/mmstec/PGCC011/blob/main/LICENSE.md) para detalhes.
