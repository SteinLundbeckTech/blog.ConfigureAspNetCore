/*
    Configure ASP.NET Core - https://blog.sltech.no
 */

using Blog.ConfigureAspNetCore.Components.Extensions;
using Blog.ConfigureAspNetCore.Components.Features;

namespace Blog.ConfigureAspNetCore.Components
{
    public class Config
    {
        private readonly string[] _args;
        private readonly FeatureBase[] _features;
        private WebApplicationBuilder _builder;

        public Config(string[] args, params FeatureBase[] feaures)
        {
            _args = args;
            _features = feaures;
            _builder = WebApplication.CreateBuilder(args);

            ProcessFeatures();
        }

        private void ProcessFeatures()
        {
            _builder.Services
                .AddControllersWithViews();

            _ = _builder.Services
                .AddHttpContextAccessor()
                .Configure<CookiePolicyOptions>(opt =>
                {
                    opt.MinimumSameSitePolicy = SameSiteMode.Lax;
                })
                .AddSession(opt =>
                {
                    opt.IdleTimeout = TimeSpan.FromMinutes(120);
                })
                .AddDistributedMemoryCache()
                .AddSession(opt => 
                {
                    opt.Cookie.Name = "mySession";
                    opt.Cookie.HttpOnly = false;
                });

            if (_features.Exists(Feature.SSL))
            {
                SSL ssl = (SSL)_features.Single(ft => ft.Feature == Feature.SSL);

                _ = _builder.Services
                    .AddHttpsRedirection(opt =>
                    {
                        opt.HttpsPort = ssl.Port;
                    });
            }

            if (_features.Exists(Feature.Service))
            {
                foreach (Service srv in _features.Where(ft => ft.Feature == Feature.Service))
                {
                    switch(srv.Scope)
                    {
                        case ServiceScopes.Singleton:
                            AddService(srv.Interface, srv.Implementation, srv.Scope);
                            break;

                        case ServiceScopes.Transient:
                            AddService(srv.Interface, srv.Implementation, srv.Scope);
                            break;

                        case ServiceScopes.Scoped:
                            AddService(srv.Interface, srv.Implementation, srv.Scope);
                            break;
                    }   
                }

                void AddService(Type? interface_, Type implementation, ServiceScopes scope)
                {
                    if (interface_ != null)
                    {
                        switch (scope)
                        {
                            case ServiceScopes.Transient:
                                _builder.Services.AddTransient(interface_, implementation);
                                break;

                            case ServiceScopes.Singleton:
                                _builder.Services.AddSingleton(interface_, implementation);
                                break;

                            case ServiceScopes.Scoped:
                                _builder.Services.AddScoped(interface_, implementation);
                                break;
                        }
                    }
                    else
                    {
                        switch (scope)
                        {
                            case ServiceScopes.Transient:
                                _builder.Services.AddTransient(implementation);
                                break;

                            case ServiceScopes.Singleton:
                                _builder.Services.AddSingleton(implementation);
                                break;

                            case ServiceScopes.Scoped:
                                _builder.Services.AddScoped(implementation);
                                break;
                        }
                    }
                }
            }

            WebApplication app = _builder.Build();

            if (_features.Exists(Feature.SSL))
            {
                _ = app
                    .UseHttpsRedirection()
                    .UseHsts()
                    .UseAntiforgery();
            }

            _ = app
                .UseStaticFiles()
                .UseRouting()
                .UseSession()
                .UseCookiePolicy(new CookiePolicyOptions() 
                {
                    MinimumSameSitePolicy = SameSiteMode.Lax
                });

            if (_features.Exists(Feature.DefaultRoute))
            {
                DefaultRoute route = (DefaultRoute)_features.Single(ft => ft.Feature == Feature.DefaultRoute);

                _ = app
                    .MapControllerRoute(
                        name: "Default",
                        pattern: route.Path
                    );
            }
            else
            {
                _ = app
                    .UseEndpoints(opt => 
                    {
                        _ = opt.MapDefaultControllerRoute();
                    });
            }

            this.WebApp = app;
            app.Run();
        }

        public WebApplication? WebApp { get; private set; }
    }
}
