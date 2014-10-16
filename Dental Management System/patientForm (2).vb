Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.IO.Ports

Public Class patientForm__2_

    Dim dbComm As New DbCommands
    Dim strItem As String
    Public patient_ID As Integer
    Dim errCounter As Integer = 6

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dobPicker.ValueChanged
        Dim Age As Double = Math.Floor(DateDiff(DateInterval.Month, dobPicker.Value, System.DateTime.Now) / 12)
        With TextBox9
            .Text = Age
        End With
        With TextBox9
            .Text = Age
        End With

        If (TextBox9.Text < 5 Or TextBox9.Text > 60) Then
            validationStatusLbl.ForeColor = Color.Red
            validationStatusLbl.Text = "Invalid Age."
            validationStatusLbl.Visible = True
            saveBtn.Enabled = False
        Else
            validationStatusLbl.ForeColor = Color.Lime
            validationStatusLbl.Text = "Valid Age."
            validationStatusLbl.Visible = True
            saveBtn.Enabled = True
        End If
    End Sub

    Private Sub addPatientRecordBtn_Click(sender As Object, e As EventArgs) Handles addPatientRecordBtn.Click

        Label1.Select()
        With Panel3
            .Enabled = True
            .AutoScroll = True
        End With

        Animations.changeForeColor(Label1, "Patient Information")
        saveBtn.Visible = True
        saveBtn.Text = "Save Patient Record"
        clearBtn.Visible = True
        clearBtn.Text = "Clear Entries"
        cancelBtn.Visible = True
        cancelBtn.Text = "Cancel Add"

        For Each cmbCollection As Control In Panel3.Controls
            With cmbCollection
                .Enabled = True
                .Visible = True
                validationStatusLbl.Visible = False

                If TypeOf cmbCollection Is TextBox Then
                    .Text = ""
                End If

                If TypeOf cmbCollection Is ComboBox Then
                    .Text = Nothing
                End If
            End With
        Next
    End Sub



    Private Sub Patient_Form_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Animations.fade_in(Me)
        Me.Show()
        Panel5.Focus()

        populateControl.populateButtonWithEvent()
        patientFormPanel3Ctrl()
        TextBox9.Enabled = True
    End Sub

    Private Sub ToolStripComboBox1_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        ListView1.Focus()
        ListView1.Items.Add(ToolStripComboBox1.Text).SubItems.Add(populateControl.tCount)
    End Sub

    Private Sub editPatientInformationBtn_Click(sender As Object, e As EventArgs) Handles editPatientInformationBtn.Click
        Label12.Visible = False
        Label32.Visible = False
        Label37.Visible = False

        Animations.changeForeColor(Label1, "Edit Patient Information")
        saveBtn.Visible = True
        saveBtn.Text = "Update Information"
        clearBtn.Visible = True
        clearBtn.Text = "Clear"
        cancelBtn.Visible = True
        cancelBtn.Text = "Cancel Editing"

        Validations.enableTB()

        For Each cmbCollection As Control In Panel3.Controls
            With cmbCollection
                .Enabled = True
                .Visible = True
                validationStatusLbl.Visible = False
            End With
        Next
        Patient_List.titleLabel.Text = "Patient List"
        Patient_List.Show()


    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click

        If saveBtn.Text = "Save Patient Record" Then

            If errCounter = 0 Then
                Validations.saveBtnEvent()
                With dbComm
                    .AddParameter("@patientFname", firstnameTb.Text.Trim, SqlDbType.VarChar)
                    .AddParameter("@patientIname", miTb.Text.Trim, SqlDbType.VarChar)
                    .AddParameter("@patientLname", lastnameTb.Text.Trim, SqlDbType.VarChar)
                    .AddParameter("@patientHaddress", homeAddressTb.Text.Trim, SqlDbType.VarChar)
                    .AddParameter("@patientPaddress", pAddress.Text.Trim, SqlDbType.VarChar)
                    .AddParameter("@Dob", dobPicker.Text, SqlDbType.Date)
                    .AddParameter("@gender", genderCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@contactNo", mobileContactTb.Text.Trim, SqlDbType.VarChar)
                    .AddParameter("@p_ID", 1, SqlDbType.Int)
                    .AddParameter("@tongue", tongueCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@fom", fomCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@bd", bDyscraciaCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@palate", palateCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@cheeks", cheeksCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@diabetes", diabetesCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@hygiene", hygieneCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@tonsils", tonsilCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@allergies", allergiesCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@kidney", kidneyCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@lips", lipsCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@hDisease", hDiseaseCmbx.Text, SqlDbType.VarChar)
                    .AddParameter("@liver", liverCmbx.Text, SqlDbType.VarChar)
                    .ExecuteStoredProcedure("insertPatient")

                    For Each lvItems As ListViewItem In ListView1.Items
                        .AddParameter("@p_ID", 1, SqlDbType.Int)
                        .AddParameter("@tCount", lvItems.SubItems(1).Text, SqlDbType.VarChar)
                        .AddParameter("@details", lvItems.Text, SqlDbType.VarChar)
                        .ExecuteStoredProcedure("insertRecord")
                    Next

                    '.ExecuteStoredProcedure("insertHistory")
                End With
            Else
                MsgBox("Registration Failed. Please fill all the fields.")
            End If
        End If

        If saveBtn.Text = "Update Information" Then
            With dbComm
                .AddParameter("@p_ID", patient_ID, SqlDbType.Int)
                .AddParameter("@p_fName", firstnameTb.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_iName", miTb.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_lName", lastnameTb.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_hAddress", homeAddressTb.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_pAddress", pAddress.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_ContactNo", mobileContactTb.Text.Trim, SqlDbType.VarChar)
                .ExecuteStoredProcedure("updatePatientInformation")

                '.ExecuteStoredProcedure("insertHistory")

                If .Success = True Then
                    MsgBox("Patient Successfully Updated.")
                Else
                    MsgBox("Updating Failed.")
                End If
            End With
        End If
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Validations.patientFormcancelBtnEvent()
        Patient_List.Hide()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False
            tongueCmbx.Text = "Normal"
            liverCmbx.Text = "Normal"
            hDiseaseCmbx.Text = "Normal"
            palateCmbx.Text = "Normal"
            lipsCmbx.Text = "Normal"
            fomCmbx.Text = "Normal"
            cheeksCmbx.Text = "Normal"
            allergiesCmbx.Text = "Normal"
            bDyscraciaCmbx.Text = "Normal"
            diabetesCmbx.Text = "Normal"
            kidneyCmbx.Text = "Normal"
            liverCmbx.Text = "Normal"
            otherCmbx.Text = "Normal"
            hygieneCmbx.Text = "Normal"
            tonsilCmbx.Text = "Normal"
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
            tongueCmbx.Text = "Not Normal"
            liverCmbx.Text = "Not Normal"
            hDiseaseCmbx.Text = "Not Normal"
            palateCmbx.Text = "Not Normal"
            lipsCmbx.Text = "Not Normal"
            fomCmbx.Text = "Not Normal"
            cheeksCmbx.Text = "Not Normal"
            allergiesCmbx.Text = "Not Normal"
            bDyscraciaCmbx.Text = "Not Normal"
            diabetesCmbx.Text = "Not Normal"
            kidneyCmbx.Text = "Not Normal"
            liverCmbx.Text = "Not Normal"
            otherCmbx.Text = "Not Normal"
            hygieneCmbx.Text = "Not Normal"
            tonsilCmbx.Text = "Not Normal"
        End If
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Animations.fade_out(Me)
        Me.Close()
        Animations.fade_in(mainForm)
        mainForm.Show()
    End Sub

    Private Sub lastnameTb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lastnameTb.KeyPress
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

    Private Sub firstnameTb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles firstnameTb.KeyPress
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

    Private Sub miTb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles miTb.KeyPress
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

    Private Sub mobileContactTb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mobileContactTb.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

#Region "Validates: Input Fields"

    Private Sub tbLastname_LostFocus(sender As Object, e As EventArgs) Handles lastnameTb.LostFocus
        If lastnameTb.Text = "" Then
            msgError1.Text = "Please enter your Lastname."
            msgError1.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub tbLastname_GotFocus(sender As Object, e As EventArgs) Handles lastnameTb.GotFocus
        If lastnameTb.Text = "" Then
            msgError1.Visible = False
            errCounter -= 1
        End If
    End Sub

    Private Sub tbFirstname_LostFocus(sender As Object, e As EventArgs) Handles firstnameTb.LostFocus
        If firstnameTb.Text = "" Then
            msgError2.Text = "Please enter your Firstname."
            msgError2.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub tbFirstname_GotFocus(sender As Object, e As EventArgs) Handles firstnameTb.GotFocus
        If firstnameTb.Text = "" Then
            msgError2.Visible = False
            errCounter -= 1
        End If
    End Sub

    Private Sub miTb_LostFocus(sender As Object, e As EventArgs) Handles miTb.LostFocus
        If miTb.Text = "" Then
            msgError3.Text = "Please enter your Confirm Password."
            msgError3.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub miTb_GotFocus(sender As Object, e As EventArgs) Handles miTb.GotFocus
        If miTb.Text = "" Then
            msgError3.Visible = False
            errCounter -= 1
        End If
    End Sub

    Private Sub genderCbx_LostFocus(sender As Object, e As EventArgs) Handles genderCmbx.LostFocus
        If genderCmbx.Text = "" Then
            msgError4.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub genderCbx_GotFocus(sender As Object, e As EventArgs) Handles genderCmbx.GotFocus
        If genderCmbx.Text = "" Then
            msgError4.Visible = False
            errCounter -= 1
        End If
    End Sub

    Private Sub homeAddressTb_LostFocus(sender As Object, e As EventArgs) Handles homeAddressTb.LostFocus
        If homeAddressTb.Text = "" Then
            msgError5.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub homeAddressTb_GotFocus(sender As Object, e As EventArgs) Handles homeAddressTb.GotFocus
        If homeAddressTb.Text = "" Then
            msgError5.Visible = False
            errCounter -= 1
        End If
    End Sub


    Private Sub mobileContactTb_LostFocus(sender As Object, e As EventArgs) Handles mobileContactTb.LostFocus
        If mobileContactTb.Text = "" Then
            msgError6.Visible = True
            errCounter += 1
        End If
    End Sub

    Private Sub mobileContactTb_GotFocus(sender As Object, e As EventArgs) Handles mobileContactTb.GotFocus
        If mobileContactTb.Text = "" Then
            msgError6.Visible = False
            errCounter -= 1
        End If
    End Sub
#End Region
End Class