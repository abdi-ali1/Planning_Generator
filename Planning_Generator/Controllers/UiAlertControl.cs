using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Planning_Generator.Controllers
{
    internal class UiAlertControl : Controller
    {

    /*    public static  void SetResult<T>(Result<T> result)
        {
            if (result == null) return;

            if (result.Success)
            {
                ViewData["Message"] = result.Value;
                ViewData["MessageType"] = "success";
            }
            else
            {
                if (result.IsExceptionType<Exception>())
                {
                    ViewData["Message"] = result.Exception.Message;
                }
                else
                {
                    ViewData["Message"] = "something went wrong try again!";
                }
                ViewData["MessageType"] = "danger";
            }
        }*/
    }
}