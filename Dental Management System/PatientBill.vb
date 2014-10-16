Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class PatientBill

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        'Dim cryRpt As New ReportDocument
        'cryRpt.Load("C:\Users\Mabel\Desktop\Dental Management System\Dental Management System\CrystalReport2.rpt")

        'Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        'Dim crParameterFieldDefinition As ParameterFieldDefinition
        'Dim crParameterValues As New ParameterValues
        'Dim crParameterDiscreteValue As New ParameterDiscreteValue

        'crParameterDiscreteValue.Value = TextBox1.Text
        'crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields
        'crParameterFieldDefinition = _
        '    crParameterFieldDefinitions.Item("Patientname")
        'crParameterValues = crParameterFieldDefinition.CurrentValues

        'crParameterValues.Clear()
        'crParameterValues.Add(crParameterDiscreteValue)
        'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        'CrystalReportViewer1.ReportSource = cryRpt
        'CrystalReportViewer1.Refresh()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class