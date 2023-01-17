using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTarefas.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Pessoa")]
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public ERealizado FeitoOuNao { get; set; } = ERealizado.AindaNao;

    }
}