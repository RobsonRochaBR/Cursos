﻿using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Agenda.Dados;
using Agenda.Web.Filters;
using Agenda.Web.Mappers;
using Agenda.Web.Models;
using RobsonROX.Mapper;
using RobsonROX.Util;

namespace Agenda.Web.Controllers
{
    [Log]
    public class TurmasController : Controller
    {
        private readonly AgendaContext _contexto;

        public TurmasController()
        {
            _contexto = new AgendaContext();
        }

        // GET: Turmas
        public ActionResult Index()
        {
            return View(_contexto.Turmas
                                 .Include(t => t.Curso)
                                 .Include(t => t.Professor)
                                 .ToList());
        }

        private CadastrarEditarTurmaModel CriarCadastrarEditarTurmaModel(TurmaModel turma = null)
        {
            CadastrarEditarTurmaModel model = new CadastrarEditarTurmaModel
            {
                Professores = _contexto.Professores.ToList(),
                Cursos = _contexto.Cursos.ToList(),
                Turma = turma ?? new TurmaModel()
            };
            return model;
        }

        // GET: Turmas/Cadastrar
        public ActionResult Cadastrar()
        {
            var model = CriarCadastrarEditarTurmaModel();
            return View(model);
        }

        // POST: Turmas/Cadastrar
        [HttpPost]
        public ActionResult Cadastrar(CadastrarEditarTurmaModel model)
        {
            if (ModelState.IsValid)
            {
                ////TODO: Passo 1
                //_contexto.Turmas.Add(model.Turma.ToTurma(_contexto));

                ////TODO: Passo 2
                //_contexto.Turmas.Add(Singleton<TurmaToTurmaModelMapper>.Instance.MapFrom(model.Turma));

                ////TODO: Passo 3
                //_contexto.Turmas.Add(model.Turma.MapTo(new Turma()));
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CriarCadastrarEditarTurmaModel(model.Turma));
        }

        // GET: Turmas/Editar
        public ActionResult Editar(int id)
        {
            Turma turma = _contexto.Turmas
                                   .Where(t => t.Id == id)
                                   .Include(t => t.Curso)
                                   .Include(t => t.Professor)
                                   .Single();
            ////TODO: Passo 1
            //return View(CriarCadastrarEditarTurmaModel(new TurmaModel(turma)));

            ////TODO: Passo 2
            //return View(CriarCadastrarEditarTurmaModel(Singleton<TurmaToTurmaModelMapper>.Instance.MapTo(turma)));

            ////TODO: Passo 3
            //return View(CriarCadastrarEditarTurmaModel(turma.MapTo(new TurmaModel())));
        }

        // POST: Turmas/Cadastrar
        [HttpPost]
        public ActionResult Editar(CadastrarEditarTurmaModel model)
        {
            if (ModelState.IsValid)
            {
                ////TODO: Passo 1
                //_contexto.Entry(model.Turma.ToTurma(_contexto)).State = EntityState.Modified;

                ////TODO: Passo 2
                //_contexto.Entry(Singleton<TurmaToTurmaModelMapper>.Instance.MapFrom(model.Turma)).State = EntityState.Modified;

                ////TODO: Passo 3
                //_contexto.Entry(model.Turma.MapTo(new Turma())).State = EntityState.Modified;
                _contexto.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: Turmas/Excluir
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            Turma turma = _contexto.Turmas.Find(id);
            if (turma != null)
            {
                _contexto.Turmas.Remove(turma);
                _contexto.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}