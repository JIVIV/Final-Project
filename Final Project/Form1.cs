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
        static public int ace = 0, joker = 0, acesUsed = 0, jokersUsed = 0, score = 6, shameCount = 0;
        static public bool usingAce = false, usingJoker = false, shame = false, armor = false, p01 = false, p02 = false, p03 = false,
            p10 = false,p11 = false, p12 = false, p13 = false, p14 = false, p20 = false, p21 = false, p22 = false, p23 = false, 
            p24 =false, p30 = false, p31 = false, p32 = false, p33 = false, p34 = false, p41 = false, p42 = false, p43 = false;

        private void C20_Click(object sender, EventArgs e)
        {
            
        }
        
        private void C14_Click(object sender, EventArgs e)
        {
            if (p14 && !armor)
            {
                p14 = false;
                p03 = false;
                placed[1, 4] = true;
                placement[1, 4].Add(inPlay);
            }
            else if (p14 && armor)
            {
                p14 = false;
                armor = false;
                placement[1, 4][0].armor += inPlay.face;
                Draw();
            }
        }

        private void C13_Click(object sender, EventArgs e)
        {
            if (inPlay.face >= placement[1, 3][0].face)
            {
                placement[1, 3].Insert(0, inPlay);
                C21.Image = Play.Image;
                if (placed[1, 0])
                {
                    switch (placement[1, 0][0].face)
                    {
                        case 11:
                            if (placement[1, 2][0].face + placement[1, 1][0].face >= placement[1, 0][0].face + placement[1, 0][0].armor)
                                C10.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[1, 2][0].color == placement[1, 0][0].color && placement[1, 1][0].color == placement[1, 0][0].color)
                            {
                                if (placement[1, 2][0].face + placement[1, 1][0].face >= placement[1,0][0].face + placement[1,0][0].armor)
                                {
                                    C10.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 2][0].suit == placement[2, 4][0].suit && placement[2, 3][0].suit == placement[2, 4][0].suit)
                            {
                                if (placement[2, 2][0].face + placement[2, 3][0].face >= placement[1, 0][0].face + placement[1, 0][0].armor)
                                {
                                    C24.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                if (placed[3, 4])
                {
                    switch (placement[3, 4][0].face)
                    {
                        case 11:
                            if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3,4][0].face + placement[3,4][0].armor)
                                C14.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[3, 2][0].color == placement[3, 4][0].color && placement[3, 3][0].color == placement[3, 4][0].color)
                            {
                                if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3, 4][0].face + placement[3, 4][0].armor)
                                {
                                    C34.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[3, 2][0].suit == placement[3, 4][0].suit && placement[3, 3][0].suit == placement[3, 4][0].suit)
                            {
                                if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3, 4][0].face + placement[3, 4][0].armor)
                                {
                                    C34.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                Draw();
                Draw();
            }
        }

        private void C12_Click(object sender, EventArgs e)
        {
            if (inPlay.face >= placement[1, 2][0].face)
            {
                placement[1, 2].Insert(0, inPlay);
                C12.Image = Play.Image;
                if (placed[4,1])
                {
                    switch (placement[4, 2][0].face)
                    {
                        case 11:
                            if (placement[2, 2][0].face + placement[3, 2][0].face >= placement[4,2][0].face + placement[4,2][0].armor)
                                C42.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[2, 2][0].color == placement[4, 2][0].color && placement[3, 2][0].color == placement[4, 2][0].color)
                            {
                                if (placement[2, 2][0].face + placement[3, 2][0].face >= placement[4, 2][0].face + placement[4, 2][0].armor)
                                {
                                    C42.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 2][0].suit == placement[4, 2][0].suit && placement[3, 2][0].suit == placement[4, 2][0].suit)
                            {
                                if (placement[2, 2][0].face + placement[3, 2][0].face >= placement[4, 2][0].face + placement[4, 2][0].armor)
                                {
                                    C42.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                Draw();
            }
        }

        private void C11_Click(object sender, EventArgs e)
        {
            if (inPlay.face >= placement[1, 1][0].face)
            {
                placement[1, 1].Insert(0, inPlay);
                C11.Image = Play.Image;
                if (placed[4,1])
                {
                    switch (placement[4, 1][0].face)
                    {
                        case 11:
                            if (placement[2, 1][0].face + placement[3, 1][0].face >= placement[4, 1][0].face + placement[4, 1][0].armor)
                                C41.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[2, 1][0].color == placement[4, 1][0].color && placement[3, 1][0].color == placement[4, 1][0].color)
                            {
                                if (placement[2, 1][0].face + placement[3, 1][0].face >= placement[4, 1][0].face + placement[4, 1][0].armor)
                                {
                                    C41.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 1][0].suit == placement[4, 1][0].suit && placement[3, 1][0].suit == placement[4, 1][0].suit)
                            {
                                if (placement[2, 1][0].face + placement[3, 1][0].face >= placement[4, 1][0].face + placement[4, 1][0].armor)
                                {
                                    C41.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                if (placed[1,4])
                {
                    switch (placement[1, 4][0].face)
                    {
                        case 11:
                            if (placement[1, 2][0].face + placement[1, 3][0].face >= placement[1, 4][0].face + placement[1, 4][0].armor)
                                C14.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[1, 2][0].color == placement[1, 4][0].color && placement[1, 3][0].color == placement[1, 4][0].color)
                            {
                                if (placement[1, 2][0].face + placement[1, 3][0].face >= placement[1, 4][0].face + placement[1, 4][0].armor)
                                {
                                    C14.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[1, 2][0].suit == placement[1, 4][0].suit && placement[1, 3][0].suit == placement[1, 4][0].suit)
                            {
                                if (placement[1, 2][0].face + placement[1, 3][0].face >= placement[1, 4][0].face + placement[1, 4][0].armor)
                                {
                                    C14.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                Draw();
            }
        }

        private void C10_Click(object sender, EventArgs e)
        {
            if (p10 && !armor)
            {
                p10 = false;
                p01 = false;
                placed[1, 0] = true;
                placement[1, 0].Add(inPlay);
            }
            else if(p10 && armor)
            {
                p10 = false;
                armor = false;
                placement[1, 0][0].armor += inPlay.face;
                Draw();
            }
        }

        private void C03_Click(object sender, EventArgs e)
        {
            if (p03 && !armor)
            {
                p03 = false;
                p14 = false;
                placed[0,3] = true;
                placement[0,3].Add(inPlay);
            }
            else if (p03 && armor)
            {
                p03 = false;
                armor = false;
                placement[0,3][0].armor += inPlay.face;
                Draw();
            }
        }

        private void C02_Click(object sender, EventArgs e)
        {

        }

        private void C01_Click(object sender, EventArgs e)
        {
            if (p01 && !armor)
            {
                p10 = false;
                p01 = false;
                placed[0,1] = true;
                placement[0,1].Add(inPlay);
            }
            else if (p10 && armor)
            {
                p10 = false;
                armor = false;
                placement[0,1][0].armor += inPlay.face;
                Draw();
            }
        }

        private void Help_Click(object sender, EventArgs e)
        {

        }

        private void newGame_Click(object sender, EventArgs e)
        {
            setUp();
        }

        private void C21_Click(object sender, EventArgs e)
        {
            if (inPlay.face >= placement[2, 1][0].face)
            {
                placement[2, 1].Insert(0, inPlay);
                C21.Image = Play.Image;
                if (placed[2,4])
                {
                    {
                        switch (placement[2, 4][0].face)
                        {
                            case 11:
                                if (placement[2, 2][0].face + placement[2, 3][0].face >= placement[2, 4][0].face + placement[2, 4][0].armor)
                                    C24.Image = imageList1.Images[0];
                                break;
                            case 12:
                                if (placement[2, 2][0].color == placement[2, 4][0].color && placement[2, 3][0].color == placement[2, 4][0].color)
                                {
                                    if (placement[2, 2][0].face + placement[2, 3][0].face >= placement[2, 4][0].face + placement[2, 4][0].armor)
                                    {
                                        C24.Image = imageList1.Images[0];
                                    }
                                }
                                break;
                            case 13:
                                if (placement[2, 2][0].suit == placement[2, 4][0].suit && placement[2, 3][0].suit == placement[2, 4][0].suit)
                                {
                                    if (placement[2, 2][0].face + placement[2, 3][0].face >= placement[2, 4][0].face + placement[2, 4][0].armor)
                                    {
                                        C24.Image = imageList1.Images[0];
                                    }
                                }
                                break;
                        }
                    }
                }
                Draw();
            }
        }

        private void C22_Click(object sender, EventArgs e)
        {
            if (p22)
            {
                if (inPlay.face >= placement[2, 2][0].face)
                {
                    placement[2, 2].Insert(0, inPlay);
                    C22.Image = Play.Image;
                }
                Draw();
            }
            else if (!placement[2,2].Any())
            {
                placement[2, 2].Insert(0, inPlay);
                C22.Image = Play.Image;
                p22 = true;
                Draw();
            }
        }

        private void C23_Click(object sender, EventArgs e)
        {
            if (inPlay.face >= placement[2, 3][0].face)
            {
                placement[2, 3].Insert(0, inPlay);
                C23.Image = Play.Image;
                if (placed[2,0])
                {
                    switch (placement[2, 0][0].face)
                    {
                        case 11:
                            if (placement[2, 2][0].face + placement[2, 1][0].face >= placement[2, 0][0].face + placement[2, 0][0].armor)
                                C20.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[2, 2][0].color == placement[2, 0][0].color && placement[2, 1][0].color == placement[2, 0][0].color)
                            {
                                if (placement[2, 2][0].face + placement[2, 1][0].face >= placement[2, 0][0].face + placement[2, 0][0].armor)
                                {
                                    C20.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 2][0].suit == placement[2, 0][0].suit && placement[2, 1][0].suit == placement[2, 0][0].suit)
                            {
                                if (placement[2, 2][0].face + placement[2, 1][0].face >= placement[2, 0][0].face + placement[2, 0][0].armor)
                                {
                                    C20.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                Draw();
            }
        }

        private void C24_Click(object sender, EventArgs e)
        {

        }

        private void C30_Click(object sender, EventArgs e)
        {

        }

        private void C31_Click(object sender, EventArgs e)
        {
            if (inPlay.face >= placement[3, 1][0].face)
            {
                placement[3, 1].Insert(0, inPlay);
                C31.Image = Play.Image;
                if (placed[0,1])
                {
                    switch (placement[0, 1][0].face)
                    {
                        case 11:
                            if (placement[2, 1][0].face + placement[1, 1][0].face >= placement[0, 1][0].face + placement[0, 1][0].armor)
                                C01.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[2, 1][0].color == placement[0, 1][0].color && placement[1, 1][0].color == placement[0, 1][0].color)
                            {
                                if (placement[2, 1][0].face + placement[1, 1][0].face >= placement[0, 1][0].face + placement[0, 1][0].armor)
                                {
                                    C01.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 1][0].suit == placement[0, 1][0].suit && placement[1, 1][0].suit == placement[0, 1][0].suit)
                            {
                                if (placement[2, 1][0].face + placement[1, 1][0].face >= placement[0, 1][0].face + placement[0, 1][0].armor)
                                {
                                    C01.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                if (placed[3,4])
                {
                    switch (placement[3, 4][0].face)
                    {
                        case 11:
                            if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3, 4][0].face + placement[3, 4][0].armor)
                                C34.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[3, 2][0].color == placement[3, 4][0].color && placement[3, 3][0].color == placement[3, 4][0].color)
                            {
                                if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3, 4][0].face + placement[3, 4][0].armor)
                                {
                                    C34.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[3, 2][0].suit == placement[3, 4][0].suit && placement[3, 3][0].suit == placement[3, 4][0].suit)
                            {
                                if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3, 4][0].face + placement[3, 4][0].armor)
                                {
                                    C34.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                Draw();
            }
        }

        private void C32_Click(object sender, EventArgs e)
        {
            if (inPlay.face >= placement[3, 2][0].face)
            {
                placement[3, 2].Insert(0, inPlay);
                C32.Image = Play.Image;
                if (placed[0,2])
                {
                    switch (placement[0, 2][0].face)
                    {
                        case 11:
                            if (placement[2, 2][0].face + placement[1, 2][0].face >= placement[0, 2][0].face + placement[0, 2][0].armor)
                                C02.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[2, 2][0].color == placement[0, 2][0].color && placement[1, 2][0].color == placement[0, 2][0].color)
                            {
                                if (placement[2, 2][0].face + placement[1, 2][0].face >= placement[0, 2][0].face + placement[0, 2][0].armor)
                                {
                                    C02.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 2][0].suit == placement[0, 2][0].suit && placement[1, 2][0].suit == placement[0, 2][0].suit)
                            {
                                if (placement[2, 2][0].face + placement[1, 2][0].face >= placement[0, 2][0].face + placement[0, 2][0].armor)
                                {
                                    C02.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                Draw();
            }
        }

        private void C33_Click(object sender, EventArgs e)
        {
            if (inPlay.face >= placement[3, 3][0].face)
            {
                placement[3, 3].Insert(0, inPlay);
                C33.Image = Play.Image;
                if (placed[0,3])
                {
                    switch (placement[0, 3][0].face)
                    {
                        case 11:
                            if (placement[2, 3][0].face + placement[1, 3][0].face >= placement[0, 3][0].face + placement[0, 3][0].armor)
                                C03.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[2, 3][0].color == placement[0, 3][0].color && placement[1, 3][0].color == placement[0, 3][0].color)
                            {
                                if (placement[2, 3][0].face + placement[1, 3][0].face >= placement[0, 2][0].face + placement[0, 2][0].armor)
                                {
                                    C03.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 3][0].suit == placement[0, 3][0].suit && placement[1, 3][0].suit == placement[0, 3][0].suit)
                            {
                                if (placement[2, 3][0].face + placement[1, 3][0].face >= placement[0, 2][0].face + placement[0, 2][0].armor)
                                {
                                    C03.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                if (placed[3,0])
                {
                    switch (placement[3, 0][0].face)
                    {
                        case 11:
                            if (placement[3, 2][0].face + placement[3, 1][0].face >= placement[3, 0][0].face + placement[3, 0][0].armor)
                                C30.Image = imageList1.Images[0];
                            break;
                        case 12:
                            if (placement[3, 2][0].color == placement[3, 0][0].color && placement[3, 1][0].color == placement[3, 0][0].color)
                            {
                                if (placement[3, 2][0].face + placement[3, 1][0].face >= placement[3, 0][0].face + placement[3, 0][0].armor)
                                {
                                    C30.Image = imageList1.Images[0];
                                }
                            }
                            break;
                        case 13:
                            if (placement[3, 2][0].suit == placement[3, 0][0].suit && placement[3, 1][0].suit == placement[3, 0][0].suit)
                            {
                                if (placement[3, 2][0].face + placement[3, 1][0].face >= placement[3, 0][0].face + placement[3, 0][0].armor)
                                {
                                    C30.Image = imageList1.Images[0];
                                }
                            }
                            break;
                    }
                }
                Draw();
            }
        }

        private void C34_Click(object sender, EventArgs e)
        {

        }

        private void C41_Click(object sender, EventArgs e)
        {

        }

        private void C42_Click(object sender, EventArgs e)
        {

        }

        private void C43_Click(object sender, EventArgs e)
        {

        }

        private void Ace_Click(object sender, EventArgs e)
        {
            usingAce = true;
            ace--;
            Ace.Text = $"{ace}";
            p11 = true;
            p12 = true;
            p13 = true;
            p21 = true;
            p22 = true;
            p23 = true;
            p31 = true;
            p32 = true;
            p33 = true;
        }

        private void Joker_Click(object sender, EventArgs e)
        {
            usingJoker = true;
            joker--;
            Joker.Text = $"{joker}";
            p11 = true;
            p12 = true;
            p13 = true;
            p21 = true;
            p22 = true;
            p23 = true;
            p31 = true;
            p32 = true;
            p33 = true;
        }

        private void Shame_Click(object sender, EventArgs e)
        {
            if (shame)
            {
                shameCount += inPlay.face;
                Shame.Text = $"{shameCount}";
                shame = false;
            }
        }

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
            Place();
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
                if(!placed[0,1])
                    p01 = true;
                if(!placed[1,0])
                    p10 = true;
            }
            else if (highesti == 1 && highestj == 2 && !placed[0,2])
            {
                placed[0, 2] = true;
                placement[0, 2].Add(royal);
            }
            else if (highesti == 1 && highestj == 3)
            {
                if(!placed[0,3])
                    p03 = true;
                if(!placed[1,4])
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
                if(!placed[3,0])
                    p30 = true;
                if(!placed[4,1])
                    p41 = true;
            }
            else if(highesti == 3 && highestj == 2 && !placed[4,2])
            {
                placed[4, 2] = true;
                placement[4, 2].Add(royal);
            }
            else if(highesti == 3 && highestj == 3)
            {
                if(!placed[3,4])
                    p34 = true;
                if(!placed[4,3])
                    p43 = true;
            }
            while(p01 || p03 || p10 || p14 || p30 || p34 || p41 || p43)
            {
                Play.Image = imageList1.Images[((royal.face * 4) + 1 - royal.suit)];
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
                inPlay = deck[0];
                deck.Remove(inPlay);
                switch (inPlay.face)
                {
                    case 1:
                        ace++;
                        Ace.Text = Convert.ToString(ace);
                        inPlay = deck[0];
                        deck.Remove(inPlay);
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
                        inPlay = deck[0];
                        deck.Remove(inPlay);
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
            Draw();
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
                                            if(placement[i,j].Any() && inPlay.face >= placement[i, j][0].face)
                                                p11 = true;
                                            break;
                                        case 2:
                                            if(placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                                p12 = true;
                                            break;
                                        case 3:
                                            if(placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                                p13 = true;
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (j)
                                    {
                                        case 1:
                                            if(placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                                p21 = true;
                                            break;
                                        case 2:
                                            if(placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                                p22 = true;
                                            break;
                                        case 3:
                                            if(placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                                p23 = true;
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (j)
                                    {
                                        case 1:
                                            if(placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                                p31 = true;
                                            break;
                                        case 2:
                                            if(placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                                p32 = true;
                                            break;
                                        case 3:
                                            if(placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
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
    public int face, suit, color, armor = 0;
}