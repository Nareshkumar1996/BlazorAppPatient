#pragma checksum "E:\Healthware\Healthware\Client\Pages\PatientList.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "410c9a78d031b0543c7a0861cc23b3a0c42e819d"
// <auto-generated/>
#pragma warning disable 1591
namespace Healthware.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\Healthware\Healthware\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Healthware\Healthware\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\Healthware\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\Healthware\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\Healthware\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\Healthware\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\Healthware\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\Healthware\Healthware\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\Healthware\Healthware\Client\_Imports.razor"
using Healthware.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\Healthware\Healthware\Client\_Imports.razor"
using Healthware.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
using Healthware.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/patientList")]
    public partial class PatientList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h2>Patient Details</h2>\r\n");
            __builder.AddMarkupContent(1, "<p><a href=\"/addPatient\">Create New Patient</a></p>");
#nullable restore
#line 11 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
 if (patientList == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(2, "<p>Loading...</p>");
#nullable restore
#line 14 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(3, "table");
            __builder.AddAttribute(4, "class", "table");
            __builder.AddMarkupContent(5, "<thead><tr><th>Name</th>\r\n            <th>Speciality</th>\r\n            <th>Location</th></tr></thead>\r\n        ");
            __builder.OpenElement(6, "tbody");
#nullable restore
#line 26 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
         foreach (var emp in patientList)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(7, "tr");
            __builder.OpenElement(8, "td");
            __builder.AddContent(9, 
#nullable restore
#line 29 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
                     emp.PatientName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n                ");
            __builder.OpenElement(11, "td");
            __builder.AddContent(12, 
#nullable restore
#line 30 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
                     emp.Speciality

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n                ");
            __builder.OpenElement(14, "td");
            __builder.AddContent(15, 
#nullable restore
#line 31 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
                     emp.Location

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n                ");
            __builder.OpenElement(17, "td");
            __builder.OpenElement(18, "a");
            __builder.AddAttribute(19, "href", "editPatient/" + (
#nullable restore
#line 33 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
                                          emp.PatientId

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(20, "Edit");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                    ");
            __builder.OpenElement(22, "a");
            __builder.AddAttribute(23, "href", "deletePatient/" + (
#nullable restore
#line 34 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
                                            emp.PatientId

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(24, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 37 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 40 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "E:\Healthware\Healthware\Client\Pages\PatientList.razor"
 
    Patient[] patientList;
    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected async Task LoadData()
    {
        patientList = await Http.GetFromJsonAsync<Patient[]>("/api/Patient");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
