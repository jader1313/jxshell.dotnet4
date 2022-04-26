ON SHUTDOWN QUIT
ON KEY LABEL ALT+F1 Quit
SET DEFAULT TO "c:\projetos\dotnet\desenvolvimento\vfp\jxshell.dotnet4.fork\tests\vfp\"

*ON ERROR QUIT
*!*	classe = "jxshell.dotnet4.Manager2"
*!*	MESSAGEBOX(classe + ' - Inicio')
*!*	x = CREATEOBJECT(classe)
*!*	MESSAGEBOX('jxshell - Após criar objeto')
*!*	x.Init()

nomeDll = "C:\Kodnet_Teste\Std2_0\Sinca.Integrador.Domain.dll"
*nomeDll = "C:\Kodnet_Teste\Net6\Sinca.Integrador.Domain.dll"

MESSAGEBOX('Inicio : ' + nomeDll)

DO ("kodnet.prg")
MESSAGEBOX('Após rodar kodnet')

_screen.kodnet.loadAssembly("System.Collections")
_screen.kodnet.loadAssemblyFile(FULLPATH(nomeDll))
MESSAGEBOX('Após carregar assemblies')

SET STEP ON 
TYPE = _screen.kodnet.getTypeOrGenericType("Sinca.Integrador.Domain.Arquivo")


arquivoClass  = _screen.kodnet.getStaticWrapper("Sinca.Integrador.Domain.Arquivo")
MESSAGEBOX('Após getStaticWrapper')

SET STEP ON 
arquivoObject = arquivoClass.construct()
arquivoObject.NomeArquivo = "Nome do arquivo"
? arquivoObject.NomeArquivo
ret = MESSAGEBOX('jxshell - Após executar'  )





IF ret = 1
	CLEAR EVENTS
	CANCEL 
	QUIT 
ENDIF 
READ EVENTS
