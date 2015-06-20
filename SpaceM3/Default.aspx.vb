Imports System.Data
Imports System.Data.SqlClient




Public Class _Default
    Inherits System.Web.UI.Page

    Public classSQL As msSQL = New msSQL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        MembershipUser currentUser = Membership.GetUser()



    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        'If username is false
        If CheckBox1.Checked = True Then
            TextBox1.Visible = True

        Else
            TextBox1.Visible = False
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim insertform As String = ""

        'If Page.IsValid Then
        '    'Try
        '    'classSQL.Execute_nonqueryInject(GetInsertSQLCommand())

        '    'Catch ex As Exception

        '    End Try
        'End If
    End Sub
End Class