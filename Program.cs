/*
    Configure ASP.NET Core - https://blog.sltech.no
 */

using Blog.ConfigureAspNetCore;
using Blog.ConfigureAspNetCore.Components;
using Blog.ConfigureAspNetCore.Components.Features;
using Blog.ConfigureAspNetCore.Components.Repo;

new Config(args,
    new SSL(),
    new Service(typeof(ITheRepo), typeof(TheRepo), ServiceScopes.Transient),
    new DefaultRoute("Demo", "Index"));
