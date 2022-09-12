using TesteDTO;
using UsoDTo;

Console.WriteLine("Hello, World!");

ProdutoDto produtoDto = new();
produtoDto.Nome = "Teste Nome Produto";
produtoDto.Valor = 10;
produtoDto.Obs = "Teste de Obs Produto";

ConsumirDTo consumirDTo = new();

Console.WriteLine(" Um Parametro: " + consumirDTo.RetornarProdutoDto(produtoDto));
Console.WriteLine(" Dois Parametro: " + consumirDTo.RetornarProdutoDto(produtoDto, 1));
Console.WriteLine(" Dois Parametro2: " + consumirDTo.RetornarProdutoDto(1, produtoDto));