using Agenda.Dados;
using Agenda.Web.Models;

namespace Agenda.Web.Mappers
{
    public class TurmaToTurmaModelMapper : IMapper<Turma, TurmaModel>
    {
        public TurmaModel MapTo(Turma source)
        {
            return new TurmaModel
            {
                Id = source.Id,
                Nome = source.Nome,
                DataInicio = source.DataInicio,
                Local = source.Local,
                ProfessorId = source.Professor.Id,
                CursoId = source.Curso.Id
            };
        }

        public Turma MapFrom(TurmaModel source)
        {
            using (var contexto = new AgendaContext())
            {
                return new Turma
                {
                    Id = source.Id,
                    Nome = source.Nome,
                    DataInicio = source.DataInicio,
                    Local = source.Local,
                    ProfessorId = source.ProfessorId,
                    Professor = contexto.Professores.Find(source.ProfessorId),
                    CursoId = source.CursoId,
                    Curso = contexto.Cursos.Find(source.CursoId)
                };
            }
        }
    }
}