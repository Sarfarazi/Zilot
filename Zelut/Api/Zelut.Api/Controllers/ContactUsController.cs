using Microsoft.AspNetCore.Mvc;
using Zelut.Application.DTOs;
using Zelut.Application.Services;

namespace Zelut.Api.Controllers;

public class ContactUsController : BaseController
{
    private readonly IContactUsService _contactUsService;
    public ContactUsController(IContactUsService contactUsService)
    {
        _contactUsService = contactUsService;
    }

    [HttpPost("home/contact-us")]
    public async Task<IActionResult> ContactUs([FromBody]CreateContactUsDto request)
    {
        var result = await _contactUsService.InsertContactUs(request);
        if(!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
