@ModelType IEnumerable(Of TesteTecnico.Usuario)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.nome)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.senha)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.admin)
        </th>
        <th></th>
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
                @Html.ActionLink("Edit", "Edit", New With {.id = item.idUsuario}) |
                @Html.ActionLink("Detalhes", "Details", New With {.id = item.idUsuario}) |
                @Html.ActionLink("Deletar", "Delete", New With {.id = item.idUsuario})
            </td>
        </tr>
    Next

</table>