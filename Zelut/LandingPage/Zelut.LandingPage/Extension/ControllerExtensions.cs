using Microsoft.AspNetCore.Mvc;

namespace Zelut.LandingPage.Extension;


public static class ControllerExtensions
{
    /// <summary>
    /// extension method for set alert message in controller
    /// </summary>
    /// <param name="controller"></param>
    /// <param name="message">message for alert</param>
    /// <param name="type">alert type.for example 'success' or 'error'</param>
    public static void SetAlert(this Controller controller, string message, string type)
    {
        controller.TempData["AlertMessage"] = message;
        controller.TempData["Type"] = type;
    }
}