Module populateControl

    Public tCount As String
    Dim dbComm As New DbCommands


    Public Sub mouseDown(sender As Object, e As MouseEventArgs)
        Dim btns As New Button()
        btns = DirectCast(sender, Button)

        tCount = btns.Text
    End Sub

    Public Sub populateButtonWithEvent()
        Dim btns() As Button = New Button() {patientForm__2_.Button1, patientForm__2_.Button2, patientForm__2_.Button3, _
                                             patientForm__2_.Button4, patientForm__2_.Button5, _
                                             patientForm__2_.Button6, patientForm__2_.Button7, patientForm__2_.Button8, patientForm__2_.Button9, _
                                             patientForm__2_.Button10, patientForm__2_.Button11, patientForm__2_.Button12, _
                                             patientForm__2_.Button13, patientForm__2_.Button14, patientForm__2_.Button15, _
                                             patientForm__2_.Button16, patientForm__2_.Button17, patientForm__2_.Button18, _
                                             patientForm__2_.Button19, patientForm__2_.Button20, patientForm__2_.Button21, _
                                             patientForm__2_.Button22, patientForm__2_.Button23, patientForm__2_.Button24, _
                                             patientForm__2_.Button25, patientForm__2_.Button26, patientForm__2_.Button27, _
                                             patientForm__2_.Button28, patientForm__2_.Button29, patientForm__2_.Button30, _
                                             patientForm__2_.Button31, patientForm__2_.Button32, patientForm__2_.Button33}
        For Each btnCount In btns
            AddHandler btnCount.MouseDown, AddressOf mouseDown
        Next
    End Sub

 
End Module
