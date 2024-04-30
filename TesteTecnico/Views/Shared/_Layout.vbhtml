@Imports TesteTecnico.Controllers
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Manga Tecnologia</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Manga", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>

            <div class="navbar-collapse collapse">
                @Code
                    If Session("NomeUsuario") IsNot Nothing Then
                        Dim isAdmin As Boolean = UsuarioController.IsAdmin(Session("NomeUsuario"))
                        Dim idUsuario As Integer = UsuarioController.ObterIdUsuario(Session("NomeUsuario"))

                End Code
              
                <p class="navbar-text navbar-right">
                    Bem-vindo, @Session("NomeUsuario")
                    @Code
                        If isAdmin Then
                    End Code
                    @Html.ActionLink("Area administrativa", "Index", "Usuario", Nothing, New With {.class = "navbar-btn btn btn-default"})
                    @Code
                        Else
                    End Code
                    @Html.ActionLink("Seu cadastro", "Details", "Usuario", New With {.id = idUsuario}, New With {.class = "navbar-btn btn btn-default"})
                    @Code
                        End If
                    End Code
                   @Html.ActionLink("Sair", "Logout", "Usuario", Nothing, New With {.class = "navbar-btn btn btn-default"})
                </p>
                @Code
    Else
                End Code
                
                    @Html.ActionLink("Cadastre-se", "Create", "Usuario", New With {.area = ""}, New With {.class = "navbar-text navbar-right"})
                    @Html.ActionLink("Login", "Login", "Usuario", New With {.area = ""}, New With {.class = "navbar-text navbar-right"})
                               
               @Code
                   End If
                    End Code
</div>
        </div>
    </div>
    <div Class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; TESTE TÉCNICO - Manga Tecnologia</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
