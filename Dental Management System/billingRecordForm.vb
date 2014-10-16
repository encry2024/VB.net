Imports ComponentOwl.BetterListView
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class billingRecordForm


    Dim provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
    Dim dte As Date
    Dim dbComm As New DbCommands
    Dim strItem As String
    Dim price As Double
    Dim total As Double
    Dim pID As Integer
    Dim trt_name As String
    Dim cmbox As New ComboBox
    Dim initDate As Date
    Dim totalPrice As Double
    Dim ftotal As Double
    Dim totalChange

    Public getPrice As Double
    Public getDate As Date
    Public getTreatment As String

    Private Sub Billing_Record_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With cmbox
            .SelectedText = "Treatment OJA"
        End With

        With dbComm
            .AddParameter("schedDate", DateTime.Now, SqlDbType.Date)
            For Each dRow As DataRow In .GetDataFromStoredProcedure("viewscehed").Rows
                Dim lvItem As New BetterListViewItem("Patient ID: " & dRow("p_ID").ToString)
                lvItem.SubItems.Add("Patient Name: " & dRow("patientFname") & " " & dRow("patientLname"))
                lvItem.SubItems.Add("Date of Sched. " & dRow("schedDate"))
                lvItem.SubItems.Add("Time of Sched. " & dRow("sched_time_in") & " - " & dRow("sched_time_out"))

                patientListView.Items.Add(lvItem)
            Next
        End With

        tbTotalCharge.Text = getPrice
        Label5.Text = getTreatment
    End Sub

    Private Sub BetterListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles patientListView.SelectedIndexChanged
        If Not patientListView.SelectedItems.Count = 0 Then '// check if item is selected.
            With patientListView.SelectedItems.Item(0)
                strItem = patientListView.Items(patientListView.FocusedItem.Index).SubItems(0).Text

                Dim reg As New Regex("[^0-9]")
                strItem = reg.Replace(strItem, "")

                Dim output As Integer
                Integer.TryParse(strItem, output)

                pID = output

            End With
        End If
        ''
        totalPrice = "0"
        With dbComm
            .AddParameter("@p_ID", pID, SqlDbType.Int)
            For Each dRow As DataRow In .GetDataFromStoredProcedure("getSelectedPatient").Rows
                nameLbl.Text = dRow("patientLname") & " " & dRow("patientFname") & " " & dRow("patientIname")
            Next

            BetterListView1.Items.Clear()
            .AddParameter("@p_ID", pID, SqlDbType.Int)
            .AddParameter("@date_of_payment", DateTime.Now, SqlDbType.Date)
            For Each DtaRow As DataRow In .GetDataFromStoredProcedure("getReceipt").Rows
                totalPrice = totalPrice + Val(DtaRow("Charge").ToString)

                Dim blvItems As New BetterListViewItem(DtaRow("TypeOfTreatment").ToString)
                blvItems.SubItems.Add(DtaRow("Treatment").ToString)
                blvItems.SubItems.Add(DtaRow("Charge").ToString)

                BetterListView1.Items.Add(blvItems)
            Next
        End With

        tbTotalCharge.Text = totalPrice

        If pID = Nothing Then
            disableField()
        Else
            enableField()
        End If
    End Sub

    Private Sub canclBtn_Click(sender As Object, e As EventArgs)
        Animations.fade_out(Me)
        Me.Close()

        Animations.fade_in(mainForm)
        mainForm.Show()
    End Sub

    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        Animations.changeForeColorButtonToWhite(btnSave)
    End Sub

    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        Animations.changeForeColorButtonToBlack(btnSave)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ftotal = Val(TextBox2.Text) - Val(tbTotalCharge.Text)
        tbPrice.Text = ftotal
        With dbComm
            .AddParameter("p_id", pID, SqlDbType.Int)
            '.AddParameter("@payment", ComboBox1.Text, SqlDbType.VarChar)
            .AddParameter("@TotalCharge", tbTotalCharge.Text, SqlDbType.Money)
            .AddParameter("@amount", TextBox2.Text, SqlDbType.Money)
            .AddParameter("@change", ftotal, SqlDbType.Money)
            .ExecuteStoredProcedure("insertBill")

            MsgBox("Transaction Complete")

            If Scheduling_Form.cbxTreatmentName.Text = "Braces" Then
                For Each lvItems As BetterListViewItem In Scheduling_Form.blvTreatmentList.Items
                    .AddParameter("@p_id", pID, SqlDbType.Int)
                    .AddParameter("@t_count", "All", SqlDbType.VarChar)
                    .AddParameter("@TypeOfTreatment", lvItems.SubItems(1).Text, SqlDbType.VarChar)
                    .AddParameter("@Treatment", lvItems.SubItems(2).Text, SqlDbType.VarChar)
                    .AddParameter("@Charge", lvItems.SubItems(3).Text, SqlDbType.VarChar)
                    .ExecuteStoredProcedure("insertReceipt")
                Next
            Else
                For Each lvItems As BetterListViewItem In Scheduling_Form.blvTreatmentList.Items
                    .AddParameter("@p_id", pID, SqlDbType.Int)
                    .AddParameter("@t_count", lvItems.Text, SqlDbType.VarChar)
                    .AddParameter("@TypeOfTreatment", lvItems.SubItems(1).Text, SqlDbType.VarChar)
                    .AddParameter("@Treatment", lvItems.SubItems(2).Text, SqlDbType.VarChar)
                    .AddParameter("@Charge", lvItems.SubItems(3).Text, SqlDbType.VarChar)
                    .ExecuteStoredProcedure("insertReceipt")
                Next
            End If

        End With
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Animations.fade_out(Me)
        Me.Close()
        Animations.fade_in(mainForm)
        mainForm.Show()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        tbPrice.Text = Val(TextBox2.Text) - Val(tbTotalCharge.Text)

        If (Val(tbPrice.Text) < 0) Then
            tbPrice.Text = 0
        Else
            tbPrice.Text = tbPrice.Text
        End If
    End Sub
End Class

