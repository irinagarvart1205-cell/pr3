using Garvart.Classes;
using System.Collections.Generic;
using System.Windows;
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
        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayer();
            Enemys.Add(new Classes.PersoInfo("Дракон1", 100, 20, 1, 15, 5, 20));
            Enemys.Add(new Classes.PersoInfo("Марионетка", 20, 5, 1, 5, 2, 5));
            Enemys.Add(new Classes.PersoInfo("Милый_дракон", 50, 3, 1, 10, 10, 15));
            dispatcherTimer.Tick += AtackPlayer; ;
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void AtackPlayer(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
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
        }

        
    }
}
