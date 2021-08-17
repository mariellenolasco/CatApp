using CatUI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CatData.Entities;
using CatData;
// See https://aka.ms/new-console-template for more information
var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

//setting up my db connections
string connectionString = configuration.GetConnectionString("CatDB");
//we're building the dbcontext using the constructor that takes in options, we're setting the connection
//string outside the context def'n
DbContextOptions<CatDBContext> options = new DbContextOptionsBuilder<CatDBContext>()
.UseSqlServer(connectionString)
.Options;
//passing the options we just built
var context = new CatDBContext(options);

IMenu menu = new MainMenu(new Repo(context));
menu.Start();
