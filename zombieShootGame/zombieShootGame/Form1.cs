using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using MySql.Data.MySqlClient;

namespace zombieShootGame
{
    public partial class Form1 : Form
    {
        bool goLeft1, goRight1, goUp1, goDown1, goLeft2, goRight2, goUp2, goDown2, gameOver;   // 플레이어 이동 방향
        string facing1 = "up";   // 플레이어 시작 방향 위쪽
        string facing2 = "up";

        int playerHealth1 = 100;     // 플레이어 체력
        int playerHealth2 = 100;
        int speed1 = 15;     // 플레이어 이동속도
        int speed2 = 15;
        int ammo1 = 20;      // 탄약 개수
        int ammo2 = 20;
        int zombieSpeed = 4;    // 좀비 이동속도
        int score1;      // 플레이어의 킬 점수
        int score2;

        MySqlConnection connection = new MySqlConnection("Server=localhost;Database=member1;Uid=root;Pwd=jsh5026033@;");

        Random randNum = new Random();  // 이 게임에서 사용될 랜덤넘버 생성
        List<PictureBox> zombiesList = new List<PictureBox>();  // 좀비 추가, 제거

        public Form1()
        {
            InitializeComponent();
            RestartGame();
            SoundEffect();
        }

        // 게임 시작 시 효과음
        private void SoundEffect()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Samsung\source\repos\zombieShootGame\zombieShootGame\Resources\031_슈퍼마리오.WAV");
            player.Play();
        }

