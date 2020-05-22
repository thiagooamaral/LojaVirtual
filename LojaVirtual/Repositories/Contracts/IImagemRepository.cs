using LojaVirtual.Models;
using System.Collections.Generic;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IImagemRepository
    {
        void Cadastrar(Imagem imagem);
        void CadastrarImagens(List<Imagem> ListaImagens);
        void Excluir(int Id);
        void ExcluirImagensDoProduto(int ProdutoId);
    }
}
