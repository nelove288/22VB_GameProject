Imports System.Threading

Public Class Form3
    Dim gameSnd As New GameSounds
    Private SoundThread As Thread

    Private Sub Form3_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Visible = True
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False

        SoundThread = New Thread(AddressOf SoundThreadTask)
        SoundThread.IsBackground = True
        SoundThread.Start()

    End Sub

    Private Sub SoundThreadTask()
        gameSnd.AddSound("bgm_Ending", "sound/bgm_Ending.mp3")
        gameSnd.SetVolume("bgm_Ending", 200) '0~1000
        gameSnd.Play("bgm_Ending")
        Do
            Thread.Sleep(33)
        Loop
        gameSnd.Dispose()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.Visible = False
        PictureBox2.Visible = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PictureBox2.Visible = False
        PictureBox3.Visible = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        PictureBox3.Visible = False
        PictureBox4.Visible = True
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        PictureBox4.Visible = False
        PictureBox5.Visible = True
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Form1.Close()
    End Sub
End Class