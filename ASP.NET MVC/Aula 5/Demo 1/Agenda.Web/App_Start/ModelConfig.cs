using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Agenda.Dados;
using Agenda.Web.Models;

namespace Agenda.Web
{
    public class ModelConfig
    {
        private static void AssociateMetadata<TModel, TMetadata>()
        {
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(TModel), typeof(TMetadata)), typeof(TModel));
        }

        public static void AssociateMetadata()
        {
            AssociateMetadata<Professor, ProfessorMetadata>();
            AssociateMetadata<Turma, TurmaMetadata>();
            AssociateMetadata<TurmaModel, TurmaMetadata>();
            AssociateMetadata<Curso, CursoMetadata>();
            //AssociateMetadata<Endereco, EnderecoMetadata>();
            //AssociateMetadata<Aluno, AlunoMetadata>();
        }
    }
}