Public Class Form5
    Private Sub PatientReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientReportToolStripMenuItem.Click
        patientRecordForm.Show()
    End Sub

    Private Sub PatientHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatientHistoryToolStripMenuItem.Click
        patientHistoryForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Animations.fade_in(mainForm)
        mainForm.Show()
    End Sub

    Private Sub BillingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillingReportToolStripMenuItem.Click
        BillReport.Show()
    End Sub
End Class