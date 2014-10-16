Module Animations


#Region "FADE-IN AND FADE-OUT REGION"

    Public Sub fade_in(ByVal frm As Form)
        For FadeIn = 0.0 To 1.1 Step 0.1
            frm.Opacity = FadeIn
            frm.Refresh()
            Threading.Thread.Sleep(5)
        Next
    End Sub

    Public Sub fade_out(ByVal frm As Form)
        For FadeOut = 90 To 10 Step -10
            frm.Opacity = FadeOut / 100
            frm.Refresh()
            Threading.Thread.Sleep(5)
        Next
    End Sub

#End Region

#Region "THIS REGION SLIDES UP AND DOWN THE PANELS IN THE BUTTONS: PRECORD, BRECORD, ARECORD."

    Public Sub Slide_down(ByVal pnl As Panel, ByVal height As Integer)
        If pnl.Height < height Then
            Do While pnl.Height < height
                pnl.Height += 1

                Threading.Thread.Sleep(2)
            Loop
        End If
    End Sub

    Public Sub Slide_up(ByVal pnl As Panel, ByVal height As Integer)
        If pnl.Height > height Then
            Do While pnl.Height > height
                pnl.Height -= 1

                Threading.Thread.Sleep(2)
            Loop
        End If
    End Sub

#End Region

#Region "BUTTON BACKCOLOR"

    Public Sub btnBackColor(ByVal btn As Button)
        btn.BackColor = Color.FromArgb(0, 105, 105)
    End Sub

    Public Sub btnReturnColor(ByVal btn As Button)
        btn.BackColor = Color.Transparent
    End Sub

#End Region

#Region "Forecolor Animation Label"

    Public Sub changeForeColor(ByVal lblName As Label, ByVal titleStr As String)
        Dim colorCodegb As Integer = 0
        lblName.Text = ""
        Do While colorCodegb < 255
            colorCodegb += 1
            lblName.Refresh()
            lblName.ForeColor = Color.FromArgb(colorCodegb, colorCodegb, colorCodegb)
            Threading.Thread.Sleep(0.5)
        Loop

        lblName.Text = titleStr
        Do While colorCodegb > 0
            colorCodegb -= 1
            lblName.Refresh()
            lblName.ForeColor = Color.FromArgb(colorCodegb, colorCodegb, colorCodegb)
            Threading.Thread.Sleep(0.5)
        Loop
    End Sub

#End Region

#Region "Forecolor Animation Button"

    Public Sub changeForeColorButton(ByVal btnName As Button, ByVal btnTitle As String)
        Dim colorCodegb As Integer = 0

        Do While colorCodegb < 255
            colorCodegb += 1
            btnName.Refresh()
            btnName.ForeColor = Color.FromArgb(colorCodegb, colorCodegb, colorCodegb)
            Threading.Thread.Sleep(0.5)

        Loop

        btnName.Text = btnTitle
        Do While colorCodegb > 0
            colorCodegb -= 1
            btnName.Refresh()
            btnName.ForeColor = Color.FromArgb(colorCodegb, colorCodegb, colorCodegb)
            Threading.Thread.Sleep(0.5)
        Loop
    End Sub

#End Region

#Region "ANIMATION MOUSE HOVER"

    Public Sub changeForeColorButtonToWhite(ByVal btnName As Button)
        Dim colorCodegb As Integer = 40

        Do While colorCodegb < 255
            colorCodegb += 1
            btnName.Refresh()
            btnName.ForeColor = Color.FromArgb(colorCodegb, colorCodegb, colorCodegb)
            Threading.Thread.Sleep(0.5)
        Loop
    End Sub

    Public Sub changeForeColorButtonToBlack(ByVal btnName As Button)
        Dim colorCodegb As Integer = 255

        Do While colorCodegb > 0
            colorCodegb -= 1
            btnName.Refresh()
            btnName.ForeColor = Color.FromArgb(colorCodegb, colorCodegb, colorCodegb)
            Threading.Thread.Sleep(0.5)
        Loop
    End Sub
#End Region

#Region "ANIMATION BUTTON BACKGROUND HOVER"
    Public Sub changeBackColorButton1(ByVal btnName As Button, ByVal btnTitle As String)
        Dim colorCodegb As Integer = 255

        Do While colorCodegb > 40
            colorCodegb -= 1
            btnName.Refresh()
            btnName.BackColor = Color.FromArgb(colorCodegb, colorCodegb, colorCodegb)
            Threading.Thread.Sleep(0.5)

        Loop
    End Sub
#End Region


    'Sample Comment
End Module
