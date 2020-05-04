using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }
        public int? CategoriaPaiId { get; set; }

        //ORM - EntityFrameworkCore: Preciso fazer isso para relacionar um objeto com o campo CatetgoriaPaiId
        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }

        /*
         * Nome: Telefone sem fio
         * Slug: telefone-sem-fio
         * URL normal: www.lojavirtual.com.br/categoria/5
         * URL amigável e com slug: www.lojavirtual.com.br/informatica
         */

        /*
         * Auto-relacionamento
         * 1 - Informática - Pai: null
         * 2 - Mouse - Pai: 1
         * 3 - Mouse sem fio - Pai: 2
         * 4 - Mouse gamer - Pai: 2
         */
    }
}
