
## 🎁 Sobre

Este trabalho tem como objetivo principal, apresentar um método computacional para estimação de Fibrose Intersticial, critério usado no Tratamento Renal Substitutivo ( TRS ), a partir de imagens digitais de biópsias renais, sob a perspectiva do Escore de Banff para Lesão.
Os Arquivos necessários e todas as orientações para uso deste projeto, estão neste repositório.
 
## ❕ Pré-Requisitos

O método computacional para segmentação de fibrose intersticial aqui apresentado, comunica-se com um software de anotação, o Cytomine. Portanto, o Cytomine é requerido para que o funcionamento ocorra como esperado. 

Para a comunicação entre o algoritmo segmentador e o software de anotação , é preciso de internet e da API Cytomine. Como o Cytomine, a API e o algoritmo desenvolvido funcionam em Python, é necessário que o mesmo esteja instalado no computador em conjunto com o framework OpenCV versão 3.9.

Para instalação do Cytomine e da API Cytomine, consultar a documentação disponível em:

- https://doc.cytomine.org/admin-guide/install ( Cytomine )
- https://doc.uliege.cytomine.org/dev-guide/clients/python/installation ( Api Cytomine )

## 🔑 Requisitos

### Hardware

É recomendado um mínimo de:
-memória RAM : 8GB
-Espaço em Disco: 20GB
-Processador: Dual-core AMD 64, EM64T
-Sistemas Operacionais: GNU/Linux, Windows, MacOS.

É preciso fornecer espaço suficiente para armazenar as imagens que serão analisadas ( depende do tamanho ).

### Software
O script segmentador.py pode ser instalado em qualquer sistema operacional que suporte versões recentes do Python e do OpenCV. 
A maioria das distribuições Linux ( incluindo Ubuntu, CentOS ) e Mac OS X Yosemite e acima atendem bem.

## ✔️ Instalar
Siga os passos abaixo:
```
1. Crie uma pasta na raiz do seu sistema operacional.
2. Baixe os arquivos deste projeto na pasta criada.
3. Seus arquivos estão prontos para uso.
```

## 🎯 Execução 
*Para executá-lo, o comando deve ser assim:*
```
$ python estimadorfi.py --host http://pathospotter-cytomine-core.bahia.fiocruz.br --public_key AAA --private_key ZZZ
```

*Nota:* 
```
Para ter acesso a --public_key e --private_key, é preciso permissão especial solicitada junto ao orientador deste trabalho.
```
## 🎁 Instituição de Ensino
* [UEFS - Universidade Estadual de Feira de Santana](https://www.uefs.br/) <br />
* [PGCC - Pós-Graduação em Ciências da Computação](https://pgcc.uefs.br/home) <br />
* PGCC002 - Exame de Qualificação<br />
* Orientador - [Angelo Amâncio Duarte](https://pgcc.uefs.br/sobre/docentes/angeloduarte) <br /> 
* Coorientador - [Washington L.C. dos Santos](https://scholar.google.com.br/citations?user=fr3-PGsAAAAJ&hl=pt-BR) <br /> 
 
## ✒️ Autor
<a href="https://github.com/mmstec"><img style="border-radius: 15px 50px 30px 5px;" src="https://avatars.githubusercontent.com/u/26969915?v=4" width="100px;" alt=""/><br /><sub><b>Marcos Morais</b></sub></a>

## 🚀 Citação
```
@MISC{estimadorfi2022,
    author = {Marcos Morais},
    title = {{Estimador de Fibrose Intersticial}},
    howpublished = "\url{https://github.com/mmstec/uefs}",
    year = {2022},
  }
```
## 📄 Licença
Este projeto está sob a licença - veja o arquivo [LICENSE](https://github.com/mmstec/uefs/blob/main/LICENSE) para detalhes.
