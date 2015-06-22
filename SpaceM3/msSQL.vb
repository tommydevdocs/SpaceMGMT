Imports System.Data.SqlClient

Public Class msSQL

    Public conn As String = ConfigurationManager.ConnectionStrings("SpaceMGMTConnectionString").ConnectionString

    Public Function GetData(ByVal sql As String) As DataTable
        Try
            Using connection As New SqlConnection(conn)
                Using command As New SqlCommand(sql, connection)
                    connection.Open()

                    Using reader As SqlDataReader = command.ExecuteReader()
                        Dim dt As New DataTable
                        dt.Load(reader)
                        reader.Close()
                        connection.Close()
                        Return dt
                    End Using

                End Using


            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataSet(ByVal sql As String, ByVal isSp As Boolean) As DataSet
        Try
            Using connection As New SqlConnection(conn)
                connection.Open()
                Dim mySqlCommand As SqlCommand = connection.CreateCommand
                mySqlCommand.CommandText = sql
                If isSp Then
                    mySqlCommand.CommandType = CommandType.StoredProcedure
                End If

                Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter
                mySqlDataAdapter.SelectCommand = mySqlCommand
                Dim ds As New DataSet
                mySqlDataAdapter.Fill(ds)
                connection.Close()
                Return ds
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetScalar(ByVal sql As String) As String
        Try
            Using connection As New SqlConnection(conn)
                Using command As New SqlCommand(sql, connection)
                    connection.Open()
                    Dim result As String = Convert.ToString(command.ExecuteScalar)
                    connection.Close()
                    Return result

                End Using
            End Using

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub Execute_nonquery(ByVal sql As String)
        Try
            Using connection As New SqlConnection(conn)
                Using command As New SqlCommand(sql, connection)
                    command.Connection.Open()
                    command.ExecuteNonQuery()
                    command.Connection.Close()
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub EXECUTE_PROCEDURE(ByVal THESQL As String)
        Try
            Using connection As New SqlConnection(conn)
                Using command As New SqlCommand(THESQL, connection)
                    connection.Open()
                    command.ExecuteNonQuery()
                    connection.Close()

                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Execute_nonqueryInject(ByVal command As SqlCommand)
        Try
            Using connection As New SqlConnection(conn)
                command.Connection = connection
                command.Connection.Open()
                command.ExecuteNonQuery()
                command.Connection.Close()

            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Sub Execute_nonqueryInject()
        Throw New NotImplementedException
    End Sub

End Class
