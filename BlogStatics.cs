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
    public enum ServiceScopes
    {
        Scoped,
        Singleton,
        Transient
    }
}
