Imports ComponentOwl.BetterListView

Public Class Edit_Schedule

    Dim dbComm As New DbCommands

    Private Sub Edit_Schedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dbComm
            .AddParameter("schedDate", DateTime.Now, SqlDbType.Date)
            For Each dRow As DataRow In .GetDataFromStoredProcedure("viewscehed").Rows
                Dim lvItem As New BetterListViewItem("Patient ID: " & dRow("p_ID").ToString)
                lvItem.SubItems.Add("Patient Name: " & dRow("patientFname") & " " & dRow("patientLname"))
                lvItem.SubItems.Add("Date of Sched. " & dRow("schedDate"))
                lvItem.SubItems.Add("Time of Sched. " & dRow("sched_time_in") & " - " & dRow("sched_time_out"))

                BetterListView1.Items.Add(lvItem)
            Next
        End With

        tbTotalCharge.Text = getPrice
        Label5.Text = getTreatment
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class