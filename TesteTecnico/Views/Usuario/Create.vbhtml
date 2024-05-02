@ModelType TesteTecnico.Usuario

@Imports TesteTecnico.Controllers

@Code
    ViewData("Title") = "Cadastro"
End Code

<h2>Cadastro</h2>

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Faça seu cadastro!</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(Function(model) model.nome, "Nome de usuário", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.nome, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.nome, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.email, "E-mail", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.email, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.email, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.senha, "Senha", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.senha, New With {.htmlAttributes = New With {.class = "form-control", .type = "password"}})
                @Html.ValidationMessageFor(Function(model) model.senha, "", New With { .class = "text-danger" })
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
             <div class="form-group">
            @Html.LabelFor(Function(model) model.admin, "Administrador", htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.admin, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.admin, "", New With {.class = "text-danger"})
            </div>
        </div>
        @code   
            End If
        End Code

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                
                @If UsuarioController.IsAdmin(Session("NomeUsuario")) Then
                    @Html.ActionLink("Voltar", "Index", Nothing, New With {.class = "btn btn-default"})
                Else
                    @Html.ActionLink("Voltar", "Index", "Home",Nothing, New With {.class = "btn btn-default"})
                End If
                <input type="submit" value="Cadastrar" class="btn btn-confirm" />
            </div>
        </div>
    </div>
            End Using

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
