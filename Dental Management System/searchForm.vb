Public Class searchForm

    Dim dbComm As New DbCommands

    Private Sub searchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dbComm
            For Each dRow As DataRow In .GetDataFromStoredProcedure("getPatientList").Rows
                BetterListView1.Items.Add("Patient ID# " & dRow("p_ID").ToString & " ").SubItems.Add("Patient Name: " & dRow("patientFname") & " " & dRow("patientLname").ToString)
            Next
        End With
    End Sub
End Class