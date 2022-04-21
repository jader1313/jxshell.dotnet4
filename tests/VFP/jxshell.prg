ON SHUTDOWN QUIT
ON KEY LABEL ALT+F1 Quit
*ON ERROR QUIT
*!*	classe = "jxshell.dotnet4.Manager2"
*!*	MESSAGEBOX(classe + ' - Inicio')
*!*	x = CREATEOBJECT(classe)
*!*	MESSAGEBOX('jxshell - Após criar objeto')
*!*	x.Init()

MESSAGEBOX('Inicio')

DO ("C:\Kodnet_Teste\kodnet.prg")
MESSAGEBOX('Após rodar kodnet')

_screen.kodnet.loadAssembly("System.Collections")
_screen.kodnet.loadAssemblyFile(FULLPATH("C:\Kodnet_Teste\Std2_0\Sinca.Integrador.Domain.dll"))
*_screen.kodnet.loadAssemblyFile(FULLPATH("C:\Kodnet_Teste\Net6\Sinca.Integrador.Domain.dll"))
MESSAGEBOX('Após carregar assemblies')

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
