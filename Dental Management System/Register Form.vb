Public Class Register_Form

    Dim validation As New Validation
    Dim dbComm As New DbCommands
    Dim errCounter As Integer = 5
    Public fname As String
    Public lname As String
    Public uname As String
    Public pass As String


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If errCounter = 0 Then
            btnSave.Enabled = True
            With dbComm
                .AddParameter("@firstname", tbFirstname.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@lastname", tbLastname.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@username", tbUsername.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@password", validation.Encrypt(tbPassword.Text.Trim), SqlDbType.VarChar)
                .AddParameter("@status", "Assistant", SqlDbType.VarChar)
                .ExecuteStoredProcedure("sp_registerUser")
            End With

            Me.Close()
        Else
            MsgBox("Please fill up all the blank fields first.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Title:="Incomplete Fields")
            msgError1.Show()
            msgError2.Show()
            msgError3.Show()
            msgError4.Show()
            msgError5.Show()
        End If
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Animations.fade_out(Me)
        Me.Close()
        mainForm.Show()
    End Sub

#Region "Validates: Firstname, and Lastname Input"
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbFirstname.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
            And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
            Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'Allowed space
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        ' Allowed backspace
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbLastname.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 65) _
    Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 90) _
    And (Microsoft.VisualBasic.Asc(e.KeyChar) < 97) _
    Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 122) Then
            'Allowed space
            If (Microsoft.VisualBasic.Asc(e.KeyChar) <> 32) Then
                e.Handled = True
            End If
        End If
        ' Allowed backspace
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub
#End Region

#Region "Validates: Input Fields"
    Private Sub tbFirstname_LostFocus(sender As Object, e As EventArgs) Handles tbFirstname.LostFocus
        If tbFirstname.Text = "" Then
            msgError1.Text = "Please enter your Firstname."
            msgError1.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub tbFirstname_GotFocus(sender As Object, e As EventArgs) Handles tbFirstname.GotFocus
        If tbFirstname.Text = "" Then
            msgError1.Visible = False
            errCounter -= 1
        End If
    End Sub


    Private Sub tbLastname_LostFocus(sender As Object, e As EventArgs) Handles tbLastname.LostFocus
        If tbLastname.Text = "" Then
            msgError2.Text = "Please enter your Lastname."
            msgError2.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub tbLastname_GotFocus(sender As Object, e As EventArgs) Handles tbLastname.GotFocus
        If tbLastname.Text = "" Then
            msgError2.Visible = False
            errCounter -= 1
        End If
    End Sub


    Private Sub tbUsername_LostFocus(sender As Object, e As EventArgs) Handles tbUsername.LostFocus
        If tbUsername.Text = "" Then
            msgError3.Text = "Please enter your Username."
            msgError3.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub tbUsername_GotFocus(sender As Object, e As EventArgs) Handles tbUsername.GotFocus
        If tbUsername.Text = "" Then
            msgError3.Visible = False
            errCounter -= 1
        End If
    End Sub


    Private Sub tbPassword_LostFocus(sender As Object, e As EventArgs) Handles tbPassword.LostFocus
        If tbPassword.Text = "" Then
            msgError4.Text = "Please enter your Password."
            msgError4.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub tbPassword_GotFocus(sender As Object, e As EventArgs) Handles tbPassword.GotFocus
        If tbPassword.Text = "" Then
            msgError4.Visible = False
            errCounter -= 1
        End If
    End Sub


    Private Sub tbConPassword_LostFocus(sender As Object, e As EventArgs) Handles tbConPassword.LostFocus
        If tbConPassword.Text = "" Then
            msgError5.Text = "Please enter your Confirm Password."
            msgError5.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub tbConPassword_GotFocus(sender As Object, e As EventArgs) Handles tbConPassword.GotFocus
        If tbConPassword.Text = "" Then
            msgError5.Visible = False
            errCounter -= 1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(errCounter)
    End Sub
#End Region

#Region "Validates: Password, Confirm Password"


    Private Sub passwordTF_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPassword.TextChanged, tbConPassword.TextChanged
        If (tbPassword.Text = tbConPassword.Text) Then
            msgError5.Text = "Password match"
            msgError4.Text = "Password match"
            msgError4.BackColor = Color.DarkGreen
            msgError5.BackColor = Color.DarkGreen
            msgError4.Visible = True
            btnSave.Enabled = True
        ElseIf (tbPassword.Text <> tbConPassword.Text) Or (tbPassword.TextLength = 0) Then
            msgError5.Text = "Password do not match"
            msgError4.Text = "Password do not match"
            msgError4.BackColor = Color.Red
            msgError4.Visible = True
            msgError5.BackColor = Color.Red
            msgError5.Visible = True

            btnSave.Enabled = False
        End If

        If (tbPassword.TextLength > 5) Then
            tbConPassword.Enabled = True
            msgError4.Text = ""
            If (tbPassword.Text = tbConPassword.Text) Then
                msgError5.Text = "Password match"
                msgError4.Text = "Password match"
                msgError4.BackColor = Color.DarkGreen
                msgError5.BackColor = Color.DarkGreen
            ElseIf (tbPassword.Text <> tbConPassword.Text) Or (tbPassword.TextLength = 0) Then
                msgError5.Text = "Password do not match"
                msgError4.Text = "Password do not match"
                msgError4.BackColor = Color.Red
                msgError5.BackColor = Color.Red
            End If
        End If

        If (tbPassword.TextLength < 6) Then
            msgError4.Text = "Password should be 6-20 characters. Character entered: " & tbPassword.Text.Count & ""
            msgError4.BackColor = Color.Red
            tbConPassword.Enabled = False
        End If

        If (tbPassword.TextLength < 6 Or tbPassword.TextLength < 6 And tbConPassword.Text = "") Then
            msgError4.Text = "Password should be 6-20 characters. Entered: " & tbPassword.Text.Count & ""
            msgError4.BackColor = Color.Red
            msgError5.Text = ""
            tbConPassword.Enabled = False
        End If

        If (tbPassword.TextLength & tbConPassword.TextLength = 0) Then
            btnSave.Enabled = False
            msgError4.Text = "Please enter your password."
            msgError5.Text = ""
            msgError4.BackColor = Color.Red
        End If

        If (tbConPassword.TextLength = 0) Then
            msgError5.Text = "Please enter your Confirm Password"
            msgError5.BackColor = Color.Red
        End If
    End Sub
#End Region
End Class