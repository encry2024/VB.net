Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class BillReport

    Dim dte As Date
    Dim dbComm As New DbCommands

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs)



    End Sub

    Private Sub dobPicker_ValueChanged(sender As Object, e As EventArgs) Handles dobPicker.ValueChanged

    End Sub

    Private Sub BillReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dbComm
            For Each dRow As DataRow In .GetDataFromStoredProcedure("getDates").Rows
                ComboBox1.Items.Add(dRow("Schedules"))
            Next
        End With
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim cryRpt As New ReportDocument
        cryRpt.Load("C:\Users\Mabel\Desktop\Dental Management System\Dental Management System\BillingReports.rpt")

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        crParameterDiscreteValue.Value = ComboBox1.Text
        crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields
        crParameterFieldDefinition = _
            crParameterFieldDefinitions.Item("Dates")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class