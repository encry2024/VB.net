Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.IO.Ports
Public Class Sms
    Dim SerialPort1 As New System.IO.Ports.SerialPort()
    Dim dbComm As New DbCommands
    Dim strItem As String
    Private Sub Sms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each cmbCollection As Control In Panel1.Controls
            With cmbCollection
                .Enabled = True
                .Visible = True
            End With
        Next
        ComboBox1.Items.Clear()
        With dbComm

            For Each dRow As DataRow In .GetDataFromStoredProcedure("getPatientList").Rows
                ComboBox1.Items.Add("Patient ID# " & dRow("p_ID") & " | Patient Lastname: " & dRow("patientLname"))
            Next
        End With
        ComboBox1.SelectedIndex = 0
        SerialPort1.PortName = "COM3"
        SerialPort1.BaudRate = 9600
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.DataBits = 8
        SerialPort1.Handshake = Handshake.RequestToSend
        SerialPort1.DtrEnable = True
        SerialPort1.RtsEnable = True
        SerialPort1.NewLine = vbCrLf

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        With dbComm
            strItem = ComboBox1.Text
            Dim reg As New Regex("[^0-9]")
            strItem = reg.Replace(strItem, "")

            Dim output As Integer
            Integer.TryParse(strItem, output)
            .AddParameter("@p_ID", output, SqlDbType.Int)
            For Each drow As DataRow In .GetDataFromStoredProcedure("getSelectedPatient").Rows
                Label1.Text = drow("patientLname") & " " & drow("patientFname") & " " & drow("patientIname")
                Label3.Text = drow("contactNo")
            Next
        End With
    End Sub

    Private Sub sendBtn_Click(sender As Object, e As EventArgs) Handles sendBtn.Click
        Dim message As String
        message = RichTextBox1.Text
        SerialPort1.Open()
        If SerialPort1.IsOpen() Then
            SerialPort1.Write("AT" & vbCrLf)
            SerialPort1.Write("AT+CMGF=1" & vbCrLf)
            SerialPort1.Write("AT+CMGS=" & Chr(34) & Label3.Text & Chr(34) & vbCrLf)
            SerialPort1.Write(message & Chr(26))
            MsgBox("Sent")
        Else
            MsgBox("Port not available")
        End If
        SerialPort1.Close()
    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
        Scheduling_Form.Show()
    End Sub
End Class