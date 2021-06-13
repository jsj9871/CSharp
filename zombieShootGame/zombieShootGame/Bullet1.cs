using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace zombieShootGame
{
    class Bullet1
    {
        public string direction1;
        public int bullet1Left;
        public int bullet1Top;

        private int speed = 40;     // 총알 속도
        private PictureBox bullet1 = new PictureBox();   // 총알 생성
        private Timer bullet1Timer = new Timer();    // 탄약 타이머 생성

        public void MakeBullet1(Form form)
        {
            bullet1.BackColor = Color.White;     // 흰색으로 총알 색상 설정
            bullet1.Size = new Size(5, 5);        // 총알 크기 5, 5로 설정
            bullet1.Tag = "bullet1";
            bullet1.Left = bullet1Left;
            bullet1.Top = bullet1Top;
            bullet1.BringToFront();  // 총알이 다른 것보다 앞으로 오도록 설정

            form.Controls.Add(bullet1);

            // 총알 발사
            bullet1Timer.Interval = speed;
            bullet1Timer.Tick += new EventHandler(Bullet1TimerEvent);
            bullet1Timer.Start();
        }

        private void Bullet1TimerEvent(object sender, EventArgs e)
        {
            // 총알 방향
            if (direction1 == "left")
            {
                bullet1.Left -= speed;   // 화면에서 왼쪽으로 이동
            }

            if (direction1 == "right")
            {
                bullet1.Left += speed;   // 화면에서 오른쪽으로 이동
            }

            if (direction1 == "up")
            {
                bullet1.Top -= speed;    // 화면에서 위로 이동
            }

            if (direction1 == "down")
            {
                bullet1.Top += speed;    // 화면에서 아래로 이동
            }

            // 총알 사거리
            if (bullet1.Left < 10 || bullet1.Left > 1250 || bullet1.Top < 40 || bullet1.Top > 600)
            {
                bullet1Timer.Stop();     // 총알 타이머 정지
                bullet1Timer.Dispose();      // 총알 타이머 폐기
                bullet1.Dispose();       // 총알 폐기
                bullet1Timer = null;     // 총알 타이머 무효화
                bullet1 = null;      // 총알 무효화
            }
        }
    }
}
