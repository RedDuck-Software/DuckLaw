#pragma checksum "E:\studyc#v2\Duck\Client\Pages\Result.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0d62e11fc05cd61b37275a9aa6d0e0a722e664a"
// <auto-generated/>
#pragma warning disable 1591
namespace Duck.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\studyc#v2\Duck\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\studyc#v2\Duck\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Duck.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\studyc#v2\Duck\Client\_Imports.razor"
using Duck.Client.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Result")]
    public partial class Result : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Duck.Client.Shared.LoadingScreen>(0);
            __builder.AddAttribute(1, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(2, "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n    <link href=\"css/Result.css\" rel=\"stylesheet\">\r\n\r\n    ");
                __builder2.AddMarkupContent(3, @"<body><div><div class=""navbar""><a href=""#""><i class=""fa fa-fw fa-download""></i> Сохранить </a>
                <a href=""#""><i class=""fa fa-fw fa-pencil""></i>Редактировать </a>
                <a href=""#""><i class=""fa fa-fw fa-list""></i>Выделить </a></div>
            <div id=""Area""><p class=""col-form-label""> Оставить коментарий для разработчика</p>
                <textarea class=""tab-content"" name=""comment"" cols=""90"" rows=""5""></textarea>
                <input type=""submit""></div></div></body>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591