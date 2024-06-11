/*
    Configure ASP.NET Core - https://blog.sltech.no
 */

using Blog.ConfigureAspNetCore.Components.Features;

namespace Blog.ConfigureAspNetCore.Components.Extensions
{
    public static class FeatureBaseCollectionExtensions
    {
        public static bool Exists(this FeatureBase[] features, Feature feature) => features.SingleOrDefault(ft => ft.Feature == feature) != null;
    }
}
