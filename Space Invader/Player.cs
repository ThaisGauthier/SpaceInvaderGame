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
    class Player : Image //inheritance
    {
        //attributs
        private int x; //position
        private int y;
        private int score;
        private TextBlock showscore;


        public Player(int x, int y, int score, TextBlock showscore) //Constructeur
        {
            Source = new BitmapImage(new Uri(@"/Ressources/Poule1.png", UriKind.Relative));
            //Position de l'image sur le canvas
            Canvas.SetLeft(this, 500);
            Canvas.SetTop(this, 500);
            this.x = x; //sauvgarde la position
            this.y = y;
            this.score = score;
            this.showscore = showscore;
            //Définir la taille de l'image
            this.Width = 150;
            this.Height = 150;
        }


        //to pu the attributes in private
        public int getx()
        { return x; }
        public void setx(int newx)
        { x = newx; }

        public int gety()
        { return y; }
        public void sety(int newy)
        { y = newy; }

        public int getscore()
        { return score; }
        public int setscore(int newscore)
        { score = newscore; return score; }

        public TextBlock getshowscore()
        { return showscore; }
        public TextBlock setshowscore()
        { showscore.Text = "SCORE = " + score; return showscore; }


        public void changepositionx(int change) //void :return nothing - public: pour accéder de la classe program
        {
            x = x + change;
        }

        public void changepositiony(int change)
        { 
            y = y + change;
        }


        //position of the player
        public void movePlayer(int newPosition)
        {
            Canvas.SetLeft(this, Canvas.GetLeft(this) + newPosition);
            changepositionx(newPosition);
        }
    }
}
