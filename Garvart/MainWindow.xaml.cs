using Garvart.Classes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace Garvart
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Classes.PersoInfo Player = new Classes.PersoInfo("Student", 100,10, 1, 0, 0, 5 );
        public List<Classes.PersoInfo> Enemys = new List<Classes.PersoInfo>();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public Classes.PersoInfo Enemy;
        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayer();
            Enemys.Add(new Classes.PersoInfo("Дракон1", 100, 20, 1, 15, 5, 20));
            Enemys.Add(new Classes.PersoInfo("Марионетка", 20, 5, 1, 5, 2, 5));
            Enemys.Add(new Classes.PersoInfo("Милый_дракон", 50, 3, 1, 10, 10, 15));
            dispatcherTimer.Tick += AtackPlayer; ;
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 100);
            dispatcherTimer.Start();
            SelectEnemy();
        }

        private void AtackPlayer(object sender, System.EventArgs e)
        {
            Player.Health -= Convert.ToInt32(Enemy.Damage * 100f / (100f - Player.Armor));
            UserInfoPlayer();
        }
        public void SelectEnemy()
        {
            int Id = new Random().Next(0, Enemys.Count);
            Enemy = new Classes.PersoInfo(
                Enemys[Id].Name,
                Enemys[Id].Health,
                Enemys[Id].Armor,
                Enemys[Id].Level,
                Enemys[Id].Glasses,
                Enemys[Id].Money,
                Enemys[Id].Damage);
            string imagePath = "";
            if (Enemy.Name == "Дракон1")

            {
                emptyHealth.Content += "Дракон1";
                imagePath = "/image/photo_2026-09-22_12-49-02.jpg";
            }
            if (Enemy.Name == "Марионетка")
            {
                imagePath = "/Image/photo_2026-09-22_12-49-12.jpg";
            }
            if (Enemy.Name == "Милый_дракон")
            {
                imagePath = "/Image/photo_2026-09-22_12-48-55.jpg";
            }
            if (imagePath != "")
            {
                emptyImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }
        }
        public void UserInfoPlayer()
        {
            if (Player.Glasses > 100 * Player.Level)
            {
                Player.Level++;
                Player.Glasses = 0;
                Player.Health += 100;
                Player.Damage++;
                Player.Armor++;
            }
         
            playerHealth.Content = "Жизненные показатели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Money;

            if (Player.Health <= 0)
            {
                MessageBox.Show("GameOver");
                Application.Current.Shutdown();
                return;
            }
            
        }

        private void AttackEnemy(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Enemy.Health -= Convert.ToInt32(Player.Damage * 100f / (100f - Enemy.Armor));

            Random rnd = new Random();
            int proverka = rnd.Next(1, 101);
           
            if (proverka <= 20)
            {
                vivid.Content = $" Контр атака {proverka} урона нанесено ";
                Player.Health -= proverka;
                playerHealth.Content = "Жизненные показатели: " + Player.Health;
            }
            
            if (Enemy.Health <=0)
            {
                int bonus = rnd.Next(0, 31);
                
                Player.Glasses += Enemy.Glasses * Enemy.Glasses * bonus / 100;
                
                Player.Money += Enemy.Money;
                UserInfoPlayer();
                SelectEnemy();
            }
            else
            {
                emptyHealth.Content = "Жизненные показатели: " + Enemy.Health;
                emptyArmor.Content = "Броня: " + Enemy.Armor;
            }
        }

        
    }
}
