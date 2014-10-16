Public Class splash

    Dim formCount As Integer = 0

    Private Sub splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If formCount <= 5 Then
            formCount += 1
            If formCount = 5 Then


                Animations.fade_out(Me)
                Me.Hide()


                Animations.fade_in(Patient_Form_2)
                Patient_Form_2.Show()
                Timer1.Enabled = False
            End If
        End If
    End Sub
End Class