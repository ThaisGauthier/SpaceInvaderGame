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
    class Attack : Image
    {
        private int x;//position
        private int y;


        public Attack(int x, int y) //Constructeur
        {
            Source = new BitmapImage(new Uri(@"/Ressources/Eau.jpg", UriKind.Relative));
            //Position de l'image sur le canvas
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
            this.x = x;
            this.y = y;
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


        public void changepositionx(int change)
        {
            x = x + change;
        }

        public void changepositiony(int change)
        {
            y = y + change;
        }

    }
}
