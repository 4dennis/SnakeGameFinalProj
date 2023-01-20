using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//To Do
//Add comments
//dont let arrow keys to double up
//draw grid
//unlock colours 
//add score board
//save scores to file
//change colide detection 
//# of apples
//adaptable mode
//draw head



namespace SnakeGameFinalProj
{
    public partial class Form1 : Form
    {

        Snake BigGreen, GreenTheSecond; //Big Green, Green the Second
        Food Apple;

        public Form1()
        {

            InitializeComponent();

            BigGreen = new Snake(5, 13, 3, Color.Green);
            GreenTheSecond = new Snake(23, 15, 9, Color.Blue);
            Apple = new Food();


        }

        public void SpeedDisplay()
        {
            txtSpeed.Text = Convert.ToString(1000/SnakeTimer.Interval);

        }
        public void AdaptableTimer()
        {
            if (rbAdaptable.Checked == true)
            {
                double size = 0;

                
                if (rbTwoPlayer.Checked == true)
                {
                    //size = 150 - (BigGreen.GetBodyCount() + GreenTheSecond.GetBodyCount()) * 3;
                    size = 250 - (Math.Sqrt(BigGreen.GetBodyCount() + GreenTheSecond.GetBodyCount())) * 30;
                }
                else
                {
                   // size = 150 - (BigGreen.GetBodyCount()) * 6;
                   size = 250 - (Math.Sqrt(BigGreen.GetBodyCount())) * 30;
                }
                if (size <= 0)
                {
                    size = 1;
                    return;
                }

            }
            
        }
        public void endGame()
        {
            SnakeTimer.Stop();
            btnPause.Enabled = false;
            Apple.ResetFood();
          
        }
        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }






        public class BodyPart
        {
            public int pX;
            public int pY;
            public Color clr;

            public BodyPart()
            {
                pX = 14;
                pY = 14;
                clr = Color.Green;
            }
            public BodyPart(int x, int y)
            {
                pX = x;
                pY = y;
            }
            public BodyPart(int x, int y, Color col)
            {
                pX = x;
                pY = y;
                clr = col;
            }
            public void Draw(Graphics g)
            {
                SolidBrush SnakeBrush = new SolidBrush(clr);
                g.FillRectangle(SnakeBrush, pX * 20, pY * 20, 20, 20);
            }

             

        }






        public class Snake
        {
            private int Direction; // 12:up, 3:right, 6:down, 9:left. Based on clock hand
            public Color clr;
             List<BodyPart> snakeBody = new List<BodyPart>();

            public Snake()
            {
                snakeBody.Clear();
                BodyPart newHead = new BodyPart();
                snakeBody.Add(newHead);
                Direction = 3; // Start game going right

            }
            public Snake(int x, int y, int dir)
            {
                snakeBody.Clear();
                BodyPart newHead = new BodyPart(x, y);
                snakeBody.Add(newHead);
                Direction = dir; 
            }

            public Snake(int x, int y, int dir, Color col)
            {
                snakeBody.Clear();
                clr = col;
                BodyPart newHead = new BodyPart(x, y, clr);
                snakeBody.Add(newHead);
                Direction = dir; 
            }

            public List<BodyPart>  bodyPosition()
            {
                
                return snakeBody;
            }

            public int GetBodyCount()
            {
                return snakeBody.Count();
            }

            public int GetHeadX()
            {
                if(snakeBody.Count == 0)
                {
                    return -1;
                }
                else
                {
                    return snakeBody[0].pX;
                }
            }

            public int GetHeadY()
            {
                if (snakeBody.Count == 0)
                {
                    return -1;
                }
                else
                {
                    return snakeBody[0].pY;
                }
            }


            public void SetDirection(int dir)
            {
                if (Direction == dir + 6 || Direction == dir - 6)
                {
                    return;
                }

                if (dir == 3)
                {
                    Direction = 3;
                }
                else if (dir == 6)
                {
                    Direction = 6;
                }
                else if (dir == 9)
                {
                    Direction = 9;
                }
                else if (dir == 12)
                {
                    Direction = 12;
                }
            }

            public bool CollideSelf()
            {
                for(int i = 2; i < snakeBody.Count; i++)
                {
                    if (snakeBody[0].pX == snakeBody[i].pX && snakeBody[0].pY == snakeBody[i].pY)
                    {
                        return true;
                    }
                    
                }
                return false;
            }

            public bool CollideWall()
            {
                if (snakeBody[0].pX < 0 || snakeBody[0].pY < 0 || snakeBody[0].pX > 29 || snakeBody[0].pY > 29)
                {
                    // Python.GetHeadX() < 0 || Python.GetHeadY() < 0 || Python.GetHeadX() > 29 || Python.GetHeadY() > 29
                    return true;
                }
                return false;
            }

            public int CollideOther(Snake other)
            {
                
                for(int i = 1; i < this.snakeBody.Count; i++)
                {
                    if (other.snakeBody[0].pX == this.snakeBody[i].pX && other.snakeBody[0].pY == this.snakeBody[i].pY)
                    {
                        return 1; //head of other snake colides with body of this snake
                    }
                }
                if (this.snakeBody[0].pX == other.snakeBody[0].pX && this.snakeBody[0].pY == other.snakeBody[0].pY)
                {
                    return -1; //head to head collision
                }
                else
                {
                    return 0; //no collision
                }

            }

            public void Move()
            {
                BodyPart newHead;
                int HeadposX, HeadposY, NewHeadposX, NewHeadposY;

                HeadposX = snakeBody[0].pX;
                HeadposY = snakeBody[0].pY;
                NewHeadposX = HeadposX;
                NewHeadposY = HeadposY;

                if (Direction == 3) // right
                {
                    NewHeadposX = HeadposX + 1;
                    NewHeadposY = HeadposY;
                }
                else if (Direction == 9) // left
                {

                    NewHeadposX = HeadposX - 1;
                    NewHeadposY = HeadposY;

                }
                else if (Direction == 6) // down
                {
                    NewHeadposX = HeadposX;
                    NewHeadposY = HeadposY + 1;
                }
                else if (Direction == 12) // up
                {
                    NewHeadposX = HeadposX;
                    NewHeadposY = HeadposY - 1;
                }



                newHead = new BodyPart(NewHeadposX, NewHeadposY, clr);

                snakeBody.Insert(0, newHead);
                snakeBody.RemoveAt(snakeBody.Count - 1);

            }

            public void DrawSnake(Graphics g)
            {
                for (int i = 0; i < snakeBody.Count; i++)
                {
                    snakeBody[i].Draw(g);
                }
            }

            public void Grow(Food Apple)
            {
                if(snakeBody[0].pX == Apple.GetfX() && snakeBody[0].pY == Apple.GetfY())
                {
                    BodyPart newHead;
                    newHead = new BodyPart(Apple.GetfX(),Apple.GetfY(), clr);
                    snakeBody.Insert(0,newHead);
                    Apple.CreateFood(this);
                }

            }


            public void ResetGame(int x,int y, int dir)
            {
                snakeBody.Clear();
                BodyPart newHead = new BodyPart(x,y, clr);
                snakeBody.Add(newHead);
                //snakeBody[0].pY = y;
                //snakeBody[0].pX = x;
                Direction = dir; // Start game going dir
               
                
            }
            public void ResetGame()
            {
                snakeBody.Clear();
                BodyPart newHead = new BodyPart();
                snakeBody.Add(newHead);
                snakeBody[0].pY = 14;
                snakeBody[0].pX = 14;
                Direction = 3; // Start game going right


            }

            public void ChangeColor(Color c)
            {
                clr = c;

                for (int i = 0; i < snakeBody.Count ; i++)
                {
                    snakeBody[i].clr = c;
                }

            }

            public bool AppleChek(int AppleX, int AppleY)
            {
                for (int i = 0; i < snakeBody.Count - 1; i++)
                {
                    if (snakeBody[i].pX == AppleX && snakeBody[i].pY == AppleY)
                    {
                        return true;
                    }
                }

                return false;
            }
            public static bool operator ==(Snake s1, Snake s2)
            {
                if (s1.snakeBody.Count == s2.snakeBody.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator !=(Snake s1, Snake s2)
            {
                if (s1.snakeBody.Count == s2.snakeBody.Count)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public static bool operator >(Snake s1, Snake s2)
            {
                if (s1.snakeBody.Count > s2.snakeBody.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator <(Snake s1, Snake s2)
            {
                if (s1.snakeBody.Count < s2.snakeBody.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class Food
        {
            protected int fX;
            protected int fY;
            public Color clr;
            protected Random randgen;

            public Food()
            {
                randgen = new Random();
                fX = 14;
                fY = 14;
                clr = Color.Red;
            }
            public void ResetFood()
            {
                fX = 14;
                fY = 14;
                
            }

            public int GetfX()
            {
                return fX;
            }
            public int GetfY()
            {
                return fY;
            }
            public void CreateFood(Snake s)
            {
              
                fX = randgen.Next(0,30);
                fY = randgen.Next(0, 30);

                while (s.AppleChek(fX, fY) == true)
                {
                    fX = randgen.Next(0, 30);
                    fY = randgen.Next(0, 30);
                }
                

            }
            public void CreateFood(Snake s, Snake g)
            {

                fX = randgen.Next(0, 30);
                fY = randgen.Next(0, 30);

                while (s.AppleChek(fX, fY) == true || g.AppleChek(fX, fY) == true)
                {
                    fX = randgen.Next(0, 30);
                    fY = randgen.Next(0, 30);
                }


            }
            public void Draw(Graphics g)
            {
                SolidBrush FoodBrush = new SolidBrush(clr);
                g.FillRectangle(FoodBrush, fX * 20, fY * 20, 20, 20);
            }
        }





        private void SnakeTimer_Tick(object sender, EventArgs e)
        {
            
            if(rbOnePlayer.Checked == true)//one snake
            {
                if (BigGreen.CollideSelf() == true || BigGreen.CollideWall() == true)
                {

                    endGame();
                    MessageBox.Show("Apples Rotten");
                    
                }
                BigGreen.Move();
                pbPlane.Invalidate();
                BigGreen.Grow(Apple);
            }
            else if (rbTwoPlayer.Checked == true) //two snakes
            {
                if ((BigGreen.CollideSelf() == true || BigGreen.CollideWall() == true || BigGreen.CollideOther(GreenTheSecond) == 1) 
                    && (GreenTheSecond.CollideSelf() == true || GreenTheSecond.CollideWall() == true || GreenTheSecond.CollideOther(BigGreen) == 1)) 
                    
                    //if both die at same time
                {
                    //tie
                    endGame();
                    MessageBox.Show("Apples Rotten");
                    
                }
                
                else if (BigGreen.CollideOther(GreenTheSecond) == 1 || GreenTheSecond.CollideSelf() == true 
                    || GreenTheSecond.CollideWall() == true)
                    //if green second hits wall, self, or other
                {
                    //big green win
                    endGame();
                    MessageBox.Show("Apples Rotten, Big Green Win, by survival");
                    
                }
                else if (GreenTheSecond.CollideOther(BigGreen) == 1 || BigGreen.CollideSelf() == true
                    || BigGreen.CollideWall() == true)
                    //if big green hits wall, self, or other
                {
                    //Green Second wins
                    endGame();
                    MessageBox.Show("Apples Rotten, Green the Second Win, by survival");
                    
                }
                else if (BigGreen.CollideOther(GreenTheSecond) == -1)//head to head
                {
                    
                    endGame();

                    if (BigGreen > GreenTheSecond) //Big green larger
                    {
                        MessageBox.Show("Apples Rotten, Big Green Wins collision");
                    }
                    else if (BigGreen < GreenTheSecond)//Green the second larger
                    {
                        MessageBox.Show("Apples Rotten, Green the Second Wins collision");
                    }
                    else //Same size
                    {
                        MessageBox.Show("Apples Rotten, Both Lose");

                    }

                }
                else
                {
                    BigGreen.Move();
                    GreenTheSecond.Move();
                    pbPlane.Invalidate();
                    BigGreen.Grow(Apple);
                    GreenTheSecond.Grow(Apple);
                }
                
            }
            AdaptableTimer();
            SpeedDisplay();

        }



        private void pbPlane_Paint(object sender, PaintEventArgs e)
        {
            BigGreen.DrawSnake(e.Graphics);
            Apple.Draw(e.Graphics);
            
            if (rbOnePlayer.Checked == true)
            {
                BigGreen.DrawSnake(e.Graphics);

            }
            else
            {
                GreenTheSecond.DrawSnake(e.Graphics);
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string KeyLetter;

            KeyLetter = e.KeyCode.ToString();



            if(KeyLetter.ToLower() == "w" )
            {
                BigGreen.SetDirection(12);

            }
            else if (KeyLetter.ToLower() == "d")
            {
                BigGreen.SetDirection(3);
            }
            else if (KeyLetter.ToLower() == "s")
            {
                BigGreen.SetDirection(6);
            }
            else if (KeyLetter.ToLower() == "a")
            {
                BigGreen.SetDirection(9);
            }

            if (e.KeyValue == 38)
            {
                GreenTheSecond.SetDirection(12);

            }
            else if (e.KeyValue == 39)
            {
                GreenTheSecond.SetDirection(3);
            }
            else if (e.KeyValue == 40)
            {
                GreenTheSecond.SetDirection(6);
            }
            else if (e.KeyValue == 37)
            {
                GreenTheSecond.SetDirection(9);
            }


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SnakeTimer.Start();

            btnStart.Enabled = false; //disable start while running
            btnPause.Enabled = true; //enable to pause
            btnReset.Enabled = true; //enable to reset

            btnColorFood.Enabled = false;
            btnColS1.Enabled = false;
            btnColS2.Enabled = false;

            gbMode.Enabled = false;

            pbPlane.Focus();


        }
        private void btnPause_Click(object sender, EventArgs e)/////////make sure key input doesnt regester when paused
        {
            if (SnakeTimer.Enabled == true)//if race timer is running, stop and change to allow continue
            {
                SnakeTimer.Stop();
                btnPause.Text = "Continue";

                btnColorFood.Enabled = true;
                btnColS1.Enabled = true;
                btnColS2.Enabled = true;
            }
            else if (SnakeTimer.Enabled == false)// resumes timer and allows pause on next click
            {
                SnakeTimer.Start();
                btnPause.Text = "Pause";

                btnColorFood.Enabled = false;
                btnColS1.Enabled = false;
                btnColS2.Enabled = false;
            }

        }

        private void rbOnePlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOnePlayer.Checked == true)
            {
                pbPlane.Invalidate();
                btnColS2.Visible = false;
            }
            else
            {
                pbPlane.Invalidate();
                btnColS2.Visible = true;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
            SpeedDisplay();

        }

        private void btnColS1_Click(object sender, EventArgs e)
        {
            cdS1.ShowDialog(); //bring up dialog to chose colour 
            BigGreen.ChangeColor(cdS1.Color); //apply change
            pbPlane.Invalidate(); //display change
        }

        private void btnColS2_Click(object sender, EventArgs e)
        {
            cdS2.ShowDialog(); //bring up dialog to chose colour 
            GreenTheSecond.ChangeColor(cdS2.Color); //apply change
            pbPlane.Invalidate(); //display change
        }

        private void btnColorFood_Click(object sender, EventArgs e)
        {
            cdFood.ShowDialog(); //bring up dialog to chose colour
            Apple.clr = cdFood.Color; //apply change
            pbPlane.Invalidate(); //display change
        }

        private void rbAdaptable_CheckedChanged(object sender, EventArgs e)
        {
            pbPlane.Focus();

            if (rbAdaptable.Checked == true) //base value
            {
                SnakeTimer.Interval = 220;
            }
            AdaptableTimer();
            SpeedDisplay();
        }

        private void rbEasy_CheckedChanged(object sender, EventArgs e)
        {
            pbPlane.Focus();

            if (rbEasy.Checked == true)
            {
                SnakeTimer.Interval = 200;
            }
            SpeedDisplay();
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            pbPlane.Focus();

            if (rbNormal.Checked == true)
            {

                SnakeTimer.Interval = 100;
            }
            SpeedDisplay();
        }

        private void rbHard_CheckedChanged(object sender, EventArgs e)
        {
            pbPlane.Focus();

            if (rbHard.Checked == true)
            {

                SnakeTimer.Interval = 50;
            }
            SpeedDisplay();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            pbPlane.Focus();
            AdaptableTimer();

            BigGreen.ResetGame(5,13,3); // reset BigGreen to beginning
            GreenTheSecond.ResetGame(23,15,9);
            btnStart.Enabled = true; //enable game to start
            btnPause.Text = "Pause"; //set pause
            btnReset.Enabled = false; //disable pause before started
            btnPause.Enabled = false; //disable pause before start
            SnakeTimer.Stop();
            Apple.ResetFood();
            gbMode.Enabled = true;
            pbPlane.Invalidate(); // redraw the pb
            btnColorFood.Enabled = true;
            btnColS1.Enabled = true;
            btnColS2.Enabled = true;
            SpeedDisplay();
        }
    }
}
