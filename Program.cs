using Microsoft.AspNetCore.Hosting;
using Slate;
using Slate.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure services and application startup in Startup.cs
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the application pipeline in Startup.cs
var env = app.Environment;
var startup = new Startup(builder.Configuration);
startup.Configure(app, env);

app.Run();
