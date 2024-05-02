@ModelType TesteTecnico.Usuario

@Imports TesteTecnico.Controllers

@Code
    ViewData("Title") = "Deletar"
End Code

<h2>Deletar cadastro</h2>


<div>
    <h4>Tem certeza que quer deletar o cadastro?</h4>
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
    @code
        Using (Html.BeginForm("DeleteConfirmed", "Usuario", New With {.id = Model.idUsuario}, FormMethod.Post, New With {.class = "delete-form"}))
    End Code

        @Html.AntiForgeryToken()
        <div class="form-actions no-color">
            @Html.ActionLink("Voltar", "Index", "Usuario", New With {.id = Model.idUsuario, .class = "btn btn-default"})
            @code
                If Model.idUsuario = UsuarioController.ObterIdUsuario(Session("NomeUsuario")) Then
            End Code
                    <input type = "submit" value="Deletar" Class="btn btn-delete" onclick="return confirm('Tem certeza que deseja excluir seu próprio usuário?')" /> 
            @code
                Else
            End Code
                    <input type = "submit" value="Deletar" Class="btn btn-delete" /> 
            @code
                End If
            End Code
        
   
    @code
        End Using
    End Code
      </div>
</div>
