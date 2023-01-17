using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorTarefas.Data;
using GestorTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestorTarefas.Controllers
{
    public class PessoaController : Controller
    {
        readonly private TarefasDbContext _db;


        public PessoaController(TarefasDbContext db)
        {
            _db = db;
        }

        public IActionResult TodasPessoas()
        {
            var pessoas = _db.Pessoas.ToList();
            return View(pessoas);
        }

        public IActionResult Buscar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Buscar(Pessoa pessoa)
        {
            var buscar = _db.Pessoas.FirstOrDefault(x => x.Nome == pessoa.Nome);
            if (buscar != null)
            {
                return RedirectToAction("Detalhes", "Pessoa", buscar);
            }
            return RedirectToAction("Criar", "Pessoa");
        }


        public IActionResult BuscarComSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuscarComSenha(Pessoa pessoa)
        {
            var buscar = _db.Pessoas.FirstOrDefault(x => x.Nome == pessoa.Nome);
            if (buscar.Nome == pessoa.Nome && buscar.Senha == pessoa.Senha)
            {
                return RedirectToAction("Detalhes", "Pessoa", buscar);
            }
            return RedirectToAction("CriarComSenha", "Pessoa");
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Pessoa pessoa)
        {
            var buscar = _db.Pessoas.FirstOrDefault(x => x.Nome == pessoa.Nome);
            if (buscar == null)
            {
                _db.Pessoas.Add(pessoa);
                _db.SaveChanges();
                return RedirectToAction("TodasPessoas", "Pessoa");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CriarComSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarComSenha(Pessoa pessoa)
        {
            var buscar = _db.Pessoas.FirstOrDefault(x => x.Nome == pessoa.Nome);
            if (buscar == null)
            {
                _db.Pessoas.Add(pessoa);
                _db.SaveChanges();
                return RedirectToAction("TodasPessoas", "Pessoa");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Detalhes(Pessoa pessoa)
        {
            return View(pessoa);
        }

        public IActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(int id, Pessoa pessoa)
        {
            var buscar = _db.Pessoas.Find(id);
            if (buscar != null)
            {
                buscar.Nome = pessoa.Nome;

                _db.Pessoas.Update(buscar);
                _db.SaveChanges();
                return RedirectToAction("TodasPessoas", "Pessoa");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Deletar(Pessoa pessoa)
        {
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var buscar = _db.Pessoas.Find(id);
            if (buscar != null)
            {
                _db.Pessoas.Remove(buscar);
                _db.SaveChanges();
                return RedirectToAction("TodasPessoas", "Pessoa");
            }
            return RedirectToAction("Criar", "Pessoa");
        }
    }
}