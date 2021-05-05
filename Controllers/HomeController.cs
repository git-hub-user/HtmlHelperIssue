using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HtmlHelperIssue.Models;

namespace HtmlHelperIssue
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("A");
        }

        public IActionResult A()
        {
            var model = GetModel();
            return View("A", model);
        }

        [HttpPost]
        public IActionResult A(MyModel model)
        {
            // Creating a new instance of model also reproduces the issue:
            // var model = GetModel();

            model.Items.RemoveAt(0);

            return View("B", model);
        }

        public MyModel GetModel()
        {
            return new MyModel
            {
                Items = new List<Item>
                {
                    new Item{Id=1},
                    new Item{Id=2},
                    new Item{Id=3}
                }
            };
        }
    }
}