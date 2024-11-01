using System.Threading.Tasks;
using XSA.Models;

namespace XSA.Interfaces
{
    public interface INewsService
    {
        //IEnumerable<NewsArticle> getNewsArticles();
        Task<TResponse> Get<TResponse>(string url);
    }
}