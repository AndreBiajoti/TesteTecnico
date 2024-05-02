@ModelType TesteTecnico.Usuario

@Imports TesteTecnico.Controllers

@Code
    ViewData("Title") = "Detalhes"
End Code

<h2>Detalhes</h2>

<div>
    <h4>Verifique os detalhes do cadastro!</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            Nome de usuário
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.nome)
        </dd>

        <dt>
            E-mail
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.email)
        </dd>

        <dt>
            Senha
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.senha)
        </dd>
        @code
            If UsuarioController.IsAdmin(Session("NomeUsuario")) Then
        End Code
        <dt>
            Administrador
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.admin)
        </dd>
        @code
            End If
        End Code
    </dl>
</div>
<p>
    @Using (Html.BeginForm("DeleteConfirmed", "Usuario", FormMethod.Post, New With {.class = "delete-form"}))
    @Html.ActionLink("Editar", "Edit", "Usuario", New With {.id = Model.idUsuario, .class = "btn btn-default spaced-button"}) 

    @If Session("NomeUsuario") IsNot Nothing AndAlso UsuarioController.IsAdmin(Session("NomeUsuario")) Then
        @Html.ActionLink("Voltar", "Index", "Usuario", New With {.id = Model.idUsuario, .class = "btn btn-default"}) 
    Else
    @Html.AntiForgeryToken()
    @<button type="submit" class="btn btn-delete" onclick="return confirm('Tem certeza que deseja excluir seu próprio usuário?')">Deletar</button>
        @Html.HiddenFor(Function(model) model.idUsuario)
    End If
    End Using
</p>
