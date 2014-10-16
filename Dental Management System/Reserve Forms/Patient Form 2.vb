Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.IO.Ports

Public Class Patient_Form_2

    Dim dbComm As New DbCommands
    Dim strItem As String


    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dobPicker.ValueChanged
        Dim Age As Double = Math.Floor(DateDiff(DateInterval.Month, dobPicker.Value, System.DateTime.Now) / 12)
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
        Animations.Slide_up(Panel2, 0)
        Label1.Select()
        With Panel3
            .Enabled = True
            .AutoScroll = True
        End With

        Label1.Location = New Point(455, -2)
        Animations.changeForeColor(Label1, "Add Patient")
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

    Private Sub saveBtn_MouseEnter(sender As Object, e As EventArgs) Handles saveBtn.MouseEnter
        Animations.changeForeColorButtonToWhite(saveBtn)
    End Sub

    Private Sub saveBtn_MouseLeave(sender As Object, e As EventArgs) Handles saveBtn.MouseLeave
        Animations.changeForeColorButtonToBlack(saveBtn)
    End Sub

    Private Sub clearBtn_MouseEnter(sender As Object, e As EventArgs) Handles clearBtn.MouseEnter
        Animations.changeForeColorButtonToWhite(clearBtn)
    End Sub

    Private Sub clearBtn_MouseLeave(sender As Object, e As EventArgs) Handles clearBtn.MouseLeave
        Animations.changeForeColorButtonToBlack(clearBtn)
    End Sub

    Private Sub cancelBtn_MouseEnter(sender As Object, e As EventArgs) Handles cancelBtn.MouseEnter
        Animations.changeForeColorButtonToWhite(cancelBtn)
    End Sub

    Private Sub cancelBtn_MouseLeave(sender As Object, e As EventArgs) Handles cancelBtn.MouseLeave
        Animations.changeForeColorButtonToBlack(cancelBtn)
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

        Label1.Location = New Point(455, -2)
        Animations.changeForeColor(Label1, "Edit Patient Information")
        saveBtn.Visible = True
        saveBtn.Text = "Search Patient"
        clearBtn.Visible = True
        clearBtn.Text = "Update Information"
        cancelBtn.Visible = True
        cancelBtn.Text = "Cancel Editing"

        Animations.Slide_down(Panel2, 75)

        Validations.enableTB()

        For Each cmbCollection As Control In Panel3.Controls
            With cmbCollection
                .Enabled = True
                .Visible = True
                validationStatusLbl.Visible = False
            End With
        Next

        searchBox.Items.Clear()
        With dbComm
            For Each dRow As DataRow In .GetDataFromStoredProcedure("getPatientList").Rows
                searchBox.Items.Add("Patient ID# " & dRow("p_ID"))
            Next
        End With
        searchBox.SelectedIndex = 0
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click

        If saveBtn.Text = "Save Patient Record" Then

            Validations.saveBtnEvent()
            If fieldCount = 7 Then
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


                    For Each lvItems As ListViewItem In ListView1.Items
                        .AddParameter("@p_ID", 1, SqlDbType.Int)
                        .AddParameter("@tCount", lvItems.SubItems(1).Text, SqlDbType.VarChar)
                        .AddParameter("@details", lvItems.Text, SqlDbType.VarChar)
                        .ExecuteStoredProcedure("insertRecord")
                    Next

                    '.ExecuteStoredProcedure("insertHistory")

                    If .Success = True Then
                        MsgBox("Patient Successfully registered.")
                    Else
                        MsgBox("Registration Failed.")
                    End If
                End With
            End If

        ElseIf saveBtn.Text = "Search Patient" Then

            With dbComm
                If CheckBox2.Checked = True Then
                    searchBox.Items.Clear()
                    With dbComm
                        For Each dRow As DataRow In .GetDataFromStoredProcedure("getPatientList").Rows
                            searchBox.Items.Add("Patient ID# " & dRow("p_ID") & " | Patient Lastname: " & dRow("patientLname"))
                        Next
                    End With
                    searchBox.SelectedIndex = 0

                ElseIf CheckBox2.Checked = False Then
                    searchBox.Items.Clear()
                    With dbComm
                        For Each dRow As DataRow In .GetDataFromStoredProcedure("getPatientList").Rows
                            searchBox.Items.Add("Patient ID# " & dRow("p_ID"))
                        Next
                    End With
                    searchBox.SelectedIndex = 0
                End If
            End With

        End If
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Validations.patientFormcancelBtnEvent()
    End Sub

    Private Sub searchBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles searchBox.SelectedIndexChanged
        With dbComm
            strItem = searchBox.Text
            Dim reg As New Regex("[^0-9]")
            strItem = reg.Replace(strItem, "")

            Dim output As Integer
            Integer.TryParse(strItem, output)

            .AddParameter("@p_ID", output, SqlDbType.Int)

            For Each dRow As DataRow In .GetDataFromStoredProcedure("getPatient").Rows
                'BetterListView1.Items.Add("Patient ID# " & dRow("p_ID").ToString & " ").SubItems.Add("Patient Name: " & dRow("patientFname") & " " & dRow("patientLname").ToString)
                lastnameTb.Text = dRow("patientLname")
                firstnameTb.Text = dRow("patientFname")
                miTb.Text = dRow("patientIname")
                homeAddressTb.Text = dRow("patientHaddress")
                pAddress.Text = dRow("patientPaddress")
                dobPicker.Text = dRow("DOB")
                genderCmbx.Text = dRow("gender")
                mobileContactTb.Text = dRow("contactNo")
            Next
            .AddParameter("@p_ID", output, SqlDbType.Int)
            For Each dtaRow As DataRow In .GetDataFromStoredProcedure("getHistory").Rows
                tongueCmbx.Text = dtaRow("tongue")
                fomCmbx.Text = dtaRow("fom")
                bDyscraciaCmbx.Text = dtaRow("bd")
                palateCmbx.Text = dtaRow("palate")
                cheeksCmbx.Text = dtaRow("cheeks")
                diabetesCmbx.Text = dtaRow("diabetes")
                hygieneCmbx.Text = dtaRow("Hygiene")
                tonsilCmbx.Text = dtaRow("tonsils")
                allergiesCmbx.Text = dtaRow("allergies")
                kidneyCmbx.Text = dtaRow("kidney")
                lipsCmbx.Text = dtaRow("lips")
                hDiseaseCmbx.Text = dtaRow("hDisease")
                liverCmbx.Text = dtaRow("liver")
            Next
        End With
    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        strItem = searchBox.Text
        Dim reg As New Regex("[^0-9]")
        strItem = reg.Replace(strItem, "")

        Dim output As Integer
        Integer.TryParse(strItem, output)
        With dbComm
            If clearBtn.Text = "Clear Entries" Then
                For Each ctrl As Control In Panel3.Controls
                    With ctrl
                        If TypeOf ctrl Is TextBox Then
                            .Text = ""
                        End If

                        If TypeOf ctrl Is ComboBox Then
                            .Text = ""
                        End If
                    End With
                Next
                ListView1.Items.Clear()
            ElseIf clearBtn.Text = "Update Information" Then
                .AddParameter("@p_ID", output, SqlDbType.Int)
                .AddParameter("@p_fName", firstnameTb.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_iName", miTb.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_lName", lastnameTb.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_hAddress", homeAddressTb.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_pAddress", pAddress.Text.Trim, SqlDbType.VarChar)
                .AddParameter("@p_ContactNo", mobileContactTb.Text.Trim, SqlDbType.VarChar)
                .ExecuteStoredProcedure("updatePatientInformation")

                If .Success = True Then
                    MsgBox("Update Successful.")
                Else
                    MsgBox("Update Failed.")
                End If
            End If
        End With
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class