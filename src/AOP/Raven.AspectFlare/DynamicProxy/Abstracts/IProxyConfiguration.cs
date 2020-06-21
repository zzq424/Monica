﻿using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Raven.AspectFlare.DynamicProxy
{
    public interface IProxyConfiguration
    {
        AppDomain ProxyDomain { get; }
        ModuleBuilder ProxyModuleBuilder { get; }
        AssemblyName ProxyAssemblyName { get; }
        AssemblyBuilder ProxyAssemblyBuilder { get; }
    }
}
