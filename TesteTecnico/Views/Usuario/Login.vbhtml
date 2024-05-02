@ModelType LoginViewModel

@Code
    ViewData("Title") = "Login"
End Code

<div class="form-horizontal" >
    <h2>Login</h2>
    @code
        Using Html.BeginForm("Login", "Usuario", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    End Code

    @Html.AntiForgeryToken()

    <div Class="form-group">
        <h4>Faça seu login!</h4>
        <hr />
        @code
            If ViewBag.LoginErrorMessage IsNot Nothing Then
        End Code        
    <div Class="alert alert-danger">
        @ViewBag.LoginErrorMessage
    </div>
        @code
            End If
        End Code 
        @Html.LabelFor(Function(model) model.nome, "Nome de usuário", New With {.class = "control-label col-md-2"})
        <div Class="col-md-10">
            @Html.TextBoxFor(Function(model) model.nome, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.nome, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div Class="form-group">
        @Html.LabelFor(Function(model) model.senha, "Senha", New With {.class = "control-label col-md-2"})
        <div Class="col-md-10">
            @Html.PasswordFor(Function(model) model.senha, New With {.class = "form-control"})
            @Html.ValidationMessageFor(Function(model) model.senha, "", New With {.class = "text-danger"})
        </div>
    </div>

    <div Class="form-group">
        <div Class="col-md-offset-2 col-md-10">
            <Button type="submit" Class="btn btn-confirm">Login</Button>
        </div>
    </div>
    @code
        End Using
    End Code
</div>