Inicializar()

TesteInjecaoDependencia()
*TesteDto()

Finalizar()

*-----------------------------------------------------------
FUNCTION Inicializar()
*-----------------------------------------------------------
	
	CLEAR 
	ON SHUTDOWN QUIT
	ON KEY LABEL ALT+F1 Quit
	SET DEFAULT TO "c:\projetos\dotnet\desenvolvimento\vfp\jxshell.dotnet4.fork\tests\vfp\"
	DO FULLPATH('kodnet.prg')

*-----------------------------------------------------------
FUNCTION TesteDto()
*-----------------------------------------------------------

	? 'Inicio : ', DATETIME() 
	lcCaminhoDlls = "C:\Projetos\DotNet\Desenvolvimento\VFP\jxshell.dotnet4.fork\tests\VFP\KodNet_DTO\TesteDTO\ConsoleApp1\bin\Debug\net6.0\"
	nomeDll = 'UsoDTo.dll'
	nomeDllDto = 'TesteDTO.dll'
	kodnet = _screen.kodnet

	kodnet.loadAssembly("System.Collections")
	kodnet.loadAssembly("System.Runtime")
	kodnet.loadAssemblyFile(lcCaminhoDlls + 'UsoDTo.dll')
	kodnet.loadAssembly("TesteDTO")

	dtoTeste = kodnet.getStaticWrapper("TesteDTO.ProdutoDto")
	loProdutoDto = dtoTeste.construct()
	loProdutoDto.Nome = 'Teste Nome Produto'
	loProdutoDto.Valor = 10
	loProdutoDto.Obs = 'Teste Obs Produto'
	wrapper  = kodnet.getStaticWrapper("UsoDTo.ConsumirDTo")
	loLista = wrapper.construct()
	?loLista.RetornarProdutoDto(loProdutoDto)
	?loLista.RetornarProdutoDto(loProdutoDto, 1)
	?loLista.RetornarProdutoDto(1,loProdutoDto)		

*-----------------------------------------------------------
FUNCTION TesteInjecaoDependencia()
*-----------------------------------------------------------

	? 'Inicio : ', DATETIME() 
	nomeClasse = "InjecaoDependenciaNET6.DependencyInjection<InjecaoDependenciaNET6.Mensagem>"
	*nomeClasse = "InjecaoDependenciaNET6.MinhaClasse"
	lcCaminhoDlls = "D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\ConsoleAppNetFramework48\ConsoleDependencyInjectionNET6_DLL_NET6\bin\x86\Release\net6.0\"
	*nomeDll = "D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\jxshell.dotnet4-master\tests\VFP\dotNet\InjecaoDependencia.dll"
	*nomeDll = "D:\ProjetosDotNet\Testes\TESTE KODNET\TESTE InjecaoDependencia\jxshell.dotnet4-master\tests\VFP\dotNet\InjecaoDependenciaNET6.dll"
	nomeDll = "InjecaoDependenciaNET6.dll"
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

*-----------------------------------------------------------
FUNCTION Finalizar()
*-----------------------------------------------------------
	
	ret = MESSAGEBOX('JXSHELL - Após executar'  )
	IF ret = 1
		CLEAR EVENTS
		CANCEL 
		QUIT 
	ENDIF 
	READ EVENTS
	? 'Fim : ', DATETIME() 
	
