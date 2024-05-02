@Imports TesteTecnico.Controllers
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" href="~/Image/Icone/favicon.ico" type="image/x-icon">
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
                <a class="navbar-brand" href="@Url.Action("Index", "Home", New With {.area = ""})" >
                    <img src="~/Image/Icone/manga.png" width="30" height="30" alt="Logo" /> Manga Tecnologia
                </a>
            </div>

            <div class="navbar-collapse collapse">
                @Code
                    If Session("NomeUsuario") IsNot Nothing Then
                        Dim isAdmin As Boolean = UsuarioController.IsAdmin(Session("NomeUsuario"))
                        Dim idUsuario As Integer = UsuarioController.ObterIdUsuario(Session("NomeUsuario"))

                End Code


                <p class="navbar-text navbar-right">

                        Olá, @Session("NomeUsuario")  

                    <span style="margin-left: 20px;"></span>
                    
                    @Code
                        If isAdmin Then
                    End Code
                    @Html.ActionLink("Area administrativa", "Index", "Usuario", Nothing, New With {.class = "btn btn-default"})
                    @Code
                        Else
                    End Code
                    @Html.ActionLink("Seu cadastro", "Details", "Usuario", New With {.id = idUsuario}, New With {.class = "btn btn-default"})
                    @Code
                        End If
                    End Code
                   @Html.ActionLink("Sair", "Logout", "Usuario", Nothing, New With {.class = "btn btn-default"})
                </p>
                @Code
                    Else
                End Code
                
                    @Html.ActionLink("Cadastre-se ", "Create", "Usuario", New With {.area = ""}, New With {.class = "navbar-text navbar-right", .style = "color: #fcead1"}) 
                    @Html.ActionLink(" Login", "Login", "Usuario", New With {.area = ""}, New With {.class = "navbar-text navbar-right", .style = "color: #fcead1"})
                               
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
            <p>&copy; André Biajoti - Manga Tecnologia</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>

<style>
    
    .navbar{
        background-color: #0f1f0b;
        color:#ffe979;           
    }

    .navbar-right{
        color:#ffffd7!important;
    }

    .navbar-brand{
        color:#ffffd7!important;
    }

    body{
        background-color:#d2f9d2;
    }

    .jumbotron{
        background-color:#bbffa7;
    }

    .btn-default{
        background-color: #f9d495; 
        border-color: #f9d495;
    }
    .btn-default:hover {
        background-color:#f9c561;
        border-color:#0f1f0b;
    }

    .btn-confirm{
        background-color: #97df83; 
        border-color: #69975c;
    }
    .btn-confirm:hover {
        background-color:#73be62;
        border-color:#5a884e;
    }

    .btn-delete{
        background-color: #fe9469; 
        border-color: #fb452b;
    }
    .btn-delete:hover {
        background-color:#fd6c4a;
        border-color:#fa1e0b;
    }

    .form-control{
        background-color:#e1fbe1!important; 
    }

    .navbar-right{
        color: #ffe979;
    }

    .spaced-button{
        margin-right: 5px;
    }
   
</style>