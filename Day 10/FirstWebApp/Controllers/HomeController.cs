using Employee_MVC_v1._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

/*  
 *  KEEP IN MIND TO NAME EVERY CONTROLLER BY SUFFIX OF CONTROLLER
 *  This the HomeController
 *  Controllers should be added in Controller folder only
 *  Every URI starting with Controller Name handles different Action calls.
 *  Every Action call returns View, which is stored in Views Folder which has separate folder for every Controller
 *  View Name should be same as the Action method name for easy convinience
 *  
 */
namespace Employee_MVC_v1._0.Controllers
{
    //Every Controller extends from abstract Controller class
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /*
         *  This is the Request Handling method which handles the request for URI - Home/Index
         *  RHM always returns IActionResult(View), it automatically picks up the View Layer from View/Home folder 
         *  View Layer Name will be - Index.cshtml
         *  If the name is different of View Layer, we need to return View("NameOfView");
         */
        public IActionResult Index()
        {
            //After Returning the View, the call goes to ViewFirst Layer, which has a prebuilt Layout for our WebApp,
            //There the layout name is mentioned, which is stored in Views/Shared folder
            //We can either choose to select the layout or not

            //This is the ViewBag, in which we can add object and it Can send it to the View layer and we can use it
            ViewBag.sendString = "String from the ViewBag";
            return View();
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
