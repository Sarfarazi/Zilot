using Microsoft.AspNetCore.Mvc;
using Zelut.LandingPage.Models;

namespace Zelut.LandingPage.Components;

public class AlertViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var message = TempData["AlertMessage"] as string;
        var type = TempData["Type"] as string;

        if(string.IsNullOrEmpty(message))
        {
            return Content(string.Empty);
        }

        return View("Alert", new AlertViewModel
        {
            AlertMessage = message,
            Type = type
        });
    }
}
