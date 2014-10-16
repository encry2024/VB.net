Imports ComponentOwl.BetterListView

Public Class Show_Schedules

    Dim dbComm As New DbCommands

    Private Sub Show_Schedules_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'With dbComm
        '    BetterListView1.Items.Clear()
        '    .AddParameter("schedDate", DateTime.Now.ToString("MMMM dd, yyyy"), SqlDbType.Date)
        '    For Each dRow As DataRow In .GetDataFromStoredProcedure("viewscehed").Rows
        '        Dim lvItem As New BetterListViewItem(dRow("patientFname").ToString & " " & dRow("patientLname").ToString)
        '        lvItem.SubItems.Add(dRow("schedDate").ToString)
        '        lvItem.SubItems.Add(dRow("sched_time_in").ToString)
        '        lvItem.SubItems.Add(dRow("sched_time_out").ToString)

        '        BetterListView1.Items.Add(lvItem)
        '    Next
        'End With


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub BetterListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BetterListView1.SelectedIndexChanged

    End Sub
End Class