using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin
{
    public class AdminAreaAttribute : AreaAttribute
    {
        public AdminAreaAttribute() : base("Admin")
        { }
    }
}
