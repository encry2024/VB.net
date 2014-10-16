Imports System.Windows.Forms.VisualStyles

Public Class patientForm

    Private Sub patientForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Load
        Animations.fade_in(Me)
        Me.AutoScroll = False
    End Sub

    Private Sub addPatientRecordBtn_Click(sender As Object, e As EventArgs) Handles addPatientRecordBtn.Click


        Animations.Slide_up(editPatientRecordPanel, 52)
        editPatientInformationBtn.BackColor = Color.Transparent
        Animations.Slide_down(addPatientRecordPanel, 196)
        addPatientRecordBtn.BackColor = Color.FromArgb(0, 100, 100)

        Panel3.Enabled = True

        Label1.Location = New Point(214, 0)
        'Animations.changeForeColor(Label1, "Add Patient Information")
        'Animations.changeForeColorButton(saveBtn, "Save Patient Record")
        'Animations.changeForeColorButton(clearBtn, "Clear Entries")
        'Animations.changeForeColorButton(cancelBtn, "Cancel")


        lastnameTb.Enabled = True
        firstnameTb.Enabled = True
        miTb.Enabled = True
        homeAddressTb.Enabled = True
        cityTb.Enabled = True
        homeContactTb.Enabled = True
        officeContactTb.Enabled = True
        mobileContactTb.Enabled = True
        dobPicker.Enabled = True
        Label12.Visible = True
    End Sub

    Private Sub editPatientInformationBtn_Click(sender As Object, e As EventArgs) Handles editPatientInformationBtn.Click
        addPatientRecordBtn.BackColor = Color.Transparent
        Animations.Slide_up(addPatientRecordPanel, 52)
        Animations.Slide_down(editPatientRecordPanel, 196)
        editPatientInformationBtn.BackColor = Color.FromArgb(0, 100, 100)

        Animations.changeForeColorButton(searchBtn, "Search Patient")
        Animations.changeForeColorButton(updateBtn, "Update Information")
        Animations.changeForeColorButton(cancelEditingBtn, "Cancel Editing")
    End Sub

    Private Sub closeBtn_MouseEnter(sender As Object, e As EventArgs) Handles closeBtn.MouseEnter
        closeBtn.Image = My.Resources.left_round_32
    End Sub

    Private Sub closeBtn_MouseLeave(sender As Object, e As EventArgs) Handles closeBtn.MouseLeave
        closeBtn.Image = My.Resources.left_round_321
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Animations.fade_out(Me)
        Me.Close()

        Animations.fade_in(Main_Form)
        Main_Form.Show()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dobPicker.ValueChanged
        Dim Age As Double = Math.Floor(DateDiff(DateInterval.Month, dobPicker.Value, System.DateTime.Now) / 12)
        TextBox9.Text = Age
        TextBox9.ForeColor = Color.FromArgb(240, 240, 240)
        If (TextBox9.Text < 5 Or TextBox9.Text > 60) Then
            validationStatusLbl.ForeColor = Color.Red
            validationStatusLbl.Text = "Invalid Age."
            validationStatusLbl.Visible = True
        Else
            validationStatusLbl.ForeColor = Color.Lime
            validationStatusLbl.Text = "Valid Age."
            validationStatusLbl.Visible = True
        End If
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click

    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        lastnameTb.Clear()
        firstnameTb.Clear()
        miTb.Clear()
        homeAddressTb.Clear()
        cityTb.Clear()
        homeContactTb.Clear()
        officeContactTb.Clear()
        mobileContactTb.Clear()
        dobPicker.CustomFormat = " "
        TextBox9.Text = ""
        validationStatusLbl.Text = ""
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Animations.Slide_up(addPatientRecordPanel, 52)

        Label1.Location = New Point(250, 0)
        Animations.changeForeColor(Label1, "Patient Information")
        addPatientRecordBtn.BackColor = Color.Transparent

        'CLEARS ENTRIES
        lastnameTb.Clear()
        firstnameTb.Clear()
        miTb.Clear()
        homeAddressTb.Clear()
        cityTb.Clear()
        homeContactTb.Clear()
        officeContactTb.Clear()
        mobileContactTb.Clear()
        dobPicker.CustomFormat = " "
        TextBox9.Text = ""
        validationStatusLbl.Text = ""

        'DISABLES CONTROLS
        lastnameTb.Enabled = False
        firstnameTb.Enabled = False
        miTb.Enabled = False
        homeAddressTb.Enabled = False
        cityTb.Enabled = False
        homeContactTb.Enabled = False
        officeContactTb.Enabled = False
        mobileContactTb.Enabled = False
        dobPicker.Enabled = False
        Label12.Visible = False
        dobPicker.CustomFormat = " "
        TextBox9.Text = ""
        validationStatusLbl.Visible = False
        validationStatusLbl.Text = ""
    End Sub

    Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click

    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click

    End Sub

    Private Sub cancelEditingBtn_Click(sender As Object, e As EventArgs) Handles cancelEditingBtn.Click
        Animations.Slide_up(editPatientRecordPanel, 52)

        Label1.Location = New Point(250, 0)
        Animations.changeForeColor(Label1, "Patient Information")
        addPatientRecordBtn.BackColor = Color.Transparent

        lastnameTb.Enabled = False
        firstnameTb.Enabled = False
        miTb.Enabled = False
        homeAddressTb.Enabled = False
        cityTb.Enabled = False
        homeContactTb.Enabled = False
        officeContactTb.Enabled = False
        mobileContactTb.Enabled = False
        dobPicker.Enabled = False
        Label12.Visible = False
        dobPicker.CustomFormat = " "
        TextBox9.Text = ""
        validationStatusLbl.Visible = False
        validationStatusLbl.Text = ""
    End Sub

    Private Sub dobPicker_Enter(sender As Object, e As EventArgs) Handles dobPicker.Enter
        dobPicker.Format = DateTimePickerFormat.Custom
        dobPicker.CustomFormat = "MMMM/ dd / yyyy"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class