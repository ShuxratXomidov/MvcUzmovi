using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace MvcUzmovi.Controllers;

public class UserController : Controller
{
    private readonly DataContext dbContext;

    public UserController(DataContext dataContext)
    {
      this.dbContext=dataContext;
    }
    
    // [Authorize]
    public IActionResult Index()
    {
        List<User> users= new List<User>();
        users=dbContext.Users.ToList();
        
        return View(users);
    }
    
      [HttpGet]

        public IActionResult Create()
        {
          return View();
        }

        [HttpPost]

        public IActionResult Store(User user)
        {
          dbContext.Users.Add(user);
          dbContext.SaveChanges();
          return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]

        public IActionResult Edit(int id)
        {
          var user = dbContext.Users.Find(id);
          return View(user);
        }

        [HttpPost]
        [Route("[controller]/[action]/{id}")]

        public IActionResult Update (int id, User newuser)
        {
          var olduser=dbContext.Users.Find(id);
          
          olduser.FirstName=newuser.FirstName;
          olduser.LastName=newuser.LastName;
          olduser.Email=newuser.Email;
          olduser.Password=newuser.Password;
          dbContext.SaveChanges();
          
          return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]

        public IActionResult Delete(int id)
        {
          var user= dbContext.Users.Find(id);
          dbContext.Users.Remove(user);
          dbContext.SaveChanges();

          return RedirectToAction("Index");
        }
}