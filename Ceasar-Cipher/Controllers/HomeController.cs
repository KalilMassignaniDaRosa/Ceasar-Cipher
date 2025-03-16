using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ceasar_Cipher.Models;
using CeasarCipher;

namespace Ceasar_Cipher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CeaserCipher _cipher;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _cipher = new CeaserCipher(); // Instancia a classe CeaserCipher
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EncryptPage()
        {
            ViewData["Title"] = "Encrypt Page";
            return View();
        }

        // Processa a criptografia (POST)
        [HttpPost]
        public IActionResult Encrypt(string phrase, int code)
        {
            if (string.IsNullOrEmpty(phrase) || code == 0)
            {
                ViewBag.Error = "Please provide both the phrase and the code.";
                return View("EncryptPage"); 
            }

            string encryptedText = _cipher.Encrypt(code, phrase); // Chama a funcao de criptografia
            ViewBag.EncryptedText = encryptedText; // Passa o texto criptografado para a View
            return View("EncryptPage");
        }

        public IActionResult DecryptPage()
        {
            ViewData["Title"] = "Dencrypt Page";
            return View();
        }

        // Processa a descriptografia (POST)
        [HttpPost]
        public IActionResult Decrypt(string phrase, int code)
        {
            if (string.IsNullOrEmpty(phrase) || code == 0)
            {
                ViewBag.Error = "Please provide both the phrase and the code.";
                return View("DecryptPage");
            }

            string decryptedText = _cipher.Decrypt(code, phrase); // Chama a funcao de descriptografia
            ViewBag.DecryptedText = decryptedText; // Passa o texto descriptografado para a View
            return View("DecryptPage");
        }

        // Pagina de erro
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
