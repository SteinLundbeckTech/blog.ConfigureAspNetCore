/*
    Configure ASP.NET Core - https://blog.sltech.no
 */

namespace Blog.ConfigureAspNetCore.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
