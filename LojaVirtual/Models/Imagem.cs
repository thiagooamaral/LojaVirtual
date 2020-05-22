using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string Caminho { get; set; }

        public int ProdutoId { get; set; }   //Banco de dados

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; } //POO, virtual em propriedades associativas
    }
}
