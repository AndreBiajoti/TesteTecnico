Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' Rota padrão para a página inicial
        routes.MapRoute(
            name:="Default",
            url:="",
            defaults:=New With {.controller = "Home", .action = "Index"}
        )

        ' Rota para a página de login
        routes.MapRoute(
            name:="Login",
            url:="Usuario/Login",
            defaults:=New With {.controller = "Usuario", .action = "Login"}
        )

    End Sub
End Module