using AuctionApp.API.Filters;
using AuctionApp.API.Services;
using AuctionApp.API.UseCases.Offers.CreateOffer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AuthenticationUserAttributes>();
builder.Services.AddScoped<LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
