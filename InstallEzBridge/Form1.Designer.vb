<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxEZ = New System.Windows.Forms.TextBox()
        Me.TextBoxTV = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ButtonBrowseEZ = New System.Windows.Forms.Button()
        Me.ButtonBrowseTV = New System.Windows.Forms.Button()
        Me.ButtonConfigure = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxBridgeName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxTiger1IniPath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "EzDental Program Folder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TigerView Folder"
        '
        'TextBoxEZ
        '
        Me.TextBoxEZ.Location = New System.Drawing.Point(169, 32)
        Me.TextBoxEZ.Name = "TextBoxEZ"
        Me.TextBoxEZ.Size = New System.Drawing.Size(262, 20)
        Me.TextBoxEZ.TabIndex = 2
        '
        'TextBoxTV
        '
        Me.TextBoxTV.Location = New System.Drawing.Point(169, 64)
        Me.TextBoxTV.Name = "TextBoxTV"
        Me.TextBoxTV.Size = New System.Drawing.Size(262, 20)
        Me.TextBoxTV.TabIndex = 3
        '
        'ButtonBrowseEZ
        '
        Me.ButtonBrowseEZ.Location = New System.Drawing.Point(469, 29)
        Me.ButtonBrowseEZ.Name = "ButtonBrowseEZ"
        Me.ButtonBrowseEZ.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBrowseEZ.TabIndex = 4
        Me.ButtonBrowseEZ.Text = "Browse..."
        Me.ButtonBrowseEZ.UseVisualStyleBackColor = True
        '
        'ButtonBrowseTV
        '
        Me.ButtonBrowseTV.Location = New System.Drawing.Point(469, 64)
        Me.ButtonBrowseTV.Name = "ButtonBrowseTV"
        Me.ButtonBrowseTV.Size = New System.Drawing.Size(75, 23)
        Me.ButtonBrowseTV.TabIndex = 5
        Me.ButtonBrowseTV.Text = "Browse..."
        Me.ButtonBrowseTV.UseVisualStyleBackColor = True
        '
        'ButtonConfigure
        '
        Me.ButtonConfigure.Location = New System.Drawing.Point(282, 165)
        Me.ButtonConfigure.Name = "ButtonConfigure"
        Me.ButtonConfigure.Size = New System.Drawing.Size(75, 23)
        Me.ButtonConfigure.TabIndex = 6
        Me.ButtonConfigure.Text = "Configure"
        Me.ButtonConfigure.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "BridgeName"
        '
        'TextBoxBridgeName
        '
        Me.TextBoxBridgeName.Location = New System.Drawing.Point(169, 91)
        Me.TextBoxBridgeName.Name = "TextBoxBridgeName"
        Me.TextBoxBridgeName.Size = New System.Drawing.Size(262, 20)
        Me.TextBoxBridgeName.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(84, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 9
        '
        'TextBoxTiger1IniPath
        '
        Me.TextBoxTiger1IniPath.Location = New System.Drawing.Point(169, 121)
        Me.TextBoxTiger1IniPath.Name = "TextBoxTiger1IniPath"
        Me.TextBoxTiger1IniPath.Size = New System.Drawing.Size(262, 20)
        Me.TextBoxTiger1IniPath.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Tiger1.ini Path"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 204)
        Me.Controls.Add(Me.TextBoxTiger1IniPath)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxBridgeName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonConfigure)
        Me.Controls.Add(Me.ButtonBrowseTV)
        Me.Controls.Add(Me.ButtonBrowseEZ)
        Me.Controls.Add(Me.TextBoxTV)
        Me.Controls.Add(Me.TextBoxEZ)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxEZ As TextBox
    Friend WithEvents TextBoxTV As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ButtonBrowseEZ As Button
    Friend WithEvents ButtonBrowseTV As Button
    Friend WithEvents ButtonConfigure As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxBridgeName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxTiger1IniPath As TextBox
    Friend WithEvents Label5 As Label
End Class
