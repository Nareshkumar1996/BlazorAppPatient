// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Healthware.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Healthware.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Healthware.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\BlazorAppPatient\Healthware\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\BlazorAppPatient\Healthware\Client\Pages\PatientList.razor"
using Healthware.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\BlazorAppPatient\Healthware\Client\Pages\PatientList.razor"
using System.Net.Http.Headers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\BlazorAppPatient\Healthware\Client\Pages\PatientList.razor"
using Healthware.Client.Extensions;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/patientList")]
    public partial class PatientList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "E:\BlazorAppPatient\Healthware\Client\Pages\PatientList.razor"
 
    Patient[] patientList;
    protected override async Task OnInitializedAsync()
    {
        await LoadData();
    }

    protected async Task LoadData()
    {
        patientList = await Http.GetJsonAsync<Patient[]>("/api/Patient", new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJuYXJlc2gua0B6dWNpc3lzdGVtcy5jb20iLCJlbWFpbCI6Im5hcmVzaC5rQHp1Y2lzeXN0ZW1zLmNvbSIsImp0aSI6IjAyNTE3ZDY2LTkxZmYtNDJlZS04NTcyLTA5YWRkOWEzYzg3NyIsImV4cCI6MTYyMDExMTU5NSwiaXNzIjoibG9jYWxob3N0IiwiYXVkIjoibG9jYWxob3N0In0.RnUrbu8j-UFojNo3ySAM8_VCx9x5fVW62Is_hXTAs80"));
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591
