using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("gatewayApi", builde =>
    {
        builde.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("oscelot.json",optional:false,reloadOnChange:true);
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGet("/", () => "Hello World!");

app.UseCors("gatewayApi");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseOcelot();
app.Run();
