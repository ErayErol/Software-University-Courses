using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TeisterMask.Data;
using TeisterMask.Models;
using System.Collections.Generic;

namespace TeisterMask.Controllers
{
    public class TaskController : Controller
    {
        // READ - LISTING

        public IActionResult Index()
        {
            using (var db = new TeisterMaskDbContext())
            {
                var tasks = db.Tasks.ToList();
                return View(tasks);
            }
        }

        // CREATE

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string status)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(status))
            {
                return RedirectToAction("Index");
            }

            Task newTask = new Task
            {
                Title = title,
                Status = status
            };

            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Add(newTask);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // UPDATE - EDIT

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var oldTask = db.Tasks.FirstOrDefault(t => t.Id == id);

                if (oldTask == null)
                {
                    return RedirectToAction("Index");
                }

                return View(oldTask);
            }
        }

        [HttpPost]
        public IActionResult Edit(Task newTask)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Index");
            }

            using (var db = new TeisterMaskDbContext())
            {
                var oldTask = db.Tasks.FirstOrDefault(t => t.Id == newTask.Id);

                if (oldTask == null)
                {
                    return RedirectToAction("Index");
                }

                oldTask.Title = newTask.Title;
                oldTask.Status = newTask.Status;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // DELETE

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var oldTask = db.Tasks.FirstOrDefault(t => t.Id == id);

                if (oldTask == null)
                {
                    return RedirectToAction("Index");
                }

                return View(oldTask);
            }
        }

        [HttpPost]
        public IActionResult Delete(Task newTask)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var task = db.Tasks.FirstOrDefault(t => t.Id == newTask.Id);

                if (task == null)
                {
                    return RedirectToAction("Index");
                }

                db.Tasks.Remove(task);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}