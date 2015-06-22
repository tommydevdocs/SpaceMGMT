Imports System.Data.SqlClient

Public Class Approval
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim SqlDataSource1 As New SqlDataSource()

            SqlDataSource1.ID = "SqlDataSource1"

            Me.Page.Controls.Add(SqlDataSource1)

            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("SpaceMGMTConnectionString").ConnectionString

            SqlDataSource1.SelectCommand = "SELECT username, currentlocation, newlocation FROM Move WHERE newlocation IS NOT NULL"

            GridView1.DataSource = SqlDataSource1

            GridView1.DataBind()

        End If



    End Sub

    'Public Sub Gridr()
    '    Try
    '        Dim con As New SqlConnection
    '        Dim cmd As New SqlCommand
    '        con.ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SpaceMGMT;Integrated Security=True"
    '        con.Open()
    '        cmd.Connection = con
    '        cmd.CommandText = "SELECT username, currentlocation, newlocation FROM Move WHERE newlocation IS NOT NULL"
    '        cmd.ExecuteReader()
    '    Catch ex As Exception

    '        Response.Write(ex)
    '    End Try
    'End Sub

    'Public Sub approve()
    '    Try


    '        Dim con As New SqlConnection
    '        Dim cmd As New SqlCommand


    '        cmd.CommandText = "UPDATE Move SET username = @username, currentlocation = @currentlocation, newlocation = @newlocation WHERE username = @username1"

    '        cmd.Parameters.AddWithValue("username", )
    '        cmd.Parameters.AddWithValue("currentlocation", BoundField.ThisExpression)
    '        cmd.Parameters.AddWithValue("newlocation", DBNull.Value)
    '        cmd.Parameters.AddWithValue("username1", BoundField.ThisExpression)

    '        cmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Response.Write(ex)
    '    End Try
    'End Sub

End Class