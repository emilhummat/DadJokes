using DadJokes.Data;
using DadJokes.Models;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes.Controllers
{
    public class JokeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public JokeController(ApplicationDbContext db) {
        _db = db;
        } 
        public IActionResult Index()
        {
            IEnumerable<Models.Joke> objList = _db.Joke;
            return View(objList);
        }
        //GET - Create
        public IActionResult Create()
        {
         return View();
        }
        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Joke obj)
        {
            if (ModelState.IsValid)
            {
                _db.Joke.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(obj);
        }
        //GET - Details
        public IActionResult Details(int id)
        {
            var obj = _db.Joke.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //GET - Edit
        public IActionResult Edit(int id) {
            var obj = _db.Joke.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);   
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Joke obj)
        {
            if (ModelState.IsValid)
            {
                _db.Joke.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(obj);
        }

        //GET - Delete
        public IActionResult Delete(int id)
        {
            var obj = _db.Joke.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int id)
        {
            var obj = _db.Joke.Find(id);
            if (obj == null) {
                return NotFound();
            }
                _db.Joke.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
