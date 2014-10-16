Imports System.Text.RegularExpressions
Imports ComponentOwl.BetterListView

Public Class Patient_List

    Dim strItem As String
    Public pID As Integer
    Dim dbcomm As New DbCommands
    Dim patientID As Integer


    Private Sub Patient_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If titleLabel.Text = "Schedules" Then
            With dbcomm
                .AddParameter("@schedDate", Scheduling_Form.dte1, SqlDbType.Date)
                For Each drow As DataRow In .GetDataFromStoredProcedure("viewSchedule").Rows
                    Dim pListView As New BetterListViewItem("Patient ID: " & drow("p_ID").ToString)
                    pListView.SubItems.Add(drow("patientFname").ToString & " " & drow("patientLname").ToString)
                    pListView.SubItems.Add(drow("contactNo").ToString)

                    patientListView.Items.Add(pListView)
                Next
            End With
        End If
        If titleLabel.Text = "Patient List" Then
            patientListView.Items.Clear()
            With dbcomm
                .AddParameter("@patient_name", searchTb.Text, SqlDbType.VarChar)
                For Each dRow As DataRow In .GetDataFromStoredProcedure("getPatient").Rows
                    Dim pListView As New BetterListViewItem("Patient ID: " & dRow("p_ID").ToString)
                    pListView.SubItems.Add(dRow("patientFname").ToString & " " & dRow("patientLname").ToString)
                    pListView.SubItems.Add(dRow("patientHaddress").ToString)
                    pListView.SubItems.Add(dRow("contactNo").ToString)

                    patientListView.Items.Add(pListView)
                Next
            End With
        End If
        Me.BringToFront()
    End Sub

    Private Sub patientListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles patientListView.SelectedIndexChanged
        If titleLabel.Text = "Schedules" Then
            If Not patientListView.SelectedItems.Count = 0 Then '// check if item is selected.
                With patientListView.SelectedItems.Item(0)
                    strItem = patientListView.Items(patientListView.FocusedItem.Index).SubItems(0).Text

                    Dim reg As New Regex("[^0-9]")
                    strItem = reg.Replace(strItem, "")

                    Dim output As Integer
                    Integer.TryParse(strItem, output)

                    pID = output
                    Validations.enableBtn(Scheduling_Form.Panel3)
                End With
            End If

            Scheduling_Form.hrCmb.Enabled = True
            Scheduling_Form.minCmb.Enabled = True
            Scheduling_Form.saveBtn.Enabled = True
            Scheduling_Form.editBtn.Enabled = True
            Scheduling_Form.cancelBtn.Enabled = True
        With dbcomm
            .AddParameter("@p_ID", pID, SqlDbType.Int)
            For Each dRow As DataRow In .GetDataFromStoredProcedure("getSelectedPatient").Rows
                Scheduling_Form.lastnameTb.Text = dRow("patientLname")
                Scheduling_Form.miTb.Text = dRow("patientIname")
                Scheduling_Form.firstnameTb.Text = dRow("patientFname")
                Scheduling_Form.genderTb.Text = dRow("gender")
                Scheduling_Form.homeAddressTb.Text = dRow("patientHaddress")
                Scheduling_Form.pAddress.Text = dRow("patientPaddress")
                Scheduling_Form.mobileContactTb.Text = dRow("contactNo")
                Scheduling_Form.dobTB.Text = dRow("Dob")
            Next

            Scheduling_Form.ListView1.Items.Clear()
            Scheduling_Form.tCountCmbx.Items.Clear()
            .AddParameter("@p_ID", pID, SqlDbType.Int)
            For Each dtaRow As DataRow In .GetDataFromStoredProcedure("dispRecord").Rows
                Scheduling_Form.ListView1.Items.Add(dtaRow("details").ToString).SubItems.Add(dtaRow("tCount").ToString)
                Scheduling_Form.tCountCmbx.Items.Add(dtaRow("tCount").ToString)
            Next
        End With

        Scheduling_Form.patient_Id = pID

        If pID = Nothing Then
            disableField()
        Else
            enableField()
        End If

        ElseIf titleLabel.Text = "Patient List" Then
        If Not patientListView.SelectedItems.Count = 0 Then '// check if item is selected.
            With patientListView.SelectedItems.Item(0)
                strItem = patientListView.Items(patientListView.FocusedItem.Index).SubItems(0).Text

                Dim reg As New Regex("[^0-9]")
                strItem = reg.Replace(strItem, "")

                Dim output As Integer
                Integer.TryParse(strItem, output)

                pID = output
                Validations.enableBtn(Scheduling_Form.Panel3)
            End With
        End If

        With dbcomm
            patientForm__2_.patient_ID = pID
            .AddParameter("@p_ID", pID, SqlDbType.Int)
            For Each dRow As DataRow In .GetDataFromStoredProcedure("getSelectedPatient").Rows
                patientForm__2_.lastnameTb.Text = dRow("patientLname")
                patientForm__2_.miTb.Text = dRow("patientIname")
                patientForm__2_.firstnameTb.Text = dRow("patientFname")
                patientForm__2_.genderCmbx.Text = dRow("gender")
                patientForm__2_.homeAddressTb.Text = dRow("patientHaddress")
                patientForm__2_.pAddress.Text = dRow("patientPaddress")
                patientForm__2_.mobileContactTb.Text = dRow("contactNo")
                    patientForm__2_.dobPicker.Text = dRow("Dob")
                Next

                .AddParameter("@p_ID", pID, SqlDbType.Int)
                For Each dtaRow As DataRow In .GetDataFromStoredProcedure("dispRecord").Rows
                    patientForm__2_.ListView1.Items.Add(dtaRow("details").ToString).SubItems.Add(dtaRow("tCount").ToString)
                Next

                .AddParameter("@p_ID", pID, SqlDbType.Int)
                For Each dRow As DataRow In .GetDataFromStoredProcedure("getSelectedPatient").Rows
                    PatientProfile.lastnameTb.Text = dRow("patientLname")
                    PatientProfile.miTb.Text = dRow("patientIname")
                    PatientProfile.firstnameTb.Text = dRow("patientFname")
                    PatientProfile.genderTb.Text = dRow("gender")
                    PatientProfile.homeAddressTb.Text = dRow("patientHaddress")
                    PatientProfile.pAddress.Text = dRow("patientPaddress")
                    PatientProfile.mobileContactTb.Text = dRow("contactNo")
                    PatientProfile.dobTB.Text = dRow("Dob")
                Next
                PatientProfile.ListView1.Items.Clear()
                .AddParameter("@p_ID", pID, SqlDbType.Int)
                For Each dtaRow As DataRow In .GetDataFromStoredProcedure("dispRecord").Rows
                    PatientProfile.ListView1.Items.Add(dtaRow("details").ToString).SubItems.Add(dtaRow("tCount").ToString)
                Next
                .AddParameter("@p_ID", pID, SqlDbType.Int)
                For Each dtaRow As DataRow In .GetDataFromStoredProcedure("getHistory").Rows
                    PatientProfile.TextBox1.Text = dtaRow("tongue")
                    PatientProfile.TextBox2.Text = dtaRow("fom")
                    PatientProfile.TextBox3.Text = dtaRow("bd")
                    PatientProfile.TextBox4.Text = dtaRow("palate")
                    PatientProfile.TextBox5.Text = dtaRow("cheeks")
                    PatientProfile.TextBox6.Text = dtaRow("diabetes")
                    PatientProfile.TextBox7.Text = dtaRow("Hygiene")
                    PatientProfile.TextBox8.Text = dtaRow("tonsils")
                    PatientProfile.TextBox9.Text = dtaRow("allergies")
                    PatientProfile.TextBox10.Text = dtaRow("kidney")
                    PatientProfile.TextBox11.Text = dtaRow("lips")
                    PatientProfile.TextBox12.Text = dtaRow("hDisease")
                    PatientProfile.TextBox13.Text = dtaRow("liver")
                Next
            End With
            If pID = Nothing Then
                disableField()
            Else
                enableField()
            End If
        End If

    End Sub

    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub searchTb_TextChanged(sender As Object, e As EventArgs) Handles searchTb.TextChanged
        If titleLabel.Text = "Schedules" Then

            patientListView.Items.Clear()
            With dbcomm
                .AddParameter("@patient_name", searchTb.Text, SqlDbType.VarChar)
                .AddParameter("@schedDate", Scheduling_Form.dte1, SqlDbType.Date)
                For Each drow As DataRow In .GetDataFromStoredProcedure("getList").Rows

                    'patientListView.Items.Add("Patient ID# " & drow("p_ID").ToString & " ").SubItems.Add(drow("patientFname") & " " & drow("patientLname").ToString)
                    Dim pListView As New BetterListViewItem("Patient ID: " & drow("p_ID").ToString)
                    pListView.SubItems.Add(drow("patientFname").ToString & " " & drow("patientLname").ToString)
                    pListView.SubItems.Add(drow("patientHaddress").ToString)
                    pListView.SubItems.Add(drow("contactNo").ToString)

                    patientListView.Items.Add(pListView)
                Next

                If searchTb.Text = "" Then
                    patientListView.Items.Clear()
                    .AddParameter("@schedDate", Scheduling_Form.dte1, SqlDbType.Date)
                    For Each drow As DataRow In .GetDataFromStoredProcedure("viewSchedule").Rows
                        Dim pListView As New BetterListViewItem("Patient ID: " & drow("p_ID").ToString)
                        pListView.SubItems.Add(drow("patientFname").ToString & " " & drow("patientLname").ToString)
                        pListView.SubItems.Add(drow("patientHaddress").ToString)
                        pListView.SubItems.Add(drow("contactNo").ToString)

                        patientListView.Items.Add(pListView)
                    Next
                End If
            End With
        ElseIf titleLabel.Text = "Patient List" Then
            patientListView.Items.Clear()
            With dbcomm
                .AddParameter("@patient_name", searchTb.Text, SqlDbType.VarChar)

                For Each drow As DataRow In .GetDataFromStoredProcedure("getPatient").Rows

                    'patientListView.Items.Add("Patient ID# " & drow("p_ID").ToString & " ").SubItems.Add(drow("patientFname") & " " & drow("patientLname").ToString)
                    Dim pListView As New BetterListViewItem("Patient ID: " & drow("p_ID").ToString)
                    pListView.SubItems.Add(drow("patientFname").ToString & " " & drow("patientLname").ToString)
                    pListView.SubItems.Add(drow("patientHaddress").ToString)
                    pListView.SubItems.Add(drow("contactNo").ToString)

                    patientListView.Items.Add(pListView)
                Next

                If searchTb.Text = "" Then
                    patientListView.Items.Clear()
                    For Each drow As DataRow In .GetDataFromStoredProcedure("getPatientList").Rows
                        Dim pListView As New BetterListViewItem("Patient ID: " & drow("p_ID").ToString)
                        pListView.SubItems.Add(drow("patientFname").ToString & " " & drow("patientLname").ToString)
                        pListView.SubItems.Add(drow("patientHaddress").ToString)
                        pListView.SubItems.Add(drow("contactNo").ToString)

                        patientListView.Items.Add(pListView)
                    Next
                End If
            End With
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class