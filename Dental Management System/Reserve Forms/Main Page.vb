Public Class Main_Page_2


    Private Sub pRecordBtn_Click(sender As Object, e As EventArgs)
        pRecordBtn.ForeColor = Color.White
        pRecordBtn.BackColor = Color.FromArgb(0, 130, 130)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timeLbl.Text = DateAndTime.Now.ToShortTimeString
    End Sub

    Private Sub Main_Page_2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timeLbl.Text = DateAndTime.Now.ToShortTimeString
        Label9.Text = Date.Now.ToString("MMMM - dd - yyyy")
    End Sub
End Class