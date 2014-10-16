Imports System.Text.RegularExpressions
Imports ComponentOwl.BetterListView

Public Class Scheduling_Form

    Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
    Dim dbcomm As New DbCommands
    Dim cbo_test As New ComboBox
    Dim dteCalendar As Date
    Dim dte As Date
    Dim time As String
    Dim strArr() As String
    Dim min() As String
    Dim compareTime_1 As String
    Dim compareTime_2 As String
    Dim errorCount As Integer = 2
    Dim total As Double
    Dim timeInHr As Integer
    Dim timeOutHr As Integer

    Public price As Double
    Public patient_Id As Integer
    Public time2 As String
    Public dte1 As Date
    Public hr As String



    Private Sub Scheduling_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        saveBtn.Enabled = False
        MonthCalendar1.MinDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        MonthCalendar1.MaxDate = MonthCalendar1.MinDate.AddMonths(12)

        With dbcomm
            For Each dtaRow As DataRow In .GetDataFromStoredProcedure("spGetTreatmeant").Rows
                cbxTreatmentType.Items.Add(dtaRow("treatment_Type").ToString)
            Next
        End With

        Me.Show()

        populateControl.populateButtonWithEvent()
        patientFormPanel3Ctrl()

        If hrCmb.Text = "" And minCmb.Text = "" Then
            hr2Cmb.Enabled = False
            min2Cmb.Enabled = False
        Else
            hr2Cmb.Enabled = True
            min2Cmb.Enabled = True
        End If

        If patient_Id = Nothing Then
            hrCmb.Enabled = False
            minCmb.Enabled = False
        Else
            hrCmb.Enabled = True
            minCmb.Enabled = True
        End If
    End Sub

    Private Sub saveBtn_MouseEnter(sender As Object, e As EventArgs) Handles saveBtn.MouseEnter
        Animations.changeForeColorButtonToWhite(saveBtn)
    End Sub

    Private Sub saveBtn_MouseLeave(sender As Object, e As EventArgs) Handles saveBtn.MouseLeave
        Animations.changeForeColorButtonToBlack(saveBtn)
    End Sub

    Private Sub editBtn_MouseEnter(sender As Object, e As EventArgs) Handles editBtn.MouseEnter
        Animations.changeForeColorButtonToWhite(editBtn)
    End Sub

    Private Sub editBtn_MouseLeave(sender As Object, e As EventArgs) Handles editBtn.MouseLeave
        Animations.changeForeColorButtonToBlack(editBtn)
    End Sub

    Private Sub cancelBtn_MouseEnter(sender As Object, e As EventArgs) Handles cancelBtn.MouseEnter
        Animations.changeForeColorButtonToWhite(cancelBtn)
    End Sub

    Private Sub cancelBtn_MouseLeave(sender As Object, e As EventArgs) Handles cancelBtn.MouseLeave
        Animations.changeForeColorButtonToBlack(cancelBtn)
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        If errorCount = 0 Then
            With dbcomm
                .AddParameter("@p_ID", patient_Id, SqlDbType.Int)
                .AddParameter("@timeIn", hrCmb.Text & ":" & minCmb.Text & " " & periodTb_1.Text, SqlDbType.VarChar)
                .AddParameter("@timeOut", hr2Cmb.Text & ":" & min2Cmb.Text & " " & periodTb_2.Text, SqlDbType.VarChar)
                .AddParameter("@schedDate", dte, SqlDbType.Date)
                .ExecuteStoredProcedure("insertSched")


                For Each lvItems As BetterListViewItem In blvTreatmentList.Items
                    .AddParameter("@p_id", patient_Id, SqlDbType.Int)
                    .AddParameter("@date_of_payment", dte1, SqlDbType.Date)
                    .AddParameter("@t_count", lvItems.Text, SqlDbType.VarChar)
                    .AddParameter("@TypeOfTreatment", lvItems.SubItems(1).Text, SqlDbType.VarChar)
                    .AddParameter("@Treatment", lvItems.SubItems(2).Text, SqlDbType.VarChar)
                    .AddParameter("@Charge", lvItems.SubItems(3).Text, SqlDbType.VarChar)
                    .ExecuteStoredProcedure("insertReceipt")
                Next
            End With
            MsgBox("Patient Scheduled")
        Else
            MsgBox("There's a conflict in your schedules.")
        End If
        If errorCount < 0 Then
            errorCount = 0
        End If
    End Sub

    Private Sub MonthCalendar1_DateSelected(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateSelected
        dte1 = MonthCalendar1.SelectionRange.Start
        dte = MonthCalendar1.SelectionRange.Start
        Patient_List.titleLabel.Text = "Schedules"
        Patient_List.Show()
        billingRecordForm.getDate = dte1
        'With dbcomm
        '    .AddParameter("schedDate", DateTime.Now.ToString("MMMM dd, yyyy"), SqlDbType.Date)
        '    For Each dRow As DataRow In .GetDataFromStoredProcedure("viewscehed").Rows
        '        Dim lvItem As New BetterListViewItem(dRow("patientFname").ToString & " " & dRow("patientLname").ToString)
        '        lvItem.SubItems.Add(dRow("schedDate").ToString)
        '        lvItem.SubItems.Add(dRow("sched_time_in").ToString)
        '        lvItem.SubItems.Add(dRow("sched_time_out").ToString)

        '        Show_Schedules.BetterListView1.Items.Add(lvItem)
        '    Next
        'End With
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Animations.fade_out(Me)
        Me.Close()
        Animations.fade_in(mainForm)
        mainForm.Show()
    End Sub

    Private Sub hrCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hrCmb.SelectedIndexChanged
        minCmb.SelectedIndex = 0
        hr = hrCmb.Text
        timeInHr = hrCmb.Text

        If Val(hrCmb.Text) > 4 Then
            periodTb_1.Text = "AM"
        ElseIf Val(hrCmb.Text) <= 4 Then
            periodTb_1.Text = "PM"
        End If

        If hrCmb.Text = "" And minCmb.Text = "" Then
            hr2Cmb.Enabled = False
            min2Cmb.Enabled = False
        Else
            hr2Cmb.Enabled = True
            min2Cmb.Enabled = True
        End If

        compareTime_1 = hrCmb.Text & ":" & minCmb.Text & " " & periodTb_1.Text

        If compareTime_1 = compareTime_2 Then
            msgError1.Text = "Invalid Schedule. Time-in and Time-out have the same time."
            msgError1.Visible = True
        Else
            msgError1.Visible = False
        End If



        With dbcomm
            .AddParameter("@schedDate", dte, SqlDbType.Date)
            For Each dtaRow As DataRow In .GetDataFromStoredProcedure("viewTime").Rows
                time2 = dtaRow("sched_time_in")
                strArr = time2.Split(":")
                If hr = strArr(0) Then
                    msgError1.Text = "Someone already occupied this time schedule."
                    msgError1.Visible = True
                    MsgBox(errorCount)
                    Exit Sub
                ElseIf hr <> strArr(0) Then
                    msgError1.Visible = False
                    errorCount -= 1
                    MsgBox(errorCount)
                    Exit Sub
                End If
            Next
        End With

        If msgError1.Text = "" And msgError2.Text = "" Then
            saveBtn.Enabled = True
        End If

        If errorCount > 0 Then
            saveBtn.Enabled = False
        Else
            saveBtn.Enabled = True
        End If
    End Sub

    Private Sub minCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles minCmb.SelectedIndexChanged
        'min = minCmb.Text
    End Sub

    Private Sub cbxTreatmentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTreatmentType.SelectedIndexChanged
        With dbcomm
            .AddParameter("@t_type", cbxTreatmentType.Text, SqlDbType.VarChar)
            For Each dtaRow As DataRow In .GetDataFromStoredProcedure("getTreatmentType").Rows
                .AddParameter("@trt_Id", dtaRow("t_id").ToString, SqlDbType.Int)
                cbxTreatmentName.Items.Clear()
                For Each dRow As DataRow In .GetDataFromStoredProcedure("getTreatmentName").Rows
                    cbxTreatmentName.Items.Add(dRow("Treatment_name").ToString)
                Next
            Next
        End With
    End Sub

    Private Sub cbxTreatmentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTreatmentName.SelectedIndexChanged
        With dbcomm
            .AddParameter("@t_treatmentName", cbxTreatmentName.Text, SqlDbType.VarChar)
            For Each dtaRow As DataRow In .GetDataFromStoredProcedure("getPrice").Rows
                price = dtaRow("price").ToString
            Next
        End With
    End Sub

    Private Sub hr2Cmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles hr2Cmb.SelectedIndexChanged
        min2Cmb.SelectedIndex = 0
        timeOutHr = hr2Cmb.Text
        With dbcomm
            .AddParameter("@schedDate", dte, SqlDbType.Date)
            For Each dtaRow As DataRow In .GetDataFromStoredProcedure("viewTime").Rows
                time2 = dtaRow("sched_time_out")
                strArr = time2.Split(":")
                If timeOutHr = strArr(0) Then
                    msgError2.Text = "Someone already occupied this time schedule."
                    msgError2.Visible = True
                    Exit Sub
                ElseIf timeOutHr <> strArr(0) Then
                    errorCount -= 1
                    MsgBox(errorCount)
                    msgError2.Visible = False
                    Exit Sub
                End If
            Next
        End With


        'If Val(hr2Cmb.Text) > 4 Then
        '    periodTb_2.Text = "AM"
        'ElseIf Val(hr2Cmb.Text) <= 4 Then
        '    periodTb_2.Text = "PM"
        'End If

        'If timeOutHr < timeInHr Then
        '    msgError2.Text = "Cannot set a Time-out schedule less than your Scheduled Time-in"
        '    msgError2.Visible = True
        '    saveBtn.Enabled = False
        'Else
        '    msgError2.Visible = False
        '    msgError2.Text = ""
        '    saveBtn.Enabled = True
        'End If

        'If periodTb_1.Text = "AM" And periodTb_2.Text = "PM" Then
        '    saveBtn.Enabled = True
        'End If

        'compareTime_2 = hr2Cmb.Text & ":" & min2Cmb.Text & " " & periodTb_2.Text

        'If msgError1.Text <> "" Then
        '    saveBtn.Enabled = False
        'End If

        'If compareTime_2 = compareTime_1 Then
        '    msgError2.Text = "Time-in and Time-out have the same time."
        '    msgError2.Visible = True
        '    saveBtn.Enabled = False
        'ElseIf msgError1.Text = "" Then
        '    msgError2.Visible = False
        '    saveBtn.Enabled = True
        'End If

        'If msgError1.Visible = True Then
        '    saveBtn.Enabled = False
        'End If

        'If errorCount <> 0 Then
        '    saveBtn.Enabled = False
        'End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim lvNewItem As New BetterListViewItem(tCountCmbx.Text)
        lvNewItem.AlignHorizontal = TextAlignmentHorizontal.Center
        lvNewItem.SubItems.Add(cbxTreatmentType.Text).AlignHorizontal = TextAlignmentHorizontal.Center
        lvNewItem.SubItems.Add(cbxTreatmentName.Text).AlignHorizontal = TextAlignmentHorizontal.Center
        lvNewItem.SubItems.Add(price.ToString).AlignHorizontal = TextAlignmentHorizontal.Center
        total = total + lvNewItem.SubItems(3).Text
        blvTreatmentList.Items.Add(lvNewItem)

        price = total

        billingRecordForm.getPrice = price
        cbxTreatmentName.Text = billingRecordForm.getTreatment
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If Not blvTreatmentList.SelectedItems.Count = 0 Then '// check if item is selected.
            With blvTreatmentList.SelectedItems.Item(0)
                total -= blvTreatmentList.SelectedItems.Item(0).SubItems(3).Text
                .Remove()

            End With
        End If
        price = total

        billingRecordForm.getPrice = price
        cbxTreatmentName.Text = billingRecordForm.getTreatment
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Show_Schedules.Show()
    End Sub

    Private Sub editBtn_Click(sender As Object, e As EventArgs) Handles editBtn.Click

    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        dte = MonthCalendar1.SelectionRange.Start
        With dbcomm
            Show_Schedules.BetterListView1.Items.Clear()
            .AddParameter("schedDate", dte, SqlDbType.Date)
            For Each dRow As DataRow In .GetDataFromStoredProcedure("viewscehed").Rows
                Dim lvItem As New BetterListViewItem(dRow("patientFname").ToString & " " & dRow("patientLname").ToString)
                lvItem.SubItems.Add(dRow("schedDate").ToString)
                lvItem.SubItems.Add(dRow("sched_time_in").ToString)
                lvItem.SubItems.Add(dRow("sched_time_out").ToString)

                Show_Schedules.BetterListView1.Items.Add(lvItem)
            Next
        End With
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Patient_List.Hide()
        Show_Schedules.Hide()
    End Sub
End Class
