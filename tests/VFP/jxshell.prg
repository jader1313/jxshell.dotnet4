CLEAR 
ON SHUTDOWN QUIT
ON KEY LABEL ALT+F1 Quit
SET DEFAULT TO "c:\projetos\dotnet\desenvolvimento\vfp\jxshell.dotnet4.fork\tests\vfp\"

nomeClasse = "InjecaoDependenciaNET6.DependencyInjection<InjecaoDependenciaNET6.Mensagem>"
*nomeClasse = "InjecaoDependenciaNET6.MinhaClasse"

? 'Inicio : ' 

lcCaminhoDlls = "D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\ConsoleAppNetFramework48\ConsoleDependencyInjectionNET6_DLL_NET6\bin\x86\Release\net6.0\"
*nomeDll = "D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\jxshell.dotnet4-master\tests\VFP\dotNet\InjecaoDependencia.dll"
*nomeDll = "D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\jxshell.dotnet4-master\tests\VFP\dotNet\InjecaoDependenciaNET6.dll"
nomeDll = "InjecaoDependenciaNET6.dll"
DO FULLPATH('kodnet.prg')

kodnet = _screen.kodnet

kodnet.loadAssembly("System.Collections")
kodnet.loadAssembly("System.Runtime")

kodnet.loadAssemblyFile(lcCaminhoDlls + "Microsoft.Extensions.Hosting.dll")
kodnet.loadAssemblyFile(lcCaminhoDlls + "Microsoft.Extensions.Hosting.Abstractions.dll")
kodnet.loadAssemblyFile(lcCaminhoDlls + "Microsoft.Extensions.DependencyInjection.dll")

kodnet.loadAssemblyFile(lcCaminhoDlls + nomeDll)
MESSAGEBOX('Ap�s carregar assemblies')

wrapper  = kodnet.getStaticWrapper(nomeClasse)
MESSAGEBOX('Ap�s getStaticWrapper')

objDI = wrapper.construct()
MESSAGEBOX('Ap�s construct')

*!*	obj.ConfigurarInjecaoDependencia()
*!*	MESSAGEBOX('Ap�s ConfigurarInjecaoDependencia')

*!*	loMensagem = loInjecaoDependenciaMensagemObj.CriarInstancia()
objMinhaClasse = objDI.CriarInstanciaMinhaClasse()
frase = objMinhaClasse.GetMsg()
MESSAGEBOX(frase)

objDI.ConfigurarInjecaoDependencia()
MESSAGEBOX('Ap�s ConfigurarInjecaoDependencia')

testeGenerico = objDI.CriarInstancia()
MESSAGEBOX(testeGenerico.GetMsg())


ret = MESSAGEBOX('jxshell - Ap�s executar'  )
IF ret = 1
	CLEAR EVENTS
	CANCEL 
	QUIT 
ENDIF 
READ EVENTS
