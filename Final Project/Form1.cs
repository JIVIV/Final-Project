using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        static public int ace = 0, joker = 0, acesUsed = 0, jokersUsed = 0, score = 6;
        static public bool usingAce = false, usingJoker = false, p01 = false, p03 = false, p10 = false,
            p11 = false, p12 = false, p13 = false, p14 = false, p21 = false, p22 = false, p23 = false,
            p30 = false, p31 = false, p32 = false, p33 = false, p34 = false, p41 = false, p43 = false;
        static public bool[,] placed = new bool[5, 5];
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
        }
         public void Draw()
        {
            inPlay = deck[0];
            deck.Remove(inPlay);
            if(inPlay.face != 14)
                Play.Image = imageList1.Images[((inPlay.face * 4) + 1 - inPlay.suit)];            
        }
        public void royalPlacement(Card royal)
        {
            int highest = 0, highesti = 0, highestj = 0;
            bool suit = false, color = false;
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (i != 2 || j != 2)
                    {
                        if (placement[i, j][0].suit == royal.suit)
                            suit = true;
                        else if (placement[i, j][0].color == royal.color)
                            color = true;
                        if (suit)
                        {
                            if (placement[i, j][0].suit == royal.suit && !placed[i,j])
                            {
                                if (highest > placement[i, j][0].face)
                                {
                                    highest = placement[i, j][0].face;
                                    highesti = i;
                                    highestj = j;
                                }
                            }
                        }
                        else if (color)
                        {
                            if (placement[i, j][0].suit == royal.suit && !placed[i,j])
                            {
                                if (highest > placement[i, j][0].face)
                                {
                                    highest = placement[i, j][0].face;
                                    highesti = i;
                                    highestj = j;
                                }
                            }
                        }
                        else
                        {
                            if (placement[i, j][0].suit == royal.suit && !placed[i,j])
                            {
                                if (highest > placement[i, j][0].face)
                                {
                                    highest = placement[i, j][0].face;
                                    highesti = i;
                                    highestj = j;
                                }
                            }
                        }
                    }
                }
            }
            if (highesti == 1 && highestj == 1)
            {
                p01 = true;
                p10 = true;
            }
            else if (highesti == 1 && highestj == 2 && !placed[0,2])
            {
                placed[0, 2] = true;
                placement[0, 2].Add(royal);
            }
            else if (highesti == 1 && highestj == 3)
            {
                p03 = true;
                p14 = true;
            }
            else if (highesti == 2 && highestj == 1 && !placed[2, 0])
            {
                placed[2,0] = true;
                placement[2, 0].Add(royal);
            }
            else if(highesti == 2 && highestj == 3 && !placed[2,4])
            {
                placed[2, 4] = true;
                placement[2, 4].Add(royal);
            }
            else if(highesti == 3 && highestj == 1)
            {
                p30 = true;
                p41 = true;
            }
            else if(highesti == 3 && highestj == 2 && !placed[4,2])
            {
                placed[4, 2] = true;
                placement[4, 2].Add(royal);
            }
            else if(highesti == 3 && highestj == 3)
            {
                p34 = true;
                p43 = true;
            }
        }
        public void setUp()
        {
            int i = 0, j = 0, k = 0;
            Card[] royal = new Card[12];
            for (i = 0; i < 5; i++)
                for (j = 0; j < 5; j++)
                {
                    placed[i, j] = false;
                    while (placement[i,j] != null)
                    {
                        inPlay = placement[i, j][0];
                        placement[i, j].Remove(inPlay);
                    }
                    placement[i, j] = new List<Card>();
                    while(deck.Count != 0)
                    {
                        inPlay = deck[0];
                        deck.Remove(inPlay);
                    }
                }
            fillAndShuffle();
            i = 1;
            j = 1;
            k = 0;
            while (!placed[3, 3])
            {
                Draw();
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
                        placement[i, j].Add(new Card { face = inPlay.face, suit = inPlay.suit, color = inPlay.color});
                        placed[i, j] = true;
                        j++;
                        if(j == 4)
                        {
                            i++;
                            j = 1;
                        }
                        if(i == 2 && j == 2)
                        {
                            j++;
                        }
                        break;
                    case 11:
                    case 12:
                    case 13:
                        royal[k] = inPlay;
                        k++;
                        break;
                    case 14:
                        joker++;
                        Joker.Text = Convert.ToString(joker);
                        Draw();
                        break;
                }
            }
            for (i = 0; i < k; i++)
                royalPlacement(royal[i]);
            for(i = 1; i < 4; i++)
                for(j = 1; j < 4; j++)
                    switch (i)
                    {
                        case 1:
                            switch (j)
                            {
                                case 1:
                                    C11.Image = imageList1.Images[((placement[i,j][0].face * 4) + 1 - placement[i,j][0].suit)];
                                    break;
                                case 2:
                                    C12.Image = imageList1.Images[((placement[i, j][0].face * 4) + 1 - placement[i, j][0].suit)];
                                    break;
                                case 3:
                                    C13.Image = imageList1.Images[((placement[i, j][0].face * 4) + 1 - placement[i, j][0].suit)];
                                    break;
                            }
                            break;
                        case 2:
                            switch (j)
                            {
                                case 1:
                                    C21.Image = imageList1.Images[((placement[i, j][0].face * 4) + 1 - placement[i, j][0].suit)];
                                    break;
                                case 3:
                                    C23.Image = imageList1.Images[((placement[i, j][0].face * 4) + 1 - placement[i, j][0].suit)];
                                    break;
                            }
                            break;
                        case 3:
                            switch (j)
                            {
                                case 1:
                                    C31.Image = imageList1.Images[((placement[i, j][0].face * 4) + 1 - placement[i, j][0].suit)];
                                    break;
                                case 2:
                                    C32.Image = imageList1.Images[((placement[i, j][0].face * 4) + 1 - placement[i, j][0].suit)];
                                    break;
                                case 3:
                                    C33.Image = imageList1.Images[((placement[i, j][0].face * 4) + 1 - placement[i, j][0].suit)];
                                    break;
                            }
                            break;
                    }
        }
        public void Place()
        {
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
                    for (int i = 1; i < 4; i++)
                        for (int j = 1; j < 4; j++)
                            switch (i)
                            {
                                case 1:
                                    switch (j)
                                    {
                                        case 1:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p11 = true;
                                            break;
                                        case 2:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p12 = true;
                                            break;
                                        case 3:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p13 = true;
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (j)
                                    {
                                        case 1:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p21 = true;
                                            break;
                                        case 2:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p22 = true;
                                            break;
                                        case 3:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p23 = true;
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (j)
                                    {
                                        case 1:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p31 = true;
                                            break;
                                        case 2:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p32 = true;
                                            break;
                                        case 3:
                                            if (inPlay.face > placement[i, j][0].face)
                                                p33 = true;
                                            break;
                                    }
                                    break;
                            }
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
        public Form1()
        {
            InitializeComponent();
            Deck.Image = imageList1.Images[0];
            Ace.Image = imageList1.Images[3];
            Joker.Image = imageList1.Images[54];
            setUp();
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