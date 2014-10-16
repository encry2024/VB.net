
Public Class PatientProfile
    'Dim pf As New PrintForm
    Private Sub PatientProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Patient_List.Show()
        Patient_List.titleLabel.Text = "Patient List"
    End Sub
    Private Sub Print_Click(sender As Object, e As EventArgs) Handles Print.Click

    End Sub
End Class