using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorTarefas.Models
{
    public class PessoaTarefaViewModel
    {
        public Pessoa Pessoa { get; set; }
        public Tarefa Tarefa { get; set; }

        public int PessoaId { get; set; }
        public int TarefaId { get; set; }
    }
}