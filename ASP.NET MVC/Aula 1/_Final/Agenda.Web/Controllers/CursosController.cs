using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Agenda.Dados;

namespace Agenda.Web.Controllers
{
    public class CursosController : Controller
    {
        private readonly AgendaContext _contexto;

        public CursosController()
        {
            _contexto = new AgendaContext();
        }

        // GET: Cursos
        public ActionResult Index()
        {
            return View(_contexto.Cursos.ToList());
        }

        // GET: Cursos/Cadastrar
        public ActionResult Cadastrar()
        {
            return View(default(Curso));
        }

        // POST: Cursos/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cursos.Add(curso);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        // GET: Cursos/Editar
        public ActionResult Editar(int id)
        {
            return View(_contexto.Cursos.Find(id));
        }

        // POST: Cursos/Cadastrar
        [HttpPost]
        public ActionResult Editar(Curso curso)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry(curso).State = EntityState.Modified;
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        // POST: Cursos/Excluir
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            Curso curso = _contexto.Cursos.Find(id);
            if (curso != null)
            {
                _contexto.Cursos.Remove(curso);
                _contexto.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}