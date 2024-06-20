using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Portfolio2.Models;

namespace Portfolio2.Shared;

public partial class MainLayout
{
    private bool collapseNavMenu = true;
    private string menuClass = "";
    private string siteHeaderClass = "mobile-menu-hide";
    private Person? person;
    private List<string> routables = new List<string> { "aboutme", "resume", "portfolio", "contact" };

    private ToastParameters _toastParameters;

    protected override void OnInitialized()
    {
        // load routable pages dynamically
        //   var components = Assembly.GetExecutingAssembly()
        //  .ExportedTypes
        //.Where(t => t.IsSubclassOf(typeof(ComponentBase))).ToList();

        //   routables = components.Where(c =>
        //       c.GetCustomAttributes(inherit: true).OfType<RouteAttribute>
        //       ().Count() > 0).Select(x => x.Name.ToLower()).ToList();

        person = PortfolioService.GetPersonalData();

        _toastParameters = new ToastParameters();
        _toastParameters.Add(nameof(ToastMessage.Status), "info");
        _toastParameters.Add(nameof(ToastMessage.Message), "Sorry, No CV found!");
    }

    protected void ChangePageOnArrowNavs(string direction)
    {
        var currentPage = NavigationManager.Uri.ToString().Replace(NavigationManager.BaseUri.ToString(), "");
        var currentPageIndex = routables.FindIndex(x => x.Contains(currentPage));

        if (direction == "n")
        {
            if (currentPageIndex + 1 < routables.Count)
                NavigationManager.NavigateTo(routables[currentPageIndex + 1].ToLower(), false);
            else
                NavigationManager.NavigateTo("/", false);
            }
        else
        {
            if (currentPageIndex - 1 >= 0)
                NavigationManager.NavigateTo(routables[currentPageIndex - 1].ToLower(), false);
        }
    }

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;

        if (!collapseNavMenu)
        {
            menuClass = "open";
            siteHeaderClass = "animate";
        }
        else
        {
            menuClass = "";
            siteHeaderClass = "mobile-menu-hide";
        }
    }

    private void CloseNavMenuOnClickOutside()
    {
        collapseNavMenu = true;
        menuClass = "";
        siteHeaderClass = "mobile-menu-hide";
    }

    private async Task DownloadCV()
    {
        // to download cv
        //var fileName = "fa.pdf";
        //var filePath = Path.Combine(Env.WebRootPath, "assets", fileName);
        //byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
        //var fileStream = new MemoryStream(fileBytes);
        //using var streamRef = new DotNetStreamReference(stream: fileStream);
        //await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);

        CloseNavMenuOnClickOutside();
        ToastService.ShowToast<ToastMessage>(_toastParameters);
    }
}
