/*
    Configure ASP.NET Core - https://blog.sltech.no
 */

namespace Blog.ConfigureAspNetCore.Components.Features
{
    public sealed class Service : FeatureBase
    {
        private readonly Type _interface;
        private readonly Type _implementation;
        private readonly ServiceScope _scope = ServiceScope.Transient;

        public Service(Type implementation, ServiceScope scope = ServiceScope.Transient) : base(Feature.Service)
        {
            _interface = null;
            _implementation = implementation;
            _scope = scope;
        }

        public Service(Type interface_, Type implementation, ServiceScope scope = ServiceScope.Transient) : base(Feature.Service) 
        {
            _interface = interface_;
            _implementation = implementation;
            _scope = scope;
        }

        public Type Interface => _interface;
        public Type Implementation => _implementation;
        public ServiceScope Scope => _scope;
    }
}
