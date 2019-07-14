// Learn more about F# at http://fsharp.org

open System.IO
open Budget.DB
open Npgsql.EntityFrameworkCore.PostgreSQL
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration

let webApp = choose [
    route "/api/test" >=> text "test"
]

type Startup(config : IConfiguration) =
    member __.ConfigureServices (services : IServiceCollection) =
            let NpgsqlConnectionString = config.GetConnectionString("default")
            let NpgsqlConf = fun (opts: DbContextOptionsBuilder) -> opts.UseNpgsql(NpgsqlConnectionString) |> ignore
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<BudgetDbContext>(NpgsqlConf) |> ignore
            services.AddGiraffe() |> ignore

    member __.Configure (app : IApplicationBuilder) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseGiraffe webApp

[<EntryPoint>]
let main argv =
    let config =
        (new ConfigurationBuilder())
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build()
    WebHostBuilder()
        .UseKestrel()
        .UseConfiguration(config)
        .UseStartup<Startup>()
        .Build()
        .Run()
    0
