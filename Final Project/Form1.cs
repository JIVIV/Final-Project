using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        static public List<Card> deck = new List<Card>();
        static public List<Card>[,] placement = new List<Card>[5,5];
        static public Card inPlay;
        static public int ace = 0, joker = 0, acesUsed = 0, jokersUsed = 0;
        static public bool usingAce = false, usingJoker = false;
        public void fillAndShuffle()
        {
            Card card = new Card();
            for(int i=0; i < 52; i++)
            {
                deck.Add(new Card { face = (i % 13) + 1, suit = (i % 4) + 1, color = (i % 2) + 1});
            }
            deck.Add(new Card { face = 14});
            deck.Add(new Card { face = 14});
            deck.Shuffle();
            Draw();
        }
         public void Draw()
        {
            inPlay = deck[0];
            deck.Remove(inPlay);
            Play.Image = imageList1.Images[((inPlay.face * 4) + 1 - inPlay.suit)];
            switch (inPlay.face)
            {
                case 1:
                    ace++;
                    Ace.Text = Convert.ToString(ace);
                    Draw();
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:

                    break;
                case 11:
                case 12:
                case 13:
                    royalPlacement(inPlay);
                    Draw();
                    break;
                case 14:
                    joker++;
                    Joker.Text = Convert.ToString(joker);
                    Draw();
                    break;
            }
        }
        public void royalPlacement(Card royal)
        {
            int highest = 0;
            bool suit = false, color = false;
            for(int i = 1; i < 4; i++)
            {
                for(int j = 1; j < 4;)
                {
                    if(i != 2 || j != 2)
                    {
                        if (!suit || !color)
                        {
                            if (placement[i, j][0].suit == royal.suit)
                            {
                                suit = true;
                            }
                            else if (placement[i, j][0].color == royal.color)
                            {
                                color = true;
                                if (placement[i, j][0].face > highest)
                                    highest = placement[i, j][0].face;
                            }
                        }
                    }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            Deck.Image = imageList1.Images[0];
            Ace.Image = imageList1.Images[3];
            Joker.Image = imageList1.Images[54];
            fillAndShuffle();
        }
    }
}

public static class CardMixer
{
    public static void Shuffle<T>(this IList<T> list)
    {
        Random rng = new Random(DateTime.Now.Second);
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

public class Card
{
    public int face, suit, color, armor;
}