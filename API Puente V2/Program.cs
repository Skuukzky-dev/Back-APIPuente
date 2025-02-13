using API_Puente_V2.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{    
    options.CustomSchemaIds(type => type.FullName);
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API GESI" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

    });


app.UseHttpsRedirection();
app.UseMiddleware<ValidationMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
