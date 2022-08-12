
using MicroserviceWebApi;
using MicroserviceWebApi.SkubanaAccess.Abstracts;
using MicroserviceWebApi.SkubanaAccess.Configuration;
using SkubanaAccess;
using SkubanaAccess.Services.Products;

var MyAllowSpecificOrigins = "MyCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("https://demo.skubana.com", "https://api.demo.skubana.com",
//                                              "https://app.skubana.com", "https://api.skubana.com")
//                                              .AllowAnyHeader()
//                                              .AllowAnyMethod();
//                      });
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);
app.UseRouting();
app.UseAuthorization();
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();



app.Run();
