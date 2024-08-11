namespace My_First_Game_2D_Redemption_
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveBgTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPlayer = new System.Windows.Forms.PictureBox();
            this.LeftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.UpMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.DownMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveBulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemiesTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBgTimer
            // 
            this.MoveBgTimer.Enabled = true;
            this.MoveBgTimer.Interval = 10;
            this.MoveBgTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainPlayer
            // 
            this.mainPlayer.BackColor = System.Drawing.Color.Transparent;
            this.mainPlayer.Image = global::My_First_Game_2D_Redemption_.Properties.Resources.cowboy;
            this.mainPlayer.Location = new System.Drawing.Point(64, 453);
            this.mainPlayer.Name = "mainPlayer";
            this.mainPlayer.Size = new System.Drawing.Size(125, 120);
            this.mainPlayer.TabIndex = 0;
            this.mainPlayer.TabStop = false;
            // 
            // LeftMoveTimer
            // 
            this.LeftMoveTimer.Interval = 10;
            this.LeftMoveTimer.Tick += new System.EventHandler(this.LeftMoveTimer_Tick);
            // 
            // RightMoveTimer
            // 
            this.RightMoveTimer.Interval = 10;
            this.RightMoveTimer.Tick += new System.EventHandler(this.RightMoveTimer_Tick);
            // 
            // UpMoveTimer
            // 
            this.UpMoveTimer.Interval = 10;
            this.UpMoveTimer.Tick += new System.EventHandler(this.UpMoveTimer_Tick);
            // 
            // DownMoveTimer
            // 
            this.DownMoveTimer.Interval = 10;
            this.DownMoveTimer.Tick += new System.EventHandler(this.DownMoveTimer_Tick);
            // 
            // MoveBulletsTimer
            // 
            this.MoveBulletsTimer.Enabled = true;
            this.MoveBulletsTimer.Interval = 10;
            this.MoveBulletsTimer.Tick += new System.EventHandler(this.MoveBulletsTimer_Tick);
            // 
            // MoveEnemiesTimer
            // 
            this.MoveEnemiesTimer.Enabled = true;
            this.MoveEnemiesTimer.Interval = 10;
            this.MoveEnemiesTimer.Tick += new System.EventHandler(this.MoveEnemiesTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1036, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Score:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ravie", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(640, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(606, 107);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game Over";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1046, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 50);
            this.label3.TabIndex = 3;
            this.label3.Text = "Level:";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.White;
            this.labelScore.Location = new System.Drawing.Point(1183, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(70, 50);
            this.labelScore.TabIndex = 4;
            this.labelScore.Text = "00";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.BackColor = System.Drawing.Color.Transparent;
            this.labelLevel.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLevel.ForeColor = System.Drawing.Color.White;
            this.labelLevel.Location = new System.Drawing.Point(1183, 59);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(63, 50);
            this.labelLevel.TabIndex = 5;
            this.labelLevel.Text = "01";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.DarkOrange;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Ravie", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(518, 201);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(356, 98);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.MouseCaptureChanged += new System.EventHandler(this.StartButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.DarkOrange;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Ravie", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Location = new System.Drawing.Point(527, 315);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(338, 96);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.MouseCaptureChanged += new System.EventHandler(this.ExitButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.BackColor = System.Drawing.Color.DarkOrange;
            this.RestartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartButton.Font = new System.Drawing.Font("Ravie", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartButton.ForeColor = System.Drawing.Color.Black;
            this.RestartButton.Location = new System.Drawing.Point(408, 430);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(475, 86);
            this.RestartButton.TabIndex = 8;
            this.RestartButton.Text = "RESTART";
            this.RestartButton.UseVisualStyleBackColor = false;
            this.RestartButton.MouseCaptureChanged += new System.EventHandler(this.RestartButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::My_First_Game_2D_Redemption_.Properties.Resources.background_jpeg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mainPlayer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "2D Redemption";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.mainPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MoveBgTimer;
        private System.Windows.Forms.PictureBox mainPlayer;
        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer MoveBulletsTimer;
        private System.Windows.Forms.Timer MoveEnemiesTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button RestartButton;
    }
}

