<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.starTimer = New System.Windows.Forms.Timer(Me.components)
        Me.o2bar = New System.Windows.Forms.Timer(Me.components)
        Me.hpBar = New System.Windows.Forms.Timer(Me.components)
        Me.invenTimer = New System.Windows.Forms.Timer(Me.components)
        Me.shopTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GoldLabel = New System.Windows.Forms.Label()
        Me.alien_Text = New System.Windows.Forms.Label()
        Me.saleList = New System.Windows.Forms.Label()
        Me.character_Text = New System.Windows.Forms.Label()
        Me.pausedTimer = New System.Windows.Forms.Timer(Me.components)
        Me.gameoverTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 33
        '
        'starTimer
        '
        Me.starTimer.Interval = 1000
        '
        'o2bar
        '
        Me.o2bar.Interval = 10000
        '
        'hpBar
        '
        Me.hpBar.Interval = 5000
        '
        'invenTimer
        '
        Me.invenTimer.Interval = 33
        '
        'shopTimer
        '
        Me.shopTimer.Interval = 33
        '
        'GoldLabel
        '
        Me.GoldLabel.AutoSize = True
        Me.GoldLabel.BackColor = System.Drawing.Color.Transparent
        Me.GoldLabel.Font = New System.Drawing.Font("휴먼둥근헤드라인", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GoldLabel.ForeColor = System.Drawing.Color.White
        Me.GoldLabel.Location = New System.Drawing.Point(70, 117)
        Me.GoldLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.GoldLabel.Name = "GoldLabel"
        Me.GoldLabel.Size = New System.Drawing.Size(0, 17)
        Me.GoldLabel.TabIndex = 0
        '
        'alien_Text
        '
        Me.alien_Text.AutoSize = True
        Me.alien_Text.BackColor = System.Drawing.Color.Transparent
        Me.alien_Text.Font = New System.Drawing.Font("맑은 고딕", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.alien_Text.ForeColor = System.Drawing.Color.LawnGreen
        Me.alien_Text.Location = New System.Drawing.Point(858, 193)
        Me.alien_Text.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.alien_Text.Name = "alien_Text"
        Me.alien_Text.Size = New System.Drawing.Size(84, 19)
        Me.alien_Text.TabIndex = 1
        Me.alien_Text.Text = "외계인 대사"
        Me.alien_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.alien_Text.Visible = False
        '
        'saleList
        '
        Me.saleList.AutoSize = True
        Me.saleList.BackColor = System.Drawing.Color.Transparent
        Me.saleList.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.saleList.ForeColor = System.Drawing.Color.White
        Me.saleList.Location = New System.Drawing.Point(593, 193)
        Me.saleList.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.saleList.Name = "saleList"
        Me.saleList.Size = New System.Drawing.Size(67, 15)
        Me.saleList.TabIndex = 2
        Me.saleList.Text = "판매리스트"
        Me.saleList.Visible = False
        '
        'character_Text
        '
        Me.character_Text.AutoSize = True
        Me.character_Text.BackColor = System.Drawing.Color.Transparent
        Me.character_Text.Font = New System.Drawing.Font("휴먼둥근헤드라인", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.character_Text.ForeColor = System.Drawing.Color.White
        Me.character_Text.Location = New System.Drawing.Point(11, 154)
        Me.character_Text.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.character_Text.Name = "character_Text"
        Me.character_Text.Size = New System.Drawing.Size(149, 16)
        Me.character_Text.TabIndex = 3
        Me.character_Text.Text = "인벤토리가 다 찼어!"
        Me.character_Text.Visible = False
        '
        'pausedTimer
        '
        Me.pausedTimer.Interval = 33
        '
        'gameoverTimer
        '
        Me.gameoverTimer.Interval = 33
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.game.My.Resources.Resources.bg
        Me.ClientSize = New System.Drawing.Size(1584, 861)
        Me.Controls.Add(Me.character_Text)
        Me.Controls.Add(Me.saleList)
        Me.Controls.Add(Me.alien_Text)
        Me.Controls.Add(Me.GoldLabel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MiningStar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents starTimer As Timer
    Friend WithEvents o2bar As Timer
    Friend WithEvents hpBar As Timer
    Friend WithEvents invenTimer As Timer
    Friend WithEvents shopTimer As Timer
    Friend WithEvents GoldLabel As Label
    Friend WithEvents alien_Text As Label
    Friend WithEvents saleList As Label
    Friend WithEvents character_Text As Label
    Friend WithEvents pausedTimer As Timer
    Friend WithEvents gameoverTimer As Timer
End Class
