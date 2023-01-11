var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    var path = context.Request.Path;
    if(path == "/info")
    {
        context.Response.WriteAsync("ASP.NET testing app\nThanks for visiting");
    }
    else if(path == "/")
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/index.html");
        var query = context.Request.Query;
        if (query["pass"] == "xcvZ3412")
        {
        context.Response.WriteAsync($"Greetings {query["name"]}");
        }
    }
    else
    {
        
        
    }
});
app.Run();
