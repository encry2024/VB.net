Imports System.IO.Ports

Public Class mainForm

    Dim SerialPort1 As New System.IO.Ports.SerialPort()
    Dim records As String
    Dim dbComm As New DbCommands
    Dim message As String
    Dim status As String

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tmrTb.Text = Date.Now.ToString("MMMM dd, yyyy")
        TextBox1.Text = DateTime.Now.ToLongTimeString


    End Sub

    Private Sub bRecordBtn_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Animations.fade_out(Me)
        Me.Hide()

        Animations.fade_in(billingRecordForm)
        billingRecordForm.Show()
    End Sub

    Private Sub pRecordBtn_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Animations.fade_out(Me)
        Me.Hide()

        Animations.fade_in(patientForm__2_)
        patientForm__2_.Show()
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles logouBtn.MouseEnter
        Animations.changeForeColorButtonToWhite(logouBtn)
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles logouBtn.MouseLeave
        Animations.changeForeColorButtonToBlack(logouBtn)
    End Sub

    Private Sub Button4_MouseEnter(sender As Object, e As EventArgs) Handles changePBtn.MouseEnter
        Animations.changeForeColorButtonToWhite(changePBtn)
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles changePBtn.MouseLeave
        Animations.changeForeColorButtonToBlack(changePBtn)
    End Sub

    Private Sub logouBtn_Click(sender As Object, e As EventArgs) Handles logouBtn.Click
        Animations.fade_out(Me)
        Me.Close()

        Animations.fade_in(loginForm)
        loginForm.Show()
    End Sub

    Private Sub aRecordBtn_Click(sender As Object, e As EventArgs) Handles aRecordBtn.Click
        Animations.fade_out(Me)
        Me.Hide()

        Animations.fade_in(Scheduling_Form)
        Scheduling_Form.Show()
    End Sub

    Private Sub createOperationBtn_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Animations.fade_out(Me)
        Me.Hide()

        Animations.fade_in(operationForm)
        operationForm.Show()
    End Sub

    Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Animations.fade_in(Me)
        Label1.Focus()

        SerialPort1.PortName = "COM3"
        SerialPort1.BaudRate = 9600
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.Two
        SerialPort1.DataBits = 8
        SerialPort1.Handshake = Handshake.RequestToSend
        SerialPort1.DtrEnable = True
        SerialPort1.RtsEnable = True
        SerialPort1.NewLine = vbCrLf

        With dbComm
            For Each dRow As DataRow In .GetDataFromStoredProcedure("sp_CheckUser").Rows
                status = dRow("sttus").ToString
            Next
        End With

        If status = "Assistant" Then
            regAssistant.Visible = False
        Else
            regAssistant.Visible = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Animations.fade_out(Me)
        Me.Hide()

        Form5.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If (TextBox1.Text = "4:00:00 PM") Then
            With dbComm
                .AddParameter("schedDate", DateTime.Now.ToString("MMMM dd, yyyy"), SqlDbType.Date)
                SerialPort1.Open()
                For Each dRow As DataRow In .GetDataFromStoredProcedure("viewscehed").Rows
                    If SerialPort1.IsOpen() Then
                        message = "Greetings, " & dRow("patientFname").ToString & " " & dRow("patientLname").ToString & ". This is Dangay Dental Clinic. Your Appointment for tomorrow is: " & DateTime.Now.AddDays(1).ToString("MMMM dd, yyyy") & " From: " & dRow("sched_time_in").ToString & " to " & dRow("sched_time_out").ToString & ". -Dr. Ang-"
                        SerialPort1.Write("AT" & vbCrLf)
                        SerialPort1.Write("AT+CMGF=1" & vbCrLf)
                        SerialPort1.Write("AT+CMGS=" & Chr(34) & dRow("contactNo") & Chr(34) & vbCrLf)
                        SerialPort1.Write(message & Chr(26))
                        message = Nothing
                    Else
                        MsgBox("Port not available")
                    End If
                Next
                SerialPort1.Close()
            End With
            MsgBox("A message for scheduled patients has been sent.")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles regAssistant.Click
        Register_Form.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Animations.fade_out(Me)
        Me.Hide()

        Animations.fade_in(PatientProfile)
        PatientProfile.Show()
    End Sub
End Class