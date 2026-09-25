<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Button1 = New Button()
        CheckBox1 = New CheckBox()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button6 = New Button()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        Button7 = New Button()
        SaveFileDialog1 = New SaveFileDialog()
        SaveFileDialog2 = New SaveFileDialog()
        TextBox4 = New TextBox()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = SystemColors.Window
        Button1.Font = New Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(189, 9)
        Button1.Name = "Button1"
        Button1.Size = New Size(123, 36)
        Button1.TabIndex = 0
        Button1.Text = "PerformAnalysis"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' CheckBox1
        ' 
        CheckBox1.Anchor = AnchorStyles.None
        CheckBox1.AutoSize = True
        CheckBox1.BackColor = SystemColors.Window
        CheckBox1.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBox1.Location = New Point(17, 12)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(166, 19)
        CheckBox1.TabIndex = 1
        CheckBox1.Text = "PickUniqueTrueIfChecked"
        CheckBox1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.BackColor = SystemColors.Window
        Button2.Font = New Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.Location = New Point(318, 9)
        Button2.Name = "Button2"
        Button2.Size = New Size(101, 36)
        Button2.TabIndex = 2
        Button2.Text = "ClearInput"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.None
        Button3.BackColor = SystemColors.Window
        Button3.Font = New Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.Location = New Point(425, 9)
        Button3.Name = "Button3"
        Button3.Size = New Size(123, 36)
        Button3.TabIndex = 3
        Button3.Text = "ClearOutput-1"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.None
        Button4.BackColor = SystemColors.Window
        Button4.Font = New Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(552, 8)
        Button4.Name = "Button4"
        Button4.Size = New Size(123, 37)
        Button4.TabIndex = 4
        Button4.Text = "ClearOutput-2"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.None
        Button6.BackColor = SystemColors.Window
        Button6.Font = New Font("Times New Roman", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button6.Location = New Point(794, 9)
        Button6.Name = "Button6"
        Button6.Size = New Size(123, 36)
        Button6.TabIndex = 6
        Button6.Text = "SaveOutput-2 "
        Button6.UseVisualStyleBackColor = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Anchor = AnchorStyles.None
        TextBox1.Font = New Font("Times New Roman", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(17, 51)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.ScrollBars = ScrollBars.Both
        TextBox1.Size = New Size(902, 89)
        TextBox1.TabIndex = 7
        ' 
        ' TextBox2
        ' 
        TextBox2.Anchor = AnchorStyles.None
        TextBox2.Font = New Font("Times New Roman", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.Location = New Point(17, 146)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.ScrollBars = ScrollBars.Both
        TextBox2.Size = New Size(902, 100)
        TextBox2.TabIndex = 8
        ' 
        ' TextBox3
        ' 
        TextBox3.Anchor = AnchorStyles.None
        TextBox3.Font = New Font("Times New Roman", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox3.Location = New Point(19, 252)
        TextBox3.Multiline = True
        TextBox3.Name = "TextBox3"
        TextBox3.ScrollBars = ScrollBars.Both
        TextBox3.Size = New Size(902, 104)
        TextBox3.TabIndex = 9
        ' 
        ' Button7
        ' 
        Button7.Anchor = AnchorStyles.None
        Button7.BackColor = SystemColors.Window
        Button7.Font = New Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button7.Location = New Point(681, 8)
        Button7.Name = "Button7"
        Button7.Size = New Size(109, 37)
        Button7.TabIndex = 10
        Button7.Text = "SaveOutput-1"
        Button7.UseVisualStyleBackColor = False
        ' 
        ' TextBox4
        ' 
        TextBox4.Anchor = AnchorStyles.None
        TextBox4.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox4.Location = New Point(19, 362)
        TextBox4.Multiline = True
        TextBox4.Name = "TextBox4"
        TextBox4.ScrollBars = ScrollBars.Both
        TextBox4.Size = New Size(900, 115)
        TextBox4.TabIndex = 11
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(933, 501)
        Controls.Add(TextBox4)
        Controls.Add(Button7)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Button6)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(CheckBox1)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button7 As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents SaveFileDialog2 As SaveFileDialog
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Button5 As Button

End Class
