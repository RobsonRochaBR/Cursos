using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Agenda.Dados;
using Agenda.Web.Filters;

namespace Agenda.Web.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly AgendaContext _contexto;

        public ProfessoresController()
        {
            _contexto = new AgendaContext();
        }

        // GET: Professores
        public ActionResult Index()
        {
            return View(_contexto.Professores.ToList());
        }

        // GET: Professores/Cadastrar
        public ActionResult Cadastrar()
        {
            return View(default(Professor));
        }

        // POST: Professores/Cadastrar
        //[Log]
        [HttpPost]
        public ActionResult Cadastrar(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _contexto.Professores.Add(professor);
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        // GET: Professores/Editar
        public ActionResult Editar(int id)
        {
            var professor = _contexto.Professores.Find(id);
            if(professor == null)
                return new HttpNotFoundResult();
                //throw new ArgumentException($"Não foi encontrado nenhum professor com o {nameof(id)} {id}", nameof(id));
            return View(professor);
        }

        // POST: Professores/Cadastrar
        [HttpPost]
        public ActionResult Editar(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _contexto.Entry(professor).State = EntityState.Modified;
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        // POST: Professores/Excluir
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            Professor professor = _contexto.Professores.Find(id);
            if (professor != null)
            {
                _contexto.Professores.Remove(professor);
                _contexto.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}