Module Validations

    Public fieldCount As Integer = 0
    Dim _success As Boolean


#Region "PATIENT FORM PANEL 3 CONTROL VALIDATIONS"

    Public Sub patientFormPanel3Ctrl()
        For Each btnCCtrl As Control In patientForm__2_.Panel3.Controls
            btnCCtrl.Enabled = False
            Patient_Form_2.Label1.Enabled = True
            Patient_Form_2.Label13.Enabled = True
            Patient_Form_2.Label35.Enabled = True
        Next
    End Sub

#End Region

#Region "THIS REGION VALIDATES THE PATIENT FORM CANCEL BUTTON. [CANCEL ADD BUTTON, CANCEL EDITING BUTTON, CLOSE ADD PATIENT FORM]"

    Public Sub patientFormcancelBtnEvent()
        If (patientForm__2_.cancelBtn.Text = "Cancel Add") Then
            patientForm__2_.Label1.Select()

            patientForm__2_.Label1.Location = New Point(493, -2)
            Animations.changeForeColor(patientForm__2_.Label1, "Patient Information")
            'Animations.changeForeColorButton(patientForm__2_.cancelBtn, "Close")

            For Each cntrlsCollection As Control In patientForm__2_.Panel3.Controls
                With cntrlsCollection

                    If TypeOf cntrlsCollection Is TextBox Then
                        cntrlsCollection.Text = Nothing
                        .Enabled = False
                    End If

                    If TypeOf cntrlsCollection Is ComboBox Then
                        cntrlsCollection.Text = Nothing
                        .Enabled = False
                    End If

                    If TypeOf cntrlsCollection Is Button Then
                        .Enabled = False
                    End If

                End With
            Next

            patientForm__2_.ListView1.Items.Clear()
            patientForm__2_.Label32.Visible = False
            patientForm__2_.Label37.Visible = False
            patientForm__2_.Label12.Visible = False

            patientForm__2_.saveBtn.Text = Nothing
            patientForm__2_.saveBtn.Visible = False
            patientForm__2_.clearBtn.Text = Nothing
            patientForm__2_.clearBtn.Visible = False
            patientForm__2_.cancelBtn.Text = Nothing
            patientForm__2_.cancelBtn.Visible = False

            patientForm__2_.TextBox9.Text = Nothing
            patientForm__2_.validationStatusLbl.Text = Nothing
            patientForm__2_.ListView1.Items.Clear()
            patientForm__2_.AutoScroll = False
            patientForm__2_.msgError1.Visible = False
            patientForm__2_.msgError2.Visible = False
            patientForm__2_.msgError3.Visible = False
            patientForm__2_.msgError4.Visible = False
            patientForm__2_.msgError5.Visible = False
            patientForm__2_.msgError6.Visible = False


        ElseIf (patientForm__2_.cancelBtn.Text = "Cancel Editing") Then

            Dim ctrls() As Control = New Control() {patientForm__2_.tongueCmbx, patientForm__2_.tonsilCmbx, patientForm__2_.liverCmbx, patientForm__2_.hDiseaseCmbx, _
                                             patientForm__2_.cheeksCmbx, patientForm__2_.allergiesCmbx, patientForm__2_.kidneyCmbx, patientForm__2_.diabetesCmbx, _
                                             patientForm__2_.hygieneCmbx, patientForm__2_.otherCmbx, patientForm__2_.fomCmbx, patientForm__2_.palateCmbx, _
                                            patientForm__2_.bDyscraciaCmbx, patientForm__2_.lipsCmbx, patientForm__2_.lastnameTb, patientForm__2_.firstnameTb, patientForm__2_.miTb, _
                                            patientForm__2_.homeAddressTb, patientForm__2_.mobileContactTb, _
                                            patientForm__2_.dobPicker, patientForm__2_.genderCmbx, patientForm__2_.Label12, patientForm__2_.pAddress}

            For Each cntrlsCollection In ctrls
                With cntrlsCollection
                    .Enabled = False

                    If TypeOf cntrlsCollection Is Button Then
                        .Enabled = False
                    End If

                    If TypeOf cntrlsCollection Is TextBox Then
                        cntrlsCollection.Text = Nothing
                    End If

                    If TypeOf cntrlsCollection Is ComboBox Then
                        cntrlsCollection.Text = Nothing
                    End If

                End With
            Next

            patientForm__2_.Label32.Visible = False
            patientForm__2_.Label37.Visible = False
            patientForm__2_.Label12.Visible = False

            patientForm__2_.saveBtn.Text = Nothing
            patientForm__2_.saveBtn.Visible = False
            patientForm__2_.clearBtn.Text = Nothing
            patientForm__2_.clearBtn.Visible = False
            patientForm__2_.cancelBtn.Text = Nothing

            patientForm__2_.msgError1.Visible = False
            patientForm__2_.msgError2.Visible = False
            patientForm__2_.msgError3.Visible = False
            patientForm__2_.msgError4.Visible = False
            patientForm__2_.msgError5.Visible = False
            patientForm__2_.msgError6.Visible = False
            patientForm__2_.cancelBtn.Visible = False

            patientForm__2_.Label1.Location = New Point(493, -2)
            Animations.changeForeColor(patientForm__2_.Label1, "Patient Information")
            'Animations.changeForeColorButton(patientForm__2_.cancelBtn, "Close")ien

            patientForm__2_.ListView1.Items.Clear()

        ElseIf (patientForm__2_.cancelBtn.Text = "Close") Then

            Animations.fade_out(patientForm__2_)
            patientForm__2_.Close()

            Animations.fade_in(mainForm)
            mainForm.Show()

        End If
    End Sub

