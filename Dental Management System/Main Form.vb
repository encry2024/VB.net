Public Class Main_Form

    Dim ctl As Control
    Dim ctlMDI As MdiClient

    Private Sub Main_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Animations.fade_in(Me)
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Animations.fade_out(Me)
        Me.Close()

        loginForm.Show()
        Animations.fade_in(loginForm)
    End Sub

    Private Sub pRecordBtn_Click(sender As Object, e As EventArgs) Handles pRecordBtn.Click
        Animations.fade_out(Me)
        Me.Hide()

        Animations.fade_in(patientForm)
        patientForm.Show()
    End Sub

    Private Sub bRecordBtn_Click(sender As Object, e As EventArgs)
        patientForm.Close()
    End Sub

    Private Sub aRecordBtn_Click(sender As Object, e As EventArgs)
    End Sub
End Class


