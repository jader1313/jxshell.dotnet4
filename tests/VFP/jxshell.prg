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
MESSAGEBOX('Após carregar assemblies')

wrapper  = kodnet.getStaticWrapper(nomeClasse)
MESSAGEBOX('Após getStaticWrapper')

objDI = wrapper.construct()
MESSAGEBOX('Após construct')

*!*	obj.ConfigurarInjecaoDependencia()
*!*	MESSAGEBOX('Após ConfigurarInjecaoDependencia')

*!*	loMensagem = loInjecaoDependenciaMensagemObj.CriarInstancia()
objMinhaClasse = objDI.CriarInstanciaMinhaClasse()
frase = objMinhaClasse.GetMsg()
MESSAGEBOX(frase)

objDI.ConfigurarInjecaoDependencia()
MESSAGEBOX('Após ConfigurarInjecaoDependencia')

testeGenerico = objDI.CriarInstancia()
MESSAGEBOX(testeGenerico.GetMsg())


ret = MESSAGEBOX('jxshell - Após executar'  )
IF ret = 1
	CLEAR EVENTS
	CANCEL 
	QUIT 
ENDIF 
READ EVENTS
