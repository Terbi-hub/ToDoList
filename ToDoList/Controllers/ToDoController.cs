using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Model;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoItemContext _context;

        public ToDoController(ToDoItemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var items = await _context.Items.ToListAsync();
            var model = new ToDoItemPageViewModel
            {
                Items = items,
                PageTitle = "All"
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoItem item)
        {
            try
            {
                if(item.Text == null)
                {
                    return View(item);
                }
                if (ModelState.IsValid)
                {
                    _context.Add(item);
                    _context.SaveChanges();
                    return RedirectToAction("Home");
                }
                return View(item);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(item);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var item = _context.Items.Find(Id);
            _context.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet]
        public IActionResult IsCompleted(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var task = _context.Items.Find(Id);
            if (!task.IsCompleted)
                task.IsCompleted = true;
            else task.IsCompleted = false;
            _context.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet]
        public IActionResult TodayWork()
        {
            //var items = _context.Items.Where(t => t.Date == DateTime.Today).ToList();
            //var model = new ToDoItemPageViewModel
            //{
            //    Items = items,
            //    PageTitle = "Today"
            //};
            //return View("Home", model);
            return Returner("Today");
        }

        [HttpGet]
        public IActionResult TomorrowWork()
        {
            //var items = _context.Items.Where(t => t.Date == DateTime.Today.AddDays(1)).ToList();
            //var model = new ToDoItemPageViewModel
            //{
            //    Items = items,
            //    PageTitle = "Tomorrow"
            //};
            //return View("Home", model);
            return Returner("Tomorrow", 1);
        }

        
        private IActionResult Returner(string NamePage, int Day = 0)
        {
            var items = _context.Items.Where(t => t.Date == DateTime.Today.AddDays(Day)).ToList();
            var model = new ToDoItemPageViewModel
            {
                Items = items,
                PageTitle = NamePage
            };
            return View("Home", model);
        }
    }
}
