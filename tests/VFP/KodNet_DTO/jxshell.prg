CLEAR 
ON SHUTDOWN QUIT
ON KEY LABEL ALT+F1 Quit
SET DEFAULT TO "F:\Desenvolvimento\jxshell.dotnet4-master\tests\VFP\"

lcCaminhoDlls = "F:\Desenvolvimento\jxshell.dotnet4-master\tests\VFP\DotNet\dlls-dto\"
nomeDll = 'UsoDTo.dll'
nomeDllDto = 'TesteDTO.dll'

DO FULLPATH('kodnet.prg')

kodnet = _screen.kodnet

kodnet.loadAssembly("System.Collections")
kodnet.loadAssembly("System.Runtime")

SET STEP ON

UsoProjetoCompartilhado()
UsoDll()

&&----------------------------------------------------------------------------------
FUNCTION UsoProjetoCompartilhado()
&&----------------------------------------------------------------------------------

SET STEP ON
	kodnet.loadAssemblyFile(lcCaminhoDlls + 'UsoDTo.dll')
	&&Projeto compartilhado
	dtoCompartilhado = kodnet.getStaticWrapper("TesteDToCompartilhado.ProdutoDtoCompartilhado")
	loProdutoDtoCompartilhado = dtoCompartilhado.construct()
	
	loProdutoDtoCompartilhado.Nome = 'Teste Nome Produto'
	loProdutoDtoCompartilhado.Valor = 10
	loProdutoDtoCompartilhado.Obs = 'Teste Obs Produto'
	
	
	ConsumoTeste = kodnet.getStaticWrapper("UsoDTo.ConsumirDtoCompartilhado")
	loConsumoDtoCom = ConsumoTeste.construct()

	?loConsumoDtoCom.RetornarProdutoDtoCompartilhado(loProdutoDtoCompartilhado)
	?loConsumoDtoCom.RetornarProdutoDtoCompartilhado(loProdutoDtoCompartilhado,1)
	?loConsumoDtoCom.RetornarProdutoDtoCompartilhado(1, loProdutoDtoCompartilhado)		
	
ENDFUNC 

&&----------------------------------------------------------------------------------
FUNCTION UsoDll()
&&----------------------------------------------------------------------------------

SET STEP ON
	kodnet.loadAssemblyFile(lcCaminhoDlls + 'UsoDTo.dll')
	
	
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
ENDFUNC 