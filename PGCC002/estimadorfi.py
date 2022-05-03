# -*- coding: utf-8 -*-
# * Copyright (c) 2009-2018.
# * Direitos autorais (c) 2009-2018. Autores: ver arquivo README no GitHub.
# *
# * Licenciado sob a Licença Apache, Versão 2.0 (a "Licença");
# * você não pode usar este arquivo exceto em conformidade com a Licença.
# * Você pode obter uma cópia da Licença em
# *
# * http://www.apache.org/licenses/LICENSE-2.0
# *
# * A menos que exigido pela lei aplicável ou acordado por escrito, o software
# * distribuído sob a Licença é distribuído "COMO ESTÁ",
# * SEM GARANTIAS OU CONDIÇÕES DE QUALQUER TIPO, expressas ou implícitas.

# pacotes necessários
import os, sys
import cv2
from matplotlib import image
import numpy as np
import matplotlib.pyplot as plt
import csv, re
from collections import OrderedDict
from argparse import ArgumentParser
from cytomine import Cytomine
from cytomine.models import Project, ProjectCollection
from cytomine.models import Annotation, AnnotationCollection
from cytomine.models import Property, PropertyCollection
from cytomine.models import ImageInstance, ImageInstanceCollection
from cytomine.models import User, UserCollection
__author__ = "Marcos Morais <mmstec@gmail.com>"
'''
  NOTA:
  Este script é um exemplo que permite obter a lista de imagens (metadados) em um determinado projeto no software de anotaçao, Cytomine.
  Se os parametros como o caminho de download for fornecido, ele baixa todas as imagens anotadas no Cytomine.
  Após baixadas as imagens anotadas no Cytomine, este script quantifica a fibrose intersticial presente nas imagens, 
  desde que essas imagens tenham sidos coradas com tricrômico de Masson
  Além disso, um arquivo .CSV é gravado com informações geradas por este script.

  Este script também está disponível no Github. 
  Para executá-lo, o comando deve ser assim:
  python estimadorfi.py --host http://pathospotter-cytomine-core.bahia.fiocruz.br --public_key AAA --private_key ZZZ
'''
def get_cytomine(parametros):
    parametros
    with Cytomine(parametros.host, parametros.public_key, parametros.private_key) as cytomine:
        projetos = ProjectCollection()
        projetos.fetch()
        for projeto in projetos:
            if(projeto.id == int(parametros.project_id)):
                # if(projeto.id):
                print("projeto id..........", projeto.id)
                print("projeto nome........", projeto.name)
                imagens = ImageInstanceCollection().fetch_with_filter(
                    "project", parametros.project_id)

                for imagem in imagens:
                    print("imagem id...........", imagem.id)
                    print("imagem filename.....", imagem.filename)
                    anotacoes = AnnotationCollection()
                    anotacoes.project = projeto.id
                    anotacoes.image = imagem.id
                    anotacoes.fetch()

                    for anotacao in anotacoes:
                        anotacao_url = "http://pathospotter-cytomine-core.bahia.fiocruz.br/#/project/{}/image/{}/annotation/{}".format(
                            projeto.id, imagem.id, anotacao.id)
                        print("anotacao id.....: ", anotacao.id)
                        print("anotacao_url....: ", anotacao_url)
                        #print("anotacao_url....: ", anotacao.cropURL)

                        propiedades = PropertyCollection(
                            anotacao).fetch().as_dict()

                        try:
                            estima_fi_humano = str(propiedades["fibrosis"])
                            observacao = estima_fi_humano
                            regex = re.compile('\W+')
                            fi = regex.split(estima_fi_humano)
                            estima_fi_humano = fi[11]+"%"
                        except:
                            observacao = "<<fibrosis>> <<percentual%> não encontrado"
                            estima_fi_humano = '0%'

                        if parametros.dir_dataset:
                            anotacao.dump(
                                dest_pattern=os.path.join(
                                    parametros.dir_dataset, "{project}",
                                    parametros.dir_alpha, "{id}.png"),
                                mask=True, alpha=True, max_size=512)
                            # anotacao.dump(dest_pattern=os.path.join(
                            # parametros.dir_dataset, "{project}",  parametros.dir_crop, "{id}.jpg"), max_size=512)
                            # anotacao.dump(dest_pattern=os.path.join(
                            # parametros.dir_dataset, "{project}",  parametros.dir_mask, "{id}.jpg"), mask=True, max_size=512)

                        # segmentar imagem anotada
                        path = os.path.join(
                            os.getcwd(),
                            parametros.dir_dataset,
                            parametros.project_id,
                            parametros.dir_alpha, "{}.png".format(anotacao.id))

                        img = cv2.imread(path)
                        resultado = segmentador(True,
                                                img,
                                                3,
                                                projeto.id,
                                                projeto.name,
                                                imagem.id,
                                                imagem.filename,
                                                anotacao.id,
                                                estima_fi_humano,
                                                parametros)
                        # teste
                        print("Resultado Final ---->Fibrose: {}".format(resultado))

                        # gravar arquivocsv
                        estima_fi_computador = resultado

                        dir_kappa = os.path.join(
                            os.getcwd(), parametros.dir_kappa)

                        geradorArquivoCSV(True,
                                          destino_arquivo=dir_kappa,
                                          nome_arquivo=str(
                                              projeto.name)+".csv",
                                          projeto_id=projeto.id,
                                          projeto_nome=projeto.name,
                                          imagem_id=imagem.id,
                                          imagem_nome=extratorNomeArquivo(
                                              imagem.filename),
                                          anotacao_id=anotacao.id,
                                          anotacao_url=anotacao_url,
                                          estima_fi_computador=estima_fi_computador,
                                          estima_fi_humano=estima_fi_humano,
                                          observacao=observacao,
                                          parametros=parametros)
        return resultado
    ### FIM método get de comunicação com o software de anotação ############################
