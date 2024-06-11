/*
    Configure ASP.NET Core - https://blog.sltech.no
 */

namespace Blog.ConfigureAspNetCore
{
    /// <summary>
    /// Supported features
    /// </summary>
    public enum Feature
    {
        SSL,
        DefaultRoute,
        Service
    }

    /// <summary>
    /// Supported service scopes
    /// </summary>
    public enum ServiceScope
    {
        Scoped,
        Singleton,
        Transient
    }
}
