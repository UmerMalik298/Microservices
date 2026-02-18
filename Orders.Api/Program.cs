var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();


app.MapGet("/ping", () => "Orders service OK");
//app.MapGet("/orders/ping", () => "Orders service OK");

app.Run();
