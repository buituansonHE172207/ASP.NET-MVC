using first_lesson.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace first_lesson.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly ProductService products;

        public FirstController(ILogger<FirstController> _logger, IWebHostEnvironment webHostEnvironment, ProductService _products)
        {
            _webHostEnvironment = webHostEnvironment;
            logger = _logger;
            products = _products;
        }

        public string Index()
        {
            logger.LogInformation("Index actions");
            logger.LogWarning("wanning message");
            return "first";
        }

        public void Nothing()
        {
            logger.LogInformation("Nothing actions");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => DateTime.Now;

         /* Kiểu trả về                 | Phương thức
            ------------------------------------------------
            ContentResult               | Content()
            EmptyResult                 | new EmptyResult()
            FileResult                  | File()
            ForbidResult                | Forbid()
            JsonResult                  | Json()
            LocalRedirectResult         | LocalRedirect()
            RedirectResult              | Redirect()
            RedirectToActionResult      | RedirectToAction()
            RedirectToPageResult        | RedirectToRoute()
            RedirectToRouteResult       | RedirectToPage()
            PartialViewResult           | PartialView()
            ViewComponentResult         | ViewComponent()
            StatusCodeResult            | StatusCode()
            ViewResult                  | View() */

            public IActionResult Readme()
            {
                var content = @"
                This is the content of the 
                multiple lines of documentation";
                return Content(content, "text/html");
            }

            public IActionResult GetImage()
            {
                string contentRootPath = _webHostEnvironment.ContentRootPath;
                
                string filePath = Path.Combine(contentRootPath, "Files", "Kasumi.png");
                var bytes = System.IO.File.ReadAllBytes(filePath);
                return File(bytes, "image/png");
            }

            public IActionResult GetJson()
            {
                return Json(
                    new  {
                        Name = "Iphone",
                        Price = 2000
                    }
                );
            }

            public IActionResult Privacy()
            {
                var url = Url.Action("Privacy", "Home");
                return LocalRedirect(url);
            }

            public IActionResult Google()
            {
                return Redirect("https://www.google.com");
            }

            public IActionResult HelloView(string username)
            {
                if (string.IsNullOrEmpty(username))
                    username = "Khach";
                
                return View("/MyView/FirstView.cshtml", username);
            }

            public IActionResult xinchao()
            {
                //return View("xinchao");
                string username = "heelo";
                return View((object) (username)); // default view name is function name
                // muon truyen string qua view thi can chuyen doi qua object
            }

            public IActionResult FirstView()
            {
                return View();
            }

            public IActionResult ViewProduct(int? id)
            {
                var product = products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    //return NotFound();
                    TempData["Thongbao"] = "This is the notification";
                    return Redirect(Url.Action("Index", "Home"));
                }
                //return View(product);
                /* ViewData["Product"] = product;
                return View(); */
                ViewBag.product = product;
                // this will be deleted after the first read
                TempData["Thongbao"] = "This is the notification";
                return View("ViewProduct3");
            }
    }
}