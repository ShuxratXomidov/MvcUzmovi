using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace Uzmovi.Controllers;

public class MovieController : Controller 
{
    private readonly DataContext dbContext;

    public MovieController(DataContext dataContext)
    {
      this.dbContext = dataContext;
    }

  
    // [Authorize]
    public IActionResult Index()
    {
      List<Movie> movies= new List<Movie>();
      movies = dbContext.Movies.ToList();

      return View(movies);
    }

    [HttpGet]
     
     public IActionResult Create()
     { 
      
        return View();
     }

     [HttpPost]

     public IActionResult Store(Movie movie)
     {
      dbContext.Movies.Add(movie);
      dbContext.SaveChanges();

      return RedirectToAction("Index");
     }

     [HttpGet]
     [Route("[controller]/[action]/{id}")]

     public IActionResult Edit(int id)
     {
      var movie = dbContext.Movies.Find(id);
      return View(movie);
     }
     [HttpPost]
        [Route("[controller]/[action]/{id}")]

        public IActionResult Update (int id, Movie newmovie)
        {
          var oldmovie=dbContext.Movies.Find(id);
          

          oldmovie.Name=newmovie.Name;
          oldmovie.Year=newmovie.Year;
          oldmovie.Country=newmovie.Country;

          dbContext.SaveChanges();
          
          return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]

        public IActionResult Delete(int id)
        {
          var movie= dbContext.Movies.Find(id);
          dbContext.Movies.Remove(movie);
          dbContext.SaveChanges();

        return RedirectToAction("Index");
        }
        
}
