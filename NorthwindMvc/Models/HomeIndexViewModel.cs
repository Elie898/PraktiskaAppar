using Northwind.EntityModels;

namespace NorthwindMvc.Models
{
    public record HomeIndexViewModel
    (
        int VisitorCount,
        IList<Category> Categories,
        IList<Product> Products
    );
}
