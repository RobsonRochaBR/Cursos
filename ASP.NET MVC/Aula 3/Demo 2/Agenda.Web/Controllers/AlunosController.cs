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
            return View(default(Aluno));
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

        // POST: Alunos/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            return Gravar(aluno);
        }

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