@ModelType LoginViewModel

@Html.BeginForm("Login", "Usuario", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
    @Html.AntiForgeryToken()

<div Class="form-group">
        @Html.LabelFor(Function(model) model.Nome, New With {.class = "control-label col-md-2"})
        <div Class="col-md-10">
        @Html.TextBoxFor(Function(model) model.Nome, New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.Nome)
        </div>
    </div>

    <div Class="form-group">
        @Html.LabelFor(Function(model) model.Senha, New With {.class = "control-label col-md-2"})
        <div Class="col-md-10">
        @Html.PasswordFor(Function(model) model.Senha, New With {.class = "form-control"})
        @Html.ValidationMessageFor(Function(model) model.Senha)
        </div>
    </div>

    <div Class="form-group">
        <div Class="col-md-offset-2 col-md-10">
            <Button type = "submit" Class="btn btn-default">Login</button>
        </div>
    </div>

