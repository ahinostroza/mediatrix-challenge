using SB.TechnicalChallenge.Presentation.Extensions;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureApplicationBuilder();

var app = builder
    .Build()
    .ConfigureApplication();

await app.RunAsync();

