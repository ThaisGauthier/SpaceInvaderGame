using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Space_Invader
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player;
        Enemy enemy1;
        Enemy enemy2;
        Enemy enemy3;
        Enemy enemy4;
        Enemy enemy5;
        Enemy enemy6;
        Enemy enemy7;
        Enemy enemy8;
        Enemy[] enemyarray;
        Bullet bullet;
        Rock rock1;
        Rock rock2;
        Rock rock3;
        Rock rock4;
        Rock rock5;
        Attack attack1;

        //Create Canvas
        Canvas canvas = new Canvas();

        public MainWindow()
        {
            InitializeComponent();

            PrepareScreen();

            // Get keyboard input
            EventManager.RegisterClassHandler(typeof(Window),
                    Keyboard.KeyDownEvent, new KeyEventHandler(keyDown), true);
        }


        private void PrepareScreen()
        {
            this.WindowState = System.Windows.WindowState.Maximized; // faire grand écran

            canvas.Background = Brushes.Black; //changer la couleur
            this.Content = canvas; //telling to the application that the canvas created is stored in the main window

            //Show the score
            TextBlock showscore = new TextBlock();
            showscore.Text = "SCORE = 0 ";
            Color color = Color.FromRgb(255, 0, 0);
            showscore.Foreground = new SolidColorBrush(color);
            Canvas.SetLeft(showscore, 20);
            Canvas.SetTop(showscore, 20);
            canvas.Children.Add(showscore);

            //Add player
            player = new Player(500, 500, 0, showscore); //donner une valeur à l'attribut
            canvas.Children.Add(player);

            //Add Enemy
            enemy1 = new Enemy(400, 50, true);
            canvas.Children.Add(enemy1);
            enemy2 = new Enemy(100, 100, true);
            canvas.Children.Add(enemy2);
            enemy3 = new Enemy(1000, 100, true);
            canvas.Children.Add(enemy3);
            enemy4 = new Enemy(800, 30, true);
            canvas.Children.Add(enemy4);
            enemy5 = new Enemy(600, 10, true);
            canvas.Children.Add(enemy5);
            enemy6 = new Enemy(500, 150, true);
            canvas.Children.Add(enemy6);
            enemy7 = new Enemy(1100, 100, true);
            canvas.Children.Add(enemy7);
            enemy8 = new Enemy(250, 50, true);
            canvas.Children.Add(enemy8);
            enemyarray = new Enemy[8] { enemy1, enemy2, enemy3, enemy4, enemy5, enemy6, enemy7, enemy8 }; //enemy array

            //Add Rock
            rock1 = new Rock(100, 100);
            canvas.Children.Add(rock1);
            rock2 = new Rock(1000, 400);
            canvas.Children.Add(rock2);
            rock3 = new Rock(300,300);
            canvas.Children.Add(rock3);
            rock4 = new Rock(700, 200);
            canvas.Children.Add(rock4);
            rock5 = new Rock(900, 150);
            canvas.Children.Add(rock5);

            //Add Attack : not working
            //attack1 = new Attack(200,200);
            //canvas.Children.Add(attack1);

            //Start Enemy Thread
            Thread thread1 = new Thread(enemy1.automaticEnemy);
            thread1.Start();
            Thread thread2 = new Thread(enemy2.automaticEnemy);
            thread2.Start();
            Thread thread3 = new Thread(enemy3.automaticEnemy);
            thread3.Start();
            Thread thread4 = new Thread(enemy4.automaticEnemy);
            thread4.Start();
            Thread thread5 = new Thread(enemy5.automaticEnemy);
            thread5.Start();
            Thread thread6 = new Thread(enemy6.automaticEnemy);
            thread6.Start();
            Thread thread7 = new Thread(enemy7.automaticEnemy);
            thread7.Start();
            Thread thread8 = new Thread(enemy8.automaticEnemy);
            thread8.Start();
        }


        private void keyDown(object sender, KeyEventArgs e) //methode pour bouger le player et le bullet
        {
            if (e.Key == Key.Left)
            {
                player.movePlayer(-12);
            }
            if (e.Key == Key.Right)
            {
                player.movePlayer(12);
            }
            if (e.Key == Key.Up)
            {
                //Add bullet
                bullet = new Bullet(player.getx(), player.gety(), player, canvas, enemyarray);
                canvas.Children.Add(bullet);
                Thread thread = new Thread(bullet.automaticBullet);
                thread.Start();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //code joint au bouton de la fenêtre d'affichage
        {
            MessageBox.Show("Hello World");
        }
    }
}

// The classes Rock and Attack are not working for now, the methodes are not created and impemented in the mainWindow
