using Catalogo_Blazor.Shared.Models.Recursos;
using System.Linq;

namespace Catalogo_Blazor.Server.Utils
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, Paginacao paginacao)
        {
            return queryable
                .Skip((paginacao.paginaAtual - 1) * paginacao.quantidadePorPagina)
                .Take(paginacao.quantidadePorPagina);
        }
    }
}
