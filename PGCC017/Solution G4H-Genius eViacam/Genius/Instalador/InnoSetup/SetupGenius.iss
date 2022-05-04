; Script gerado pelo Inno Setup Script Wizard.
; VEJA A DOCUMENTAÇÃO PARA OBTER DETALHES SOBRE A CRIAÇÃO DE ARQUIVOS DE SCRIPT DE CONFIGURAÇÃO DO INNO!
; State University of Feira de Santana
; PGCC017 - Games and Digital Entertainment
; Professor Victor Travassos Sarinho
; PhD in Computer Science, UFBA
; Desenvolvedor: Marcos Morais
; Visite https://linktr.ee/marcosmoraisjr

#define MyAppName "Genius"
#define MyAppVersion "1.0"
#define MyAppPublisher "UEFS - PGCC017 - Games and Digital Entertainment"
#define MyAppURL "https://linktr.ee/marcosmoraisjr"
#define MyAppExeName "Genius.exe"
#define MyAppAssocName MyAppName + " File"
#define MyAppAssocExt ".myp"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt

[Setup]
; Script gerado pelo Inno Setup Script Wizard.
; VEJA A DOCUMENTAÇÃO PARA OBTER DETALHES SOBRE A CRIAÇÃO DE ARQUIVOS DE SCRIPT DE CONFIGURAÇÃO DO INNO!
AppId={{CE4002E8-5816-42B0-9BC3-5017AD192551}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
ChangesAssociations=yes
DisableProgramGroupPage=yes
InfoAfterFile=D:\Desenvolvimento\VISUALSTUDIO2019\Solution G4H-Genius eViacam\Genius\bin\Debug\Leiame.txt
; Remova o comentário da linha a seguir para executar no modo de instalação não administrativa (instalar apenas para o usuário atual)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=D:\Desenvolvimento\VISUALSTUDIO2019\Solution G4H-Genius eViacam\Genius\Instalador\InnoSetup
OutputBaseFilename=instaladorG4H
Compression=lzma
SolidCompression=yes
WizardStyle=modern
UserInfoPage=no
// Display a message box

[Code]
function CheckSerial(Serial: String): Boolean;
begin
if Serial = '123456' then
Result := True
else
Result := False;
end;

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "armenian"; MessagesFile: "compiler:Languages\Armenian.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "bulgarian"; MessagesFile: "compiler:Languages\Bulgarian.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
Name: "icelandic"; MessagesFile: "compiler:Languages\Icelandic.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
Name: "slovak"; MessagesFile: "compiler:Languages\Slovak.isl"
Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "D:\Desenvolvimento\VISUALSTUDIO2019\Solution G4H-Genius eViacam\Genius\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Desenvolvimento\VISUALSTUDIO2019\Solution G4H-Genius eViacam\Genius\bin\Debug\Leiame.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Desenvolvimento\VISUALSTUDIO2019\Solution G4H-Genius eViacam\Genius\bin\Debug\eViacam.exe"; DestDir: "{app}"; Flags: ignoreversion deleteafterinstall
//apagar o arquivo no final deleteafterinstall
;Não use sinalizadores "Flags: ignoreversion" em nenhum arquivo de sistema compartilhado

[Registry]
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "{app}\{#MyAppExeName},0"
Root: HKA; Subkey: "Software\Classes\{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKA; Subkey: "Software\Classes\Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".myp"; ValueData: ""

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName} G4H um jogo para saúde"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
//o arquivo batch deve ser executado em durante a instalação:
Filename: "{app}\eViacam.exe"; Parameters: "install"; Flags: runascurrentuser runhidden
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent



