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
        static public List<Card> deck = new List<Card>();            // Deck of Cards
        static public List<Card>[,] placement = new List<Card>[5,5]; //List of Cards in each button
        static public Card inPlay;                                   //Current card in play
        static public Card[] royal = new Card[12];
        static public int ace = 0, joker = 0, acesUsed = 0, jokersUsed = 0, score = 6, shameCount = 0, l, k, remaining;    //Amounts
        static public bool usingAce = false, usingJoker = false, armor = false;
        static public bool[,] placed = new bool[5, 5], fullOfRoyals = new bool[5, 5], isDead = new bool[5, 5];


        /* ------------------------------------------------------------------------------------------ */ 
        /* ----------------------- Royals ----------------------------------------------------------- */
        private void C01_Click(object sender, EventArgs e) //Places card in (0, 1)
        {
            if (l < k)
            {
                placed[0, 1] = true;
                placement[0, 1].Add(royal[l]);
                C01.BackgroundImage = Set(royal[l].image);
                l++;
                C01.Enabled = false;
                C10.Enabled = false;
                RoyalPlacement();
            }
            else
            {
                if (armor)
                {
                    armor = false;
                    Shame.Enabled = false;
                    placement[0, 1][0].armor += inPlay.face;
                    C01.Text = $"{placement[0, 1][0].face + placement[0, 1][0].armor}";
                    Draw();
                }
                else
                {
                    placed[0, 1] = true;
                    placement[0, 1].Add(inPlay);
                    C01.BackgroundImage = Set(inPlay.image);
                    Draw();
                }
                C01.Enabled = false;
                C10.Enabled = false;
            }
        }

        private void C02_Click(object sender, EventArgs e) //Places card in (0, 2)
        {
            armor = false;
            placement[0, 2][0].armor += inPlay.face;
            C02.Text = $"{placement[0, 2][0].face + placement[0, 2][0].armor}";
            C02.Enabled = false;
            Shame.Enabled = false;
            Draw();
        }

        private void C03_Click(object sender, EventArgs e) //Places card in (0, 3)
        {
            if (l < k)
            {
                placed[0, 3] = true;
                placement[0, 3].Add(royal[l]);
                C03.BackgroundImage = Set(royal[l].image);
                l++;
                C03.Enabled = false;
                C14.Enabled = false;
                RoyalPlacement();
            }
            else
            {
                if (armor)
                {
                    armor = false;
                    Shame.Enabled = false;
                    placement[0, 3][0].armor += inPlay.face;
                    C03.Text = $"{placement[0, 3][0].face + placement[0, 3][0].armor}";
                    Draw();
                }
                else
                {
                    placed[0, 3] = true;
                    placement[0, 3].Add(inPlay);
                    C03.BackgroundImage = Set(inPlay.image);
                    Draw();
                }
                C03.Enabled = false;
                C14.Enabled = false;
            }
        }

        private void C10_Click(object sender, EventArgs e) //Places card in (1, 0)
        {
            if (l < k)
            {
                placed[1, 0] = true;
                placement[1, 0].Add(royal[l]);
                C10.BackgroundImage = Set(royal[l].image);
                l++;
                C01.Enabled = false;
                C10.Enabled = false;
                RoyalPlacement();
            }
            else
            {
                if (armor)
                {
                    armor = false;
                    Shame.Enabled = false;
                    placement[1, 0][0].armor += inPlay.face;
                    C10.Text = $"{placement[1, 0][0].face + placement[1, 0][0].armor}";
                    Draw();
                }
                else
                {
                    placed[1, 0] = true;
                    placement[1, 0].Add(inPlay);
                    C10.BackgroundImage = Set(inPlay.image);
                    Draw();
                }
                C01.Enabled = false;
                C10.Enabled = false;
            }
        }

        private void C14_Click(object sender, EventArgs e) //Places card in (1, 4)
        {
            if (l < k)
            {
                placed[1, 4] = true;
                placement[1, 4].Add(royal[l]);
                C14.BackgroundImage = Set(royal[l].image);
                l++;
                C03.Enabled = false;
                C14.Enabled = false;
                RoyalPlacement();
            }
            else
            {
                if (armor)
                {
                    armor = false;
                    Shame.Enabled = false;
                    placement[1, 4][0].armor += inPlay.face;
                    C14.Text = $"{placement[1, 4][0].face + placement[1, 4][0].armor}";
                    Draw();
                }
                else
                {
                    placed[1, 4] = true;
                    placement[1, 4].Add(inPlay);
                    C14.BackgroundImage = Set(inPlay.image);
                    Draw();
                }
                C03.Enabled = false;
                C14.Enabled = false;
            }
        }

        private void C20_Click(object sender, EventArgs e) //Places card in (2, 0)
        {
            armor = false;
            placement[2, 0][0].armor += inPlay.face;
            C20.Text = $"{placement[2, 0][0].face + placement[2, 0][0].armor}";
            C20.Enabled = false;
            Shame.Enabled = false;
            Draw();
        }

        private void C24_Click(object sender, EventArgs e) //Places card in (2, 4)
        {
            armor = false;
            placement[2, 4][0].armor += inPlay.face;
            C24.Text = $"{placement[2, 4][0].face + placement[2, 4][0].armor}";
            C24.Enabled = false;
            Shame.Enabled = false;
            Draw();
        }

        private void C30_Click(object sender, EventArgs e) //Places card in (3, 0)
        {
            if (l < k)
            {
                placed[3, 0] = true;
                placement[3, 0].Add(royal[l]);
                C30.BackgroundImage = Set(royal[l].image);
                l++;
                C30.Enabled = false;
                C41.Enabled = false;
                RoyalPlacement();
            }
            else
            {
                if (armor)
                {
                    armor = false;
                    Shame.Enabled = false;
                    placement[3, 0][0].armor += inPlay.face;
                    C30.Text = $"{placement[3, 0][0].face + placement[3, 0][0].armor}";
                    Draw();
                }
                else
                {
                    placed[3, 0] = true;
                    placement[3, 0].Add(inPlay);
                    C30.BackgroundImage = Set(inPlay.image);
                    Draw();
                }
                C41.Enabled = false;
                C30.Enabled = false;
            }
        }

        private void C34_Click(object sender, EventArgs e) //Places card in (3, 4)
        {
            if (l < k)
            {
                placed[3, 4] = true;
                placement[3, 4].Add(royal[l]);
                C34.BackgroundImage = Set(royal[l].image);
                l++;
                C34.Enabled = false;
                C43.Enabled = false;
                RoyalPlacement();
            }
            else
            {
                if (armor)
                {
                    armor = false;
                    Shame.Enabled = false;
                    placement[3, 4][0].armor += inPlay.face;
                    C34.Text = $"{placement[3, 4][0].face + placement[3, 4][0].armor}";
                    Draw();
                }
                else
                {
                    placed[3, 4] = true;
                    placement[3, 4].Add(inPlay);
                    C34.BackgroundImage = Set(inPlay.image);
                    Draw();
                }
                C43.Enabled = false;
                C34.Enabled = false;
            }
        }

        private void C41_Click(object sender, EventArgs e)//Places card in (4, 1)
        {
            if (l < k)
            {
                placed[4, 1] = true;
                placement[4, 1].Add(royal[l]);
                C41.BackgroundImage = Set(royal[l].image);
                l++;
                C30.Enabled = false;
                C41.Enabled = false;
                RoyalPlacement();
            }
            else
            {
                if (armor)
                {
                    armor = false;
                    Shame.Enabled = false;
                    placement[4, 1][0].armor += inPlay.face;
                    C41.Text = $"{placement[4, 1][0].face + placement[4, 1][0].armor}";
                    Draw();
                }
                else
                {
                    placed[4, 1] = true;
                    placement[4, 1].Add(inPlay);
                    C41.BackgroundImage = Set(inPlay.image);
                    Draw();
                }
                C41.Enabled = false;
                C30.Enabled = false;
            }
        }

        private void C42_Click(object sender, EventArgs e)//Places card in (4, 2)
        {
            armor = false;
            placement[4, 2][0].armor += inPlay.face;
            C42.Text = $"{placement[4, 2][0].face + placement[4, 2][0].armor}";
            C42.Enabled = false;
            Shame.Enabled = false;
            Draw();
        }

        private void C43_Click(object sender, EventArgs e)//Places card in (4, 3)
        {
            if (l < k)
            {
                placed[4, 3] = true;
                placement[4, 3].Add(royal[l]);
                C43.BackgroundImage = Set(royal[l].image);
                l++;
                C34.Enabled = false;
                C43.Enabled = false;
                RoyalPlacement();
            }
            else
            {
                if (armor)
                {
                    armor = false;
                    Shame.Enabled = false;
                    placement[4, 3][0].armor += inPlay.face;
                    C43.Text = $"{placement[4, 3][0].face + placement[4, 3][0].armor}";
                    Draw();
                }
                else
                {
                    placed[4, 3] = true;
                    placement[4, 3].Add(inPlay);
                    C43.BackgroundImage = Set(inPlay.image);
                    Draw();
                }
                C43.Enabled = false;
                C34.Enabled = false;
            }
        }


        /* ------------------------------------------------------------------------------------------ */
        /* ----------------------- Placement -------------------------------------------------------- */


        private void C11_Click(object sender, EventArgs e) //Places card in (1, 1)
        {
            if (!(usingAce || usingJoker))
            {
                placement[1, 1].Insert(0, inPlay);
                C11.BackgroundImage = Play.BackgroundImage;
                if (placed[4, 1])
                {
                    switch (placement[4, 1][0].face)
                    {
                        case 11:
                            if (placement[2, 1][0].face + placement[3, 1][0].face >= placement[4, 1][0].face + placement[4, 1][0].armor)
                            {
                                C41.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[4, 1] = true;
                            }
                            break;
                        case 12:
                            if (placement[2, 1][0].color == placement[4, 1][0].color && placement[3, 1][0].color == placement[4, 1][0].color)
                            {
                                if (placement[2, 1][0].face + placement[3, 1][0].face >= placement[4, 1][0].face + placement[4, 1][0].armor)
                                {
                                    C41.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[4, 1] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 1][0].suit == placement[4, 1][0].suit && placement[3, 1][0].suit == placement[4, 1][0].suit)
                            {
                                if (placement[2, 1][0].face + placement[3, 1][0].face >= placement[4, 1][0].face + placement[4, 1][0].armor)
                                {
                                    C41.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[4, 1] = true;
                                }
                            }
                            break;
                    }
                }
                if (placed[1, 4])
                {
                    switch (placement[1, 4][0].face)
                    {
                        case 11:
                            if (placement[1, 2][0].face + placement[1, 3][0].face >= placement[1, 4][0].face + placement[1, 4][0].armor)
                            {
                                C14.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[1, 4] = true;
                            }
                            break;
                        case 12:
                            if (placement[1, 2][0].color == placement[1, 4][0].color && placement[1, 3][0].color == placement[1, 4][0].color)
                            {
                                if (placement[1, 2][0].face + placement[1, 3][0].face >= placement[1, 4][0].face + placement[1, 4][0].armor)
                                {
                                    C14.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[1, 4] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[1, 2][0].suit == placement[1, 4][0].suit && placement[1, 3][0].suit == placement[1, 4][0].suit)
                            {
                                if (placement[1, 2][0].face + placement[1, 3][0].face >= placement[1, 4][0].face + placement[1, 4][0].armor)
                                {
                                    C14.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[1, 4] = true;
                                }
                            }
                            break;
                    }
                }
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
            else if (usingJoker && placement[1, 1].Count > 1)
            {
                deck.Insert(0, inPlay);
                inPlay = placement[1,1][0];
                placement[1,1].Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                C11.BackgroundImage = Set(placement[1, 1][0].image);
                usingJoker = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
            else if (usingAce)
            {
                usingAce = false;
                while(placement[1,1].Any())
                {
                    deck.Add(placement[1,1][0]);
                    placement[1, 1].Remove(placement[1, 1][0]);
                }
                placement[1,1].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                C11.BackgroundImage = Set(placement[1, 1][0].image);
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
        }
        private void C12_Click(object sender, EventArgs e) //Places card in (1, 2)
        {
            if (!(usingAce || usingJoker))
            {
                placement[1, 2].Insert(0, inPlay);
                C12.BackgroundImage = Play.BackgroundImage;
                if (placed[4, 2] && placed[2,2])
                {
                    switch (placement[4, 2][0].face)
                    {
                        case 11:
                            if (placement[2, 2][0].face + placement[3, 2][0].face >= placement[4, 2][0].face + placement[4, 2][0].armor)
                            {
                                C42.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[4, 2] = true;
                            }
                            break;
                        case 12:
                            if (placement[2, 2][0].color == placement[4, 2][0].color && placement[3, 2][0].color == placement[4, 2][0].color)
                            {
                                if (placement[2, 2][0].face + placement[3, 2][0].face >= placement[4, 2][0].face + placement[4, 2][0].armor)
                                {
                                    C42.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[4, 2] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 2][0].suit == placement[4, 2][0].suit && placement[3, 2][0].suit == placement[4, 2][0].suit)
                            {
                                if (placement[2, 2][0].face + placement[3, 2][0].face >= placement[4, 2][0].face + placement[4, 2][0].armor)
                                {
                                    C42.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[4, 2] = true;
                                }
                            }
                            break;
                    }
                }
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
            else if (usingJoker && placement[1, 2].Count > 1)
            {
                deck.Insert(0, inPlay);
                inPlay = placement[1,2][0];
                placement[1,2].Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                C12.BackgroundImage = Set(placement[1, 2][0].image);
                usingJoker = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
            else if (usingAce)
            {
                usingAce = false;
                while (placement[1,2].Any())
                {
                    deck.Add(placement[1,2][0]);
                    placement[1, 2].Remove(placement[1, 2][0]);
                }
                placement[1,2].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                C12.BackgroundImage = Set(placement[1, 2][0].image);
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
        }

        private void C13_Click(object sender, EventArgs e) //Places card in (1, 3)
        {
            if (!(usingAce || usingJoker))
            {
                placement[1, 3].Insert(0, inPlay);
                C13.BackgroundImage = Play.BackgroundImage;
                if (placed[1, 0])
                {
                    switch (placement[1, 0][0].face)
                    {
                        case 11:
                            if (placement[1, 2][0].face + placement[1, 1][0].face >= placement[1, 0][0].face + placement[1, 0][0].armor)
                            {
                                C10.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[1, 0] = true;
                            }
                            break;
                        case 12:
                            if (placement[1, 1][0].color == placement[1, 0][0].color && placement[1, 2][0].color == placement[1, 0][0].color)
                            {
                                if (placement[1, 2][0].face + placement[1, 1][0].face >= placement[1, 0][0].face + placement[1, 0][0].armor)
                                {
                                    C10.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[1, 0] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[1, 1][0].suit == placement[1, 0][0].suit && placement[1, 2][0].suit == placement[1, 0][0].suit)
                            {
                                if (placement[1, 2][0].face + placement[1, 1][0].face >= placement[1, 0][0].face + placement[1, 0][0].armor)
                                {
                                    C10.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[1, 0] = true;
                                }
                            }
                            break;
                    }
                }
                if (placed[4, 3])
                {
                    switch (placement[4, 3][0].face)
                    {
                        case 11:
                            if (placement[2, 3][0].face + placement[3, 3][0].face >= placement[4, 3][0].face + placement[4, 3][0].armor)
                            {
                                C43.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[4, 3] = true;
                            }
                            break;
                        case 12:
                            if (placement[2, 3][0].color == placement[3, 3][0].color && placement[4, 3][0].color == placement[4, 3][0].color)
                            {
                                if (placement[2, 3][0].face + placement[3, 3][0].face >= placement[4, 3][0].face + placement[4, 3][0].armor)
                                {
                                    C43.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[4, 3] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 3][0].suit == placement[4, 3][0].suit && placement[3, 3][0].suit == placement[4, 3][0].suit)
                            {
                                if (placement[2, 3][0].face + placement[3, 3][0].face >= placement[4, 3][0].face + placement[4, 3][0].armor)
                                {
                                    C43.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[4, 3] = true;
                                }
                            }
                            break;
                    }
                }
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
            else if (usingJoker && placement[1, 3].Count > 1)
            {
                deck.Insert(0, inPlay);
                inPlay = placement[1,3][0];
                placement[1,3].Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                C13.BackgroundImage = Set(placement[1, 3][0].image);
                usingJoker = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
            else if (usingAce)
            {
                usingAce = false;
                while (placement[1,3].Any())
                {
                    deck.Add(placement[1,3][0]);
                    placement[1, 3].Remove(placement[1,3][0]);
                }
                placement[1,3].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                C13.BackgroundImage = Set(placement[1, 3][0].image);
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
        }

        
        private void C21_Click(object sender, EventArgs e) //Places card in (2, 1)
        {
            if (!(usingAce || usingJoker))
            {
                placement[2, 1].Insert(0, inPlay);
                C21.BackgroundImage = Play.BackgroundImage;
                if (placed[2, 4] && placed[2,2])
                {
                    {
                        switch (placement[2, 4][0].face)
                        {
                            case 11:
                                if (placement[2, 2][0].face + placement[2, 3][0].face >= placement[2, 4][0].face + placement[2, 4][0].armor)
                                {
                                    C24.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[2, 4] = true;
                                }
                                break;
                            case 12:
                                if (placement[2, 2][0].color == placement[2, 4][0].color && placement[2, 3][0].color == placement[2, 4][0].color)
                                {
                                    if (placement[2, 2][0].face + placement[2, 3][0].face >= placement[2, 4][0].face + placement[2, 4][0].armor)
                                    {
                                        C24.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                        isDead[2, 4] = true;
                                    }
                                }
                                break;
                            case 13:
                                if (placement[2, 2][0].suit == placement[2, 4][0].suit && placement[2, 3][0].suit == placement[2, 4][0].suit)
                                {
                                    if (placement[2, 2][0].face + placement[2, 3][0].face >= placement[2, 4][0].face + placement[2, 4][0].armor)
                                    {
                                        C24.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                        isDead[2, 4] = true;
                                    }
                                }
                                break;
                        }
                    }
                }
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
            else if (usingJoker && placement[2, 1].Count > 1)
            {
                deck.Insert(0, inPlay);
                inPlay = placement[2,1][0];
                placement[2,1].Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                C21.BackgroundImage = Set(placement[2, 1][0].image);
                usingJoker = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
            else if (usingAce)
            {
                usingAce = false;
                while (placement[2,1].Any())
                {
                    deck.Add(placement[2,1][0]);
                    placement[2, 1].Remove(placement[2, 1][0]);
                }
                placement[2,1].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                C21.BackgroundImage = Set(placement[2, 1][0].image);
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
        }
        
        private void C22_Click(object sender, EventArgs e) //Places card in (2, 2)
        {
            if (placed[2, 2])
            {
                if (!(usingAce || usingJoker))
                {
                    placement[2, 2].Insert(0, inPlay);
                    C22.BackgroundImage = Play.BackgroundImage;
                    C11.Enabled = false;
                    C12.Enabled = false;
                    C13.Enabled = false;
                    C21.Enabled = false;
                    C22.Enabled = false;
                    C23.Enabled = false;
                    C31.Enabled = false;
                    C32.Enabled = false;
                    C33.Enabled = false;
                    Draw();
                }
                else if (usingJoker && placement[2, 2].Count > 1)
                {
                    deck.Insert(0, inPlay);
                    inPlay = placement[2,2][0];
                    placement[2,2].Remove(inPlay);
                    Play.BackgroundImage = Set(inPlay.image);
                    C22.BackgroundImage = Set(placement[2, 2][0].image);
                    usingJoker = false;
                    C11.Enabled = false;
                    C12.Enabled = false;
                    C13.Enabled = false;
                    C21.Enabled = false;
                    C22.Enabled = false;
                    C23.Enabled = false;
                    C31.Enabled = false;
                    C32.Enabled = false;
                    C33.Enabled = false;
                    Place();
                }
                else if (usingAce)
                {
                    usingAce = false;
                    while (placement[2,2].Any())
                    {
                        deck.Add(placement[2,2][0]);
                        placement[2,2].Remove(placement[2,2][0]);
                    }
                    placement[2,2].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                    C22.BackgroundImage = Set(placement[2,2][0].image);
                    C11.Enabled = false;
                    C12.Enabled = false;
                    C13.Enabled = false;
                    C21.Enabled = false;
                    C22.Enabled = false;
                    C23.Enabled = false;
                    C31.Enabled = false;
                    C32.Enabled = false;
                    C33.Enabled = false;
                    Place();
                }                 
            }
            else if (!placement[2, 2].Any())
            {
                placement[2, 2].Insert(0, inPlay);
                C22.BackgroundImage = Play.BackgroundImage;
                placed[2, 2] = true;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
        }

        private void C23_Click(object sender, EventArgs e) //Places card in (2, 3)
        {
            if (!(usingAce || usingJoker))
            {
                placement[2, 3].Insert(0, inPlay);
                C23.BackgroundImage = Play.BackgroundImage;
                if (placed[2, 0] && placed[2, 2])
                {
                    switch (placement[2, 0][0].face)
                    {
                        case 11:
                            if (placement[2, 2][0].face + placement[2, 1][0].face >= placement[2, 0][0].face + placement[2, 0][0].armor)
                            {
                                C20.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[2, 0] = true;
                            }
                            break;
                        case 12:
                            if (placement[2, 2][0].color == placement[2, 0][0].color && placement[2, 1][0].color == placement[2, 0][0].color)
                            {
                                if (placement[2, 2][0].face + placement[2, 1][0].face >= placement[2, 0][0].face + placement[2, 0][0].armor)
                                {
                                    C20.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[2, 0] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 2][0].suit == placement[2, 0][0].suit && placement[2, 1][0].suit == placement[2, 0][0].suit)
                            {
                                if (placement[2, 2][0].face + placement[2, 1][0].face >= placement[2, 0][0].face + placement[2, 0][0].armor)
                                {
                                    C20.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[2, 0] = true;
                                }
                            }
                            break;
                    }
                }
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
            else if (usingJoker && placement[2, 3].Count > 1)
            {
                deck.Insert(0, inPlay);
                inPlay = placement[2,3][0];
                placement[2, 3].Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                C23.BackgroundImage = Set(placement[2, 3][0].image);
                usingJoker = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
            else if (usingAce)
            {
                usingAce = false;
                while (placement[2, 3].Any())
                {
                    deck.Add(placement[2, 3][0]);
                    placement[2, 3].Remove(placement[2, 3][0]);
                }
                placement[2, 3].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                C23.BackgroundImage = Set(placement[2, 3][0].image);
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
        }

        private void C31_Click(object sender, EventArgs e) //Places card in (3, 1)
        {
            if (!(usingAce || usingJoker))
            {
                placement[3, 1].Insert(0, inPlay);
                C31.BackgroundImage = Play.BackgroundImage;
                if (placed[0, 1])
                {
                    switch (placement[0, 1][0].face)
                    {
                        case 11:
                            if (placement[2, 1][0].face + placement[1, 1][0].face >= placement[0, 1][0].face + placement[0, 1][0].armor)
                            {
                                C01.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[0, 1] = true;
                            }
                            break;
                        case 12:
                            if (placement[2, 1][0].color == placement[0, 1][0].color && placement[1, 1][0].color == placement[0, 1][0].color)
                            {
                                if (placement[2, 1][0].face + placement[1, 1][0].face >= placement[0, 1][0].face + placement[0, 1][0].armor)
                                {
                                    C01.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[0, 1] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 1][0].suit == placement[0, 1][0].suit && placement[1, 1][0].suit == placement[0, 1][0].suit)
                            {
                                if (placement[2, 1][0].face + placement[1, 1][0].face >= placement[0, 1][0].face + placement[0, 1][0].armor)
                                {
                                    C01.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[0, 1] = true;
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
                            if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3, 4][0].face + placement[3, 4][0].armor)
                            {
                                C34.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[3, 4] = true;
                            }
                            break;
                        case 12:
                            if (placement[3, 2][0].color == placement[3, 4][0].color && placement[3, 3][0].color == placement[3, 4][0].color)
                            {
                                if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3, 4][0].face + placement[3, 4][0].armor)
                                {
                                    C34.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[3, 4] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[3, 2][0].suit == placement[3, 4][0].suit && placement[3, 3][0].suit == placement[3, 4][0].suit)
                            {
                                if (placement[3, 2][0].face + placement[3, 3][0].face >= placement[3, 4][0].face + placement[3, 4][0].armor)
                                {
                                    C34.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[3, 4] = true;
                                }
                            }
                            break;
                    }
                }
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
            else if (usingJoker && placement[3, 1].Count > 1)
            {
                deck.Insert(0, inPlay);
                inPlay = placement[3, 1][0];
                placement[3, 1].Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                C31.BackgroundImage = Set(placement[3, 1][0].image);
                usingJoker = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
            else if (usingAce)
            {
                usingAce = false;
                while (placement[3, 1].Any())
                {
                    deck.Add(placement[3, 1][0]);
                    placement[3, 1].Remove(placement[3, 1][0]);
                }
                placement[3, 1].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                C31.BackgroundImage = Set(placement[3, 1][0].image);
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
        }

        private void C32_Click(object sender, EventArgs e) //Places card in (3, 2)
        {
            if (!(usingAce || usingJoker))
            {
                placement[3, 2].Insert(0, inPlay);
                C32.BackgroundImage = Play.BackgroundImage;
                if (placed[0, 2] && placed[2,2])
                {
                    switch (placement[0, 2][0].face)
                    {
                        case 11:
                            if (placement[2, 2][0].face + placement[1, 2][0].face >= placement[0, 2][0].face + placement[0, 2][0].armor)
                            {
                                C02.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[0, 2] = true;
                            }
                            break;
                        case 12:
                            if (placement[2, 2][0].color == placement[0, 2][0].color && placement[1, 2][0].color == placement[0, 2][0].color)
                            {
                                if (placement[2, 2][0].face + placement[1, 2][0].face >= placement[0, 2][0].face + placement[0, 2][0].armor)
                                {
                                    C02.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[0, 2] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 2][0].suit == placement[0, 2][0].suit && placement[1, 2][0].suit == placement[0, 2][0].suit)
                            {
                                if (placement[2, 2][0].face + placement[1, 2][0].face >= placement[0, 2][0].face + placement[0, 2][0].armor)
                                {
                                    C02.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[0, 2] = true;
                                }
                            }
                            break;
                    }
                }
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
            else if (usingJoker && placement[3, 2].Count > 1)
            {
                deck.Insert(0, inPlay);
                inPlay = placement[3, 2][0];
                placement[3, 2].Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                C32.BackgroundImage = Set(placement[3, 2][0].image);
                usingJoker = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
            else if (usingAce)
            {
                usingAce = false;
                while (placement[3, 2].Any())
                {
                    deck.Add(placement[3, 2][0]);
                    placement[3, 2].Remove(placement[3,2][0]);
                }
                placement[3, 2].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                C32.BackgroundImage = Set(placement[3, 2][0].image);
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
        }

        private void C33_Click(object sender, EventArgs e) //Places card in (3, 3)
        {
            if (!(usingAce || usingJoker))
            {
                placement[3, 3].Insert(0, inPlay);
                C33.BackgroundImage = Play.BackgroundImage;
                if (placed[0, 3])
                {
                    switch (placement[0, 3][0].face)
                    {
                        case 11:
                            if (placement[2, 3][0].face + placement[1, 3][0].face >= placement[0, 3][0].face + placement[0, 3][0].armor)
                            {
                                C03.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[0, 3] = true;
                            }
                            break;
                        case 12:
                            if (placement[2, 3][0].color == placement[0, 3][0].color && placement[1, 3][0].color == placement[0, 3][0].color)
                            {
                                if (placement[2, 3][0].face + placement[1, 3][0].face >= placement[0, 3][0].face + placement[0, 3][0].armor)
                                {
                                    C03.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[0, 3] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[2, 3][0].suit == placement[0, 3][0].suit && placement[1, 3][0].suit == placement[0, 3][0].suit)
                            {
                                if (placement[2, 3][0].face + placement[1, 3][0].face >= placement[0, 3][0].face + placement[0, 3][0].armor)
                                {
                                    C03.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[0, 3] = true;
                                }
                            }
                            break;
                    }
                }
                if (placed[3, 0])
                {
                    switch (placement[3, 0][0].face)
                    {
                        case 11:
                            if (placement[3, 2][0].face + placement[3, 1][0].face >= placement[3, 0][0].face + placement[3, 0][0].armor)
                            {
                                C30.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                isDead[3, 0] = true;
                            }
                            break;
                        case 12:
                            if (placement[3, 2][0].color == placement[3, 0][0].color && placement[3, 1][0].color == placement[3, 0][0].color)
                            {
                                if (placement[3, 2][0].face + placement[3, 1][0].face >= placement[3, 0][0].face + placement[3, 0][0].armor)
                                {
                                    C30.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[3, 0] = true;
                                }
                            }
                            break;
                        case 13:
                            if (placement[3, 2][0].suit == placement[3, 0][0].suit && placement[3, 1][0].suit == placement[3, 0][0].suit)
                            {
                                if (placement[3, 2][0].face + placement[3, 1][0].face >= placement[3, 0][0].face + placement[3, 0][0].armor)
                                {
                                    C30.BackgroundImage = Properties.Resources.d594che_212dcb27_a73c_4da5_bccc_6250146355cc;
                                    isDead[3, 0] = true;
                                }
                            }
                            break;
                    }
                }
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Draw();
            }
            else if (usingJoker && placement[3,3].Count > 1)
            {
                deck.Insert(0, inPlay);
                inPlay = placement[3, 3][0];
                placement[3, 3].Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                C33.BackgroundImage = Set(placement[3, 3][0].image);
                usingJoker = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
            else if (usingAce)
            {
                usingAce = false;
                while (placement[3, 3].Any())
                {
                    deck.Add(placement[3, 3][0]);
                    placement[3, 3].Remove(placement[3, 3][0]);
                }
                placement[3, 3].Add(new Card { face = 1, suit = 1, color = 1, image = 0 });
                C33.BackgroundImage = Set(placement[3, 3][0].image);
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                Place();
            }
        }

       /* ------------------------------------------------------------------------------------------ */
       /* ----------------------- Help Print ------------------------------------------------------- */


        private void Help_Click(object sender, EventArgs e) //Display's instructions for the game to the user (works)
        {
            MessageBox.Show("Placement\n " +
            "With the deck face-down, draw cards from the top and lay them out face-up in a 3×3 grid." +
            " If you draw any royals, aces or jokers during this, put them on a separate pile and " +
            "keep drawing til you’ve made the grid of just number cards\n" +
            "If you did draw some royals, you now place them the same way we will when playing:" +
            " put it outside the grid, adjacent to the grid card it’s most similar to. ‘Most similar’ means:\n" +
            "1. Highest value card of the same suit\n" +
            "2. If none, highest value card of the same colour\n" +
            "3. If none, highest value card\n" +
            "4. If there’s a tie, or most similar card is on a corner," +
            " you can choose between the equally valid positions" +
            "\n\nThe Goal\n" +
            "kill all the royals\n\n" +
            "\nPlay\n" +
            "If it’s a royal: use placement rule above.\n" +
            "If it has value 2 - 10: you must place it on the grid.It can go on any card with the same or lower value, regardless of suit.\n" +
            "If it’s an ace or joker: keep it to one side\n\n" +
            "Killing royals: if you’re able to place a card on the grid opposite a royal – so there are two cards between – those two cards Attack the royal. The sum of their values is the must be at least as much as health of the royal to kill them: if it’s not, you can still place the card, but the royal is unaffected. The value of the card you just placed is not part of the Attack, only the two between." +
            "\n\nJacks: 11 health.The cards Attacking can be any suit." +
            "\nQueens: 12 health.The cards Attacking must match the colour of the queen to count." +
            "\nKings: 13 health.The cards Attacking must match the suit of the king to count\n\n"
            + "Ploys:\n " +
            "Aces are Extractions: at any time you can use up one of the aces you’ve drawn to pick up one " +
            "stack of cards from the grid and put them face - down at the bottom of your draw pile.\n" +
            "You can do this even after drawing a card and before placing it. Turn the ace face-down to remember you’ve used it.\n" +
            "Jokers are Reassignments: at any time you can use up one you’ve drawn to move the top card of one " +
            "stack on the grid to another position. The place you move it to must be a valid spot to play " +
            "the card, and placing it can trigger an Attack the same way a normal play can. " +
            "Turn the joker face-down to remember you’ve used it.\n" +
            "If you cannot place a card: and you have no Ploys to use, " +
            "you must add the card as Armour to the royal it’s most similar to(lowest value royal of same suit, failing " +
            "that lowest of same colour, etc). It increases their health by the value of " +
            "the card. So a King with a 3 as armour now has 13 + 3 = 16 health.You can add armour to a" +
            " royal that already has armour – it stacks. If a royal ends up with 20 + health(or 19 + for a King)" +
            ", you are naturally boned.)\n" +
            "If there are no living royals on the table: if every spot around the grid has a dead " +
            "royal on it – all 12 – you’ve won!If not, just keep drawing cards until you find a royal," +
            " placing the cards in a face-up pile as you go.Once you find a royal, place it, " +
            "then add the cards you cycled through to the bottom of your deck.\n" +
            "If the draw pile runs out: and you haven’t killed all the royals, and have no " +
            "Ploys to use, you’ve lost");
        }

        /* ------------------------------------------------------------------------------------------ */
        /* ----------------------- New Game & Setup ------------------------------------------------- */

        private void NewGame_Click(object sender, EventArgs e) //Restarts the game (works)
        {
            SetUp();
        }
        public void TillRoyal()
        {
            inPlay = deck[0];
            while (inPlay.face < 11)
            {
                deck.Remove(inPlay);
                deck.Add(inPlay);
                inPlay = deck[0];
            }
        }
        public void FillAndShuffle() //Fills the deck with card objects and calls the shuffle function (works)
        {
            Card card = new Card();
            for (int i = 0; i < 52; i++)
            {
                deck.Add(new Card { face = (i % 13) + 1, suit = (i % 4) + 1, color = (i % 2) + 1, image = i });
            }
            deck.Add(new Card { face = 14 });
            deck.Add(new Card { face = 14 });
            deck.Shuffle();
        }
        public void Draw()                         //Draws the top card and then removes it from the list (works)
        {
            if (deck.Count != 0)
            {
                if (RoyalCheck())
                    TillRoyal();

                inPlay = deck[0];
                deck.Remove(inPlay);
                Play.BackgroundImage = Set(inPlay.image);
                remaining = deck.Count;
                RemainingCards.Text = $"Cards left in deck: {remaining}";
                Place();
            }
            else
            {
                Play.BackgroundImage = base.BackgroundImage;
                MessageBox.Show("You Lose");
                C01.Enabled = false;
                C02.Enabled = false;
                C03.Enabled = false;
                C10.Enabled = false;
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C14.Enabled = false;
                C20.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C24.Enabled = false;
                C30.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                C34.Enabled = false;
                C41.Enabled = false;
                C42.Enabled = false;
                C43.Enabled = false;
                Joker.Enabled = false;
                Ace.Enabled = false;
            }
        }

        public void SetUp() //Restarts the game (works)
        {
            C01.BackgroundImage = base.BackgroundImage;
            C02.BackgroundImage = base.BackgroundImage;
            C03.BackgroundImage = base.BackgroundImage;
            C10.BackgroundImage = base.BackgroundImage;
            C14.BackgroundImage = base.BackgroundImage;
            C20.BackgroundImage = base.BackgroundImage;
            C22.BackgroundImage = base.BackgroundImage;
            C24.BackgroundImage = base.BackgroundImage;
            C30.BackgroundImage = base.BackgroundImage;
            C34.BackgroundImage = base.BackgroundImage;
            C41.BackgroundImage = base.BackgroundImage;
            C42.BackgroundImage = base.BackgroundImage;
            C43.BackgroundImage = base.BackgroundImage;

            int i, j;
            deck = new List<Card>();
            C01.Enabled = false;
            C02.Enabled = false;
            C03.Enabled = false;
            C10.Enabled = false;
            C11.Enabled = false;
            C12.Enabled = false;
            C13.Enabled = false;
            C14.Enabled = false;
            C20.Enabled = false;
            C21.Enabled = false;
            C22.Enabled = false;
            C23.Enabled = false;
            C24.Enabled = false;
            C30.Enabled = false;
            C31.Enabled = false;
            C32.Enabled = false;
            C33.Enabled = false;
            C34.Enabled = false;
            C41.Enabled = false;
            C42.Enabled = false;
            C43.Enabled = false;
            Joker.Enabled = true;
            Ace.Enabled = true;
            deck = new List<Card>();
            C01.Text = "";
            C02.Text = "";
            C03.Text = "";
            C10.Text = "";
            C11.Text = "";
            C12.Text = "";
            C13.Text = "";
            C14.Text = "";
            C20.Text = "";
            C21.Text = "";
            C22.Text = "";
            C23.Text = "";
            C24.Text = "";
            C30.Text = "";
            C31.Text = "";
            C32.Text = "";
            C33.Text = "";
            C34.Text = "";
            C41.Text = "";
            C42.Text = "";
            C43.Text = "";
            score = 0;
            ace = 0;
            Ace.Text = "0";
            joker = 0;
            Joker.Text = "0";
            Score.Text = $"Jokers used + Aces used: 0";
            for (i = 0; i < 5; i++)
                for (j = 0; j < 5; j++)
                {
                    placed[i, j] = false;
                    fullOfRoyals[i, j] = false;
                    isDead[i, j] = false;
                    placement[i, j] = new List<Card>();
                }
            FillAndShuffle();
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
                        placement[i, j].Add(new Card { face = inPlay.face, suit = inPlay.suit, color = inPlay.color, image = inPlay.image });
                        placed[i, j] = true;
                        j++;
                        if (j == 4)
                        {
                            i++;
                            j = 1;
                        }
                        if (i == 2 && j == 2)
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
            if (l < k)
                RoyalPlacement();
            else
                TillRoyal();
            for (i = 1; i < 4; i++)
                for (j = 1; j < 4; j++)
                    switch (i)
                    {
                        case 1:
                            switch (j)
                            {
                                case 1:
                                    C11.BackgroundImage = Set(placement[i, j][0].image);
                                    break;
                                case 2:
                                    C12.BackgroundImage = Set(placement[i, j][0].image);
                                    break;
                                case 3:
                                    C13.BackgroundImage = Set(placement[i, j][0].image);
                                    break;
                            }
                            break;
                        case 2:
                            switch (j)
                            {
                                case 1:
                                    C21.BackgroundImage = Set(placement[i, j][0].image);
                                    break;
                                case 3:
                                    C23.BackgroundImage = Set(placement[i, j][0].image);
                                    break;
                            }
                            break;
                        case 3:
                            switch (j)
                            {
                                case 1:
                                    C31.BackgroundImage = Set(placement[i, j][0].image);
                                    break;
                                case 2:
                                    C32.BackgroundImage = Set(placement[i, j][0].image);
                                    break;
                                case 3:
                                    C33.BackgroundImage = Set(placement[i, j][0].image);
                                    break;
                            }
                            break;
                    }
            shameCount = 0;
            Shame.Text = "0";
            if (RoyalCheck())
                TillRoyal();
            Draw();
        }

        /* ------------------------------------------------------------------------------------------ */
        /* ----------------------- Ace & Joker ------------------------------------------------------ */

        private void Ace_Click(object sender, EventArgs e)
        {
            if (ace > 0 && !usingAce)
            {
                usingAce = true;
                ace--;
                Ace.Text = $"{ace}";
                C11.Enabled = true;
                C12.Enabled = true;
                C13.Enabled = true;
                C21.Enabled = true;
                C22.Enabled = true;
                C23.Enabled = true;
                C31.Enabled = true;
                C32.Enabled = true;
                C33.Enabled = true;
                score++;
                Score.Text = $"Jokers used + Aces used: {score}";
            }
            else if (usingAce)
            {
                usingAce = false;
                ace++;
                Ace.Text = $"{ace}";
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                score--;
                Score.Text = $"Jokers used + Aces used: {score}";
                Place();
            }
        }

        private void Joker_Click(object sender, EventArgs e)
        {
            if (joker > 0 && !usingJoker)
            {
                usingJoker = true;
                joker--;
                Joker.Text = $"{joker}";
                C11.Enabled = true;
                C12.Enabled = true;
                C13.Enabled = true;
                C21.Enabled = true;
                C22.Enabled = true;
                C23.Enabled = true;
                C31.Enabled = true;
                C32.Enabled = true;
                C33.Enabled = true;
                score++;
                Score.Text = $"Jokers used + Aces used: {score}";
            }
            else if (usingJoker)
            {
                usingJoker = false;
                joker++;
                Joker.Text = $"{joker}";
                C11.Enabled = false;
                C12.Enabled = false;
                C13.Enabled = false;
                C21.Enabled = false;
                C22.Enabled = false;
                C23.Enabled = false;
                C31.Enabled = false;
                C32.Enabled = false;
                C33.Enabled = false;
                score--;
                Score.Text = $"Jokers used + Aces used: {score}";
                Place();
            }
        }

        private void Shame_Click(object sender, EventArgs e)
        {
            
            shameCount += inPlay.face;
            Shame.Text = $"{shameCount}";
            armor = false;
            Shame.Enabled = false;
            C01.Enabled = false;
            C02.Enabled = false;
            C03.Enabled = false;
            C10.Enabled = false;
            C14.Enabled = false;
            C20.Enabled = false;
            C24.Enabled = false;
            C30.Enabled = false;
            C34.Enabled = false;
            C41.Enabled = false;
            C42.Enabled = false;
            C43.Enabled = false;
            Draw();
        }

        /* ------------------------------------------------------------------------------------------ */
        /* ----------------------- Royal Functions -------------------------------------------------- */
        public bool RoyalCheck()
        {
            bool needRoyals = true;
            int numDeadRoyals = 0;

            if (placed[0, 1] && !isDead[0, 1])
                needRoyals = false;
            else if (placed[0, 1])
                numDeadRoyals++;

            if (placed[0, 2] && !isDead[0, 2])
                needRoyals = false;
            else if (placed[0, 2])
                numDeadRoyals++;

            if (placed[0, 3] && !isDead[0, 3])
                needRoyals = false;
            else if (placed[0, 3])
                numDeadRoyals++;

            if (placed[1, 0] && !isDead[1, 0])
                needRoyals = false;
            else if (placed[1, 0])
                numDeadRoyals++;

            if (placed[1, 4] && !isDead[1, 4])
                needRoyals = false;
            else if (placed[1, 4])
                numDeadRoyals++;

            if (placed[2, 0] && !isDead[2, 0])
                needRoyals = false;
            else if (placed[2, 0])
                numDeadRoyals++;

            if (placed[2, 4] && !isDead[2, 4])
                needRoyals = false;
            else if (placed[2, 4])
                numDeadRoyals++;

            if (placed[3, 0] && !isDead[3, 0])
                needRoyals = false;
            else if (placed[3, 0])
                numDeadRoyals++;

            if (placed[3, 4] && !isDead[3, 4])
                needRoyals = false;
            else if (placed[3, 4])
                numDeadRoyals++;

            if (placed[4, 1] && !isDead[4, 1])
                needRoyals = false;
            else if (placed[4, 1])
                numDeadRoyals++;

            if (placed[4, 2] && !isDead[4, 2])
                needRoyals = false;
            else if (placed[4, 2])
                numDeadRoyals++;

            if (placed[4, 3] && !isDead[4, 3])
                needRoyals = false;
            else if (placed[4, 3])
                numDeadRoyals++;

            if (numDeadRoyals == 12)
                MessageBox.Show("You Win!");

            return needRoyals;
        }
        public void RoyalPlacement(Card royal)      //Function for placing royals (doesn't work)
        {
            int highest = 0, highesti = 0, highestj = 0;
            bool suit = false, color = false;
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if ((i != 2 || j != 2) && !fullOfRoyals[i,j])
                    {
                        if (placement[i, j][0].suit == royal.suit && !suit)
                        {
                            suit = true;
                            highest = 0;
                            highesti = 0;
                            highestj = 0;
                        }
                        else if (placement[i, j][0].color == royal.color && !color && !suit)
                        {
                            color = true;
                            highest = 0;
                            highesti = 0;
                            highestj = 0;
                        }
                        if (suit)
                        {
                            if (placement[i, j][0].suit == royal.suit && placed[i,j])
                            {
                                if (highest < placement[i, j][0].face)
                                {
                                    highest = placement[i, j][0].face;
                                    highesti = i;
                                    highestj = j;
                                }
                            }
                        }
                        else if (color)
                        {
                            if (placement[i, j][0].color == royal.color && placed[i,j])
                            {
                                if (highest < placement[i, j][0].face)
                                {
                                    highest = placement[i, j][0].face;
                                    highesti = i;
                                    highestj = j;
                                }
                            }
                        }
                        else
                        {
                            if (placed[i,j])
                            {
                                if (highest < placement[i, j][0].face)
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
                if (!placed[0, 1] && !placed[1, 0])
                {
                    C01.Enabled = true;
                    C10.Enabled = true;
                }
                else if (placed[0, 1])
                {
                    placed[1, 0] = true;
                    placement[1, 0].Add(royal);
                    C10.BackgroundImage = Set(royal.image);
                    fullOfRoyals[1, 1] = true;
                    Draw();
                }
                else if (placed[1, 0])
                {
                    placed[0, 1] = true;
                    placement[0, 1].Add(royal);
                    C01.BackgroundImage = Set(royal.image);
                    fullOfRoyals[1, 1] = true;
                    Draw();
                }
            }
            else if (highesti == 1 && highestj == 2 && !placed[0,2])
            {
                placed[0, 2] = true;
                placement[0, 2].Add(royal);
                C02.BackgroundImage = Set(royal.image);
                fullOfRoyals[1, 2] = true;
                Draw();
            }
            else if (highesti == 1 && highestj == 3)
            {
                if (!placed[0, 3] && !placed[1, 4])
                {
                    C03.Enabled = true;
                    C14.Enabled = true;
                }
                else if(placed[0, 3])
                {
                    placed[1, 4] = true;
                    placement[1, 4].Add(royal);
                    C14.BackgroundImage = Set(royal.image);
                    fullOfRoyals[1, 3] = true;
                    Draw();
                }
                else if (placed[1, 4])
                {
                    placed[0, 3] = true;
                    placement[0, 3].Add(royal);
                    C03.BackgroundImage = Set(royal.image);
                    fullOfRoyals[1, 3] = true;
                    Draw();
                }
            }
            else if (highesti == 2 && highestj == 1 && !placed[2, 0])
            {
                placed[2,0] = true;
                placement[2, 0].Add(royal);
                C20.BackgroundImage = Set(royal.image);
                fullOfRoyals[2, 1] = true;
                Draw();
            }
            else if(highesti == 2 && highestj == 3 && !placed[2,4])
            {
                placed[2, 4] = true;
                placement[2, 4].Add(royal);
                C24.BackgroundImage = Set(royal.image);
                fullOfRoyals[2, 3] = true;
                Draw();
            }
            else if(highesti == 3 && highestj == 1)
            {
                if (!placed[3, 0] && !placed[4, 1])
                {
                    C30.Enabled = true;
                    C41.Enabled = true;
                }
                else if (placed[3, 0])
                {
                    placed[4, 1] = true;
                    placement[4, 1].Add(royal);
                    C41.BackgroundImage = Set(royal.image);
                    fullOfRoyals[3, 1] = true;
                    Draw();
                }
                else if (placed[4, 1])
                {
                    placed[3, 0] = true;
                    placement[3, 0].Add(royal);
                    C30.BackgroundImage = Set(royal.image);
                    fullOfRoyals[3, 1] = true;
                    Draw();
                }
            }
            else if(highesti == 3 && highestj == 2 && !placed[4,2])
            {
                placed[4, 2] = true;
                placement[4, 2].Add(royal);
                C42.BackgroundImage = Set(royal.image);
                fullOfRoyals[3, 2] = true;
                Draw();
            }
            else if(highesti == 3 && highestj == 3)
            {
                if (!placed[3, 4] && !placed[4, 3])
                {
                    C34.Enabled = true;
                    C43.Enabled = true;
                }
                else if (placed[4, 3])
                {
                    placed[3, 4] = true;
                    placement[3, 4].Add(royal);
                    C34.BackgroundImage = Set(royal.image);
                    fullOfRoyals[3, 3] = true;
                    Draw();
                }
                else if (placed[3, 4])
                {
                    placed[4, 3] = true;
                    placement[4, 3].Add(royal);
                    C43.BackgroundImage = Set(royal.image);
                    fullOfRoyals[3, 3] = true;
                    Draw();
                }
            }
        }

        public void RoyalPlacement()
        {
            int highest = 0, highesti = 0, highestj = 0;
            bool suit = false, color = false;
            
            if (l < k)
            {
                Play.BackgroundImage = Set(royal[l].image);
                for (int i = 1; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if ((i != 2 || j != 2) && l < k && !fullOfRoyals [i,j])
                        {
                            if (placement[i, j][0].suit == royal[l].suit && !suit)
                            {
                                suit = true;
                                highest = 0;
                                highesti = 0;
                                highestj = 0;
                            }
                            else if (placement[i, j][0].color == royal[l].color && !color && !suit)
                            {
                                color = true;
                                highest = 0;
                                highesti = 0;
                                highestj = 0;
                            }
                            if (suit)
                            {
                                if (placement[i, j][0].suit == royal[l].suit && placed[i, j])
                                {
                                    if (highest < placement[i, j][0].face)
                                    {
                                        highest = placement[i, j][0].face;
                                        highesti = i;
                                        highestj = j;
                                    }
                                }
                            }
                            else if (color)
                            {
                                if (placement[i, j][0].color == royal[l].color && placed[i, j])
                                {
                                    if (highest < placement[i, j][0].face)
                                    {
                                        highest = placement[i, j][0].face;
                                        highesti = i;
                                        highestj = j;
                                    }
                                }
                            }
                            else
                            {
                                if (placed[i, j])
                                {
                                    if (highest < placement[i, j][0].face)
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
                    if (!placed[0, 1] && !placed[1, 0])
                    {
                        C01.Enabled = true;
                        C10.Enabled = true;
                    }
                    else if (placed[0, 1])
                    {
                        placed[1, 0] = true;
                        placement[1, 0].Add(royal[l]);
                        C10.BackgroundImage = Set(royal[l].image);
                        l++;
                        fullOfRoyals[1, 1] = true;
                        RoyalPlacement();
                    }
                    else if (placed[1, 0])
                    {
                        placed[0, 1] = true;
                        placement[0, 1].Add(royal[l]);
                        C01.BackgroundImage = Set(royal[l].image);
                        l++;
                        fullOfRoyals[1, 1] = true;
                        RoyalPlacement();
                    }
                }
                else if (highesti == 1 && highestj == 2 && !placed[0, 2])
                {
                    placed[0, 2] = true;
                    placement[0, 2].Add(royal[l]);
                    C02.BackgroundImage = Set(royal[l].image);
                    l++;
                    fullOfRoyals[1, 2] = true;
                    RoyalPlacement();
                }
                else if (highesti == 1 && highestj == 3)
                {
                    if (!placed[0, 3] && !placed[1, 4])
                    {
                        C03.Enabled = true;
                        C14.Enabled = true;
                    }
                    else if (placed[0, 3])
                    {
                        placed[1, 4] = true;
                        placement[1, 4].Add(royal[l]);
                        C14.BackgroundImage = Set(royal[l].image);
                        l++;
                        fullOfRoyals[1, 3] = true;
                        RoyalPlacement();
                    }
                    else if (placed[1, 4])
                    {
                        placed[0, 3] = true;
                        placement[0, 3].Add(royal[l]);
                        C03.BackgroundImage = Set(royal[l].image);
                        l++;
                        fullOfRoyals[1, 3] = true;
                        RoyalPlacement();
                    }
                }
                else if (highesti == 2 && highestj == 1 && !placed[2, 0])
                {
                    placed[2, 0] = true;
                    placement[2, 0].Add(royal[l]);
                    C20.BackgroundImage = Set(royal[l].image);
                    l++;
                    fullOfRoyals[2, 1] = true;
                    RoyalPlacement();
                }
                else if (highesti == 2 && highestj == 3 && !placed[2, 4])
                {
                    placed[2, 4] = true;
                    placement[2, 4].Add(royal[l]);
                    C24.BackgroundImage = Set(royal[l].image);
                    l++;
                    fullOfRoyals[2, 3] = true;
                    RoyalPlacement();
                }
                else if (highesti == 3 && highestj == 1)
                {
                    if (!placed[3, 0] && !placed[4, 1])
                    {
                        C30.Enabled = true;
                        C41.Enabled = true;
                    }
                    else if (placed[3, 0])
                    {
                        placed[4, 1] = true;
                        placement[4, 1].Add(royal[l]);
                        C41.BackgroundImage = Set(royal[l].image);
                        l++;
                        fullOfRoyals[3, 1] = true;
                        RoyalPlacement();
                    }
                    else if (placed[4, 1])
                    {
                        placed[3, 0] = true;
                        placement[3, 0].Add(royal[l]);
                        C03.BackgroundImage = Set(royal[l].image);
                        l++;
                        RoyalPlacement();
                    }
                }
                else if (highesti == 3 && highestj == 2 && !placed[4, 2])
                {
                    placed[4, 2] = true;
                    placement[4, 2].Add(royal[l]);
                    C42.BackgroundImage = Set(royal[l].image);
                    l++;
                    fullOfRoyals[3, 2] = true;
                    RoyalPlacement();
                }
                else if (highesti == 3 && highestj == 3)
                {
                    if (!placed[3, 4] && !placed[4, 3])
                    {
                        C34.Enabled = true;
                        C43.Enabled = true;
                    }
                    else if (placed[4, 3])
                    {
                        placed[3, 4] = true;
                        placement[3, 4].Add(royal[l]);
                        C34.BackgroundImage = Set(royal[l].image);
                        l++;
                        fullOfRoyals[3, 3] = true;
                        RoyalPlacement();
                    }
                    else if (placed[3, 4])
                    {
                        placed[4, 3] = true;
                        placement[4, 3].Add(royal[l]);
                        C43.BackgroundImage = Set(royal[l].image);
                        l++;
                        fullOfRoyals[3, 3] = true;
                        RoyalPlacement();
                    }
                }
            }
            else
                Place();
        }

        /* ------------------------------------------------------------------------------------------ */
        /* ------------------------ Card Functions -------------------------------------------------- */
        public void Place()
        {
            int lowest = 100, lowesti = 0, lowestj = 0;
            bool suit = false, color = false;
            Shame.Enabled = true;
            armor = true;
            switch (inPlay.face)
            {
                case 1:
                    armor = false;
                    Shame.Enabled = false;
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
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C11.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                        case 2:
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C12.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                        case 3:
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C13.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (j)
                                    {
                                        case 1:
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C21.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                        case 2:
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C22.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            else if(!placement[i,j].Any())
                                            {
                                                C22.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                        case 3:
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C23.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (j)
                                    {
                                        case 1:
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C31.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                        case 2:
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C32.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                        case 3:
                                            if (placement[i, j].Any() && inPlay.face >= placement[i, j][0].face)
                                            {
                                                C33.Enabled = true;
                                                Shame.Enabled = false;
                                                armor = false;
                                            }
                                            break;
                                    }
                                    break;
                            }
                    break;
                case 11:
                case 12:
                case 13:
                    armor = false;
                    Shame.Enabled = false;
                    RoyalPlacement(inPlay);
                    break;
                case 14:
                    armor = false;
                    Shame.Enabled = false;
                    joker++;
                    Joker.Text = Convert.ToString(joker);
                    Draw();
                    break;                    
            }
            if (armor)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!isDead[i, j])
                        {
                            switch (i)
                            {
                                case 0:
                                    switch (j)
                                    {
                                        case 1:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 2:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 3:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (j)
                                    {
                                        case 0:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 4:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (j)
                                    {
                                        case 0:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 4:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (j)
                                    {
                                        case 0:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 4:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                case 4:
                                    switch (j)
                                    {
                                        case 1:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 2:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 3:
                                            if (placed[i, j])
                                            {
                                                if (placement[i, j][0].suit == inPlay.suit && !suit)
                                                {
                                                    suit = true;
                                                    lowest = 100;
                                                }
                                                else if (placement[i, j][0].color == inPlay.color && !color && !suit)
                                                {
                                                    color = true;
                                                    lowest = 100;
                                                }
                                                if (suit)
                                                {
                                                    if (placement[i, j][0].suit == inPlay.suit && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else if (color)
                                                {
                                                    if (placement[i, j][0].color == inPlay.color && placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    if (placed[i, j])
                                                    {
                                                        if (lowest > placement[i, j][0].face)
                                                        {
                                                            lowest = placement[i, j][0].face;
                                                            lowesti = i;
                                                            lowestj = j;
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                }

                switch (lowesti)
                {
                    case 0:
                        switch (lowestj)
                        {
                            case 1:
                                if (placed[lowesti, lowestj])
                                {
                                    C01.Enabled = true;
                                }
                                break;
                            case 2:
                                if (placed[lowesti, lowestj])
                                {
                                    C02.Enabled = true;
                                }
                                break;
                            case 3:
                                if (placed[lowesti, lowestj])
                                {
                                    C03.Enabled = true;
                                }
                                break;
                        }
                        break;
                    case 1:
                        switch (lowestj)
                        {
                            case 0:
                                if (placed[lowesti, lowestj])
                                {
                                    C10.Enabled = true;
                                }
                                break;
                            case 4:
                                if (placed[lowesti, lowestj])
                                {
                                    C14.Enabled = true;
                                }
                                break;
                        }
                        break;
                    case 2:
                        switch (lowestj)
                        {
                            case 0:
                                if (placed[lowesti, lowestj])
                                {
                                    C20.Enabled = true;
                                }
                                break;
                            case 4:
                                if (placed[lowesti, lowestj])
                                {
                                    C24.Enabled = true;
                                }
                                break;
                        }
                        break;
                    case 3:
                        switch (lowestj)
                        {
                            case 0:
                                if (placed[lowesti, lowestj])
                                {
                                    C30.Enabled = true;
                                }
                                break;
                            case 4:
                                if (placed[lowesti, lowestj])
                                {
                                    C34.Enabled = true;
                                }
                                break;
                        }
                        break;
                    case 4:
                        switch (lowestj)
                        {
                            case 1:
                                if (placed[lowesti, lowestj])
                                {
                                    C41.Enabled = true;
                                }
                                break;
                            case 2:
                                if (placed[lowesti, lowestj])
                                {
                                    C42.Enabled = true;
                                }
                                break;
                            case 3:
                                if (placed[lowesti, lowestj])
                                {
                                    C43.Enabled = true;
                                }
                                break;
                        }
                        break;
                }
            }
        }

        public Image Set(int image)
        {
            Image picture;
            picture = Properties.Resources._2_of_clubs;
            switch (image)
            {
                case 0:
                    picture = Properties.Resources.ace_of_spades;
                    break;
                case 1:
                    picture = Properties.Resources._2_of_diamonds;
                    break;
                case 2:
                    picture = Properties.Resources._3_of_clubs;
                    break;
                case 3:
                    picture = Properties.Resources._4_of_hearts;
                    break;
                case 4:
                    picture = Properties.Resources._5_of_spades;
                    break;
                case 5:
                    picture = Properties.Resources._6_of_diamonds;
                    break;
                case 6:
                    picture = Properties.Resources._7_of_clubs;
                    break;
                case 7:
                    picture = Properties.Resources._8_of_hearts;
                    break;
                case 8:
                    picture = Properties.Resources._9_of_spades;
                    break;
                case 9:
                    picture = Properties.Resources._10_of_diamonds;
                    break;
                case 10:
                    picture = Properties.Resources.jack_of_clubs2;
                    break;
                case 11:
                    picture = Properties.Resources.queen_of_hearts2;
                    break;
                case 12:
                    picture = Properties.Resources.king_of_spades2;
                    break;
                case 14:
                    picture = Properties.Resources._2_of_clubs;
                    break;
                case 15:
                    picture = Properties.Resources._3_of_hearts;
                    break;
                case 16:
                    picture = Properties.Resources._4_of_spades;
                    break;
                case 17:
                    picture = Properties.Resources._5_of_diamonds;
                    break;
                case 18:
                    picture = Properties.Resources._6_of_clubs;
                    break;
                case 19:
                    picture = Properties.Resources._7_of_hearts;
                    break;
                case 20:
                    picture = Properties.Resources._8_of_spades;
                    break;
                case 21:
                    picture = Properties.Resources._9_of_diamonds;
                    break;
                case 22:
                    picture = Properties.Resources._10_of_clubs;
                    break;
                case 23:
                    picture = Properties.Resources.jack_of_hearts2;
                    break;
                case 24:
                    picture = Properties.Resources.queen_of_spades2;
                    break;
                case 25:
                    picture = Properties.Resources.king_of_diamonds2;
                    break;
                case 27:
                    picture = Properties.Resources._2_of_hearts;
                    break;
                case 28:
                    picture = Properties.Resources._3_of_spades;
                    break;
                case 29:
                    picture = Properties.Resources._4_of_diamonds;
                    break;
                case 30:
                    picture = Properties.Resources._5_of_clubs;
                    break;
                case 31:
                    picture = Properties.Resources._6_of_hearts;
                    break;
                case 32:
                    picture = Properties.Resources._7_of_spades;
                    break;
                case 33:
                    picture = Properties.Resources._8_of_diamonds;
                    break;
                case 34:
                    picture = Properties.Resources._9_of_clubs;
                    break;
                case 35:
                    picture = Properties.Resources._10_of_hearts;
                    break;
                case 36:
                    picture = Properties.Resources.jack_of_spades2;
                    break;
                case 37:
                    picture = Properties.Resources.queen_of_diamonds2;
                    break;
                case 38:
                    picture = Properties.Resources.king_of_clubs2;
                    break;
                case 40:
                    picture = Properties.Resources._2_of_spades;
                    break;
                case 41:
                    picture = Properties.Resources._3_of_diamonds;
                    break;
                case 42:
                    picture = Properties.Resources._4_of_clubs;
                    break;
                case 43:
                    picture = Properties.Resources._5_of_hearts;
                    break;
                case 44:
                    picture = Properties.Resources._6_of_spades;
                    break;
                case 45:
                    picture = Properties.Resources._7_of_diamonds;
                    break;
                case 46:
                    picture = Properties.Resources._8_of_clubs;
                    break;
                case 47:
                    picture = Properties.Resources._9_of_hearts;
                    break;
                case 48:
                    picture = Properties.Resources._10_of_spades;
                    break;
                case 49:
                    picture = Properties.Resources.jack_of_diamonds2;
                    break;
                case 50:
                    picture = Properties.Resources.queen_of_clubs2;
                    break;
                case 51:
                    picture = Properties.Resources.king_of_hearts2;
                    break;
            }
            return picture;
        }
        public Form1()
        {
            InitializeComponent();
            Ace.BackgroundImage = Properties.Resources.ace_of_spades2;
            Joker.BackgroundImage = Properties.Resources.red_joker;
            SetUp();
        }
    }
}

/* ------------------------------------------------------------------------------------------ */
/* -------------------------- Game Classes -------------------------------------------------- */
public static class CardMixer  //Extension to the List class for shuffling a List
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
public class Card       //members of the Card class
{
    public int face, suit, color, armor = 0, image;
}