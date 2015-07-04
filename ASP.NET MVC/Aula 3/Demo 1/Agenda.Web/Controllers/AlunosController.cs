using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Agenda.Dados;

namespace Agenda.Web.Controllers
{
    public class AlunosController : Controller
    {
        private readonly AgendaContext _contexto;

        public AlunosController()
        {
            _contexto = new AgendaContext();
        }

        // GET: Alunos
        public ActionResult Index()
        {
            return View(_contexto.Alunos.ToList());
        }

        // GET: Alunos/Cadastrar
        public ActionResult Cadastrar()
        {
            return View(new Aluno {EnderecosAdicionais = new List<Endereco> {new Endereco(), new Endereco(), new Endereco()} });
        }

        [NonAction]
        private ActionResult Gravar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry(aluno).State = aluno.Id != 0 ? EntityState.Modified : EntityState.Added;
                _contexto.SaveChanges();
                TempData["Mensagem"] = "Aluno gravado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        /* TODO: Passo 1 ******************************
        // POST: Alunos/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(int? id)
        {
            var aluno = new Aluno {Nome = Request.Form["Nome"], EMail = Request["EMail"]};
            return Gravar(aluno);
        }
        /****************************************/

        /* TODO: Passo 2 ******************************
        // POST: Alunos/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(FormCollection formCollection)
        {
            var aluno = new Aluno {Nome = formCollection["Nome"], EMail = formCollection["EMail"]};
            return Gravar(aluno);
        }
        /****************************************/

        /* TODO: Passo 3 ******************************
        // POST: Alunos/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(string nome, string email)
        {
            var aluno = new Aluno {Nome = nome, EMail = email};
            return Gravar(aluno);
        }
        /****************************************/

        /* TODO: Passos 4 e 5 *************************
        // POST: Alunos/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            return Gravar(aluno);
        }
        /****************************************/

        // GET: Alunos/Editar
        public ActionResult Editar(int id)
        {
            return View(_contexto.Alunos.Find(id));
        }

        // POST: Alunos/Cadastrar
        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            return Gravar(aluno);
        }

        // POST: Alunos/Excluir
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            Aluno aluno = _contexto.Alunos.Find(id);
            if (aluno != null)
            {
                _contexto.Alunos.Remove(aluno);
                _contexto.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}