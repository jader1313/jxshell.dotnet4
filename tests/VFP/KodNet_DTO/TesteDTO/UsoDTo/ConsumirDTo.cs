using TesteDTO;

namespace UsoDTo
{
    public class ConsumirDTo
    {

        public string RetornarProdutoDto(int teste, ProdutoDto produto)
        {
            return $"Nome: {produto.Nome} - Valor: {produto.Valor} - Obs: {produto.Obs}";
        }

        public string RetornarProdutoDto(ProdutoDto produto)
        {
            return $"Nome: {produto.Nome} - Valor: {produto.Valor} - Obs: {produto.Obs}";
        }

        public string RetornarProdutoDto(ProdutoDto produto, int teste)
        {
            return $"Nome: {produto.Nome} - Valor: {produto.Valor} - Obs: {produto.Obs}";
        }
    }
}
