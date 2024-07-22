using Server_SingalR.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.UseRouting();
app.MapGet("/", () => "Hello World!");

app.UseEndpoints(endpoints => endpoints.MapHub<NotificationHub>("/notification"));

app.Run();
