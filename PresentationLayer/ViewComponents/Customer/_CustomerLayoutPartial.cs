using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.Customer;

public class _CustomerLayoutPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}