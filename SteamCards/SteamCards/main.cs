using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SteamCards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;       
        }




        //窗口移动
        Point MouseOff; //记录鼠标移动位置
        bool LeftMouse; //判定是否为左键

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        if(e.Button ==MouseButtons .Left )
            {
                MouseOff = new Point(-e.X, -e.Y);
                LeftMouse = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (LeftMouse)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(MouseOff.X,MouseOff .Y);//移动后的位置
                Location = mouseSet;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (LeftMouse)
            {
                LeftMouse = false;//释放鼠标后标注为false;
            }
        }

        private void title_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", "http://steamcommunity.com/id/kamakoto");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", "https://www.steamcardexchange.net/index.php?showcase-filter-recadded");
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1 .Text ==("请输入起始等级"))
                textBox1 .Text="";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
                textBox1.Text = "请输入起始等级";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == ("请输入目标等级"))
                textBox2 .Text="";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
                textBox2.Text = "请输入目标等级";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a = 0, b = 0, c = 0;
                int summary = 0;
                int Lv1 = int.Parse(textBox1.Text);
                int Lv2 = int.Parse(textBox2.Text);
                int LvSummary = Lv2 - Lv1;
                label1.Text = "升级所需级数：" + LvSummary;
                for (; Lv1 < Lv2; Lv1++)
                {
                    a = Lv1 % 100 / 10;
                    b = Lv1 % 1000 / 100;
                    c = Lv1 % 10000 / 1000;
                    summary +=(a * 1) + (b * 10) + (c * 100) + 1;
                }
                label2.Text = "预计卡牌套数：" + summary;
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}
