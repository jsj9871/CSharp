using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace zombieShootGame
{
    class Bullet2
    {
        public string direction2;
        public int bullet2Left;
        public int bullet2Top;

        private int speed = 40;     // 총알 속도
        private PictureBox bullet2 = new PictureBox();   // 총알 생성
        private Timer bullet2Timer = new Timer();    // 탄약 타이머 생성

        public void MakeBullet2(Form form)
        {
            bullet2.BackColor = Color.Red;     // 흰색으로 총알 색상 설정
            bullet2.Size = new Size(5, 5);        // 총알 크기 5, 5로 설정
            bullet2.Tag = "bullet2";
            bullet2.Left = bullet2Left;
            bullet2.Top = bullet2Top;
            bullet2.BringToFront();  // 총알이 다른 것보다 앞으로 오도록 설정

            form.Controls.Add(bullet2);

            // 총알 발사
            bullet2Timer.Interval = speed;
            bullet2Timer.Tick += new EventHandler(Bullet2TimerEvent);
            bullet2Timer.Start();
        }

        private void Bullet2TimerEvent(object sender, EventArgs e)
        {
            // 총알 방향
            if (direction2 == "left")
            {
                bullet2.Left -= speed;   // 화면에서 왼쪽으로 이동
            }

            if (direction2 == "right")
            {
                bullet2.Left += speed;   // 화면에서 오른쪽으로 이동
            }

            if (direction2 == "up")
            {
                bullet2.Top -= speed;    // 화면에서 위로 이동
            }

            if (direction2 == "down")
            {
                bullet2.Top += speed;    // 화면에서 아래로 이동
            }

            // 총알 사거리
            if (bullet2.Left < 10 || bullet2.Left > 1250 || bullet2.Top < 40 || bullet2.Top > 600)
            {
                bullet2Timer.Stop();     // 총알 타이머 정지
                bullet2Timer.Dispose();      // 총알 타이머 폐기
                bullet2.Dispose();       // 총알 폐기
                bullet2Timer = null;     // 총알 타이머 무효화
                bullet2 = null;      // 총알 무효화
            }
        }
    }
}
