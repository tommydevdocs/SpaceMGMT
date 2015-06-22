Imports System.Data
Imports System.Data.SqlClient




Public Class _Default
    Inherits System.Web.UI.Page

    Public classSQL As msSQL = New msSQL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


        TextBox1.Text = user.Identity.Name.ToString



    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.Visible = True
        Else
            TextBox1.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        insert()
    End Sub

   

    'Public Sub update()

    '    Dim con As New SqlConnection
    '    Dim cmd As New SqlCommand
    '    con.ConnectionString = "SpaceMGMTConnectionString"
    '    con.Open()
    '    cmd.Connection = con

    '    cmd.CommandText = "(UPDATE table (username, currentlocation, newlocation)" & _
    '        " VALUES (WHERE @username =)" & TextBox1.Text)"


    '    cmd.Parameters.AddWithValue("@username", TextBox1.Text)
    '    cmd.Parameters.AddWithValue("@currentlocation", ListBox1.SelectedValue)
    '    cmd.Parameters.AddWithValue("@newlocation", ListBox2.SelectedValue)

    '    cmd.ExecuteNonQuery()
    'End Sub

    'New Request
    Public Sub insert()
        Try

        
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SpaceMGMT;Integrated Security=True"
        con.Open()
        cmd.Connection = con

            cmd.CommandText = "INSERT INTO Move (username, currentlocation, newlocation) VALUES (@username, @currentlocation, @newlocation)"

            cmd.Parameters.AddWithValue("username", TextBox1.Text)
            cmd.Parameters.AddWithValue("currentlocation", ListBox1.SelectedValue)
            cmd.Parameters.AddWithValue("newlocation", ListBox2.SelectedValue)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Response.Write(ex)
        End Try
    End Sub


    'Approve
    Public Sub approve()
        Try


            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            con.ConnectionString = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SpaceMGMT;Integrated Security=True"
            con.Open()
            cmd.Connection = con


            cmd.CommandText = "UPDATE Move SET username = @username, currentlocation = @currentlocation, newlocation = @newlocation WHERE username = @username1"
                          
            cmd.Parameters.AddWithValue("username", TextBox1.Text)
            cmd.Parameters.AddWithValue("currentlocation", ListBox2.SelectedValue)
            cmd.Parameters.AddWithValue("newlocation", DBNull.Value)
            cmd.Parameters.AddWithValue("username1", TextBox1.Text)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Response.Write(ex)
        End Try
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        approve()
    End Sub
End Class

