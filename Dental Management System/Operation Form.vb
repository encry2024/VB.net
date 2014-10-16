Imports ComponentOwl.BetterListView
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Public Class operationForm

    Dim cbxIndex As Integer
    Dim dbComm As New DbCommands
    Dim strItem As String
    Dim treatment_id As Integer

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Animations.fade_out(Me)
        Close()

        Animations.fade_in(mainForm)
        mainForm.Show()
    End Sub

    Private Sub operationForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        With dbComm
            cbxListOperation.Items.Clear()
            For Each dRow As DataRow In .GetDataFromStoredProcedure("getAllTreatment").Rows
                cbxListOperation.Items.Add(dRow("Treatment_type"))
            Next
         end with
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        With dbComm
            .AddParameter("@t_id", treatment_id, SqlDbType.Int)
            .AddParameter("@t_Name", tbNameOperation.Text.Trim, SqlDbType.VarChar)
            .AddParameter("@t_Price", tbPrice.Text, SqlDbType.Money)
            .ExecuteStoredProcedure("insertTreatment")
        End With
    End Sub

    Private Sub cbxListOperation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxListOperation.SelectedIndexChanged
        With dbComm
            .AddParameter("@treatment_type", cbxListOperation.Text, SqlDbType.VarChar)
            For Each dRow As DataRow In .GetDataFromStoredProcedure("getTreatmentId").Rows
                treatment_id = dRow("t_id").ToString
            Next
        End With
        MsgBox(treatment_id)
    End Sub
End Class