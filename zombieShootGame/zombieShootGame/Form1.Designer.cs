
namespace zombieShootGame
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.healthBar2 = new System.Windows.Forms.ProgressBar();
            this.healthBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScore2 = new System.Windows.Forms.Label();
            this.txtScore1 = new System.Windows.Forms.Label();
            this.txtAmmo2 = new System.Windows.Forms.Label();
            this.txtAmmo1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.player2 = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            this.SuspendLayout();
            // 
            // healthBar2
            // 
            this.healthBar2.Location = new System.Drawing.Point(922, 40);
            this.healthBar2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.healthBar2.Name = "healthBar2";
            this.healthBar2.Size = new System.Drawing.Size(249, 27);
            this.healthBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.healthBar2.TabIndex = 38;
            this.healthBar2.Value = 100;
            // 
            // healthBar1
            // 
            this.healthBar1.Location = new System.Drawing.Point(922, 9);
            this.healthBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.healthBar1.Name = "healthBar1";
            this.healthBar1.Size = new System.Drawing.Size(249, 27);
            this.healthBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.healthBar1.TabIndex = 37;
            this.healthBar1.Value = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(828, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 29);
            this.label4.TabIndex = 36;
            this.label4.Text = "Health: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(828, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 29);
            this.label1.TabIndex = 35;
            this.label1.Text = "Health: ";
            // 
            // txtScore2
            // 
            this.txtScore2.AutoSize = true;
            this.txtScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore2.ForeColor = System.Drawing.Color.White;
            this.txtScore2.Location = new System.Drawing.Point(468, 38);
            this.txtScore2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtScore2.Name = "txtScore2";
            this.txtScore2.Size = new System.Drawing.Size(92, 29);
            this.txtScore2.TabIndex = 34;
            this.txtScore2.Text = "Kills: 0";
            // 
            // txtScore1
            // 
            this.txtScore1.AutoSize = true;
            this.txtScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore1.ForeColor = System.Drawing.Color.White;
            this.txtScore1.Location = new System.Drawing.Point(468, 9);
            this.txtScore1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtScore1.Name = "txtScore1";
            this.txtScore1.Size = new System.Drawing.Size(92, 29);
            this.txtScore1.TabIndex = 33;
            this.txtScore1.Text = "Kills: 0";
            // 
            // txtAmmo2
            // 
            this.txtAmmo2.AutoSize = true;
            this.txtAmmo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo2.ForeColor = System.Drawing.Color.White;
            this.txtAmmo2.Location = new System.Drawing.Point(147, 38);
            this.txtAmmo2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtAmmo2.Name = "txtAmmo2";
            this.txtAmmo2.Size = new System.Drawing.Size(114, 29);
            this.txtAmmo2.TabIndex = 32;
            this.txtAmmo2.Text = "Ammo: 0";
            // 
            // txtAmmo1
            // 
            this.txtAmmo1.AutoSize = true;
            this.txtAmmo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo1.ForeColor = System.Drawing.Color.White;
            this.txtAmmo1.Location = new System.Drawing.Point(147, 9);
            this.txtAmmo1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtAmmo1.Name = "txtAmmo1";
            this.txtAmmo1.Size = new System.Drawing.Size(114, 29);
            this.txtAmmo1.TabIndex = 31;
            this.txtAmmo1.Text = "Ammo: 0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 29);
            this.label6.TabIndex = 30;
            this.label6.Text = "Player2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "Player1";
            // 
            // player1
            // 
            this.player1.Image = global::zombieShootGame.Properties.Resources.up1;
            this.player1.Location = new System.Drawing.Point(386, 536);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(71, 100);
            this.player1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player1.TabIndex = 39;
            this.player1.TabStop = false;
            // 
            // player2
            // 
            this.player2.Image = global::zombieShootGame.Properties.Resources.up2;
            this.player2.Location = new System.Drawing.Point(710, 536);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(71, 100);
            this.player2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player2.TabIndex = 40;
            this.player2.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.MainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1232, 763);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.healthBar2);
            this.Controls.Add(this.healthBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScore2);
            this.Controls.Add(this.txtScore1);
            this.Controls.Add(this.txtAmmo2);
            this.Controls.Add(this.txtAmmo1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar healthBar2;
        private System.Windows.Forms.ProgressBar healthBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtScore2;
        private System.Windows.Forms.Label txtScore1;
        private System.Windows.Forms.Label txtAmmo2;
        private System.Windows.Forms.Label txtAmmo1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.PictureBox player2;
        private System.Windows.Forms.Timer GameTimer;
    }
}

