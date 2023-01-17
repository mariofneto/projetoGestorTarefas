using System.Runtime.CompilerServices;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorTarefas.Data;
using GestorTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestorTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefasDbContext _db;

        public TarefaController(TarefasDbContext db)
        {
            _db = db;
        }


        public IActionResult TodasTarefas(int id)
        {
            var tarefas = _db.Tarefas.Where(t => t.PessoaId == id)
                                .ToList();
            return View(tarefas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(int id, Tarefa tarefa)
        {
            var pessoa = _db.Pessoas.Find(id);

            tarefa.PessoaId = pessoa.Id;
            _db.Tarefas.Add(tarefa);
            _db.SaveChanges();
            return RedirectToAction("TodasTarefas", "Tarefa", pessoa);
        }

        public IActionResult Editar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Editar(int id, Tarefa tarefa)
        {
            var tarefaAntiga = _db.Tarefas.Find(id);
            if (tarefa != null)
            {
                tarefaAntiga.Nome = tarefa.Nome;
                tarefaAntiga.FeitoOuNao = tarefa.FeitoOuNao;
                tarefaAntiga.DataCriacao = tarefa.DataCriacao;
                _db.Tarefas.Update(tarefaAntiga);
                _db.SaveChanges();
                return RedirectToAction("Buscar", "Pessoa");
            }
            return View();
        }

        [HttpPost]
        public IActionResult MarcaComoFeito(int id)
        {
            var buscar = _db.Tarefas.Find(id);
            var pessoa = _db.Pessoas.FirstOrDefault(x => x.Id == buscar.PessoaId);


            if (buscar != null)
            {
                buscar.FeitoOuNao = ERealizado.Feito;
                _db.Tarefas.Update(buscar);
                _db.SaveChanges();
                return RedirectToAction("Criar", "Tarefa", pessoa);
            }
            return RedirectToAction("TodasTarefas", "Tarefa", buscar);
        }

        public IActionResult Deletar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var tarefaDeletar = _db.Tarefas.Find(id);
            var pessoa = _db.Pessoas.FirstOrDefault(x => x.Id == tarefaDeletar.PessoaId);
            if (tarefaDeletar != null)
            {
                _db.Tarefas.Remove(tarefaDeletar);
                _db.SaveChanges();
                return RedirectToAction("TodasTarefas", "Tarefa", pessoa);
            }
            return RedirectToAction("TodasTarefas", "Tarefa", tarefaDeletar);
        }


    }
}