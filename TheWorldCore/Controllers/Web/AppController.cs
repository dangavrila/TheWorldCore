using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorldCore.Services;
using TheWorldCore.ViewModels;

namespace TheWorldCore.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IConfigurationRoot _config;

        public AppController(IMailService mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
                ModelState.AddModelError("", "AOL service is not supported.");

            if (ModelState.IsValid)
            {
                _mailService.SendMessage(_config["MailSettings:ToAddress"], "dan.gavrila3@gmail.com", model.Email, model.Message);

                ModelState.Clear();

                ViewBag.UserMessage = "Message sent!";
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
