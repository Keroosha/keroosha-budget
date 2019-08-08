module Budget.WebApp

open System
open System.IO
open Budget.DB
open Budget.WebAppQuery
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open HotChocolate
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open HotChocolate.AspNetCore

type Startup(config : IConfiguration) =
    member __.ConfigureServices (services : IServiceCollection) =
            let npgsqlConnectionString = config.GetConnectionString("default")
            let npgsqlConf = fun (opts: DbContextOptionsBuilder) ->
                opts.UseNpgsql(npgsqlConnectionString) |> ignore
            let graphQlSetup = fun(srv: IServiceProvider) ->
                SchemaBuilder.New()
                    .AddServices(srv)
                    .AddQueryType<GraphQLQuery>()
                    .Create()
            
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<BudgetDbContext>(npgsqlConf)
                .AddGraphQL(graphQlSetup) |> ignore
            services.AddGiraffe |> ignore

    member __.Configure (app : IApplicationBuilder) =
        app.UseGiraffe WebAppRoute.WebAppRoutes |> ignore
        app.UseGraphQL() |> ignore
        app.UsePlayground() |> ignore

[<EntryPoint>]
let main argv =
    let config =
        (new ConfigurationBuilder())
            .SetBasePath(Directory.)
            .AddJsonFile("./appsettings.json", false)
            .Build()
    WebHostBuilder()
        .UseKestrel()
        .UseConfiguration(config)
        .UseStartup<Startup>()
        .Build()
        .Run()
    0
