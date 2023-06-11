using Microsoft.AspNetCore.Mvc;

namespace Uzmovi.Controllers;

public class GenreController : Controller 
{
    private readonly DataContext dbContext;

    public GenreController(DataContext dataContext)
    {
      this.dbContext = dataContext;
    }

  
    
    public IActionResult Index()
    {


      List<Genre> genres= new List<Genre>();
      genres = dbContext.Genres.ToList();
      
      return View(genres);
    }


    [HttpGet]
     
     public IActionResult Create()
     { 
      
        return View();
     }

     [HttpPost]

     public IActionResult Store(Genre genre)
     {
      dbContext.Genres.Add(genre);
      dbContext.SaveChanges();

      return RedirectToAction("Index");
     }

     [HttpGet]
     [Route("[controller]/[action]/{id}")]

     public IActionResult Edit(int id)
     {
      var movie = dbContext.Genres.Find(id);
      return View(movie);
     }
     [HttpPost]
        [Route("[controller]/[action]/{id}")]

        public IActionResult Update (int id, Genre newgenre)
        {
          var oldgenre=dbContext.Genres.Find(id);
          

          oldgenre.Name=newgenre.Name;
          

          dbContext.SaveChanges();
          
          return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]

        public IActionResult Delete(int id)
        {
          var genre= dbContext.Genres.Find(id);
          dbContext.Genres.Remove(genre);
          dbContext.SaveChanges();

        return RedirectToAction("Index");
        }
        
}
