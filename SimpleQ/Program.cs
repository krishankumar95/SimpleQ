using SimpleQ.Interface.Publisher;

using SimpleQ.SimpleQ.Interface.Htttp;
using SimpleQ.Broker.Slim.DataAccess.DAL;
using SimpleQ.Broker.Common;
using SimpleQ.Broker.Slim;
using System.Reflection;
using MediatR;
using SimpleQ.Interface.Relayer;
using SimpleQ.Interface.Relayer.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SimpleQ.Interface.Publisher.IPublisher, SlimBrokerPublisher>();
builder.Services.AddSingleton<IRelayer, SlimBrokerHttpRelayer>();
builder.Services.AddSingleton<IMessageRepository, MessageRepository>();
builder.Services.AddSingleton<IBroker, SlimBroker>();

builder.Services.AddMediatR(typeof(SlimBrokerHttpRelayer));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
