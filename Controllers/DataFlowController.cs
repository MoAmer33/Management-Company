using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    public class DataFlowController : Controller
    {
        public IActionResult SetSessionData()
        {
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 21);
            return Content("saved successfully");
        }
        public IActionResult getSessionData()
        {
            string name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content($"Name ={name} \t age={age}");
        }

        public IActionResult SetCookies()
        { 
            CookieOptions cookieOptions = new CookieOptions(); 
            cookieOptions.Expires = DateTime.Now.AddSeconds(20);
            HttpContext.Response.Cookies.Append("Name", "Ahmed",cookieOptions);
            HttpContext.Response.Cookies.Append("Age", "22",cookieOptions);
            return Content("save Cookies");
        }
        public IActionResult getCookies()
        {
            string name = HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"name={name}\t age={age}");
        }
    }
}
