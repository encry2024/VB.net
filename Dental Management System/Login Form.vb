Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography

Public Class loginForm

    Dim dbComm As New DbCommands

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Animations.fade_in(Me)
        usernameTb.Focus()
        With dbComm
            ' .GetDataFromStoredProcedure("@chkAdminTbl").Rows

            ' End If
        End With
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Animations.fade_out(Me)
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        If loginBtn.Text = "Register" Then
            dbComm.AddParameter("@adminUsername", adminUsername.Text, SqlDbType.VarChar)
            dbComm.AddParameter("@adminPassword", Encrypt(adminPassTb.Text), SqlDbType.VarChar)
            dbComm.ExecuteStoredProcedure("insertAdmin")

            MsgBox("Successful Registration.")

            If dbComm.Success = True Then
                Do While accntInfoPanel.Location.X < 454
                    accntInfoPanel.Location = New Point(accntInfoPanel.Location.X + 1, accntInfoPanel.Location.Y)
                    Threading.Thread.Sleep(1)
                Loop

                Do While Panel3.Location.X < 4
                    Panel3.Location = New Point(Panel3.Location.X + 1, Panel3.Location.Y)
                    Threading.Thread.Sleep(1)
                Loop
            ElseIf dbComm.Success = False Then
                lblMessage.Visible = True
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "Registration Failed."
            End If
        End If

        If loginBtn.Text = "&Login" Then
            dbComm.AddParameter("@username", usernameTb.Text, SqlDbType.VarChar)
            dbComm.AddParameter("@password", passwordTb.Text, SqlDbType.VarChar)
            dbComm.GetDataStoredProcedure("checkAccount")

            usernameTb.Clear()
            passwordTb.Clear()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Do While Panel3.Location.X > -500
            Panel3.Location = New Point(Panel3.Location.X - 1, Panel3.Location.Y)
            Threading.Thread.Sleep(1)
        Loop

        Do While accntInfoPanel.Location.X > 4
            accntInfoPanel.Location = New Point(accntInfoPanel.Location.X - 1, accntInfoPanel.Location.Y)
            Threading.Thread.Sleep(1)

            loginBtn.Text = "Register"
        Loop
    End Sub

    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function
End Class
