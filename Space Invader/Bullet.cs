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
    class Bullet : Image
    {
        private int x;//position
        private int y;
        private Player player;
        private Canvas canvas;
        private Enemy [] enemyarray;


        public Bullet(int x, int y, Player player, Canvas canvas, Enemy [] enemyarray) //Constructeur
        {
            Source = new BitmapImage(new Uri(@"/Ressources/Oeuf.jpg", UriKind.Relative));
            //Position de l'image sur le canvas
            Canvas.SetLeft(this, player.getx() + 40);
            Canvas.SetTop(this, player.gety() - 25);
            this.x = x;
            this.y = y;
            this.player = player;
            this.canvas = canvas;
            this.enemyarray = enemyarray;
            //Définir la aille de l'image
            this.Width = 40;
            this.Height = 40;
        }


        public int getx()
        { return x; }
        public void setx(int newx)
        { x = newx; }

        public int gety()
        { return y; }
        public void sety(int newy)
        { y = newy; }

        public Player getplayer()
        { return player; }

        public Canvas getcanvas()
        { return canvas; }

        public Enemy [] getenemyarray()
        { return enemyarray; }


        public void automaticBullet() //Bullet bouge toute seul
        {
            while (true)
            {
                Thread.Sleep(200);
                this.Dispatcher.Invoke(() =>
                {
                    changepositiony(-30);
                    for (int i = 0; i < enemyarray.Length; i ++)
                    {
                        if (enemyarray[i].getalive()== true) //on test si l'enemy est en vie
                        {
                            if (x + 30 < 50 + enemyarray[i].getx() && x + 30 > 30 + enemyarray[i].getx() - 35 && y - 30 < 50 + enemyarray[i].gety() && y - 30 > enemyarray[i].gety() - 50)
                            {
                                canvas.Children.Remove(enemyarray[i]);
                                enemyarray[i].setalive();
                                // to print the score score
                                player.setscore(player.getscore() + 1); // score goes up of 1
                                canvas.Children.Remove(player.getshowscore());
                                player.setshowscore();
                                Color color = Color.FromRgb(255, 0, 0);
                                player.getshowscore().Foreground = new SolidColorBrush(color);
                                Canvas.SetLeft(player.getshowscore(), 20);
                                Canvas.SetTop(player.getshowscore(), 20);
                                canvas.Children.Add(player.getshowscore());

                                //to show an ending message to the player
                                if (player.getscore() == enemyarray.Length)
                                {
                                    canvas.Children.Clear();
                                    TextBlock endgame = new TextBlock();
                                    endgame.Text = "YOU WIN";
                                    endgame.Foreground = new SolidColorBrush(color);
                                    Canvas.SetLeft(endgame, 600);
                                    Canvas.SetTop(endgame, 400);
                                    canvas.Children.Add(endgame);
                                }
                            }
                        }
                    }
                });
            }
        }

        public void changepositionx(int change)
        {
            x = x + change;
        }

        public void changepositiony(int change)
        {
            y = y + change;
            Canvas.SetTop(this, Canvas.GetTop(this) + change);
        }
    }
}