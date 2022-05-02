# Contador de Frequência de Palavras MPI

## 🎁 Sobre

Este projeto tem como objetivo principal atender a uma demanda avaliativa na disciplina PGCC011 (Computação de Alto Desempenho) do Programa de Pós-Graduação em Ciências da Computação (stricto sensu) da Universidade Estadual de Feira de Santana. Para tanto, o presente projeto deve contribuir na verificação do comportamento da escalabilidade de códigos seriais nas linguagens C, bem como as possíveis razões para as diferenças (ou não) de desempenho. Desta forma, foram desenvolvidos os códigos serial e paralelo na linguagem de programação C++ para cômputo da frequência de palavras em arquivos textos.

## 🚀 Começando

### 📋 Pré-requisitos para compilação

Abaixo, orientações de compilação:

**Pré-Requisitos**
*Para o código paralelo em C (após gerar o executável):*
```
$ mpirun -n <quantidadenodos> ./contaPalavrasMPI.e <nomedoarquivo.txt> <arquivosaida.txt>
```
