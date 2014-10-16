<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Register_Form))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.msgError5 = New System.Windows.Forms.Label()
        Me.msgError4 = New System.Windows.Forms.Label()
        Me.msgError3 = New System.Windows.Forms.Label()
        Me.msgError2 = New System.Windows.Forms.Label()
        Me.msgError1 = New System.Windows.Forms.Label()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tbConPassword = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.tbUsername = New System.Windows.Forms.TextBox()
        Me.tbLastname = New System.Windows.Forms.TextBox()
        Me.tbFirstname = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.msgError5)
        Me.Panel1.Controls.Add(Me.msgError4)
        Me.Panel1.Controls.Add(Me.msgError3)
        Me.Panel1.Controls.Add(Me.msgError2)
        Me.Panel1.Controls.Add(Me.msgError1)
        Me.Panel1.Controls.Add(Me.closeBtn)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.tbConPassword)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.tbPassword)
        Me.Panel1.Controls.Add(Me.tbUsername)
        Me.Panel1.Controls.Add(Me.tbLastname)
        Me.Panel1.Controls.Add(Me.tbFirstname)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(525, 504)
        Me.Panel1.TabIndex = 0
        '
        'msgError5
        '
        Me.msgError5.BackColor = System.Drawing.Color.Red
        Me.msgError5.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.msgError5.ForeColor = System.Drawing.Color.White
        Me.msgError5.Location = New System.Drawing.Point(196, 344)
        Me.msgError5.Name = "msgError5"
        Me.msgError5.Size = New System.Drawing.Size(270, 20)
        Me.msgError5.TabIndex = 62
        Me.msgError5.Text = "Please enter your Confirm Password"
        Me.msgError5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.msgError5.Visible = False
        '
        'msgError4
        '
        Me.msgError4.BackColor = System.Drawing.Color.Red
        Me.msgError4.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.msgError4.ForeColor = System.Drawing.Color.White
        Me.msgError4.Location = New System.Drawing.Point(196, 291)
        Me.msgError4.Name = "msgError4"
        Me.msgError4.Size = New System.Drawing.Size(270, 20)
        Me.msgError4.TabIndex = 61
        Me.msgError4.Text = "Please enter your Password"
        Me.msgError4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.msgError4.Visible = False
        '
        'msgError3
        '
        Me.msgError3.BackColor = System.Drawing.Color.Red
        Me.msgError3.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.msgError3.ForeColor = System.Drawing.Color.White
        Me.msgError3.Location = New System.Drawing.Point(196, 238)
        Me.msgError3.Name = "msgError3"
        Me.msgError3.Size = New System.Drawing.Size(270, 20)
        Me.msgError3.TabIndex = 60
        Me.msgError3.Text = "Please enter your Username"
        Me.msgError3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.msgError3.Visible = False
        '
        'msgError2
        '
        Me.msgError2.BackColor = System.Drawing.Color.Red
        Me.msgError2.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.msgError2.ForeColor = System.Drawing.Color.White
        Me.msgError2.Location = New System.Drawing.Point(196, 185)
        Me.msgError2.Name = "msgError2"
        Me.msgError2.Size = New System.Drawing.Size(270, 20)
        Me.msgError2.TabIndex = 59
        Me.msgError2.Text = "Please enter your Lastname"
        Me.msgError2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.msgError2.Visible = False
        '
        'msgError1
        '
        Me.msgError1.BackColor = System.Drawing.Color.Red
        Me.msgError1.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.msgError1.ForeColor = System.Drawing.Color.White
        Me.msgError1.Location = New System.Drawing.Point(196, 132)
        Me.msgError1.Name = "msgError1"
        Me.msgError1.Size = New System.Drawing.Size(270, 20)
        Me.msgError1.TabIndex = 58
        Me.msgError1.Text = "Please enter your Firstname"
        Me.msgError1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.msgError1.Visible = False
        '
        'closeBtn
        '
        Me.closeBtn.BackColor = System.Drawing.Color.White
        Me.closeBtn.FlatAppearance.BorderSize = 0
        Me.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue
        Me.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.closeBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.closeBtn.ForeColor = System.Drawing.Color.White
        Me.closeBtn.Image = CType(resources.GetObject("closeBtn.Image"), System.Drawing.Image)
        Me.closeBtn.Location = New System.Drawing.Point(497, -1)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(27, 24)
        Me.closeBtn.TabIndex = 57
        Me.closeBtn.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(60, 403)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(406, 33)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Create Account"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'tbConPassword
        '
        Me.tbConPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbConPassword.Location = New System.Drawing.Point(196, 321)
        Me.tbConPassword.MaxLength = 20
        Me.tbConPassword.Name = "tbConPassword"
        Me.tbConPassword.Size = New System.Drawing.Size(270, 23)
        Me.tbConPassword.TabIndex = 10
        Me.tbConPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbConPassword.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(57, 324)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Verify Password:"
        '
        'tbPassword
        '
        Me.tbPassword.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbPassword.Location = New System.Drawing.Point(196, 268)
        Me.tbPassword.MaxLength = 20
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.Size = New System.Drawing.Size(270, 23)
        Me.tbPassword.TabIndex = 8
        Me.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tbPassword.UseSystemPasswordChar = True
        '
        'tbUsername
        '
        Me.tbUsername.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbUsername.Location = New System.Drawing.Point(196, 215)
        Me.tbUsername.MaxLength = 15
        Me.tbUsername.Name = "tbUsername"
        Me.tbUsername.Size = New System.Drawing.Size(270, 23)
        Me.tbUsername.TabIndex = 7
        Me.tbUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbLastname
        '
        Me.tbLastname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbLastname.Location = New System.Drawing.Point(196, 162)
        Me.tbLastname.MaxLength = 30
        Me.tbLastname.Name = "tbLastname"
        Me.tbLastname.Size = New System.Drawing.Size(270, 23)
        Me.tbLastname.TabIndex = 6
        Me.tbLastname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbFirstname
        '
        Me.tbFirstname.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbFirstname.Location = New System.Drawing.Point(196, 109)
        Me.tbFirstname.MaxLength = 25
        Me.tbFirstname.Name = "tbFirstname"
        Me.tbFirstname.Size = New System.Drawing.Size(270, 23)
        Me.tbFirstname.TabIndex = 5
        Me.tbFirstname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(57, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(57, 218)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(57, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Lastname:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(57, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Firstname:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semilight", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(317, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Create an Account"
        '
        'Register_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(525, 504)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Register_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register_Form"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents tbUsername As System.Windows.Forms.TextBox
    Friend WithEvents tbLastname As System.Windows.Forms.TextBox
    Friend WithEvents tbFirstname As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tbConPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents closeBtn As System.Windows.Forms.Button
    Friend WithEvents msgError5 As System.Windows.Forms.Label
    Friend WithEvents msgError4 As System.Windows.Forms.Label
    Friend WithEvents msgError3 As System.Windows.Forms.Label
    Friend WithEvents msgError2 As System.Windows.Forms.Label
    Friend WithEvents msgError1 As System.Windows.Forms.Label
End Class
