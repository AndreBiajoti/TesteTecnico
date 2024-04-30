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

        ' Rota para a página de Logout do usuario
        routes.MapRoute(
            name:="Logout",
            url:="Usuario/logout",
            defaults:=New With {.controller = "Usuario", .action = "Logout"}
        )

        ' Rota para visualizar o usuario comum
        routes.MapRoute(
            name:="Details",
            url:="Usuario/Details/{id}",
            defaults:=New With {.controller = "Usuario", .action = "Details", .id = UrlParameter.Optional}
        )

        ' Rota para a página index do usuario
        routes.MapRoute(
            name:="Index",
            url:="Usuario",
            defaults:=New With {.controller = "Usuario", .action = "index"}
        )

        ' Rota para a página de cadastro do usuario
        routes.MapRoute(
            name:="Cadastro",
            url:="Usuario/cadastro",
            defaults:=New With {.controller = "Usuario", .action = "Create"}
        )

        ' Rota para editar o usuario
        routes.MapRoute(
            name:="Edit",
            url:="Usuario/edit",
            defaults:=New With {.controller = "Usuario", .action = "Edit"}
        )

        ' Rota para confirmar a exclusão de um usuário
        routes.MapRoute(
            name:="DeleteConfirmed",
            url:="Usuario/DeleteConfirmed/{id}",
            defaults:=New With {.controller = "Usuario", .action = "DeleteConfirmed", .id = UrlParameter.Optional}
        )

        ' Rota para a deletar usuario
        routes.MapRoute(
            name:="Delete",
            url:="Usuario/delete/{id}",
            defaults:=New With {.controller = "Usuario", .action = "Delete", .id = UrlParameter.Optional}
        )
    End Sub
End Module