using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace livrariaDB.Models
{
    public class Livro
    {
        [Column("livroId")]
        [Display(Name = "Livro ID")]
        public int livroId { get; set; }

        
        [Column("livroTitulo")]
        [Display(Name = "Titulo do livro")]
        public string? livroTitulo { get; set; }

        [Column("livroAutor")]
        [Display(Name = "autor do livro")]
        public string? livroAutor { get; set; }

        [Column("livroPublicacao")]
        [Display(Name = "Publicação")]
        public string? livroPublicacao { get; set; }

        [Column("genero")]
        [Display(Name = "Gênero")]
        public string? genero { get; set; }

        [Column("isbn")]
        [Display(Name = "ISBN")]
        public int isbn { get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }
    }
}
