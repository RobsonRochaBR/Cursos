using Agenda.Dados;
using Agenda.Web.Models;
using RobsonROX.Mapper;

namespace Agenda.Web.Mappers
{
    public class TurmaModelMapperRegister : IMapperRegister<TurmaModel>
    {
        public void RegisterMappings(MappingRegistry<TurmaModel> mappings)
        {
            //Mapeamento de TurmaModel para Turma
            mappings.For<Turma>().UseAttributes().AndUseConventions().And((model, turma) =>
            {
                using (var contexto = new AgendaContext())
                {
                    turma.Professor = contexto.Professores.Find(model.ProfessorId);
                    turma.Curso = contexto.Cursos.Find(model.CursoId);
                }
                return turma;
            });
        }
    }
}