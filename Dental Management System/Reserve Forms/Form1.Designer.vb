<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.controlContainerPanel = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.aRecordContainerPanel = New System.Windows.Forms.Panel()
        Me.aRecordPanel = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.aDeleteBtn = New System.Windows.Forms.Button()
        Me.aSearchBtn = New System.Windows.Forms.Button()
        Me.aEditBtn = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.aRecordBtn = New System.Windows.Forms.Button()
        Me.controlContainerPanel.SuspendLayout()
        Me.aRecordContainerPanel.SuspendLayout()
        Me.aRecordPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'controlContainerPanel
        '
        Me.controlContainerPanel.AutoScroll = True
        Me.controlContainerPanel.Controls.Add(Me.Label12)
        Me.controlContainerPanel.Controls.Add(Me.aRecordContainerPanel)
        Me.controlContainerPanel.Controls.Add(Me.Panel3)
        Me.controlContainerPanel.Location = New System.Drawing.Point(0, 12)
        Me.controlContainerPanel.Name = "controlContainerPanel"
        Me.controlContainerPanel.Size = New System.Drawing.Size(860, 527)
        Me.controlContainerPanel.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Location = New System.Drawing.Point(5, 414)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 32)
        Me.Label12.TabIndex = 103
        Me.Label12.Text = "Notification:"
        '
        'aRecordContainerPanel
        '
        Me.aRecordContainerPanel.AutoSize = True
        Me.aRecordContainerPanel.Controls.Add(Me.aRecordPanel)
        Me.aRecordContainerPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.aRecordContainerPanel.Location = New System.Drawing.Point(0, 0)
        Me.aRecordContainerPanel.Name = "aRecordContainerPanel"
        Me.aRecordContainerPanel.Size = New System.Drawing.Size(860, 52)
        Me.aRecordContainerPanel.TabIndex = 29
        '
        'aRecordPanel
        '
        Me.aRecordPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.aRecordPanel.Controls.Add(Me.Button1)
        Me.aRecordPanel.Controls.Add(Me.aRecordBtn)
        Me.aRecordPanel.Controls.Add(Me.aDeleteBtn)
        Me.aRecordPanel.Controls.Add(Me.aSearchBtn)
        Me.aRecordPanel.Controls.Add(Me.aEditBtn)
        Me.aRecordPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.aRecordPanel.Location = New System.Drawing.Point(0, 0)
        Me.aRecordPanel.Name = "aRecordPanel"
        Me.aRecordPanel.Size = New System.Drawing.Size(860, 52)
        Me.aRecordPanel.TabIndex = 26
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(38, 72)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 33)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Set Patient Appointment"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'aDeleteBtn
        '
        Me.aDeleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.aDeleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.aDeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aDeleteBtn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aDeleteBtn.ForeColor = System.Drawing.Color.White
        Me.aDeleteBtn.Location = New System.Drawing.Point(38, 189)
        Me.aDeleteBtn.Name = "aDeleteBtn"
        Me.aDeleteBtn.Size = New System.Drawing.Size(150, 33)
        Me.aDeleteBtn.TabIndex = 7
        Me.aDeleteBtn.Text = "Delete Appointment"
        Me.aDeleteBtn.UseVisualStyleBackColor = True
        '
        'aSearchBtn
        '
        Me.aSearchBtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.aSearchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.aSearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aSearchBtn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aSearchBtn.ForeColor = System.Drawing.Color.White
        Me.aSearchBtn.Location = New System.Drawing.Point(38, 111)
        Me.aSearchBtn.Name = "aSearchBtn"
        Me.aSearchBtn.Size = New System.Drawing.Size(150, 33)
        Me.aSearchBtn.TabIndex = 6
        Me.aSearchBtn.Text = "Search Appointment"
        Me.aSearchBtn.UseVisualStyleBackColor = True
        '
        'aEditBtn
        '
        Me.aEditBtn.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue
        Me.aEditBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.aEditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aEditBtn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.aEditBtn.ForeColor = System.Drawing.Color.White
        Me.aEditBtn.Location = New System.Drawing.Point(38, 150)
        Me.aEditBtn.Name = "aEditBtn"
        Me.aEditBtn.Size = New System.Drawing.Size(150, 33)
        Me.aEditBtn.TabIndex = 8
        Me.aEditBtn.Text = "Edit Appointment"
        Me.aEditBtn.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.AutoSize = True
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(860, 0)
        Me.Panel3.TabIndex = 2
        '
        'aRecordBtn
        '
        Me.aRecordBtn.BackColor = System.Drawing.Color.Transparent
        Me.aRecordBtn.Dock = System.Windows.Forms.DockStyle.Top
        Me.aRecordBtn.FlatAppearance.BorderSize = 0
        Me.aRecordBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.aRecordBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.aRecordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aRecordBtn.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.aRecordBtn.ForeColor = System.Drawing.Color.White
        Me.aRecordBtn.Image = CType(resources.GetObject("aRecordBtn.Image"), System.Drawing.Image)
        Me.aRecordBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.aRecordBtn.Location = New System.Drawing.Point(0, 0)
        Me.aRecordBtn.Name = "aRecordBtn"
        Me.aRecordBtn.Size = New System.Drawing.Size(860, 52)
        Me.aRecordBtn.TabIndex = 5
        Me.aRecordBtn.Text = "Appointment Records"
        Me.aRecordBtn.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 523)
        Me.Controls.Add(Me.controlContainerPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.controlContainerPanel.ResumeLayout(False)
        Me.controlContainerPanel.PerformLayout()
        Me.aRecordContainerPanel.ResumeLayout(False)
        Me.aRecordPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents controlContainerPanel As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents aRecordContainerPanel As System.Windows.Forms.Panel
    Friend WithEvents aRecordPanel As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents aDeleteBtn As System.Windows.Forms.Button
    Friend WithEvents aSearchBtn As System.Windows.Forms.Button
    Friend WithEvents aEditBtn As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents aRecordBtn As System.Windows.Forms.Button
End Class
