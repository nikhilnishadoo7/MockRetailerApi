using MockRetailerApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// ========================================
// ADD CORS
// ========================================

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

// ========================================
// USE CORS
// ========================================

app.UseCors("AllowAll");

app.UseMiddleware<ApiHeaderMiddleware>();

app.MapControllers();

app.Run();
