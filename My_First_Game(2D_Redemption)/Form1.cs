using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace My_First_Game_2D_Redemption_
{
    public partial class Form1 : Form
    {
        PictureBox[] cloud;
        PictureBox[] Death;
        int backgroundSpeed;
        Random rnd;
        int playerSpeed;

        PictureBox[] bullets;
        int bulletsSpeed;

        PictureBox[] enemies;
        int sizeEnemy;
        int enemiesSpeed;

        int Score;
        int Level;

        WindowsMediaPlayer Shoot;
        WindowsMediaPlayer GameSong;
        WindowsMediaPlayer Rip;
        WindowsMediaPlayer KillingPlayer;
        WindowsMediaPlayer ripDeath;

        public Form1()
        {
            InitializeComponent();

            // Установка KeyPreview в true
            this.KeyPreview = true;

            // Инициализация таймеров
            LeftMoveTimer = new Timer();
            RightMoveTimer = new Timer();
            UpMoveTimer = new Timer();
            DownMoveTimer = new Timer();

            LeftMoveTimer.Interval = 20;
            RightMoveTimer.Interval = 20;
            UpMoveTimer.Interval = 20;
            DownMoveTimer.Interval = 20;

            LeftMoveTimer.Tick += new EventHandler(LeftMoveTimer_Tick);
            RightMoveTimer.Tick += new EventHandler(RightMoveTimer_Tick);
            UpMoveTimer.Tick += new EventHandler(UpMoveTimer_Tick);
            DownMoveTimer.Tick += new EventHandler(DownMoveTimer_Tick);

            // Подключение обработчиков событий клавиатуры
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);
        }

        private bool cloudsMoving = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isGameOver)
                return; // Прекратите выполнение, если игра окончена

            if (isGameOver || !cloudsMoving)
                return; // Прекратите выполнение, если игра окончена или облака не движутся

            ////for (int i = 0; i < cloud.Length; i++)
            ////{
            ////    cloud[i].Left += backgroundSpeed;

            ////    if (cloud[i].Left >= 1280)
            ////    {
            ////        cloud[i].Left = cloud[i].Height;
            ////    }
            ////}

            ////for (int i = cloud.Length; i < cloud.Length; i--)
            ////{
            ////    cloud[i].Left += backgroundSpeed - 10;

            ////    if (cloud[i].Left > 1280)
            ////    {
            ////        cloud[i].Left = cloud[i].Left;
            ////    }
            ////}
            foreach (var c in cloud)
            {
                c.Left -= backgroundSpeed;

                if (-c.Left > c.Width)
                {
                    c.Left = this.Width;
                    c.Top = rnd.Next(140, 220);
                }
            }

            foreach (var t in Death)
            {
                t.Left -= backgroundSpeed / 2;

                // Плавное движение вверх-вниз
                int verticalMovement = (int)(10 * Math.Sin(t.Left * Math.PI / 180));
                t.Top = t.Top + verticalMovement;

                if (-t.Left > t.Width)
                {
                    t.Left = this.Width;
                    t.Top = rnd.Next(0, this.Height);
                }
            }
        }

        private void HideClouds()
        {
            foreach (var c in cloud)
            {
                c.Visible = false;
            }
        }

        private void ShowClouds()
        {
            foreach (var c in cloud)
            {
                c.Visible = true;
            }
        }

        //Пример использования градиента для создания тени облака
        private void DrawCloudWithShadow(PictureBox cloud)
        {
            Bitmap bitmap = new Bitmap(cloud.Width, cloud.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(cloud.Image, new Rectangle(0, 0, cloud.Width, cloud.Height), 0, 0, cloud.Width, cloud.Height, GraphicsUnit.Pixel);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, Color.Black)))
                {
                    g.FillEllipse(brush, 10, 10, cloud.Width, cloud.Height);
                }
            }

            cloud.Image = bitmap;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartGame();

            // Скрыть кнопки после начала игры
            StartButton.Visible = false;
            ExitButton.Visible = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            // Сброс игры и запуск заново
            InitializeEnemies(); // Инициализируем врагов
            StartGame();
            // Сброс персонажа на начальную позицию
            mainPlayer.Location = new Point(50, 360);

            // Убедитесь, что все враги видимы
            foreach (var enemy in enemies)
            {
                enemy.Visible = true;
            }
        }

        private void ShowMenu()
        {
            // Показать кнопки START и EXIT
            StartButton.Visible = true;
            ExitButton.Visible = true;

            // Остановить все игровые процессы
            GameSong.controls.pause();
            MoveEnemiesTimer.Stop();
            MoveBulletsTimer.Stop();
            timer1.Stop();
            LeftMoveTimer.Stop();
            RightMoveTimer.Stop();
            UpMoveTimer.Stop();
            DownMoveTimer.Stop();

            // Скрыть облака
            HideClouds();

            // Скрыть главного игрока
            mainPlayer.Visible = false;

            // Скрыть врагов и пули
            foreach (var e in enemies)
            {
                e.Visible = false;
            }

            foreach (var b in bullets)
            {
                b.Visible = false;
            }

            // Остановите движение объектов Death
            foreach (var d in Death)
            {
                d.Visible = false;
            }
        }

        private void StartGame()
        {
            // Сброс переменных
            isGameOver = false;
            Score = 0;
            Level = 1;

            // Скрыть сообщение об окончании игры
            label1.Visible = false;
            labelLevel.Visible = true;
            labelScore.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            // Обновление отображения счета и уровня
            labelScore.Text = "00";
            labelLevel.Text = "01";

            // Показать главного игрока
            mainPlayer.Visible = true;

            // Установите начальное положение персонажа
            mainPlayer.Location = new Point(50, 360);

            // Остановите движение облаков
            cloudsMoving = true;

            // Показать облака через некоторое время или по определенному событию
            // Например, после начала движения врагов или после запуска игры
            ShowClouds(); // Если нужно показать облака в начале игры

            // Инициализация врагов
            InitializeEnemies();

            // Запуск игровых таймеров и музыки
            GameSong.controls.play();
            MoveEnemiesTimer.Start();
            MoveBulletsTimer.Start();
            timer1.Start(); // Запускаем таймер для обновления объектов

            // Скрыть кнопку RESTART
            RestartButton.Visible = false;
        }

        private void InitializeEnemies()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                int sizeEnemy = rnd.Next(60, 90);
                enemies[i].Size = new Size(sizeEnemy, sizeEnemy);
                enemies[i].Location = new Point((i + 1) * rnd.Next(150, 200) + 1280, rnd.Next(300, 600));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundSpeed = 5;
            cloud = new PictureBox[20];
            Death = new PictureBox[1];
            rnd = new Random();
            playerSpeed = 2;

            bullets = new PictureBox[1];
            bulletsSpeed = 80;

            enemies = new PictureBox[10];
            sizeEnemy = rnd.Next(60, 80);
            enemiesSpeed = 3;

            Score = 0;
            Level = 1;

            Image easyEnemies = Image.FromFile("assets\\virus.gif");
            Image deathImage = Image.FromFile("assets\\Death.png");
            Image Cloud = Image.FromFile("assets\\Cloud.png");

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Image = easyEnemies;
                enemies[i].BackColor = Color.Transparent;
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].Size = new Size(sizeEnemy, sizeEnemy);
                enemies[i].Location = new Point((i + 1) * rnd.Next(90, 160) + 1280, rnd.Next(300, 600));

                this.Controls.Add(enemies[i]);
            }

            for (int i = 0; i < Death.Length; i++)
            {
                Death[i] = new PictureBox();
                Death[i].Image = deathImage;
                Death[i].SizeMode = PictureBoxSizeMode.Zoom;
                Death[i].Size = new Size(100, 100);
                Death[i].Location = new Point(rnd.Next(0, this.Width) + 1280, rnd.Next(0, this.Height));
                Death[i].BackColor = Color.Transparent;

                this.Controls.Add(Death[i]);
            }

            Shoot = new WindowsMediaPlayer();
            Shoot.URL = "songs\\shoot.mp3";
            Shoot.settings.volume = 5;

            Rip = new WindowsMediaPlayer();
            Rip.URL = "songs\\EnemyExplosion.mp3";
            Rip.settings.volume = 25;

            ripDeath = new WindowsMediaPlayer();
            ripDeath.URL = "songs\\goblin-death.mp3";
            ripDeath.settings.volume = 25;

            KillingPlayer = new WindowsMediaPlayer();
            KillingPlayer.URL = "songs\\SoundOfDeath.mp3";
            KillingPlayer.settings.volume = 25;

            GameSong = new WindowsMediaPlayer();
            GameSong.URL = "songs\\GameSong.mp3";
            GameSong.settings.setMode("loop", true);
            GameSong.settings.volume = 15;

            for(int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].BorderStyle = BorderStyle.None;
                bullets[i].Size = new Size(20, 5);
                bullets[i].BackColor = Color.White;

                this.Controls.Add(bullets[i]);
            }

            for (int i = 0; i < cloud.Length; i++)
            {
                cloud[i] = new PictureBox();
                //cloud[i].Image = Cloud;
                //cloud[i].SizeMode = PictureBoxSizeMode.Zoom;
                //cloud[i].Size = new Size(100, 100);
                //cloud[i].BackColor = Color.Transparent;
                cloud[i].BorderStyle = BorderStyle.None;
                cloud[i].Location = new Point(rnd.Next(-1000, 1280), rnd.Next(200, 200));
                if (i % 2 == 1)
                {
                    cloud[i].Size = new Size(rnd.Next(100, 255), rnd.Next(30, 70));
                    cloud[i].BackColor = Color.FromArgb(rnd.Next(50, 125), 255, 200, 200);
                }
                else
                {
                    cloud[i].Size = new Size(150, 25);
                    cloud[i].BackColor = Color.FromArgb(rnd.Next(50, 125), 255, 205, 205);
                }

                this.Controls.Add(cloud[i]); // Добавляем на форму.
            }

            // Инициализация ваших объектов и таймеров

            // Скрываем ненужные элементы управления до начала игры
            label1.Visible = false;
            labelLevel.Visible = false;
            labelScore.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            RestartButton.Visible = false;

            // Остановите все таймеры при загрузке формы
            MoveEnemiesTimer.Stop();
            MoveBulletsTimer.Stop();
            timer1.Stop();

            // Скрыть облака
            HideClouds();

            // Скрываем главного игрока
            mainPlayer.Visible = false;

            // Заставьте форму получать фокус
            this.Focus();
        }


        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (mainPlayer.Left > 10)
            {
                mainPlayer.Left -= playerSpeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            // Проверка, чтобы персонаж не выходил за правую границу экрана

            if (mainPlayer.Right < this.ClientSize.Width)
            {
                mainPlayer.Left += playerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
          {
            int screenHeight = this.ClientSize.Height; // Высота экрана
            int middleScreen = screenHeight / 2; // Средина экрана
            int upperLimit = middleScreen + 15; // Верхний предел с учетом смещения

            if (mainPlayer.Top > upperLimit) // Проверяем, не выше ли верхнего предела
            {
                mainPlayer.Top -= playerSpeed;
            }

        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            int screenHeight = this.ClientSize.Height; // Высота экрана
            int characterBottom = mainPlayer.Bottom; // Нижняя граница персонажа

            if (characterBottom < screenHeight) // Проверяем, не ниже ли нижней границы экрана
            {
                mainPlayer.Top += playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            mainPlayer.Image = Properties.Resources.cowboy_run;

            if (e.KeyCode == Keys.Left)
            {
                LeftMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Right)
            {
                RightMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Up)
            {
                UpMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Down)
            {
                DownMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Space)
            {
                Shoot.controls.play();

                for (int i = 0; i < bullets.Length; i++)
                {
                    Intersect();

                    if (bullets[i].Left > this.Width)
                    {
                        bullets[i].Location = new Point(mainPlayer.Location.X + 100 + i * 50, mainPlayer.Location.Y + 50);
                        bullets[i].Visible = true; // Убедитесь, что пули видимы
                        break; // Выход из цикла после установки первой видимой пули
                    }
                }
            }

            // Обработка нажатия клавиши ESC
            if (e.KeyCode == Keys.Escape)
            {
                ShowMenu(); // Показать меню
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            mainPlayer.Image = Properties.Resources.cowboy;

            if (e.KeyCode == Keys.Left)
            {
                LeftMoveTimer.Stop();
            }

            if (e.KeyCode == Keys.Right)
            {
                RightMoveTimer.Stop();
            }

            if (e.KeyCode == Keys.Up)
            {
                UpMoveTimer.Stop();
            }

            if (e.KeyCode == Keys.Down)
            {
                DownMoveTimer.Stop();
            }
        }

        private void MoveBulletsTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < bullets.Length; i++)
            {
                bullets[i].Left += bulletsSpeed;
            }
        }

        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiesSpeed);
        }

        private void MoveEnemies(PictureBox[] enemies, int speed)
        {
            for(int i = 0; i < enemies.Length; i++)
            {
                enemies[i].Left -= speed + (int)(Math.Sin(enemies[i].Left * Math.PI / 180) + Math.Cos(enemies[i].Left * Math.PI/ 180));

                Intersect();

                if(enemies[i].Left < -enemies[i].Width)
                {
                    int sizeEnemy = rnd.Next(60, 90);
                    enemies[i].Size = new Size(sizeEnemy, sizeEnemy);
                    enemies[i].Location = new Point((i + 1) * rnd.Next(150, 200) + 1280, rnd.Next(300, 650));
                }
            }
        }

        private void Intersect()
        {
            // Проверка пересечения с врагами

            for (int i = 0; i < enemies.Length; i++)
            {
                // Создаем уменьшенные области столкновения для врага
                Rectangle enemyBounds = enemies[i].Bounds;
                Rectangle enemyCollisionBounds = new Rectangle(
                    enemyBounds.X + 10,  // Уменьшаем область с левого края
                    enemyBounds.Y + 10,  // Уменьшаем область сверху
                    enemyBounds.Width - 20,  // Уменьшаем ширину
                    enemyBounds.Height - 20  // Уменьшаем высоту
                );

                // Проверяем пересечение с уменьшенной областью врага
                if (bullets[0].Bounds.IntersectsWith(enemyCollisionBounds))
                {
                    Rip.controls.play();

                    Score += 1;
                    labelScore.Text = (Score < 10) ? "0" + Score.ToString() : Score.ToString();

                    if (Score % 10 == 0)
                    {
                        Level += 1;
                        labelLevel.Text = (Level < 10) ? "0" + Level.ToString() : Level.ToString();

                        if (enemiesSpeed <= 3)
                        {
                            enemiesSpeed++;
                        }

                        if (Level == 4)
                        {
                            GameOver("YOU WIN!");
                        }
                    }

                    enemies[i].Location = new Point((i + 1) * rnd.Next(150, 250) + 1280, rnd.Next(420, 650));
                    bullets[0].Location = new Point(2000, mainPlayer.Location.Y + 50);
                }

                // Создаем уменьшенные области столкновения для игрока
                Rectangle playerBounds = mainPlayer.Bounds;
                Rectangle playerCollisionBounds = new Rectangle(
                    playerBounds.X + 10,  // Уменьшаем область с левого края
                    playerBounds.Y + 10,  // Уменьшаем область сверху
                    playerBounds.Width - 20,  // Уменьшаем ширину
                    playerBounds.Height - 20  // Уменьшаем высоту
                );

                // Проверяем пересечение с уменьшенной областью игрока
                if (playerCollisionBounds.IntersectsWith(enemyCollisionBounds))
                {
                    mainPlayer.Visible = false;

                    GameOver("GAME OVER");
                }
            }

            // Проверка пересечения с объектом Death
            for (int i = 0; i < Death.Length; i++)
            {
                Rectangle deathBounds = Death[i].Bounds;
                Rectangle deathCollisionBounds = new Rectangle(
                    deathBounds.X + 10,
                    deathBounds.Y + 10,
                    deathBounds.Width - 20,
                    deathBounds.Height - 20
                );

                if (bullets[0].Bounds.IntersectsWith(deathCollisionBounds))
                {
                    // Действие при пересечении с объектом Death
                    ripDeath.controls.play();

                    // Можно увеличить счет или добавить другие действия
                    Score += 5;
                    labelScore.Text = (Score < 10) ? "0" + Score.ToString() : Score.ToString();

                    Death[i].Location = new Point(rnd.Next(0, this.Width) + 1280, rnd.Next(0, this.Height));
                    bullets[0].Location = new Point(2000, mainPlayer.Location.Y + 50);
                }
            }
        }

        private bool isGameOver = false;

        private void GameOver(string str)
        {
            label1.Text = str;
            label1.Location = new Point(200, 250);
            label1.Visible = true;
            labelLevel.Visible = false;
            labelScore.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            GameSong.controls.stop();
            Shoot.controls.stop();
            MoveEnemiesTimer.Stop();
            LeftMoveTimer.Stop();
            RightMoveTimer.Stop();
            UpMoveTimer.Stop();
            DownMoveTimer.Stop();
            MoveBulletsTimer.Stop();
            timer1.Stop(); // Остановите таймер, который отвечает за обновление объектов

            isGameOver = true; // Установите флаг, что игра окончена

            // Остановите движение объектов Death
            foreach (var d in Death)
            {
                d.Left = this.Width; // Переместите их за пределы экрана
                d.Top = this.Height; // Переместите их за пределы экрана
            }

            foreach (var e in enemies)
            {
                e.Visible = false;
            }

            foreach (var b in bullets)
            {
                b.Visible = false;
            }

            // Скрыть облака
            HideClouds();

            KillingPlayer.controls.play();

            // Показываем кнопку RESTART
            RestartButton.Visible = true;
        }
    }
}
