﻿using Microsoft.AspNetCore.Authorization;

using System;

namespace Monica.Authorization.Abstraction.Attributes
{
    /// <summary>
    /// 限制登录用户访问
    /// </summary>
    public class LoginAttribute : AuthorizeAttribute
    {
        public LoginAttribute()
        {
            Policy = "MonicaPermission";
        }
    }
}