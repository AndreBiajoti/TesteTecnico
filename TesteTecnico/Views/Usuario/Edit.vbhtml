@ModelType TesteTecnico.Usuario

@Imports TesteTecnico.Controllers

@Code
    ViewData("Title") = "Editar"
End Code

<h2>Editar</h2>

@Using (Html.BeginForm("Edit", "Usuario", New With {.id = Model.idUsuario}, FormMethod.Post, New With {.class = "form-horizontal"}))
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>Altere os dados do cadastro!</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.idUsuario)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.nome, "Nome de usuário", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.nome, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.nome, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.email, "Email", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.email, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.email, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.senha, "Senha", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.senha, New With {.htmlAttributes = New With {.class = "form-control", .type = "password"}})
                @Html.ValidationMessageFor(Function(model) model.senha, "", New With {.class = "text-danger"})
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.confirmarSenha, "Confirmar senha", htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.EditorFor(Function(model) model.confirmarSenha, New With {.htmlAttributes = New With {.class = "form-control", .type = "password"}})
                 @Html.ValidationMessageFor(Function(model) model.confirmarSenha, "", New With {.class = "text-danger"})
             </div>
         </div>

    @code
        If UsuarioController.IsAdmin(Session("NomeUsuario")) Then
    End Code
        <div Class="form-group">
            @Html.LabelFor(Function(model) model.admin, "Administrador", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div Class="col-md-10">
                @Html.EditorFor(Function(model) model.admin, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.admin, "", New With {.class = "text-danger"})
            </div>
        </div>
    @code   
        End If
    End Code
    
            
    <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Editar" class="btn btn-default" onclick="return confirm('Tem certeza que deseja editar?')" />
                @code
                    If UsuarioController.IsAdmin(Session("NomeUsuario")) Then
                End Code
                @Html.ActionLink("Voltar", "Index", Nothing, New With {.class = "btn btn-default"})
                @code
                    Else
                End Code
                @Html.ActionLink("Voltar", "Details", Nothing, New With {.id = Model.idUsuario, .class = "btn btn-default"})
                @code
                    End If
                End Code  </div>
        </div>
    </div>      
                    End Using



@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
