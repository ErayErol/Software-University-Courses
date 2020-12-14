using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Data;
using Phonebook.Data.Models;

namespace Phonebook.Controllers
{
    public class ContactController : Controller
    {

        [HttpPost]
        public IActionResult Create (Contact contact)
        {
            DataAccsess.Contacts.Add(contact);

            return RedirectToAction("Index", "Home");
        }
    }
}