        // 격발 시 효과음
        private void SoundEffect1()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Samsung\source\repos\zombieShootGame\zombieShootGame\Resources\120_폭발.wav");
            player.Play();
        }

        // 플레이어가 총에 맞았을 때 효과음
        private void SoundEffect2()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Samsung\source\repos\zombieShootGame\zombieShootGame\Resources\029_권총한발.WAV");
            player.Play();
        }

        // 게임종료 시 효과음
        private void SoundEffect3()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Samsung\source\repos\zombieShootGame\zombieShootGame\Resources\033_와우.wav");
            player.Play();
        }

        // 좀비가 총에 맞았을 때 효과음
        private void SoundEffect4()
        {
            SoundPlayer player = new SoundPlayer(@"C:\Users\Samsung\source\repos\zombieShootGame\zombieShootGame\Resources\025_터지는소리BOOM.WAV");
            player.Play();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            Form3 form3 = new Form3();

            if (playerHealth1 > 0.1)
            {
                healthBar1.Value = playerHealth1;     // 프로그래스바를 플레이어의 체력으로
            }
            else
            {
                gameOver = true;    // 게임 종료
                player1.Image = Properties.Resources.dead1;  // 플레이어1 사망 시 이미지 변경
                GameTimer.Stop();   // 게임 타이머 종료
                form2.Show();   // 게임 결과 창 보여주기
                SoundEffect3();

                string insertQuery = "INSERT INTO member_tb(Player1, Player2) VALUES('" + txtScore1.Text + "', '" + txtScore2.Text + "')";
                // 테이블 member_tb 테이블에  Player1과 Player2 라는 항목의 값을 그값은 txtScore.Text 와  txtScore2.Text 에입력된 값

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try//예외 처리
                {
                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("정상적으로 들어갔다");
                    }
                    else
                    {
                        MessageBox.Show("비정상이다");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }

            if (playerHealth2 > 0.1)
            {
                healthBar2.Value = playerHealth2;     // 프로그래스바를 플레이어의 체력으로
            }
            else
            {
                gameOver = true;    // 게임 종료
                player2.Image = Properties.Resources.dead1;  // 플레이어1 사망 시 이미지 변경
                GameTimer.Stop();   // 게임 타이머 종료
                form3.Show();   // 게임 결과 창 보여주기
                SoundEffect3();

                string insertQuery = "INSERT INTO member_tb(Player1, Player2) VALUES('" + txtScore1.Text + "', '" + txtScore2.Text + "')";
                // 테이블 member_tb 테이블에  Player1과 Player2 라는 항목의 값을 그값은 txtScore.Text 와  txtScore2.Text 에 입력된 값

                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);

                try//예외 처리
                {
                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("정상적으로 갔다");
                    }
                    else
                    {
                        MessageBox.Show("비정상이다");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                connection.Close();
            }

            // 탄약, 점수 설정
            txtAmmo1.Text = "Ammo: " + ammo1;
            txtAmmo2.Text = "Ammo: " + ammo2;
            txtScore1.Text = "Kills: " + score1;
            txtScore2.Text = "Kills: " + score2;

            // 플레이어1 이동 가능 범위 설정
            if (goLeft1 == true && player1.Left > 0)
            {
                player1.Left -= speed1;   // 플레이어 왼쪽으로 이동
            }
            if (goRight1 == true && player1.Left + player1.Width < this.ClientSize.Width)
            {
                player1.Left += speed1;   // 플레이어 오른쪽으로 이동
            }
            if (goUp1 == true && player1.Top > 60)
            {
                player1.Top -= speed1;    // 플레이어 위쪽으로 이동
            }
            if (goDown1 == true && player1.Top + player1.Height < this.ClientSize.Height)
            {
                player1.Top += speed1;    // 플레이어 아래쪽으로 이동
            }

            // 플레이어2 이동 가능 범위 설정
            if (goLeft2 == true && player2.Left > 0)
            {
                player2.Left -= speed2;   // 플레이어 왼쪽으로 이동
            }
            if (goRight2 == true && player2.Left + player2.Width < this.ClientSize.Width)
            {
                player2.Left += speed2;   // 플레이어 오른쪽으로 이동
            }
            if (goUp2 == true && player2.Top > 60)
            {
                player2.Top -= speed2;    // 플레이어 위쪽으로 이동
            }
            if (goDown2 == true && player2.Top + player2.Height < this.ClientSize.Height)
            {
                player2.Top += speed2;    // 플레이어 아래쪽으로 이동
            }

            // 플레이어 체력이 30보다 적을 때
            if (playerHealth1 < 30)
            {
                healthBar1.ForeColor = Color.Red;   // 체력바를 빨간색으로 변경
                healthBar1.Style = ProgressBarStyle.Continuous;
            }

            if (playerHealth2 < 30)
            {
                healthBar2.ForeColor = Color.Red;
                healthBar2.Style = ProgressBarStyle.Continuous;
            }

            // 반복
            foreach (Control x in this.Controls)
            {
                // 플레이어가 탄약을 주웠을때
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player1.Bounds.IntersectsWith(x.Bounds))
                    {
                        // 탄약 그림 제거
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo1 += 5;  // 탄약 5개 증가
                    }

                    if (player2.Bounds.IntersectsWith(x.Bounds))
                    {
                        // 탄약 그림 제거
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo2 += 5;  // 탄약 5개 증가
                    }
                }

                // 플레이어가 총알에 맞았을 때
                if (x is PictureBox && (string)x.Tag == "bullet1")
                {
                    // 플레이어 체력 감소
                    if (player2.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth2 -= 10;    // 10씩 감소
                        SoundEffect2();
                    }
                }
                if (x is PictureBox && (string)x.Tag == "bullet2")
                {
                    // 플레이어 체력 감소
                    if (player1.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth1 -= 10;
                        SoundEffect2();
                    }
                }


                // 플레이어가 좀비에게 닿였을 때
                if (x is PictureBox && (string)x.Tag == "zombie")
                    {
                    // 플레이어 체력 감소
                    if (player1.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth1 -= 1; // 1씩 감소
                    }
                    if (player2.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth2 -= 1;
                    }
                        
                        // 좀비가 플레이어를 따라가게 끔 만듬
                        if (x.Left > player1.Left)
                        {
                            x.Left -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zleft;
                        }
                        if (x.Left < player1.Left)
                        {
                            x.Left += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zright;
                        }
                        if (x.Top > player1.Top)
                        {
                            x.Top -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zup;
                        }
                        if (x.Top < player1.Top)
                        {
                            x.Top += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zdown;
                        }


                        if (x.Left > player2.Left)
                        {
                            x.Left -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zleft;
                        }
                        if (x.Left < player2.Left)
                        {
                            x.Left += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zright;
                        }
                        if (x.Top > player2.Top)
                        {
                            x.Top -= zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zup;
                        }
                        if (x.Top < player2.Top)
                        {
                            x.Top += zombieSpeed;
                            ((PictureBox)x).Image = Properties.Resources.zdown;
                        }

                    
                }

                foreach (Control j in this.Controls)
                {
                    // 좀비가 플레이어1의 총알에 맞았을 때
                    if (j is PictureBox && (string)j.Tag == "bullet1" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score1++;    // 킬 스코어 1씩 증가
                            SoundEffect4();

                            // 총알과 좀비 제거
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies();  // 좀비 재스폰

                            
                        }
                    }
                }

                foreach (Control j in this.Controls)
                {
                    // 좀비가 플레이어2의 총알에 맞았을 때
                    if (j is PictureBox && (string)j.Tag == "bullet2" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score2++;    // 킬 스코어 1씩 증가
                            SoundEffect4();

                            // 총알과 좀비 제거
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            MakeZombies();  // 좀비 재스폰
                        }
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // 게임종료
            if (gameOver == true)
            {
                return;
            }

            // 방향키에 따라 플레이어 이동방향 설정
            if (e.KeyCode == Keys.Left)
            {
                // 플레이어가 왼쪽으로 이동
                goLeft1 = true;
                facing1 = "left";
                player1.Image = Properties.Resources.left1;   // 왼쪽 방향의 플레이어 이미지로
            }

            if (e.KeyCode == Keys.Right)
            {
                // 플레이어가 오른쪽으로 이동
                goRight1 = true;
                facing1 = "right";
                player1.Image = Properties.Resources.right1;  // 오른쪽 방향의 플레이어 이미지로
            }

            if (e.KeyCode == Keys.Up)
            {
                // 플레이어가 위로 이동
                goUp1 = true;
                facing1 = "up";
                player1.Image = Properties.Resources.up1;     // 위쪽 방향의 플레이어 이미지로
            }

            if (e.KeyCode == Keys.Down)
            {
                // 플레이어가 아래로 이동
                goDown1 = true;
                facing1 = "down";
                player1.Image = Properties.Resources.down1;   // 아래쪽 방향의 플레이어 이미지로
            }

            if (e.KeyCode == Keys.A)
            {
                // 플레이어가 왼쪽으로 이동
                goLeft2 = true;
                facing2 = "left";
                player2.Image = Properties.Resources.left2;   // 왼쪽 방향의 플레이어 이미지로
            }

            if (e.KeyCode == Keys.D)
            {
                // 플레이어가 오른쪽으로 이동
                goRight2 = true;
                facing2 = "right";
                player2.Image = Properties.Resources.right2;  // 오른쪽 방향의 플레이어 이미지로
            }

            if (e.KeyCode == Keys.W)
            {
                // 플레이어가 위로 이동
                goUp2 = true;
                facing2 = "up";
                player2.Image = Properties.Resources.up2;     // 위쪽 방향의 플레이어 이미지로
            }

            if (e.KeyCode == Keys.S)
            {
                // 플레이어가 아래로 이동
                goDown2 = true;
                facing2 = "down";
                player2.Image = Properties.Resources.down2;   // 아래쪽 방향의 플레이어 이미지로
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // 플레이어 정지
            if (e.KeyCode == Keys.Left)
            {
                goLeft1 = false;     // 왼쪽으로 가는 플레이어 정지
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight1 = false;    // 오른쪽으로 가는 플레이어 정지
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp1 = false;       // 위쪽으로 가는 플레이어 정지
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown1 = false;     // 아래쪽으로 가는 플레이어 정지
            }

            if (e.KeyCode == Keys.A)
            {
                goLeft2 = false;     // 왼쪽으로 가는 플레이어 정지
            }

            if (e.KeyCode == Keys.D)
            {
                goRight2 = false;    // 오른쪽으로 가는 플레이어 정지
            }

            if (e.KeyCode == Keys.W)
            {
                goUp2 = false;       // 위쪽으로 가는 플레이어 정지
            }

            if (e.KeyCode == Keys.S)
            {
                goDown2 = false;     // 아래쪽으로 가는 플레이어 정지
            }

            if (e.KeyCode == Keys.End && ammo1 > 0 && gameOver == false)
            {
                ammo1--;     // 탄약 사용했을때 한 개씩 감소
                ShootBullet1(facing1);


                if (ammo1 < 1)   // 탄약을 모두 사용
                {
                    DropAmmo();     // 추가 탄약 스폰
                }
            }

            if (e.KeyCode == Keys.Space && ammo2 > 0 && gameOver == false)
            {
                ammo2--;     // 탄약 사용했을때 한 개씩 감소
                ShootBullet2(facing2);


                if (ammo2 < 1)   // 탄약을 모두 사용
                {
                    DropAmmo();     // 추가 탄약 스폰
                }
            }

            // 엔터 누르면 게임 재시작
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
        }

        // 총알 설정
        private void ShootBullet1(string direction1)
        {
            Bullet1 shootBullet1 = new Bullet1();      // 총알 생성
            shootBullet1.direction1 = direction1;      // 총알 방향
            shootBullet1.bullet1Left = player1.Left + (player1.Width / 2);  // 왼쪽부분에서 플레이어1의 가운데
            shootBullet1.bullet1Top = player1.Top + (player1.Height / 2);   // 상단부분에서의 플레이어1의 가운데
            shootBullet1.MakeBullet1(this);
            SoundEffect1();
        }

        private void ShootBullet2(string direction2)
        {
            Bullet2 shootBullet2 = new Bullet2();      // 총알 생성
            shootBullet2.direction2 = direction2;      // 총알 방향
            shootBullet2.bullet2Left = player2.Left + (player2.Width / 2);  // 왼쪽부분에서 플레이어2의 가운데
            shootBullet2.bullet2Top = player2.Top + (player2.Height / 2);   // 상단부분에서의 플레이어2의 가운데
            shootBullet2.MakeBullet2(this);
            SoundEffect1();
        }

        // 좀비 설정
        private void MakeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;      // 좀비 이미지 설정
            zombie.Left = randNum.Next(0, 900);     // 랜덤한 지역에 좀비 생성
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;      // 이미지 크기에 따라 크기 조정
            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            player1.BringToFront();      // 플레이어와 좀비가 겹칠 때, 플레이어가 위로
        }

        // 탄약을 채울 수 있는 그림상자 생성
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;   // 탄약 이미지 설정
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;    // 이미지 크기에 따라 크기 조정
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width);   // 랜덤한 지역에 탄약 생성
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();    // 겹칠 때, 탄약이 위로
            player1.BringToFront();  // 겹칠 때, 플레이어가 위로
            player2.BringToFront();  // 겹칠 때, 플레이어가 위로
        }

        // 게임 재시작
        private void RestartGame()
        {
            player1.Image = Properties.Resources.up1;     // 위쪽 방향 보면서 재시작
            player2.Image = Properties.Resources.up2;

            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);    // 모든 그림상자 제거
            }

            zombiesList.Clear();

            for (int i = 0; i < 3; i++)     // 최대 좀비 수
            {
                MakeZombies();
            }

            // 플레이어 정지
            goUp1 = false;
            goDown1 = false;
            goLeft1 = false;
            goRight1 = false;
            goUp2 = false;
            goDown2 = false;
            goLeft2 = false;
            goRight2 = false;
            gameOver = false;

            playerHealth1 = 100;     // 플레이어 체력 100으로
            score1 = 0;      // 점수 0으로
            ammo1 = 20;      // 탄약 개수 10으로
            playerHealth2 = 100;     // 플레이어 체력 100으로
            score2 = 0;      // 점수 0으로
            ammo2 = 20;      // 탄약 개수 10으로
            healthBar1.ForeColor = Color.Green;     // 체력바 초록색으로
            healthBar2.ForeColor = Color.Green;


            GameTimer.Start();  // 게임 타이머 시작
        }
    }
}
