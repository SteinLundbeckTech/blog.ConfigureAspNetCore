﻿/*
    Configure ASP.NET Core - https://blog.sltech.no
 */

namespace Blog.ConfigureAspNetCore.Components.Features
{
    public abstract class FeatureBase(Feature feat)
    {
        public Feature Feature => feat;
    }
}
