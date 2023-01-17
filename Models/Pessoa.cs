using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorTarefas.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        public string Senha { get; set; }
        public IEnumerable<Tarefa> Tarefas { get; set; }
    }
}