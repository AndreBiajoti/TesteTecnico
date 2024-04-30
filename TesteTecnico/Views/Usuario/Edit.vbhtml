@ModelType TesteTecnico.Usuario

@Imports TesteTecnico.Controllers

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Usuario</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        @Html.HiddenFor(Function(model) model.idUsuario)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.nome, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.nome, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.nome, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.email, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.email, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.email, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.senha, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.senha, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.senha, "", New With { .class = "text-danger" })
            </div>
        </div>

    @code
        If UsuarioController.IsAdmin(Session("NomeUsuario")) Then
    End Code
        <div Class="form-group">
            @Html.LabelFor(Function(model) model.admin, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div Class="col-md-10">
                @Html.EditorFor(Function(model) model.admin, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.admin, "", New With { .class = "text-danger" })
            </div>
        </div>
    @code   
        End If
    End Code
    
            
    <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>      End Using

<div>
    @code
        If UsuarioController.IsAdmin(Session("NomeUsuario")) Then
    End Code
    @Html.ActionLink("Back to List", "Index")
    @code
        Else
    End Code
    @Html.ActionLink("Back to List", "Details", New With {.id = Model.idUsuario})
    @code
        End If
    End Code
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
