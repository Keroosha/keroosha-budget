module Budget.WebApp

open System.IO
open Budget.DB
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Configuration
open FSharp.Control.Tasks.V2.ContextInsensitive

type Startup(config : IConfiguration) =
    member __.ConfigureServices (services : IServiceCollection) =
            let NpgsqlConnectionString = config.GetConnectionString("default")
            let NpgsqlConf = fun (opts: DbContextOptionsBuilder) -> opts.UseNpgsql(NpgsqlConnectionString) |> ignore
            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<BudgetDbContext>(NpgsqlConf) |> ignore
            services.AddGiraffe() |> ignore

    member __.Configure (app : IApplicationBuilder) =
        app.UseGiraffe WebAppRoute.WebAppRoutes

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
