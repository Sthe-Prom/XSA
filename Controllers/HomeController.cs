using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using XSA.Models;
using System;
using NewsAPI.Net;
using NewsAPI.Net.Models;
using Newtonsoft.Json;
using XSA.Interfaces;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace XSA.Controllers;

// [Route("api/[controller]")]
// [ApiController]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;

    private readonly INewsService newsService_context;
    private readonly HttpClient httpClient;

    public HomeController(ILogger<HomeController> _logger, INewsService _newsService_context)
    {
        logger = _logger;
        newsService_context = _newsService_context;
        httpClient = new HttpClient();
    }

    public IActionResult About() => View();

    public IActionResult Index() => View();

    public IActionResult Blog() => View();

    public IActionResult Events() => View();

    public IActionResult Contact() => View();

    public IActionResult Gallary() => View();
    
    public IActionResult BlogDetails() => View();

    public IActionResult Team() => View();

    // public IActionResult Events() => View();

    public IActionResult News(NewsViewModel vm)
    {
        //vm.NewsArticles = newsService_context.getNewsArticles();     
        return View(vm);   
    }

    // public async Task<JsonResult> PrintResults()
    // {        

    //     //var results = https://newsapi.org/v2/top-headlines?country=us&apiKey=d77c76f0fd0b439ba5096ed343318243

    //     // var api = new NewsClient("d77c76f0fd0b439ba5096ed343318243");

    //     // //var sources = await api.GetSourcesAsync();
    //     // //var sources  = api.GetSourcesAsync().GetAwaiter().GetResult();

    //     // //var everything = await api.GetEverythingAsync("bitcoin", "sources", "domains", Language.ENGLISH);
    //     // var everything2 = await api.GetEverythingAsync("bitcoin", lang: Language.ENGLISH);

    //     // JsonViewModel model = new JsonViewModel();

    //     // model.ResponseMessage = JsonConvert.SerializeObject(everything2); 

    //     // return Json(model);
    // }   

    public async Task<IActionResult> MyMethod()
    {
        // var response = await newsService_context.Get<NewsArticle>("https://newsapi.org/v2/top-headlines?country=us&apiKey=d77c76f0fd0b439ba5096ed343318243");

        // // List<NewsArticle> newsList = new List<NewsArticle>();

        // // foreach (var article in response.Articles)
        // // {

        // //     NewsArticle vm = new NewsArticle();
        // //     vm.Title = response.Title;
        // //     vm.Picture = response.Url;
        // //     vm.Body = response.Description;
        // //     vm.Author = response.Author;
        // //     vm.Date = response.PublishedAt;

        // //     newsList.Add(vm);
    
        // // }

        //JsonViewModel model = new JsonViewModel();
        // model.ResponseMessage = JsonConvert.SerializeObject(newsList); 
        
            var httpClient = new HttpClient();
        
            var response = await httpClient.GetAsync("https://newsapi.org/v2/top-headlines?country=us&apiKey=d77c76f0fd0b439ba5096ed343318243");
            var content = await response.Content.ReadAsStringAsync();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");
            //return JsonConvert.SerializeObject(content);          
        

        return Content(content);
        
    }

    [HttpGet]
    public async Task<IActionResult> GetData()
    {
        // Replace "API_URL" with the actual URL of the third-party API you want to access
        var apiUrl = "https://newsapi.org/v2/top-headlines?country=us&apiKey=d80a0d21aebf4745905be2b0ea6cc806";
        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
    
        if (response.IsSuccessStatusCode)
        {
            string data = await response.Content.ReadAsStringAsync();
            // Process the data or return it as-is
            return Ok(data);
        }
        else
        {
            // Handle the error condition
            return StatusCode((int)response.StatusCode);
        }
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
