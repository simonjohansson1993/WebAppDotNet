#pragma checksum "C:\Users\simon.simon\source\repos\myFirstWebApplication\myFirstWebApplication\Views\Shared\_CrimeLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7ccff92224f25e581c56da3534e9db56ea3d513"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CrimeLayout), @"mvc.1.0.view", @"/Views/Shared/_CrimeLayout.cshtml")]
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
#nullable restore
#line 1 "C:\Users\simon.simon\source\repos\myFirstWebApplication\myFirstWebApplication\Views\_ViewImports.cshtml"
using environment_crime.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7ccff92224f25e581c56da3534e9db56ea3d513", @"/Views/Shared/_CrimeLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"481eb8c50b82a82ddbf3e44c9f9c99a96364188a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CrimeLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\simon.simon\source\repos\myFirstWebApplication\myFirstWebApplication\Views\Shared\_CrimeLayout.cshtml"
  
  Layout = "_MainLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c7ccff92224f25e581c56da3534e9db56ea3d5133218", async() => {
                WriteLiteral("\r\n    <div id=\"content\">\r\n\r\n      <h2>Detaljer för ärendet</h2>\r\n");
#nullable restore
#line 10 "C:\Users\simon.simon\source\repos\myFirstWebApplication\myFirstWebApplication\Views\Shared\_CrimeLayout.cshtml"
        
        string controller = (string)Html.ViewContext.RouteData.Values["controller"];
        if (controller == "Coordinator") {

#line default
#line hidden
#nullable disable
                WriteLiteral("          <p class=\"info\">Du är inloggad som samordnare </p>\r\n");
#nullable restore
#line 14 "C:\Users\simon.simon\source\repos\myFirstWebApplication\myFirstWebApplication\Views\Shared\_CrimeLayout.cshtml"
        }
        else if (controller == "Investigator") {

#line default
#line hidden
#nullable disable
                WriteLiteral("          <p class=\"info\">Du är inloggad som handläggare</p>\r\n");
#nullable restore
#line 17 "C:\Users\simon.simon\source\repos\myFirstWebApplication\myFirstWebApplication\Views\Shared\_CrimeLayout.cshtml"

        }
        else {

#line default
#line hidden
#nullable disable
                WriteLiteral("          <p class=\"info\">Du är inloggad som avdelningschef</p>\r\n");
#nullable restore
#line 21 "C:\Users\simon.simon\source\repos\myFirstWebApplication\myFirstWebApplication\Views\Shared\_CrimeLayout.cshtml"
        }
      

#line default
#line hidden
#nullable disable
                WriteLiteral(@"     
      <!--


  <h3>Ärende: 2020-45-0201</h3>
  <section id=""leftColumn"">
    <h3>Anmälan</h3>
    <p>
      <span class=""label"">Typ av brott: </span><br />
      Nedskräpning
    </p>
    <p>
      <span class=""label"">Brottsplats: </span><br />
      Skogslunden vid Jensens gård
    </p>
    <p>
      <span class=""label"">Brottsdatum: </span><br />
      2020-04-24
    </p>
    <p>
      <span class=""label"">Anmälare: </span><br />
      Maja Färjedal
    </p>
    <p>
      <span class=""label"">Telefon: </span><br />
      432-554 55 22
    </p>
    <p>
      <span class=""label"">Observationer:</span><br />
      Jag upptäckte soporna på en promenad den 24 april
    </p>
  </section>

  <section id=""rightColumn"">
    <h3>Utredning</h3>
    <p>
      <span class=""label"">Status:</span><br />
      Pågående
    </p>
    <p>
      <span class=""label"">Ansvarig avdelning: </span><br />
      Tekniska avloppshanteringen
    </p>
    <p>
      <span class=""label"">Handlägg");
                WriteLiteral(@"are: </span><br />
      Ada Bengtsson
    </p>
    <p>
      <span class=""label"">Provtagning: </span><br />
      Provtagning.pdf
    </p>
    <p>
      <span class=""label"">Ytterligare information: </span><br />
      Bland soporna hittades ett brev adresserat till Gösta Olsson
    </p>
    <p>
      <span class=""label"">Händelser: </span><br />
      Brev skickat till Gösta Olsson om soporna och anmälan som är gjord till polisen 2020-05-20
    </p>
    <p>
      <span class=""label"">Bilder: </span><br />
      <img src=""../images/imagetest.jpg"" alt=""klicka på bilden"" />
    </p>
  </section>
      //-->
    </div><!-- End Content -->

      <div>
        ");
#nullable restore
#line 91 "C:\Users\simon.simon\source\repos\myFirstWebApplication\myFirstWebApplication\Views\Shared\_CrimeLayout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n      </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
