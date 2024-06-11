namespace Blog.ConfigureAspNetCore.Components.Features
{
    public sealed class SSL : FeatureBase
    {
        private readonly int _port = 443;

        public SSL() : base(Feature.SSL) 
        { }

        public SSL(int port) : base(Feature.SSL)
        {
            _port = port;
        }

        public int Port => _port;
    }
}
