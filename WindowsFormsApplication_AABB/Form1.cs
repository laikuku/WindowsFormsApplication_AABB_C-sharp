using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication_AABB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "開始";
            button2.Text = "比對";
            button3.Text = "顯示答案";
            label2.Text = "A:   B:";
            label4.Text = "註解:先按開始，產生數字後，在欄位中輸入數字再按比對。";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Random crandom=new Random();
            int[] AABBarray=new int[4];
            for (int i = 0; i < 3; i++)
            {
                AABBarray[i] = crandom.Next(1, 10) - 1;
            }

            label1.Text = AABBarray[0].ToString() + AABBarray[1].ToString() + AABBarray[2].ToString() + AABBarray[3].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == label1.Text)
            {
                label2.Text = "猜對囉~";
            }
            else
            {
                //這裡是分解猜的數字
                int anInteger;
                anInteger = Convert.ToInt32(textBox1.Text);
                //anInteger = int.Parse(textBox1.Text);
                String str = anInteger.ToString("0000");
                int[] key_array=new int[4];
                
                //這裡是分解答案
                int ans;
                ans = Convert.ToInt32(label1.Text);
                //anInteger = int.Parse(textBox1.Text);
                String ans_str = ans.ToString("0000");
                int[] ans_array = new int[4];


                //這裡將內容轉成INT並分割丟到array中
                for (int i = 0; i < textBox1.TextLength; i++)
                {
                    //MessageBox.Show(str.Substring(i,1));
                    key_array[i] = Int32.Parse(str.Substring(i, 1));
                    ans_array[i] = Int32.Parse(ans_str.Substring(i, 1));
                }

                int Aa = 0;
                int Bb = 0;
                int[]A_array = {0,0,0,0};
                //比較A
                for (int i = 0; i < textBox1.TextLength; i++)
                {
                    if (key_array[i] == ans_array[i]) //比較A
                    {
                        //MessageBox.Show("has"+key_array[i]);
                        A_array[i] = 1;
                        //MessageBox.Show("A" + i);
                        Aa++;
                    }
                }
                //比較B
                for (int i = 0; i < textBox1.TextLength; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((key_array[i] == ans_array[j]) && (A_array[j] < 1))
                        {
                            //MessageBox.Show("has" + key_array[i] + ans_array[j] + A_array[j] + j);
                            Bb++;
                        }
                    }


                }



                label2.Text = "A:" + Aa.ToString() + "B:" + Bb.ToString();
                label3.Text = label3.Text + textBox1.Text + "    " + label2.Text + "\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        
    }
}
