using WEGGAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = new ExceptionMiddleware(app.Environment).Invoke
}
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection()
    .UseCors("AllowAllHeaders")
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.Run();
