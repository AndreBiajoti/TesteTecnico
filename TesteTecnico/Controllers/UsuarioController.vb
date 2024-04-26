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
                Return RedirectToAction("Index")
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
                Return RedirectToAction("Index")
            End If
            Return View(usuario)
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

        ' POST: Usuario/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim usuario As Usuario = db.Usuario.Find(id)
            db.Usuario.Remove(usuario)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
