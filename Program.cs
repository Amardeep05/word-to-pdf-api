using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using GemBox.Document;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddOpenApi();
// Add services to the container
builder.Services.AddControllers();  // <-- This is required
// For API versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});
//builder.Services.Configure<FormOptions>(options =>
//{
//    options.MultipartBodyLengthLimit = 104857600; // 100 MB
//});

var app = builder.Build();
// Initialize GemBox
ComponentInfo.SetLicense("FREE-LIMITED-KEY"); // use "FREE-LIMITED-KEY" for free version
app.MapControllers();
app.Run();