def set_cytomine(parametros):
    p = parametros
    with Cytomine(p.host, p.public_key, p.private_key) as cytomine:
        annotations = AnnotationCollection()
        annotations.project = p.project_id
        annotations.fetch()
        for annotation in annotations:
            try:
                prop = Property(annotation, key='fibrosis', value='0%').save()
                print(prop)
            except:
                print('erro ', prop)
    ### FIM método set de comunicação com o software de anotação ############################
def segmentador(executar, imagem, cor, projeto_id, projeto_nome, imagem_id, imagem_nome, anotacao_id, estima_fi_humano, parametros):
    if(executar):
        # Em OPenCV, a escala de cor HSV vai de 0~179
        coreshsv = OrderedDict({
            "Vermelho1": ([0, 80, 90], [15, 255, 255]),
            "Vermelho2": ([165, 80, 90], [180, 255, 255]),
            "Verde": ([45, 80, 90], [75, 255, 255]),
            "Azul": ([105, 80, 90], [135, 255, 255])
        })
        if cor == 0:
            minimo, maximo = coreshsv["Vermelho1"]
        elif cor == 1:
            minimo, maximo = coreshsv["Vermelho2"]
        elif cor == 2:
            minimo, maximo = coreshsv["Verde"]
        elif cor == 3:
            minimo, maximo = coreshsv["Azul"]
        else:
            minimo, maximo = coreshsv["Azul"]

        minimo = np.array(minimo, dtype='uint8')
        maximo = np.array(maximo, dtype='uint8')
        img_rgb = cv2.cvtColor(imagem, cv2.COLOR_BGR2RGB)
        img_hsv = cv2.cvtColor(imagem, cv2.COLOR_BGR2HSV)

        # Limiar a imagem HSV para obter apenas cores azuis
        mascara = cv2.inRange(img_hsv, minimo, maximo)
        # concatenando a imagem original com a mascara
        segmentacao = cv2.bitwise_and(imagem, imagem, mask=mascara)
        # destacando a segmentacao sobre a imagem original (osfuscada)
        sobreposicao = cv2.addWeighted(segmentacao, 0.9, imagem, 0.4, 0)
        # -----------
        # desfoque = cv2.GaussianBlur(mascara, (5, 5), 0)
        # sobel_x = cv2.Sobel(desfoque, cv2.CV_64F, 1, 0, ksize=3)  # filtro eixo x (limiar)
        # sobel_y = cv2.Sobel(desfoque, cv2.CV_64F, 0, 1, ksize=3)  # filtro eixo y
        # sobel_x = cv2.convertScaleAbs(sobel_x)  # convertendo valores x
        # sobel_y = cv2.convertScaleAbs(sobel_y)  # convertendo valores y
        # sobel = cv2.addWeighted(src1=sobel_x, alpha=0.5, src2=sobel_y, beta=0.5, gamma=0)  # concatenando as imagens
        # canny = cv2.Canny(desfoque, 80, 140)  # limiarAlto=80 limiarBaixo=140
        # kernel = np.ones((3, 3), np.uint8)
        # dilatacao = cv2.dilate(canny, kernel, iterations=2)
        # erosao = cv2.erode(dilatacao, kernel, iterations=1)
        # borda = cv2.bitwise_and(imagem, imagem, mask=erosao)
        # sobreposicao = cv2.addWeighted(borda, 1, imagem, 0.4, 0)
        # -----------
        # ~
        # procurar os contornos, procura contornos dentro dos contornos, aproxima os contornos
        tmp = cv2.findContours(mascara, cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
        # compatibilidade entre versões diferentes do OpenCV
        contornos = tmp[0] if len(tmp) == 2 else tmp[1]
        # retorna 3 parametros, 1)imagens, 2contornos,3) hierarquia dos contornos
        # Desenha os contornos
        # imagem, contornos, (-1) são todos, a cor, espessura
        cv2.drawContours(sobreposicao, contornos, -1, (255, 0, 0), 2)
        #
        ##########################################################################
        # FORMA 01
        # pegando valores de dimessão da imagem total e segmentada
        imagemFull = imagem.shape[0]*imagem.shape[1]
        imagemMask = cv2.countNonZero(mascara)
        # estimando percentual FI
        resultadoFI = round((imagemMask*100/imagemFull))
        print("Método de cálculo 1->Fibrose: "+str(resultadoFI)+"%")
        ##########################################################################
        # FORMA 02
        # calculando a quantidade de pixels
        pixelsBranco = np.sum(mascara == 255)  # somente branco (mascara)
        # somente preto (restante da imagem)
        pixelsPreto = np.sum(mascara == 0)
        pixelsFull = pixelsBranco + pixelsPreto
        # estimando percentual FI
        resultadoFI = round(pixelsBranco*100/pixelsFull)
        print("Método de cálculo 2->Fibrose: "+str(resultadoFI)+"%")
        ##########################################################################

        # preparando caminho para arquivo mascara
        dir_mascara = os.path.join(os.getcwd(
        ), parametros.dir_dataset, parametros.project_id,  parametros.dir_mascara)
        if(os.path.isdir(dir_mascara) == False):
            # pasta não existe, criar
            os.makedirs(dir_mascara)

        # salva imgagem
        cv2.imwrite(os.path.join(
            dir_mascara, "{}.png".format(anotacao_id)), mascara)

        # preparando caminho do arquivo segmentacao
        dir_segmentacao = os.path.join(os.getcwd(
        ), parametros.dir_dataset, parametros.project_id,  parametros.dir_segmentacao)
        if(os.path.isdir(dir_segmentacao) == False):
            # pasta não existe, criar
            os.makedirs(dir_segmentacao)

        # salvar imagem segmentada
        cv2.imwrite(os.path.join(dir_segmentacao,
                    "{}.png".format(anotacao_id)), segmentacao)

        # exibir imagens False = não , True = sim
        mostrarImagens(False, img_rgb, mascara, sobreposicao,
                       segmentacao, resultadoFI, projeto_id, projeto_nome, imagem_id, imagem_nome, anotacao_id)

        return str(resultadoFI)+'%'
    ### FIM método estimador de fibrose (segmenta imagem) ###################################
def geradorArquivoCSV(executar, destino_arquivo,
                      nome_arquivo,
                      projeto_id,
                      projeto_nome,
                      imagem_id,
                      imagem_nome,
                      anotacao_id,
                      anotacao_url,
                      estima_fi_computador,
                      estima_fi_humano,
                      observacao,
                      parametros):
    if(executar):
        # excutar método de gravação de aqruivo csv
        primeiravez = False
        if(os.path.isdir(destino_arquivo) == False):
            # pasta não existe, criar
            os.makedirs(destino_arquivo)
            primeiravez = True

        header = ['projeto_id',
                  'projeto_nome',
                  'imagem_id',
                  'imagem_nome',
                  'anotacao_id',
                  'anotacao_url',
                  'estima_fi_computador',
                  'estima_fi_humano',
                  'observacao']

        data = [projeto_id,
                projeto_nome,
                imagem_id,
                imagem_nome,
                anotacao_id,
                anotacao_url,
                estima_fi_computador,
                estima_fi_humano,
                observacao]

        path = os.path.join(os.getcwd(), destino_arquivo, nome_arquivo)
        with open(path, 'a', newline='', encoding='UTF8') as f:
            writer = csv.writer(f, delimiter=',')
            if (primeiravez):
                writer.writerow(header)
                primeiravez = False
            writer.writerow(data)
            f.close
    ### FIM método gerador de arquivo csv ###################################################
def mostrarImagens(executar, imagen, mascara, sobreposicao, segmentacao, resultado, projeto_id, projeto_nome, imagem_id, imagem_nome, anotacao_id):
    if(executar):
        # imagens e respectivos titulos
        imagens = [imagen.copy(),
                   mascara.copy(),
                   cv2.cvtColor(segmentacao.copy(), cv2.COLOR_BGR2RGB),
                   cv2.cvtColor(sobreposicao.copy(), cv2.COLOR_BGR2RGB)]
        titulos = ['Anotação {}'.format(anotacao_id),
                   'Máscara',
                   'Máscara Aplicada \n(segmentação)',
                   'Resultado Fibrosis'
                   ]
        # preparando a plotagem
        plt.figure(figsize=(12, 4))
        for i in range(len(imagens)):
            plt.subplot(1, 4, i+1)
            plt.imshow(imagens[i], cmap='gray')
            plt.title("{0}\nPROJETO {1} | LÂMINA {2}".format(
                projeto_nome,  projeto_id, imagem_id), fontsize=7)
            if(i == 3):
                plt.xlabel("{}\n{}%".format(
                    titulos[i], resultado), fontsize=10)
            else:
                plt.xlabel(titulos[i], fontsize=10)
            plt.xticks([]), plt.yticks([])
            plt.subplots_adjust(wspace=0.1)
        plt.show()
    ### FIM método exibidor de imagens ######################################################
def extratorNomeArquivo(string):
    regex = re.compile('\W+')
    string = regex.split(string)
    return string[2].upper()+"."+string[3].upper()
    ### FIM método retorna nome do arquivo ##################################################
if __name__ == '__main__':
    parser = ArgumentParser(prog="Segmentador")
    parser.add_argument('--host', help="Onde o Cytomine está hospedado")
    parser.add_argument('--public_key', help="A chave pública Cytomine")
    parser.add_argument('--private_key', help="A chave privada Cytomine")
    parser.add_argument('--dir_dataset', help="Onde armazenar imagens")
    parser.add_argument('--dir_alpha', help="Onde armazenar imagens anotadas")
    parser.add_argument('--dir_mascara', help="Onde armazenar imagens máscara")
    parser.add_argument('--dir_segmentacao',
                        help="Onde armazenar imagens segmentadas")
    parser.add_argument('--dir_kappa', help="Local para receber arquivo.scv")
    parametros, _ = parser.parse_known_args(sys.argv[1:])

    # comunicando com o cytomine na fiocruz
    # obs. os parametros das linhas comentadas devem ser passadas por argumento na chamada do script.
    print("Processamento iniciado.")
    parametros.host = 'http://pathospotter-cytomine-core.bahia.fiocruz.br'
    # parametros.public_key = 'AAA'
    # parametros.private_key = 'ZZZ'
    parametros.dir_dataset = 'dataset'
    parametros.dir_alpha = 'alpha'
    parametros.dir_mascara = 'mascara'
    parametros.dir_segmentacao = 'segmentacao'
    parametros.dir_kappa = parametros.dir_dataset

    # projetos disponíveis no cytomine
    projetos = ['8163', '169854', '261318', '261334', '261372']
    for i in range(0, len(projetos)):
        parametros.project_id = projetos[i]
        get_cytomine(parametros)
        print("Contando: ", i+1)
    print("Processamento concluído.")
'''
  Este script também está disponível no Github. 
  Para executá-lo, o comando deve ser assim:
  python estimadorfi.py --host http://pathospotter-cytomine-core.bahia.fiocruz.br --public_key AAA --private_key ZZZ
'''