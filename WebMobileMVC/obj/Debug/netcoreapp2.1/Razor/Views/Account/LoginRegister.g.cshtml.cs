#pragma checksum "D:\Project\TMDT\CamPhoneShop\WebMobileMVC\Views\Account\LoginRegister.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6d671db0eabd05661594b357ca8f26e2a1ad785"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_LoginRegister), @"mvc.1.0.view", @"/Views/Account/LoginRegister.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/LoginRegister.cshtml", typeof(AspNetCore.Views_Account_LoginRegister))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Project\TMDT\CamPhoneShop\WebMobileMVC\Views\_ViewImports.cshtml"
using WebMobileMVC;

#line default
#line hidden
#line 2 "D:\Project\TMDT\CamPhoneShop\WebMobileMVC\Views\_ViewImports.cshtml"
using WebMobileMVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6d671db0eabd05661594b357ca8f26e2a1ad785", @"/Views/Account/LoginRegister.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5017ced2044ad011c8781c1b1e0d43fefebf6a45", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_LoginRegister : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("login-box"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Project\TMDT\CamPhoneShop\WebMobileMVC\Views\Account\LoginRegister.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(34, 636, true);
            WriteLiteral(@"
<!-- Start Page Title -->
<div class=""page-title"">
    <div class=""container"">
        <div class=""column"">
            <h1>Đăng nhập & Đăng ký</h1>
        </div>
        <div class=""column"">
            <ul class=""breadcrumbs"">
                <li><a href=""index-1.html"">Trang chủ</a></li>
                <li class=""separator"">&nbsp;</li>
                <li>Đăng nhập & Đăng ký</li>
            </ul>
        </div>
    </div>
</div>
<!-- End Page Title -->
<!-- Start Account Access -->
<div class=""container padding-top-1x padding-bottom-3x"">
    <div class=""row"">
        <div class=""col-md-6"">
            ");
            EndContext();
            BeginContext(670, 1794, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6ea334f6ae146209d28599aca30dd18", async() => {
                BeginContext(708, 1749, true);
                WriteLiteral(@"
                <h4 class=""margin-bottom-1x"">Đăng nhập bằng tài khoản:</h4>
                <div class=""row margin-bottom-1x"">
                    <div class=""col-xl-6 col-md-6 col-sm-6""><a class=""btn btn-sm btn-block facebook-btn"" href=""#""><i class=""socicon-facebook""></i>&nbsp;Facebook</a></div>
                    <div class=""col-xl-6 col-md-6 col-sm-6""><a class=""btn btn-sm btn-block google-btn"" href=""#""><i class=""socicon-googleplus""></i>&nbsp;Google+</a></div>
                </div>
                <h4 class=""margin-bottom-1x"">Hoặc sử dụng tài khoản:</h4>
                <div class=""form-group input-group"">
                    <input class=""form-control"" type=""email"" placeholder=""Nhập E-Mail"" required><span class=""input-group-addon""><i class=""icon-mail""></i></span>
                </div>
                <div class=""form-group input-group"">
                    <input class=""form-control"" type=""password"" placeholder=""Nhập mật khẩu"" required><span class=""input-group-addon""><i class=""icon-lock""></i");
                WriteLiteral(@"></span>
                </div>
                <div class=""d-flex flex-wrap justify-content-between padding-bottom-1x"">
                    <div class=""custom-control custom-checkbox"">
                        <input class=""custom-control-input"" type=""checkbox"" id=""remember_me"" checked>
                        <label class=""custom-control-label"" for=""remember_me"">Ghi nhớ tài khoản</label>
                    </div><a class=""navi-link"" href=""account-password-recovery.html"">Quên mật khẩu?</a>
                </div>
                <div class=""text-center text-sm-right"">
                    <button class=""btn btn-primary margin-bottom-none"" type=""submit"">Đăng nhập</button>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2464, 289, true);
            WriteLiteral(@"
        </div>
        <div class=""col-md-6"">
            <div class=""padding-top-3x hidden-md-up""></div>
            <h3 class=""margin-bottom-1x padding-top-1x"">Chưa có tài khoản? Đăng ký tại đây</h3>
            <p>Hãy điền đầy đủ các thông tin sau để đăng ký ...</p>
            ");
            EndContext();
            BeginContext(2753, 2020, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ada5165df66849eb85c5c43ada037426", async() => {
                BeginContext(2785, 1981, true);
                WriteLiteral(@"
                <div class=""col-sm-6"">
                    <div class=""form-group"">
                        <label for=""reg-fn"">Họ</label>
                        <input class=""form-control"" type=""text"" id=""reg-fn"" required>
                    </div>
                </div>
                <div class=""col-sm-6"">
                    <div class=""form-group"">
                        <label for=""reg-ln"">Tên</label>
                        <input class=""form-control"" type=""text"" id=""reg-ln"" required>
                    </div>
                </div>
                <div class=""col-sm-6"">
                    <div class=""form-group"">
                        <label for=""reg-email"">Địa chỉ E-Mail</label>
                        <input class=""form-control"" type=""email"" id=""reg-email"" required>
                    </div>
                </div>
                <div class=""col-sm-6"">
                    <div class=""form-group"">
                        <label for=""reg-phone"">Số điện thoại</label>
   ");
                WriteLiteral(@"                     <input class=""form-control"" type=""text"" id=""reg-phone"" required>
                    </div>
                </div>
                <div class=""col-sm-6"">
                    <div class=""form-group"">
                        <label for=""reg-pass"">Mật khẩu</label>
                        <input class=""form-control"" type=""password"" id=""reg-pass"" required>
                    </div>
                </div>
                <div class=""col-sm-6"">
                    <div class=""form-group"">
                        <label for=""reg-pass-confirm"">Nhập lại mật khẩu</label>
                        <input class=""form-control"" type=""password"" id=""reg-pass-confirm"" required>
                    </div>
                </div>
                <div class=""col-12 text-center text-sm-right"">
                    <button class=""btn btn-primary margin-bottom-none"" type=""submit"">Đăng ký</button>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4773, 65, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<!-- End Account Access -->");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
