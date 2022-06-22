﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using testcrud3.Data;
using testcrud3.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<testcrud3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("testcrud3Context") ?? throw new InvalidOperationException("Connection string 'testcrud3Context' not found.")));
builder.Services.AddScoped<ITestDBRepository, TestDBRepository>();
builder.Services.AddDbContext<testcrud3.Models.ScaffoldContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("testcrud3Context") ?? throw new InvalidOperationException("Connection string 'testcrud3Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Run();
