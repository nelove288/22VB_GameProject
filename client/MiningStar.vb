Public Class Form2

    Private pgBar As New ProgressBar()
    Dim currentKeys As New ArrayList
    Dim gameSnd As New GameSounds

    '캐릭터 관련
    Dim character As Image
    Dim heart As Image
    Dim o2 As Image
    Dim gold As Image
    Dim c_MAX_heart As Integer
    Dim c_heart As Integer
    Dim c_heart_X As Integer
    Dim c_MAX_oxygen As Integer
    Dim c_oxygen As Integer
    Dim c_oxygen_X As Integer
    Dim c_x As Integer
    Dim c_y As Integer
    Dim c_money As Integer
    Dim c_ability As Integer
    Dim HpBarstate As Boolean
    Dim c_pickax_state As Integer
    Dim c_o2tank_state As Integer


    '인벤토리
    Structure inventoryData
        Dim tmpX As Integer
        Dim tmpY As Integer
        Dim item As Image
        Dim item_X As Integer
        Dim item_Y As Integer
        Dim price As Integer
    End Structure
    Dim inven As Image
    Dim invenArraylist As New ArrayList
    Dim inven_state As Boolean

    '상점
    Structure shopData
        Dim product_Name As String
        Dim product_Price As Integer
        Dim product_ability As Integer
    End Structure

    Dim pickax As Image
    Dim o2_tank As Image
    Dim alien As Image
    Dim shop As Image
    Dim shopArraylist As New ArrayList
    Dim shop_state As Boolean

    '말풍선
    Dim tX As Integer
    Dim tY As Integer
    Dim textimage As Image
    Dim tstate As Integer

    '인벤토리, 상점 UI 좌표 변수
    Dim UI_x As Integer
    Dim UI_y As Integer

    '소행성
    Structure asteroidData
        Dim x_pos As Integer
        Dim y_pos As Integer
        Dim direction As Integer
    End Structure
    Dim asteroid As Image
    Dim astArraylist As New ArrayList

    '광물 별
    Structure starData
        Dim sx_pos As Integer
        Dim sy_pos As Integer
        Dim scount As Integer
        Dim sprice As Integer
        Dim star As Image
    End Structure
    Dim starArraylist As New ArrayList

    Dim paused_state As Boolean
    Dim gameover_state As Boolean
    Dim HTP_state As Boolean

    Dim paused As Image
    Dim HTP_img As Image
    Dim gameover_img As Image

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        alien_Text.Visible = False
        saleList.Visible = False

        '사운드 추가
        gameSnd.AddSound("get_Gold", "sound/get_Gold.mp3")
        gameSnd.SetVolume("get_Gold", 200) '0~1000
        gameSnd.AddSound("product_purchase", "sound/product_purchase.mp3")
        gameSnd.SetVolume("product_purchase", 200) '0~1000
        gameSnd.AddSound("star_mining", "sound/star_mining.mp3")
        gameSnd.SetVolume("star_mining", 200) '0~1000
        gameSnd.AddSound("ast_Collision", "sound/ast_Collision.mp3")
        gameSnd.SetVolume("ast_Collision", 200) '0~1000


        With pgBar
            .Size = New System.Drawing.Size(70, 30)
            .ForeColor = Color.Blue
            .Step = 1
            .Visible = False
        End With
        Me.Controls.Add(pgBar)

        c_MAX_heart = 5
        c_MAX_oxygen = 3
        c_heart = 5
        c_oxygen = 3
        c_ability = 0
        c_money = 0

        '상점 물품 추가
        Dim p As shopData
        '평범한 곡괭이
        p.product_Name = "stone_pickax"
        p.product_Price = 1000
        p.product_ability = 2
        shopArraylist.Add(p)
        '좋은 곡괭이
        p.product_Name = "steel_pickax"
        p.product_Price = 5000
        p.product_ability = 5
        shopArraylist.Add(p)
        '체력 회복 포션
        p.product_Name = "HP_potion"
        p.product_Price = 100
        p.product_ability = c_MAX_heart
        shopArraylist.Add(p)
        '작은 산소통
        p.product_Name = "oxygen_tank"
        p.product_Price = 500
        p.product_ability = 4
        shopArraylist.Add(p)
        '큰 산소통
        p.product_Name = "big_oxygen _tank"
        p.product_Price = 2500
        p.product_ability = 5
        shopArraylist.Add(p)
        '탈출권
        p.product_Name = "escape_ticket"
        p.product_Price = 15000
        p.product_ability = 0
        shopArraylist.Add(p)

        heart = My.Resources.heart
        o2 = My.Resources.oxygen
        gold = My.Resources.gold


        alien = My.Resources.alien
        asteroid = My.Resources.asteroid
        character = My.Resources.character
        inven = My.Resources.inven
        shop = My.Resources.shop

        paused = My.Resources.paused
        HTP_img = My.Resources.htp
        gameover_img = My.Resources.gameover

        '산소 체크
        o2bar.Enabled = True


        c_x = Me.Width / 2 - character.Width
        c_y = Me.Height / 3

        UI_x = Me.Width / 2 - (inven.Width / 2) - 50
        UI_y = Me.Height / 3 - (inven.Height / 2) + 50

    End Sub

    Private Sub Sound()
        gameSnd.AddSound("BGsound", "sound/BGsound.mp3")
        gameSnd.SetVolume("BGsound", 300) '0~1000
        gameSnd.Play("BGsound")
    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If Not currentKeys.Contains(e.KeyCode) Then
            currentKeys.Add(e.KeyCode)
        End If
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        currentKeys.Remove(e.KeyCode)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        '배경음악 반복
        If gameSnd.IsPlaying("BGsound") = False Then
            Sound()
        End If

        GoldLabel.Text = CStr(c_money) + " G"

        starControlFunction()
        characterControlFunction()

        astControlFunction()

        HpBarstate = hpBar.Enabled

        Invalidate()
    End Sub

    '캐릭터 관리
    Dim character_direction As Integer = 0 '방향에 따른 사진 설정 변수
    Private Sub characterControlFunction()
        For i = 0 To currentKeys.Count - 1
            If currentKeys(i) = Keys.Left And c_x > 0 Then '왼쪽 방향키
                If character_direction = 1 Then
                    character.RotateFlip(RotateFlipType.RotateNoneFlipX)
                    character_direction = 0
                End If
                c_x = c_x - 10

            ElseIf currentKeys(i) = Keys.Right And c_x < Width - (character.Width) Then '오른쪽 방향키
                If character_direction = 0 Then
                    character.RotateFlip(RotateFlipType.RotateNoneFlipX)
                    character_direction = 1
                End If
                c_x = c_x + 10

            ElseIf currentKeys(i) = Keys.Up And c_y > 0 - (character.Height - 100) Then '위쪽 방향키
                c_y = c_y - 10

            ElseIf currentKeys(i) = Keys.Down And c_y < Height - (character.Height + 50) Then '아래쪽 방향키
                c_y = c_y + 10

            ElseIf currentKeys(i) = Keys.E Then ' 인벤
                invenControlFunction()

            ElseIf c_x < (alien.Width + 1230) And (c_x + (character.Width / 2)) > 1230 And (c_y + 50) < (alien.Height + 0) And (c_y + character.Height) > 0 Then
                If currentKeys(i) = Keys.Space Then ' 상점
                    shopControlFunction()
                End If

            ElseIf currentKeys(i) = Keys.P Then '일시정지
                pausedControlFunction()
            End If
        Next
    End Sub

    '일시정지
    Private Sub pausedControlFunction()
        Timer1.Enabled = False
        o2bar.Enabled = False
        hpBar.Enabled = False
        pausedTimer.Enabled = True
        paused_state = True

        For i = 0 To currentKeys.Count - 1

            If currentKeys(i) = 49 Or currentKeys(i) = Keys.Escape Then
                Timer1.Enabled = True
                o2bar.Enabled = True
                If HpBarstate = True Then
                    hpBar.Enabled = True
                End If
                pausedTimer.Enabled = False
                paused_state = False
                HTP_state = False

            ElseIf currentKeys(i) = 50 Then
                HTP_state = True
                Exit For
            ElseIf currentKeys(i) = 51 Then
                gameSnd.Dispose()
                Me.Close()
                Form1.Close()
            End If
        Next

    End Sub

    '인벤토리 관리
    Private Sub invenControlFunction()
        Timer1.Enabled = False
        o2bar.Enabled = False
        hpBar.Enabled = False
        invenTimer.Enabled = True
        inven_state = True

        For i = 0 To currentKeys.Count - 1
            If currentKeys(i) = Keys.Escape Then
                invenTimer.Enabled = False
                o2bar.Enabled = True
                If HpBarstate = True Then
                    hpBar.Enabled = True
                End If
                Timer1.Enabled = True
                inven_state = False
            End If
        Next
    End Sub

    '상점 관리
    Private Sub shopControlFunction()
        If c_oxygen = 0 Then
            hpBar.Stop()
        End If
        c_oxygen = c_MAX_oxygen
        Timer1.Enabled = False
        o2bar.Enabled = False
        hpBar.Enabled = False
        shopTimer.Enabled = True
        shop_state = True

        For i = 0 To currentKeys.Count - 1
            If shop_state = True Then
                Dim l1, l2, l3, l4 As Integer
                alien_Text.Text = "지구인 안뇽! 준비된 상품이야." + vbCrLf + "편히 둘러보고 가!"
                alien_Text.Visible = True

                If currentKeys(i) = Keys.S Then

                    If invenArraylist.Count = 0 Then
                        alien_Text.Text = "어라 아무것도 가지고 있지 않아!"
                    Else
                        character_Text.Visible = False
                        Dim index As Integer = 0
                        While index <> invenArraylist.Count
                            Dim inven = CType(invenArraylist(index), inventoryData)
                            c_money += inven.price
                            invenArraylist.RemoveAt(index)
                        End While
                        gameSnd.Play("get_Gold")
                        alien_Text.Text = "판매 성공! 고마워!"
                    End If
                End If

                '물건 구매
                For j = 0 To shopArraylist.Count - 1
                    Dim p = CType(shopArraylist(j), shopData)

                    '숫자 1번
                    If currentKeys(i) = 49 Then
                        If p.product_Name = "stone_pickax" Then
                            If c_money >= p.product_Price Then
                                If p.product_ability > c_ability Then
                                    alien_Text.Text = "평범한 곡괭이 구매에 성공했어!"
                                    gameSnd.Play("product_purchase")
                                    c_money -= p.product_Price
                                    c_ability = p.product_ability
                                    c_pickax_state = 1
                                    pickax = My.Resources.stone_pickax
                                    shopArraylist.RemoveAt(j)
                                    Exit For
                                Else
                                    alien_Text.Text = "지금 쓰고있는 곡괭이가 더 좋은것 같아!"
                                End If
                            Else
                                alien_Text.Text = "돈이 부족해"
                            End If
                        Else
                            alien_Text.Text = "평범한 곡괭이는 구매하지 못해"
                        End If

                    ElseIf currentKeys(i) = 50 Then
                        If p.product_Name = "steel_pickax" Then
                            If c_money >= p.product_Price Then
                                alien_Text.Text = "좋은 곡괭이 구매에 성공했어!"
                                gameSnd.Play("product_purchase")
                                c_money -= p.product_Price
                                c_ability = p.product_ability
                                c_pickax_state = 1
                                pickax = My.Resources.steel_pickax
                                shopArraylist.RemoveAt(j)
                                Exit For
                            Else
                                alien_Text.Text = "돈이 부족해"
                            End If
                        Else
                            alien_Text.Text = "좋은 곡괭이는 구매하지 못해"
                        End If

                    ElseIf currentKeys(i) = 51 Then
                        If p.product_Name = "HP_potion" Then
                            If c_money >= p.product_Price Then
                                If c_heart < c_MAX_heart Then
                                    alien_Text.Text = "너의 체력은 회복됐어!"
                                    gameSnd.Play("product_purchase")
                                    c_money -= p.product_Price
                                    c_heart = p.product_ability
                                    Exit For
                                Else
                                    alien_Text.Text = "이미 체력은 다 차있어"
                                End If
                            Else
                                alien_Text.Text = "돈이 부족해"
                            End If
                        End If

                    ElseIf currentKeys(i) = 52 Then
                        If p.product_Name = "oxygen_tank" Then
                            If c_money >= p.product_Price Then
                                If p.product_ability > c_MAX_oxygen Then
                                    alien_Text.Text = "작은 산소통 구매에 성공했어!"
                                    gameSnd.Play("product_purchase")
                                    c_money -= p.product_Price
                                    c_MAX_oxygen = p.product_ability
                                    c_oxygen = c_MAX_oxygen
                                    o2bar.Interval = 12000
                                    c_o2tank_state = 1
                                    o2_tank = My.Resources.o2_tank
                                    shopArraylist.RemoveAt(j)
                                    Exit For
                                Else
                                    alien_Text.Text = "지금 쓰고있는 산소통이 더 좋은것 같아!"
                                End If
                            Else
                                alien_Text.Text = "돈이 부족해"
                            End If
                        Else
                            alien_Text.Text = "작은 산소통은 구매하지 못해"
                        End If

                    ElseIf currentKeys(i) = 53 Then
                        If p.product_Name = "big_oxygen _tank" Then
                            If c_money >= p.product_Price Then
                                alien_Text.Text = "큰 산소통 구매에 성공했어!"
                                gameSnd.Play("product_purchase")
                                c_money -= p.product_Price
                                c_MAX_oxygen = p.product_ability
                                c_oxygen = c_MAX_oxygen
                                o2bar.Interval = 15000
                                c_o2tank_state = 1
                                o2_tank = My.Resources.big_o2_tank
                                shopArraylist.RemoveAt(j)
                                Exit For
                            Else
                                alien_Text.Text = "돈이 부족해"
                            End If
                        Else
                            alien_Text.Text = "큰 산소통은 구매하지 못해"
                        End If

                    ElseIf currentKeys(i) = 54 Then
                        If p.product_Name = "escape_ticket" Then
                            If c_money >= p.product_Price Then
                                gameSnd.RemoveSound("BGsound")
                                Form3.Show()
                                Me.Hide()
                                Exit For
                            Else
                                alien_Text.Text = "돈이 부족해"
                            End If
                        Else
                            alien_Text.Text = "탈출권은 구매하지 못해"
                        End If
                    End If
                Next

                For j = 0 To invenArraylist.Count - 1
                    Dim inven = CType(invenArraylist(j), inventoryData)
                    If inven.price = 20 Then
                        l1 += 1
                    ElseIf inven.price = 50 Then
                        l2 += 1
                    ElseIf inven.price = 300 Then
                        l3 += 1
                    ElseIf inven.price = 700 Then
                        l4 += 1
                    End If
                Next
                saleList.Text = "광물 별 리스트 (판매 : S키) " + vbCrLf + vbCrLf + "석탄 별 : " + CStr(l1) + "개 x 20G" + vbCrLf + "금 별 : " + CStr(l2) + "개 x 50G" + vbCrLf + "다이아 별 : " + CStr(l3) + "개 x 300G" + vbCrLf + "에메랄드 별 : " + CStr(l4) + "개 x 700G" + vbCrLf
                saleList.Visible = True


            End If


            If currentKeys(i) = Keys.Escape Then
                shopTimer.Enabled = False
                saleList.Visible = False
                alien_Text.Visible = False
                o2bar.Enabled = True
                If HpBarstate = True Then
                    hpBar.Enabled = True
                End If
                Timer1.Enabled = True
                shop_state = False
            End If

        Next
    End Sub

    '소행성 관리
    Private Sub astControlFunction()
        Dim ast As asteroidData
        Dim n As Integer

        Randomize()

        n = Rnd() * 100
        If n Mod 20 = 0 And astArraylist.Count < 10 Then
            ast.direction = Rnd() * 1
            If ast.direction = 0 Then
                ast.x_pos = ast.direction * 1600 - asteroid.Width
            Else
                ast.x_pos = ast.direction * 1600
            End If
            ast.y_pos = Rnd() * (900 - asteroid.Height)
            astArraylist.Add(ast)
        End If


        For i = 0 To astArraylist.Count - 1
            Dim o = CType(astArraylist(i), asteroidData)

            If o.direction = 0 Then
                o.x_pos = o.x_pos + 7
            Else
                o.x_pos = o.x_pos - 7
            End If
            astArraylist(i) = o

        Next

        '화면 밖의 소행성 삭제 및 소행성 충돌 
        Dim index As Integer = 0
        While index <> astArraylist.Count
            Dim obj = CType(astArraylist(index), asteroidData)

            If c_x < obj.x_pos + asteroid.Width And c_x + character.Width > obj.x_pos And (c_y + 50) < obj.y_pos + asteroid.Height And (c_y + (character.Height - 30)) > obj.y_pos Then '
                gameSnd.Play("ast_Collision")
                c_heart -= 1
                astArraylist.RemoveAt(index)
                index -= 1
                If c_heart = 0 Then
                    gameover_state = True
                    starTimer.Enabled = False
                    pgBar.Enabled = False
                    pgBar.Visible = False
                    gameSnd.RemoveSound("BGsound")
                    Timer1.Enabled = False
                    gameoverTimer.Enabled = True
                    gameover()

                End If
            End If

            If obj.direction = 0 And obj.x_pos > Me.Width Or obj.direction = 1 And obj.x_pos < 0 - asteroid.Width Then
                astArraylist.RemoveAt(index)
                index -= 1
            End If

            index += 1
        End While
    End Sub



    '광물 별 관리
    Private Sub starControlFunction()
        Dim s As starData
        Dim inv As inventoryData

        Dim n As Integer

        Randomize()

        n = Rnd() * 100
        If n Mod 20 = 0 And starArraylist.Count < 5 Then

            If n > 0 And n < 55 Then ' 1 - 54
                s.star = My.Resources.coalStar
                s.scount = 3
                s.sprice = 20
            ElseIf n < 80 Then
                s.star = My.Resources.Star
                s.scount = 5
                s.sprice = 50
            ElseIf n < 95 Then
                s.star = My.Resources.diaStar
                s.scount = 10
                s.sprice = 300
            Else
                s.star = My.Resources.emStar
                s.scount = 15
                s.sprice = 700
            End If

            s.sx_pos = Rnd() * 1530
            s.sy_pos = Rnd() * (900 - (s.star.Height * 2))

            If s.sx_pos > 1230 And s.sy_pos < 0 + alien.Height Then
                s.sx_pos -= alien.Width
                s.sy_pos += alien.Height
            End If

            starArraylist.Add(s)
        End If


        For i = 0 To starArraylist.Count - 1
            Dim o = CType(starArraylist(i), starData)
            starArraylist(i) = o
        Next


        Dim index As Integer = 0
        While index <> starArraylist.Count
            Dim obj = CType(starArraylist(index), starData)

            If c_x < obj.sx_pos + obj.star.Width And c_x + character.Width > obj.sx_pos And (c_y + 50) < obj.sy_pos + obj.star.Height And (c_y + character.Height) > obj.sy_pos Then
                For i = 0 To currentKeys.Count - 1
                    If currentKeys(i) = Keys.Space Then

                        If invenArraylist.Count < 12 Then
                            pgBar.Location = New System.Drawing.Point(c_x, c_y - 30)
                            pgBar.Visible = True
                            If (obj.scount - c_ability) <= 0 Then
                                pgBar.Maximum = 1
                            Else
                                pgBar.Maximum = obj.scount - c_ability
                            End If
                            starTimer.Enabled = True
                        Else
                            character_Text.Visible = True
                        End If

                        If pgBar.Value = pgBar.Maximum Then
                            starTimer.Enabled = False
                            pgBar.Enabled = False
                            pgBar.Visible = False
                            pgBar.Value = 0

                            inv.tmpX = UI_x + 55
                            inv.tmpY = UI_y + 215
                            For j = 1 To invenArraylist.Count
                                inv.tmpX += 105
                                If j Mod 4 = 0 Then
                                    inv.tmpX = UI_x + 55
                                    inv.tmpY += 105
                                End If
                            Next
                            inv.item_X = inv.tmpX
                            inv.item_Y = inv.tmpY
                            inv.price = obj.sprice
                            inv.item = obj.star
                            invenArraylist.Add(inv)
                            starArraylist.RemoveAt(index)

                        End If
                        Exit While
                    Else
                        starTimer.Stop()
                        pgBar.Enabled = False
                        pgBar.Value = 0
                        pgBar.Visible = False
                    End If
                Next
            Else
                pgBar.Visible = False
                pgBar.Enabled = False
            End If

            index += 1
        End While

    End Sub

    '게임오버 창
    Private Sub gameover()
        For i = 0 To currentKeys.Count - 1
            If currentKeys(i) = Keys.Space Then
                Me.Close()
            End If
        Next
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawImage(alien, 1230, 0)

        '별
        For i = 0 To starArraylist.Count - 1
            Dim s = CType(starArraylist(i), starData)
            e.Graphics.DrawImage(s.star, s.sx_pos, s.sy_pos)
        Next

        '캐릭터
        e.Graphics.DrawImage(character, c_x, c_y)

        '소행성
        For i = 0 To astArraylist.Count - 1
            Dim o = CType(astArraylist(i), asteroidData)
            e.Graphics.DrawImage(asteroid, o.x_pos, o.y_pos)
        Next

        '캐릭터 스탯 창
        c_heart_X = 30
        For i = 0 To c_heart - 1
            e.Graphics.DrawImage(heart, c_heart_X, 10)
            c_heart_X += 50
        Next

        c_oxygen_X = 30
        For i = 0 To c_oxygen - 1
            e.Graphics.DrawImage(o2, c_oxygen_X, 60)
            c_oxygen_X += 50
        Next

        e.Graphics.DrawImage(gold, 25, 110)

        '인벤 켰을때
        If inven_state = True Then
            e.Graphics.DrawImage(inven, UI_x, UI_y)
            If c_pickax_state = 1 Then
                e.Graphics.DrawImage(pickax, UI_x + 85, UI_y + 105)
            End If
            If c_o2tank_state = 1 Then
                e.Graphics.DrawImage(o2_tank, UI_x + 377, UI_y + 30)
            End If

            For i = 0 To invenArraylist.Count - 1
                Dim o = CType(invenArraylist(i), inventoryData)
                e.Graphics.DrawImage(o.item, o.item_X, o.item_Y)
            Next
        End If

        '상점 켰을때
        If shop_state = True Then
            e.Graphics.DrawImage(shop, UI_x, UI_y)
        End If

        '일시정지 창
        If paused_state = True Then
            e.Graphics.DrawImage(paused, UI_x + CInt(paused.Width / 2) - 100, UI_y + 50)
            If HTP_state = True Then
                e.Graphics.DrawImage(HTP_img, UI_x - 100, UI_y + 50)
            End If
        End If

        '게임오버
        If gameover_state = True Then
            e.Graphics.DrawImage(gameover_img, CInt(Width / 2 - 120), CInt(Height / 3))
        End If

    End Sub

    Private Sub starTimer_Tick(sender As Object, e As EventArgs) Handles starTimer.Tick
        gameSnd.Play("star_mining")
        pgBar.PerformStep()
    End Sub

    Private Sub o2bar_Tick(sender As Object, e As EventArgs) Handles o2bar.Tick

        If c_oxygen > 0 Then
            c_oxygen -= 1
        Else
            hpBar.Enabled = True
        End If
    End Sub

    Private Sub hpbar_Tick(sender As Object, e As EventArgs) Handles hpBar.Tick
        c_heart -= 1
        If c_heart = 0 Then
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub invenTimer_Tick(sender As Object, e As EventArgs) Handles invenTimer.Tick
        invenControlFunction()
        Invalidate()
    End Sub

    Private Sub shopTimer_Tick(sender As Object, e As EventArgs) Handles shopTimer.Tick
        GoldLabel.Text = CStr(c_money) + " G"
        shopControlFunction()
        Invalidate()
    End Sub

    Private Sub pausedTimer_Tick(sender As Object, e As EventArgs) Handles pausedTimer.Tick
        pausedControlFunction()
        Invalidate()
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Close()
    End Sub

    Private Sub gameoverTimer_Tick(sender As Object, e As EventArgs) Handles gameoverTimer.Tick
        gameover()
        Invalidate()
    End Sub
End Class
