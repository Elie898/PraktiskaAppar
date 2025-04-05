var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
    
}
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();

app.MapGet("/hello", () => $"Enviroment is {app.Environment.EnvironmentName}"); ;

app.Run();
WriteLine("Detta exekveras efter ");
