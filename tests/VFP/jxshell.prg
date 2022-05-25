CLEAR 
ON SHUTDOWN QUIT
ON KEY LABEL ALT+F1 Quit
SET DEFAULT TO "c:\projetos\dotnet\desenvolvimento\vfp\jxshell.dotnet4.fork\tests\vfp\"

*nomeDll = "C:\Kodnet_Teste\Std2_0\Sinca.Integrador.Domain.dll"
*nomeDll = "C:\Kodnet_Teste\Net6\Sinca.Integrador.Domain.dll"
*nomeClasse = "Sinca.Integrador.Domain.Arquivo"

nomeDll    = "D:\ProjetosDotNet\Testes\ChamarTelaWpf.Vfp\src\AplicativoWinUI3\bin\x86\Debug\net6.0-windows10.0.19041.0\win10-x86\LibWinUI3.dll"
nomeClasse = "LibWinUI3.TelaExemplo1"

? 'Inicio : ' + nomeDll
DO ("kodnet.prg")
_screen.kodnet.loadAssembly("System.Collections")
_screen.kodnet.loadAssembly("System.Runtime")
_screen.kodnet.loadAssemblyFile(FULLPATH(nomeDll))
*MESSAGEBOX('Após carregar assemblies')

wrapper  = _screen.kodnet.getStaticWrapper(nomeClasse)
MESSAGEBOX('Após getStaticWrapper')

obj = wrapper.construct()
MESSAGEBOX('Após construct')

*!*	obj.CaminhoArquivo = "Nome do arquivo"
*!*	? obj.CaminhoArquivo
obj.Activate()

ret = MESSAGEBOX('jxshell - Após executar'  )


IF ret = 1
	CLEAR EVENTS
	CANCEL 
	QUIT 
ENDIF 
READ EVENTS
