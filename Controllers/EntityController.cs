using Microsoft.AspNetCore.Mvc;
using Slate.Models;
using Slate.Services;

public class EntityController : Controller
{
    private readonly EntityService _entityService;

    public EntityController(EntityService entityService)
    {
        _entityService = entityService;
    }

    public async Task<IActionResult> Index()
    {
        var entities = await _entityService.GetAllAsync();
        return View(entities);
    }

    // Other actions...
}
