#pragma checksum "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5492377c9dd978190ee51a88194dc8e191733251"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(EduHome.Views.Course.Views_Course_CourseDetail), @"mvc.1.0.view", @"/Views/Course/CourseDetail.cshtml")]
namespace EduHome.Views.Course
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/_ViewImports.cshtml"
using EduHome.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5492377c9dd978190ee51a88194dc8e191733251", @"/Views/Course/CourseDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ffb09777ee681668584f258ce0982d224e8ddb9", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_CourseDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CourseDetailVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/course/courses-details.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("courses-details"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/blog/blog-img.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("blog"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""banner-area-wrapper"">
    <div class=""banner-area text-center"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xs-12"">
                    <div class=""banner-content-wrapper"">
                        <div class=""banner-content"">
                            <h2>courses details</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""courses-details-area blog-area pt-150 pb-140"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-8"">
                <div class=""courses-details"">
                    <div class=""courses-details-img"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5492377c9dd978190ee51a88194dc8e1917332516803", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n                    <div class=\"course-details-content\">\n                        <h2>");
#nullable restore
#line 28 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                       Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\n                        <p>");
#nullable restore
#line 29 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                      Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                        <div class=\"course-details-left\">\n                            <div class=\"single-course-left\">\n                                <h3>about course</h3>\n                                <p>");
#nullable restore
#line 33 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                              Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                            </div>\n                            <div class=\"single-course-left\">\n                                <h3>how to apply</h3>\n                                <p>");
#nullable restore
#line 37 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                              Write(Model.ApplicationRule);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                            </div>\n                            <div class=\"single-course-left\">\n                                <h3>certification</h3>\n                                <p>");
#nullable restore
#line 41 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                              Write(Model.Certification);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>
                        <div class=""course-details-right"">
                            <h3>COURSE FEATURES</h3>
                            <ul>
                                <li>starts <span>");
#nullable restore
#line 47 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                            Write(Model.StartDate?.ToString("dd MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\n                                <li>duration <span>");
#nullable restore
#line 48 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                              Write(Model.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\n                                <li>class duration <span>");
#nullable restore
#line 49 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                                    Write(Model.ClassDuration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\n                                <li>skill level <span>");
#nullable restore
#line 50 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                                 Write(Model.SkillLevel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\n                                <li>language <span>");
#nullable restore
#line 51 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                              Write(Model.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\n                                <li>students <span>");
#nullable restore
#line 52 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                              Write(Model.StudentCapacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\n                                <li>assesments <span>");
#nullable restore
#line 53 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                                Write(Model.Assesment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\n                            </ul>\n                            <h3 class=\"red\">course fee $");
#nullable restore
#line 55 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                                   Write(Model.Fee);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-md-4"">
                <div class=""blog-sidebar right"">
                    <div class=""single-blog-widget mb-50"">
                        <h3>search</h3>
                        <div class=""blog-search"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5492377c9dd978190ee51a88194dc8e19173325113070", async() => {
                WriteLiteral(@"
                                <input type=""search"" placeholder=""Search..."" name=""search"" />
                                <button type=""submit"">
                                    <span><i class=""fa fa-search""></i></span>
                                </button>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                        </div>\n                    </div>\n                    <div class=\"single-blog-widget mb-50\">\n                        <h3>categories</h3>\n                        <ul>\n");
#nullable restore
#line 76 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                             foreach (var category in Model.Categories)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li><a>");
#nullable restore
#line 78 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                                  Write(category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 79 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\n                    </div>\n                    <div class=\"single-blog-widget mb-50\">\n                        <div class=\"single-blog-banner\">\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5492377c9dd978190ee51a88194dc8e19173325115944", async() => {
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5492377c9dd978190ee51a88194dc8e19173325116160", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                            <h2>best<br> eductaion<br> theme</h2>\n                        </div>\n                    </div>\n\n                    ");
#nullable restore
#line 89 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
               Write(await Component.InvokeAsync("LatestBlog"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
#nullable restore
#line 97 "/Users/niyazibabayev/Projects/EduHome/EduHome/Views/Course/CourseDetail.cshtml"
Write(await Component.InvokeAsync("Newsteller"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CourseDetailVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
