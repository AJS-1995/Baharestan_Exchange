﻿using _0_Framework.Application.Auth;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost
{
    public class PermissionTagHelper : TagHelper
    {
        public int Permission { get; set; }
        private readonly IAuthHelper _authHelper;
        public PermissionTagHelper(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }
    }
}