namespace Agenda.Web.Mappers
{
    public interface IMapper<TFrom, TTo>
    {
        TTo MapTo(TFrom source);
        TFrom MapFrom(TTo source);
    }
}