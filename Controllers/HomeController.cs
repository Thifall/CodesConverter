using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CodesConverter.Models;
using CodesConverter.Models.Ciphers.Interfaces;
using CodesConverter.Models.Encoding.Interfaces;

namespace CodesConverter.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEncoder _encoder;

        public HomeController(IEncoder encoder)
        {
            _encoder = encoder;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel()
            {
                Ciphers = _encoder.Ciphers
            };
            return View(model);
        } 

        [HttpPost]
        public IActionResult Encode(TextChangeRequestModel model)
        {
            var selectedCipher = Request.Form["Cipher"];
            var textTochange = Request.Form["TextToChange"];
            var result = _encoder.Encode(textTochange.First(), selectedCipher.First(), "");
            HomeViewModel indexModel = new HomeViewModel()
            {
                TextToChange = model.TextToChange,
                Result = result,
                Ciphers = _encoder.Ciphers,
                Key = model.Key,
            };
            return View("Index", indexModel);
        }

        [HttpPost]
        public IActionResult Decode(TextChangeRequestModel model)
        {
            var selectedCipher = Request.Form["Cipher"];
            var textTochange = Request.Form["TextToChange"];
            var result = _encoder.Decode(textTochange.First(), selectedCipher.First(), "");
            HomeViewModel indexModel = new HomeViewModel()
            {
                TextToChange = model.TextToChange,
                Result = result,
                Ciphers = _encoder.Ciphers,
                Key = model.Key,
            };
            return View("Index", indexModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
