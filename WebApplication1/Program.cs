using Microsoft.AspNetCore.Authentication;
using WebApiDemo.Formatters;
using WebApplication1.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductDal,EfProductDal>();
builder.Services.AddMvc(options =>
{
    options.OutputFormatters.Add(new VcardOutputFormatter());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<AuthenticationMiddleware>();
//app.UseMvc(config =>
//{
//    config.MapRoute("DefaultRoute", "api/{controller}/{action}");
//});
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();


