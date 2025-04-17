using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace LAMP

{
    public partial class Form1 : Form
    {
        private bool mouseDown; //Both are for Dragging option
        private Point lastLocation;
        public Form1()
        {
            InitializeComponent();
            sidePanel.Height = button1.Height; //SidePanel will slide accordingly
           
            this.FormBorderStyle = FormBorderStyle.None; //Needed for Resize borderless Form
            
        }
        const int WM_NCHITTEST = 0x0084; //Start of Resize The Borderless window code
        const int HTCLIENT = 1;
        const int HTCAPTION = 2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if (m.Result == (IntPtr)HTCLIENT)
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }
                    break;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x40000;
                return cp;
            }
        } //End of Resize The Borderless window code
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      



        private void button1_Click(object sender, EventArgs e) //Home Button
        {
            sidePanel.Height = button1.Height;
            sidePanel.Top = button1.Top;
           
        }

       
        private void button7_Click(object sender, EventArgs e) //Close Button
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e) //Minimize Button
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e) //Maximise Button
        {
            if (WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
               
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) //Drag Event evoke
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) //Drag
        {
            mouseDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) //Drag
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e) //With Pannel Drag
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e) //With Pannel Drag
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e) //With Pannel Drag
        {
            mouseDown = false;
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e) //Double Click Upper-Panel to Minimize-Maximize 
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button3.Height;
            sidePanel.Top = button3.Top;
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button4.Height;
            sidePanel.Top = button4.Top;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sidePanel.Height = button6.Height;
            sidePanel.Top = button6.Top;
           
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            LOGIN log = new LOGIN();
            this.Hide();
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
