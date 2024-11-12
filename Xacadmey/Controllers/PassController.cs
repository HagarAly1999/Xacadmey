using Microsoft.AspNetCore.Mvc;

namespace Xacadmey.Controllers
{
    public class PassController : Controller
    {
        public IActionResult first()
        {
            TempData["Msg"] = "data from first action";
            return Content("data saved");
        }
        public IActionResult second() {

            string msg = "empty";
            if (TempData.ContainsKey("Msg")){
                msg = TempData.Peek("Msg").ToString();
                }
           
            return Content("second "+msg);
        
        
        }
        public IActionResult third()
        {

            string msg = "empty";
            if (TempData.ContainsKey("Msg"))
            {
                msg = TempData.Peek("Msg").ToString();
                TempData.Keep("Msg");
            }
            return Content("third " + msg);
        }
    }
}
