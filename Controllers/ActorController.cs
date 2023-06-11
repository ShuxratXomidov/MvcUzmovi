using Microsoft.AspNetCore.Mvc;

namespace MvcUzmovi.Controllers;

public class ActorController : Controller
{
    private readonly DataContext dbContext;

    public ActorController(DataContext dataContext)
    {
        this.dbContext = dataContext;
    }
    
    public IActionResult Index()
    {
        List<Actor> actors = new List<Actor>();
        actors = dbContext.Actors.ToList();

        return View(actors);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Store(Actor actor)
    {
        dbContext.Actors.Add(actor);
        dbContext.SaveChanges();


        return RedirectToAction("Index");
    }

    [HttpGet]
        [Route("[controller]/[action]/{id}")]

        public IActionResult Edit(int id)
        {
          var actor = dbContext.Actors.Find(id);
          return View(actor);
        }

    [HttpPost]
    
    [Route("[controller]/[action]/{id}")]
    
    public IActionResult Update(int id, Actor newactor)
    {
        var oldactor= dbContext.Actors.Find(id);

        oldactor.Id = newactor.Id;
        oldactor.Name = newactor.Name;
        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    
    [Route("[controller]/[action]/{id}")]

    public IActionResult Delete(int id)
    {
        var actor = dbContext.Actors.Find(id);
        dbContext.Actors.Remove(actor);
        dbContext.SaveChanges();

        return RedirectToAction("Index");
    }





}
