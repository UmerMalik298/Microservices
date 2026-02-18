var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();



var productsBaseUrl = builder.Configuration["Services:Products"];

app.MapGet("/details", async () =>
{
    using var http = new HttpClient();
    var productResponse = await http.GetStringAsync($"{productsBaseUrl}/ping");

    return new
    {
        OrderId = 123,
        ProductServiceResponse = productResponse
    };
});


app.MapGet("/ping", () => "Orders service OK");
//app.MapGet("/orders/ping", () => "Orders service OK");

app.Run();
