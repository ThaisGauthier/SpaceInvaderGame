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
    class Rock : Image 
    {
        private int x;//position
        private int y; 


        public Rock(int x, int y) //Constructeur
        {
            Source = new BitmapImage(new Uri(@"/Ressources/Cloture.jpg", UriKind.Relative));
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
            this.x = x;
            this.y = y;
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

    }
}