#End Region

#Region "PATIENT FORM SAVE BUTTON VALIDATION"
    Public Sub saveBtnEvent()
        Dim inputFields() As TextBox = New TextBox() {patientForm__2_.lastnameTb, patientForm__2_.firstnameTb, patientForm__2_.miTb, _
                                                    patientForm__2_.homeAddressTb, patientForm__2_.pAddress, patientForm__2_.mobileContactTb}
        fieldCount = 0
        For Each tBox As TextBox In inputFields
            If tBox.Text.Length <> 0 Then
                fieldCount += 1
            End If

            If tBox.Text = Nothing Then
                MsgBox(tBox.Name & " field is empty.")
            Else

            End If
        Next

        If patientForm__2_.genderCmbx.Text.Length <> 0 Then
            fieldCount += 1
        End If

    End Sub
#End Region

#Region "PATIENT FORM EDIT BUTTON VALIDATIONS"

    Public Sub enableTB()
        Dim ctrls() As TextBox = New TextBox() {patientForm__2_.lastnameTb, patientForm__2_.firstnameTb, patientForm__2_.miTb, _
                                    patientForm__2_.homeAddressTb, patientForm__2_.mobileContactTb, _
                                    patientForm__2_.pAddress}

        For Each cntrlsCollection In ctrls
            With cntrlsCollection
                .ReadOnly = False
            End With
        Next
    End Sub

#End Region

#Region "DISABLE BUTTON"

    Public Sub disableBtn(ByVal pnl As Panel)
        For Each ctrl As Control In pnl.Controls
            With ctrl
                If TypeOf ctrl Is Button Then
                    .Enabled = False
                End If
            End With
        Next
    End Sub

#End Region

#Region "ENABLE BUTTON"

    Public Sub enableBtn(ByVal pnl As Panel)
        For Each ctrl As Control In pnl.Controls
            With ctrl
                If TypeOf ctrl Is Button Then
                    .Enabled = True
                End If
            End With
        Next
    End Sub

#End Region

#Region "DISABLES FORMS CONTROL"

    Public Sub disableField()
        For Each ctrl As Control In billingRecordForm.Panel3.Controls
            With ctrl

                If TypeOf ctrl Is ComboBox Then
                    .Enabled = False
                End If

                If TypeOf ctrl Is Button Then
                    .Enabled = False
                End If

            End With
        Next
    End Sub
#End Region

#Region "ENABLES FORM CONTROL"

    Public Sub enableField()
        For Each ctrl As Control In billingRecordForm.Panel3.Controls
            With ctrl

                If TypeOf ctrl Is ComboBox Then
                    .Enabled = True
                End If

                If TypeOf ctrl Is Button Then
                    .Enabled = True
                End If

            End With
        Next
    End Sub
#End Region

End Module
