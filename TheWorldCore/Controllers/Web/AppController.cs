using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorldCore.Models;
using TheWorldCore.Services;
using TheWorldCore.ViewModels;

namespace TheWorldCore.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IConfigurationRoot _config;
        private readonly IWorldCoreRepository _repository;
        private readonly ILogger<AppController> _logger;

        public AppController(IMailService mailService, IConfigurationRoot config, IWorldCoreRepository repository, ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var data = _repository.GetAllTrips();

                return View(data);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to get trips: {ex.Message}");
                return Redirect("/error");
            }
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email != null)
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
