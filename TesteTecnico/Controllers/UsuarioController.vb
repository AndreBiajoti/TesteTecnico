Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports TesteTecnico

Namespace Controllers
    Public Class UsuarioController
        Inherits System.Web.Mvc.Controller

        Private db As New TesteTecnicoEntities

        Public Function ObterNomeUsuario(nomeUsuario As String) As String
            ' Lógica para consultar o banco de dados e obter o nome do usuário
            ' Suponha que você esteja usando Entity Framework
            Using db As New TesteTecnicoEntities()
                Dim usuario = db.Usuario.FirstOrDefault(Function(u) u.nome = nomeUsuario)
                If usuario IsNot Nothing Then
                    Return usuario.nome
                Else
                    Return Nothing ' Ou uma string vazia, dependendo do seu caso
                End If
            End Using
        End Function

        ' GET: Usuario
        Function Index() As ActionResult
            Return View(db.Usuario.ToList())
        End Function

        ' GET: /Usuario/Login
        Function Login() As ActionResult
            Return View()
        End Function

        ' POST: /Usuario/Login
        <HttpPost>
        <ValidateAntiForgeryToken>
        Function Login(model As LoginViewModel) As ActionResult
            Dim loginBemSucedido As Boolean = VerificarCredenciais(model)
            If loginBemSucedido Then

                ' Obter o nome de usuário do banco de dados
                Dim nomeUsuario As String = ObterNomeUsuario(model.nome)

                ' Armazenar o nome do usuário na sessão
                Session("NomeUsuario") = nomeUsuario

                ' Redirecionar para a página inicial
                Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", "Nome de usuário ou senha inválidos.")
                Return View(model)
            End If
        End Function

        Private Function VerificarCredenciais(model As LoginViewModel) As Boolean
            Dim usuario = db.Usuario.FirstOrDefault(Function(u) u.nome = model.nome AndAlso u.senha = model.senha)
            If usuario IsNot Nothing Then
                ' Credenciais corretas, login bem-sucedido
                Return True
            End If
            ' Credenciais incorretas, login mal-sucedido
            Return False
        End Function

        Function Logout() As ActionResult
            ' Limpar a sessão ou fazer qualquer outra operação de logout necessária
            Session.Clear() ' Limpar toda a sessão, por exemplo

            ' Redirecionar para a página Usuario após o logout
            Return RedirectToAction("Index", "Home")
        End Function

        ' Verificar se o usuário logado é um administrador (admin = 1)
        Public Shared Function IsAdmin(nomeUsuario As String) As Boolean
            Using db As New TesteTecnicoEntities()
                Dim usuario = db.Usuario.FirstOrDefault(Function(u) u.nome = nomeUsuario)
                If usuario IsNot Nothing AndAlso usuario.admin = 1 Then
                    Return True
                End If
                Return False
            End Using
        End Function

        ' Obter o ID do usuario (através do cabeçalho)
        Public Shared Function ObterIdUsuario(nomeUsuario As String) As Integer
            Using db As New TesteTecnicoEntities()
                Dim usuario = db.Usuario.FirstOrDefault(Function(u) u.nome = nomeUsuario)
                If usuario IsNot Nothing Then
                    Return usuario.idUsuario
                Else
                    Return -1
                End If
            End Using
        End Function

        ' GET: Usuario/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        ' GET: Usuario/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Usuario/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="idUsuario,nome,email,senha,admin")> ByVal usuario As Usuario) As ActionResult
            If ModelState.IsValid Then
                db.Usuario.Add(usuario)
                db.SaveChanges()

                If Session("NomeUsuario") Is Nothing Then
                    Session("NomeUsuario") = usuario.nome
                    Return RedirectToAction("Index", "Home")
                End If

                Return RedirectToAction("Index", "Usuario")
            End If
            Return View(usuario)
        End Function

        ' GET: Usuario/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If

            ' Verificar se o usuário é um administrador
            Dim isAdmin As Boolean = UsuarioController.IsAdmin(Session("NomeUsuario"))

            ' Se o usuário não for um administrador, remover a propriedade admin
            If Not isAdmin Then
                ModelState.Remove("admin")
            End If

            Return View(usuario)
        End Function

        ' POST: Usuario/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="idUsuario,nome,email,senha,admin")> ByVal usuario As Usuario) As ActionResult
            If ModelState.IsValid Then
                db.Entry(usuario).State = EntityState.Modified
                db.SaveChanges()

                ' Verificar se o usuário é um administrador
                Dim isAdmin As Boolean = UsuarioController.IsAdmin(Session("NomeUsuario"))

                ' Verificar se o usuário é um administrador
                If isAdmin Then
                    ' Redirecionar o administrador para a página Index
                    Return RedirectToAction("Index", "Usuario")
                Else
                    usuario.admin = False
                    ' Redirecionar o usuário comum para a página Details
                    Return RedirectToAction("Details", "Usuario", New With {.id = usuario.idUsuario})
                End If
            End If
            Return View(usuario)
        End Function

        ' POST: Usuario/DeleteConfirmed/5
        <HttpPost()>
        <ActionName("DeleteConfirmed")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim usuario As Usuario = db.Usuario.Find(id)

            ' Verificar se o usuário está excluindo seu próprio cadastro
            Dim idUsuario As Integer = ObterIdUsuario(Session("NomeUsuario"))
            Dim isDeletingOwnAccount As Boolean = (id = idUsuario)

            ' Se o usuário está excluindo seu próprio cadastro, fazer logout
            If isDeletingOwnAccount Then
                ' Limpar a sessão ou fazer qualquer outra operação de logout necessária
                Session.Clear()

                db.Usuario.Remove(usuario)
                db.SaveChanges()

                Return RedirectToAction("Index", "Home")
            End If

            db.Usuario.Remove(usuario)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        ' GET: Usuario/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim usuario As Usuario = db.Usuario.Find(id)
            If IsNothing(usuario) Then
                Return HttpNotFound()
            End If
            Return View(usuario)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
