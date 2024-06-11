namespace Blog.ConfigureAspNetCore.Components.Features
{
    public sealed class DefaultRoute : FeatureBase
    {
        private readonly string _controller;
        private readonly string _action;

        public DefaultRoute(string controller, string action) : base(Feature.DefaultRoute)
        {
            _controller = controller;
            _action = action;
        }

        public string Path => $"{{controller={_controller}}}/{{action={_action}}}/{{id?}}";
    }
}
