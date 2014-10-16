Imports System.Data.SqlClient
Imports System.Text
Imports ComponentOwl.BetterListView

Public Class DbCommands


    Const DATA_SOURCE As String = "Server = MABEL-PC\SQLEXPRESS"
    Const DB_NAME As String = "; Database = DentalDB"

    Private _connectionString As String
    Private _prmList As List(Of SqlParameter)
    Private _success As Boolean
    Private _message As String

    Public Sub New()
        Dim buildConString As New StringBuilder
        'buildConString.Append("Server = JAKE-PC")
        buildConString.Append(DATA_SOURCE)
        'buildConString.Append("; Database = Registration")
        buildConString.Append(DB_NAME)
        ''buildConString.Append("; user id=")
        ''buildConString.Append(DB_USER)
        ''buildConString.Append("; password=")
        ''buildConString.Append(USER_PWD)
        buildConString.Append("; trusted_connection=yes")

        _connectionString = buildConString.ToString()
        _prmList = New List(Of SqlParameter)
        _prmList.Clear()

    End Sub

    Public ReadOnly Property Success() As Boolean
        Get
            Return _success
        End Get
    End Property

    Public ReadOnly Property Message() As String
        Get
            Return _message
        End Get
    End Property

    Public Sub AddParameter(ByVal prmClmnName As String, ByVal prmValue As String, ByVal prmType As SqlDbType, Optional ByVal prmSize As Short = 0)
        Dim prm As New SqlParameter

        prm.ParameterName = prmClmnName
        prm.Value = prmValue
        prm.Direction = ParameterDirection.Input
        prm.Size = prmSize

        If prmType = SqlDbType.Char Or prmType = SqlDbType.VarChar Then
            prm.Size = prmSize
        End If

        _prmList.Add(prm)
    End Sub

    Public Sub ExecuteStoredProcedure(ByVal spName As String)

        Dim cmd As New SqlCommand
        Dim con As New SqlConnection(_connectionString)

        Try
            _success = True
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = spName
            cmd.Connection = con
            If _prmList.Count > 0 Then
                For Each prm As SqlParameter In _prmList
                    cmd.Parameters.Add(prm)
                Next
            End If

            cmd.ExecuteNonQuery()

            _message = "Successfully Registered."
        Catch ex As Exception
            _success = False
            _message = ex.Message
        Finally
            con = Nothing
            cmd = Nothing
            _prmList.Clear()
        End Try

    End Sub

    Public Function GetDataFromStoredProcedure(ByVal spName As String) As DataTable
        Dim ds As New SqlDataAdapter
        Dim dt As New DataTable
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection(_connectionString)

        Try
            _success = True
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = spName
            cmd.Connection = con
            If _prmList.Count > 0 Then
                For Each prm As SqlParameter In _prmList
                    cmd.Parameters.Add(prm)
                Next
            End If
            ds.SelectCommand = cmd
            ds.Fill(dt)

        Catch ex As Exception
            _success = False
            _message = ex.Message
            MsgBox(_message)
        Finally
            con.Dispose()
            cmd.Dispose()
            ds.Dispose()
            ds = Nothing
            con = Nothing
            cmd = Nothing
            _prmList.Clear()
        End Try

        Return dt
    End Function

    Public Sub ExecuteStoredProcedureWithReturnValue(ByVal spName As String)
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection(_connectionString)
        Dim sqlRdr As SqlDataReader
        Try
            _success = True
            con.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = spName
            cmd.Connection = con
            If _prmList.Count > 0 Then
                For Each prm As SqlParameter In _prmList
                    cmd.Parameters.Add(prm)
                Next
            End If

            sqlRdr = cmd.ExecuteReader

        Catch ex As Exception
            _success = False
            _message = ex.Message
            MsgBox(ex.Message)
        Finally
            _prmList.Clear()
            con = Nothing
            cmd = Nothing
        End Try
    End Sub

    Public Sub GetDataStoredProcedure(ByVal spName As String)
        Dim cmd As New SqlCommand
        Dim conn As New SqlConnection(_connectionString)
        Dim sqlRdr As SqlDataReader

        Try
            _success = True
            conn.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = spName
            cmd.Connection = conn
            If _prmList.Count > 0 Then
                For Each prm As SqlParameter In _prmList
                    cmd.Parameters.Add(prm)
                Next
            End If

            sqlRdr = cmd.ExecuteReader

            If (sqlRdr.Read() = True) Then
                Animations.fade_out(loginForm)
                loginForm.Hide()

                Animations.fade_in(mainForm)
                mainForm.Show()
            Else
                loginForm.lblMessage.Visible = True
                loginForm.lblMessage.ForeColor = Color.Red
                loginForm.lblMessage.Text = "Login Unsuccessful"
            End If

        Catch ex As Exception
            _success = False
            _message = ex.Message
            MsgBox(ex.Message)
        Finally
            conn.Dispose()
            cmd.Dispose()
            conn = Nothing
            cmd = Nothing
            _prmList.Clear()
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
