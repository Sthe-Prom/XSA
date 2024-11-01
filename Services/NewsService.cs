using System;
using NewsAPI.Net;
using NewsAPI.Net.Models;
using Newtonsoft.Json;
using XSA.Interfaces;
using XSA.Models;

namespace XSA.Services
{
    public class NewsService: INewsService
    {      
        // init with your API key
        // var newsApiClient = new NewsApiClient("d77c76f0fd0b439ba5096ed343318243");
        // var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
        // {
        //     Q = "Apple",
        //     SortBy = SortBys.Popularity,
        //     Language = Languages.EN,
        //     From = new DateTime(2018, 1, 25)
        // });

       

        //var topHeadlines = await api.GetTopHeadlinesAsync("dotnet", "sources", "domains", Language.ENGLISH);

        
        // public IEnumerable<NewsArticle> getNewsArticles()
        // {
        //        List<NewsArticle> newsList = new List<NewsArticle>();

        //     if (articlesResponse.Status == Statuses.Ok)
        //     {
        //         // total results found
        //         // Console.WriteLine(articlesResponse.TotalResults);
                
        //         // here's the first 20
        //         foreach (var article in everything.Articles)
        //         {

        //             NewsArticle vm = new NewsArticle();
        //             vm.Title = article.Title;
        //             vm.Picture = article.Url;
        //             vm.Body = article.Description;
        //             vm.Author = article.Author;
        //             vm.Date = article.PublishedAt;

        //             newsList.Add(vm);
          
        //         }
        //     }

        //       return newsList;
        // }

        public async Task<TResponse> Get<TResponse>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(content);
                
            }
        }

        // public async Task<JsonResult> PrintResults()
        // {
        //     var api = new NewsAPIClient("d77c76f0fd0b439ba5096ed343318243");

        //     var sources = await api.GetSourcesAsync();

        //     var everything = await api.GetEverythingAsync("bitcoin", "sources", "domains", Language.ENGLISH);

        //     JsonViewModel model = new JsonViewModel();

        //     model.ResponseMessage = JsonConvert.SerializeObject(everything); 

        //     return Json(model);
        // }   

        
    }
}