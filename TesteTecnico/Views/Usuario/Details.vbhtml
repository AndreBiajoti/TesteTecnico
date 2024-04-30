@ModelType TesteTecnico.Usuario

@Imports TesteTecnico.Controllers

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Usuario</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.nome)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.nome)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.senha)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.senha)
        </dd>
        @code
            If UsuarioController.IsAdmin(Session("NomeUsuario")) Then
        End Code
        <dt>
            @Html.DisplayNameFor(Function(model) model.admin)
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
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.idUsuario}) |

    @If Session("NomeUsuario") IsNot Nothing AndAlso UsuarioController.IsAdmin(Session("NomeUsuario")) Then
        @Html.ActionLink("Voltar", "Index", "Usuario")
    End If



   @Using (Html.BeginForm("DeleteConfirmed", "Usuario", FormMethod.Post, New With {.class = "delete-form"}))
    @Html.AntiForgeryToken()
    @<button type="submit" class="delete-link" onclick="return confirm('Tem certeza que deseja excluir seu próprio usuário?')">Delete</button>
        @Html.HiddenFor(Function(model) model.idUsuario)
   End Using
</p>
