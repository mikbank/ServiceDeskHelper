using Microsoft.AspNetCore.Mvc;
using ServiceDeskHelper.Core.Config;

namespace ServiceDeskHelper.Web.Controllers;

public class AboutController : Controller
//Controller to handle displaying the config settings on About section
{
    private readonly AppSettings _settings;

    public AboutController(AppSettings settings)
    {
        _settings = settings;
    }

    public IActionResult Index()
    {
        return View(_settings);
    }
}
