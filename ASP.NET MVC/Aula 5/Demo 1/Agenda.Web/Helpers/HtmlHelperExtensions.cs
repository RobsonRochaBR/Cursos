using System;
using System.Web.Mvc;

namespace Agenda.Web.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Saudacoes(this HtmlHelper htmlHelper)
        {
            string result;
            TimeSpan hora = DateTime.Now.TimeOfDay;
            TimeSpan inicioManha = new TimeSpan(6, 0, 0);
            TimeSpan inicioTarde = new TimeSpan(12, 0, 0);
            TimeSpan inicioNoite = new TimeSpan(18, 0, 0);
            if (hora >= inicioManha && hora < inicioTarde)
            {
                result = "Bom dia!";
            }
            else if (hora >= inicioTarde && hora < inicioNoite)
            {
                result = "Boa tarde!";
            }
            else
            {
                result = "Boa noite!";
            }

            var builder = new TagBuilder("div") {InnerHtml = result};
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}