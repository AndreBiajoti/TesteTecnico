@ModelType TesteTecnico.Usuario

@Imports TesteTecnico.Controllers

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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

        <dt>
            @Html.DisplayNameFor(Function(model) model.admin)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.admin)
        </dd>

    </dl>
    @Using (Html.BeginForm("DeleteConfirmed", "Usuario", New With {.id = Model.idUsuario}, FormMethod.Post, New With {.class = "delete-form"}))
        @Html.AntiForgeryToken()
        @<div class="form-actions no-color">
             @code
                 If Model.idUsuario = UsuarioController.ObterIdUsuario(Session("NomeUsuario")) Then
             End Code
                    <input type = "submit" value="Delete" Class="btn btn-default" onclick="return confirm('Tem certeza que deseja excluir seu próprio usuário?')" /> |
            @code
                Else
            End Code
            <input type = "submit" value="Delete" Class="btn btn-default" /> |
            @code
                End If
            End Code
        
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
