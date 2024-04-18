using Microsoft.AspNetCore.Mvc;
using QRCodeGeneratorHelper.Helper.QRCodeGeneratorHelper;
using QRCodeGeneratorHelper.Models;
using QRCodeGeneratorHelper.ViewModels;
using System.Diagnostics;

namespace QRCodeGeneratorHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQRCodeGeneratorHelper qRCodeGeneratorHelper;

        public HomeController(ILogger<HomeController> logger , IQRCodeGeneratorHelper qRCodeGeneratorHelper)
        {
            _logger = logger;
            this.qRCodeGeneratorHelper = qRCodeGeneratorHelper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string text)
        {
            if(string.IsNullOrEmpty(text))
               return BadRequest();

            byte[] QRCodeAsBytes = qRCodeGeneratorHelper.GenerateQRCode(text);
            string QRCodeAsImageBase64 = $"data:image/png;base64,{Convert.ToBase64String(QRCodeAsBytes)}";

            GenerateQRCodeViewModel model = new GenerateQRCodeViewModel();

            model.QRCodeImageUrl = QRCodeAsImageBase64;


            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
