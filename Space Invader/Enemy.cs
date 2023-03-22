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
    class Enemy : Image
    {
        private int x; //position
        private int y;
        private bool alive = true;


        public Enemy(int x, int y, bool alive)
        {
            Source = new BitmapImage(new Uri(@"/Ressources/Renard.jpg", UriKind.Relative));
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
            this.x = x;
            this.y = y;
            this.alive = alive;
            this.Width = 100;
            this.Height = 100;
        }


        public int getx()
        { return x; }
        public void setx(int newx)
        { x = newx; }

        public int gety()
        { return y; }
        public void sety(int newy)
        { y = newy; }

        public bool getalive()
        { return alive; }
        public bool setalive()
        { alive = false; return alive; }


        public void automaticEnemy() //Enemy moving alone
        {
            Random random = new Random(); //to generate a random number, so a random position of the enemy
            int a;
            while (true)
            {
                Thread.Sleep(800);
                this.Dispatcher.Invoke(() =>
                {
                    a = random.Next(1, 100);
                    if (a > 50)
                    {
                        changepositionx(+10);
                    }
                    else
                    {
                        changepositionx(-10);
                    }
                changepositiony(10);
                });
            }
        }


        public void changepositionx(int change)
        {
            if ((change + x < 1200) && (change + x > 0))
            {
                x = x + change;
                Canvas.SetLeft(this, Canvas.GetLeft(this) + change);
            } 
        }

        public void changepositiony(int change)
        {
            if ((change + y < 550) && (change + y > 0))
            {
                y = y + change;
                Canvas.SetTop(this, Canvas.GetTop(this) + change);
            }
        }
    }
}