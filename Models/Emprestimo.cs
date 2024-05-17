using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace livrariaDB.Models
{
    public class Emprestimo
    {
        [Column("emprestimoId")]
        [Display(Name = "Emprestimo ID")]
        public int emprestimoId { get; set; }

        [Column("livroId")]
        [Display(Name = "Título")]
        public int livroId { get; set; }

        [Column("livroEmprestimo")]
        [Display(Name = "emprestimo do livro")]
        public Livro? livroEmprestimo { get; set; }

        [Column("dataEmprestimo")]
        [Display(Name = "Data do empréstimo")]
        public string? dataEmprestimo { get; set; }

        [Column("dataDevolucao")]
        [Display(Name = "Data da devolucao")]
        public string? dataDevolucao { get; set; }

        [Column("cliente")]
        [Display(Name = "cliente")]
        public string? cliente { get; set; }
    }
}
