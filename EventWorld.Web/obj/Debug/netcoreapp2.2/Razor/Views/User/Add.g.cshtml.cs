#pragma checksum "D:\Licenta\EventWorld.Web\Views\User\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c9f1c3467926de3e9a6cfd383de87a6e5c9768f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Add), @"mvc.1.0.view", @"/Views/User/Add.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/User/Add.cshtml", typeof(AspNetCore.Views_User_Add))]
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
#line 1 "D:\Licenta\EventWorld.Web\Views\_ViewImports.cshtml"
using EventWorld.Web;

#line default
#line hidden
#line 2 "D:\Licenta\EventWorld.Web\Views\_ViewImports.cshtml"
using EventWorld.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c9f1c3467926de3e9a6cfd383de87a6e5c9768f", @"/Views/User/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe9900f652c2791b78813c5e9545e1f2d2d548bf", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery-validation/dist/jquery.validate.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("addUserForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal form-bordered"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Licenta\EventWorld.Web\Views\User\Add.cshtml"
  
    ViewData["Title"] = "Add user";

#line default
#line hidden
            BeginContext(46, 59, true);
            WriteLiteral("\r\n<header class=\"page-header\">\r\n    <h2>Add User</h2>\r\n    ");
            EndContext();
            BeginContext(105, 51, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c9f1c3467926de3e9a6cfd383de87a6e5c9768f5443", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(156, 8, true);
            WriteLiteral("\r\n\r\n    ");
            EndContext();
            BeginContext(164, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c9f1c3467926de3e9a6cfd383de87a6e5c9768f6628", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(235, 71, true);
            WriteLiteral("\r\n</header>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        ");
            EndContext();
            BeginContext(306, 2723, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c9f1c3467926de3e9a6cfd383de87a6e5c9768f7889", async() => {
                BeginContext(381, 2641, true);
                WriteLiteral(@"
            <section class=""panel"">
                <header class=""panel-heading"">

                    <h2 class=""panel-title"">Add user</h2>
                </header>
                <div class=""panel-body"">

                    <div class=""form-group"">
                        <label class=""col-md-1 control-label"" for=""inputDefault"">First name<span class=""required"">*</span></label>
                        <div class=""col-md-3"">
                            <input type=""text"" class=""form-control"" id=""firstName"" required>
                        </div>
                    </div>

                    <div class=""form-group"">
                        <label class=""col-md-1 control-label"" for=""inputDefault"">Last name<span class=""required"">*</span></label>
                        <div class=""col-md-3"">
                            <input type=""text"" class=""form-control"" id=""lastName"" required>
                        </div>
                    </div>

                    <div class=""form-group""");
                WriteLiteral(@">
                        <label class=""col-md-1 control-label"" for=""inputDefault"">Email<span class=""required"">*</span></label>
                        <div class=""col-md-3"">
                            <input type=""email"" class=""form-control"" id=""email"" required>
                        </div>
                    </div>

                    <div class=""form-group"">
                        <label class=""col-md-1 control-label"" for=""inputDefault"">Password<span class=""required"">*</span></label>
                        <div class=""col-md-3"">
                            <input type=""password"" class=""form-control"" id=""password"" required>
                        </div>
                    </div>

                    <div class=""form-group"">
                        <label class=""col-md-1 control-label"" for=""inputDefault"">Repeat Password<span class=""required"">*</span></label>
                        <div class=""col-md-3"">
                            <input type=""password"" class=""form-control"" id=""rep");
                WriteLiteral(@"eatPassword"" required>
                        </div>
                    </div>

                </div>
                <footer class=""panel-footer"">
                    <div class=""row"">
                        <div class=""col-sm-9 col-sm-offset-3"">
                            <button type=""submit"" class=""btn btn-primary"" id=""saveUser"">Submit</button>
                            <button type=""button"" class=""btn btn-default"" id=""cancelButton"">Cancel</button>
                        </div>
                    </div>
                </footer>
            </section>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3029, 1220, true);
            WriteLiteral(@"
    </div>
</div>

<script type=""text/javascript"">
    debugger;
    function SaveUser() {
        debugger;
        console.log()
        var registerModel = {
            FirstName: $(""#firstName"").val(),
            LastName: $(""#lastName"").val(),
            Email: $(""#email"").val(),
            Password: $(""#password"").val(),
            ConfirmPassword: $(""#repeatPassword"").val(),
        };

        $.ajax({
            type: ""Post"",
            url: ""/User/Register"",
            data: registerModel,
            success: function () {
                location.href = ""/Home/Index"";
            },
            error: function (data) {
                if (data.status == 200) {
                    location.href = data.responseText;
                }
                if (data.status == 550) {
                    alert(data.responseText);
                }
            }
        });
    }


    $('#addUserForm').submit(function (event) {
        debugger;
        event.pre");
            WriteLiteral("ventDefault();\r\n        SaveUser();\r\n        return false;\r\n    });\r\n\r\n    $(document).on(\"click\", \"#cancelButton\", function () {\r\n        location.href = \"/admin/Users/Index\";\r\n    });\r\n</script>");
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