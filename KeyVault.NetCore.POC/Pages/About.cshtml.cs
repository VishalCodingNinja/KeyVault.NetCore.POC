using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace KeyVault.NetCore.POC.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public AboutModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration = null;

        public void OnGet()
        {
            Message = "My key val = " + _configuration["AppSecret"];
        }
    }
}
