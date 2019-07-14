module WebAppRoute
open Giraffe

let v0 = choose [
    GET >=> choose [
        route "/" >=> text "root"
        route "/data" >=> text "not root"
        ]
    RequestErrors.NOT_FOUND "NotFound"
    ]

let WebAppRoutes: HttpHandler = subRoute "/api" (choose [
        subRoute "/v0" (v0)
    ])