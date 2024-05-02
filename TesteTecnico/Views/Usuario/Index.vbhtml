@ModelType IEnumerable(Of TesteTecnico.Usuario)
@Code
    ViewData("Title") = "Administrador"
End Code

<h2>Lista de cadastros</h2>

<p>
    @Html.ActionLink("Cadastrar usuário", "Create", Nothing, New With {.class = "btn btn-default"})
</p>
<table class="table">
    <tr>
        <th>
            Nome
        </th>
        <th>
            E-mail
        </th>
        <th>
            Senha
        </th>
        <th>
            Administrador
        </th>
        <th>
            Ações
        </th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.nome)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.email)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.senha)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.admin)
            </td>
            <td>
                <button type="button" onclick="window.location='@Url.Action("Edit", New With {.id = item.idUsuario})'" class="btn btn-default">Editar</button>
                <button type="button" onclick="window.location='@Url.Action("Details", New With {.id = item.idUsuario})'" class="btn btn-default">Detalhes</button>
                <button type="button" onclick="window.location='@Url.Action("Delete", New With {.id = item.idUsuario})'" class="btn btn-default">Deletar</button>
            </td>
        </tr>
    Next

</table>