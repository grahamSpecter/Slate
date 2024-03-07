using Microsoft.AspNetCore.Mvc;
using Slate.Services;

public class MatterController : Controller
{
    private readonly MatterService _matterService;

    public MatterController(MatterService matterService)
    {
        _matterService = matterService;
    }

    public async Task<IActionResult> Index()
    {
        var matters = await _matterService.GetAllAsync();
        return View(matters);
    }

    // Other actions...
}
