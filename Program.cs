using Demo.Resolvers;
using Microsoft.EntityFrameworkCore;
using SchemaFirst.Data;
using SchemaFirst.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<PersonDbContext>(options =>
    // Edit accordingly
    options.UseSqlServer("Server=localhost;Database=FilteringDemo;User=sa;Password=somepassword"))
    .AddAutoMapper(config =>
    {
        config.AddProfile<PersonProfile>();
    })
    .AddScoped<PersonRepository>()
    .AddGraphQLServer()
    .ModifyRequestOptions(opt =>
    {
        opt.IncludeExceptionDetails = true;
    })
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddQueryType<Query>();

var app = builder.Build();

// Make sure we have an schema and some data.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<PersonDbContext>();

    context.Database.Migrate();

    using (var transaction = context.Database.BeginTransaction())
    {
        if (context.Persons.SingleOrDefault(x => x.Id == 1) is null)
            context.Persons.Add(new Person(1, "George", "Washington"));
        if (context.Persons.SingleOrDefault(x => x.Id == 2) is null)
            context.Persons.Add(new Person(2, "Jose", "de San Martin"));
        if (context.Persons.SingleOrDefault(x => x.Id == 3) is null)
            context.Persons.Add(new Person(3, "Napoleon", "Bonaparte"));
        context.SaveChanges();
        transaction.Commit();
    }
}

app.MapGraphQL();

app.Run();
