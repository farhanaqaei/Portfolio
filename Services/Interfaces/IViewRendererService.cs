namespace Portfolio2.Services.Interfaces;

public interface IViewRendererService
{
    Task<string> RenderToStringAsync(string viewName, object model);
}
