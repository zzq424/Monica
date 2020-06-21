﻿namespace Raven.AspectFlare.DynamicProxy
{
    public class ProxyConfigurationFactory : IProxyConfigurationFactory
    {
        public IProxyConfiguration BuildConfiguration()
        {
            return new ProxyConfiguration();
        }
    }
}
