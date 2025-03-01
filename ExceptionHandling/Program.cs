using ExceptionHandling;
using ExceptionHandling.Filters;
using ExceptionHandling.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Exception handling using Filter
//builder.Services.AddControllers(options =>
//{
//    //options.Filters.Add(new GlobalExceptionFilter());
//    options.Filters.Add(new CustomExceptionFilter());
//});

//Exception handling using Middleware
//builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

//Exception handling using IExceptionHandler
builder.Services.AddExceptionHandler<AppExceptionHandler>();
builder.Services.AddExceptionHandler<NotImplementedExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseExceptionHandler(_ => { });  //AppExceptionHandler

app.Run();
