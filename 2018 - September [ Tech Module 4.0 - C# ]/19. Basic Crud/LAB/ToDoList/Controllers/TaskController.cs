using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        // READ

        public IActionResult Index()
        {
            using (var db = new ToDoDbContext())
            {
                List<Task> tasks = db.Tasks.ToList();
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
        public IActionResult Create(string title, string comments)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(comments))
            {
                return RedirectToAction("Index");
            }

            Task newTask = new Task
            {
                Title = title,
                Comments = comments
            };

            using (var db = new ToDoDbContext())
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
            using (var db = new ToDoDbContext())
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

            using (var db = new ToDoDbContext())
            {
                var oldTask = db.Tasks.FirstOrDefault(t => t.Id == newTask.Id);

                if (oldTask == null)
                {
                    return RedirectToAction("Index");
                }

                oldTask.Title = newTask.Title;
                oldTask.Comments = newTask.Comments;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // DELETE

        [HttpGet]
        public IActionResult Details(int id)
        {
            using (var db = new ToDoDbContext())
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
        public IActionResult Delete(int id)
        {
            using (var db = new ToDoDbContext())
            {
                var task = db.Tasks.FirstOrDefault(t => t.Id == id);

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