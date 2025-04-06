using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Northwind.Razor.Employees.MyFeature.Pages;

public class EmployeesModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Northwind App - Employees";
    }
}
