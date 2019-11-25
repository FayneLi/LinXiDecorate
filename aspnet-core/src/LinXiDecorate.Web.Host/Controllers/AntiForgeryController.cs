using Microsoft.AspNetCore.Antiforgery;
using LinXiDecorate.Controllers;

namespace LinXiDecorate.Web.Host.Controllers
{
    public class AntiForgeryController : LinXiDecorateControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
