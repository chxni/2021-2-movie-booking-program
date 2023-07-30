using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace 윈프_과제_홀수반_정찬희
{
    public partial class time_seat_select : Form
    {
        public time_seat_select()
        {
            InitializeComponent();
        }
        
        public static string movie, time, theater, seat, pNum;
        public static int adult, child, totalNum;
        private string strTemp;

        private void SelectSeat(string s, bool b)
        {
            if (b)
            {
                seat += s;
                seat += " ";
            }
            else
            {
                strTemp = seat;
                int i = strTemp.IndexOf(s);
                seat = strTemp.Remove(i, s.Length+1);
            }
        }

        private void time_seat_select_Load(object sender, EventArgs e)
        {
            label8.Text = "<" + movie + ">" + " 예매하기";

            StreamReader reader = new StreamReader("time.txt");
            string sampleString = null;

            listView1.Items.Clear();
            while (!reader.EndOfStream)
            {
                sampleString = reader.ReadLine();
                if (sampleString == null)
                {
                    break;
                }

                string[] spstring = sampleString.Split('-', ',');

                
                if (spstring[0] == movie)
                {
                    for(int i = 1; i <= 2; i++)
                    {
                        int count = listView1.Items.Count;
                        string[] t = spstring[i].Split(' ');
                        ListViewItem time_theater = new ListViewItem(t);
                        listView1.Items.Add(time_theater);
                    }
                }
            }
            reader.Dispose();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            SelectSeat(check.Name, check.Checked);
        }

        private void UpDown1_ValueChanged(object sender, EventArgs e)
        {
            adult = (int)UpDown1.Value;
        }

        private void UpDown2_ValueChanged(object sender, EventArgs e)
        {
            child = (int)UpDown2.Value;
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = item.SubItems;
                time = subItem[0].Text;
                theater = subItem[1].Text;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            pNum = textBox3.Text;
        }

        public static implicit operator string(time_seat_select v)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult ans = 0;
            
            if (pNum == null || listView1.SelectedItems.Count <= 0)
            {
                if(pNum == null)
                    MessageBox.Show("전화번호 뒷자리를 입력해주세요.", "확인", MessageBoxButtons.OK);
                if(listView1.SelectedItems.Count <= 0)
                    MessageBox.Show("상영시간을 선택해주세요.", "확인", MessageBoxButtons.OK);
            }
            else
            {
                ans = MessageBox.Show("<" + movie + ">" + " " + time + " " + theater + ' ' + seat + "을(를) 예매 하시겠습니까?","예매 확인", MessageBoxButtons.OKCancel);
                if (ans == DialogResult.OK)
                {
                    StreamWriter sw = File.AppendText("info.txt");
                    sw.WriteLine(pNum + '/' + movie + '/' + time + '/' + theater + '/' + seat + '/' + "성인 " + adult + " " + "어린이 " + child);
                    sw.Close();
                    this.Close();
                }
            }
        }
    }
}
