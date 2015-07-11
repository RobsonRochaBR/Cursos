using Agenda.Dados;
using Agenda.Web.Models;
using RobsonROX.Mapper;

namespace Agenda.Web.Mappers
{
    public class TurmaMapperRegister : IMapperRegister<Turma>
    {
        public void RegisterMappings(MappingRegistry<Turma> mappings)
        {
            //Mapeamento de Turma para TurmaModel
            mappings.For<TurmaModel>().UseAttributes().AndUseConventions().And((turma, model) =>
            {
                model.ProfessorId = turma.Professor.Id;
                model.CursoId = turma.Curso.Id;
                return model;
            });
        }
    }
}