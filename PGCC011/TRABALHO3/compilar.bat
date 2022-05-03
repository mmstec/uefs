@echo off

rem Anotações
rem gcc -Wall -framework OpenCL -DCL_DEVICE_TYPE_DEFAULT  -I./C_common -oDeviceInfo DeviceInfo.c*/
rem gcc DeviceInfo.c -o DeviceInfo -L "C:\Program Files (x86)\AMD APP SDK\3.0\bin\x86" -l OpenCL -I "C:\Program Files (x86)\AMD APP SDK\3.0\include" 

REN 0 = Preto
REN 1 = Azul Marinho
REN 2 = Verde
REN 3 = Verde-Azulado
REN 4 = Vinho
REN 5 = Rosa
REN 6 = Oliva
REN 7 = Cinza Claro
REN 8 = Cinza Escuro
REN 9 = Azul
REN A = Verde claro
REN B = Ciano
REN C = Vermelho
REN D = Pink
REN E = Amarelo
REN F = Branco
color 8f

	cls
	echo -------------------------------------------------------
	set titulo=PROGRAMANDO COM OPENCL
	set programa="contaPalavrasOpenCL"
	set lib32="C:\Program Files (x86)\AMD APP SDK\3.0\bin\x86"
	set lib64="C:\Program Files (x86)\AMD APP SDK\3.0\bin\x86_64" 
	set include="C:\Program Files (x86)\AMD APP SDK\3.0\include" 

	title %titulo% 
	if exist "%programa%.exe" (
		del %programa%.exe
	)

	g++ %programa%.cpp -o %programa% -L %lib64% -l OpenCL -I %include% -std=c++0x

	if exist "%programa%.exe" (
	  color 9f
	  cls
	  echo Executando %programa%.exe
	  %programa%.exe _arquivo.txt resultado.txt
	  pause
	  color 8f
	) else (
	  color 5f
	  echo Arquivo %programa%.exe não encontrado
	  pause
	)
