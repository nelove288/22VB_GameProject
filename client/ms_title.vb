Public Class Form1
    Dim gameSnd As New GameSounds

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        gameSnd.AddSound("BGsound", "sound/BGsound.mp3")
        gameSnd.SetVolume("BGsound", 300) '0~1000
        gameSnd.Play("BGsound")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox3.Visible = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        gameSnd.Dispose()
        Form2.Show()
        Me.Hide()
    End Sub
End Class