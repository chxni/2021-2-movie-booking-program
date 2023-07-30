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
    public partial class booking_check : Form
    {
        public booking_check()
        {
            InitializeComponent();
        }

        string[] spstring;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("전화번호 뒷자리를 입력해주세요.", "확인", MessageBoxButtons.OK);
            }
            else
            {
                StreamReader reader = new StreamReader("info.txt");
                string sampleString = null;

                listView1.Items.Clear();
                while (!reader.EndOfStream)
                {
                    sampleString = reader.ReadLine();
                    if (sampleString == null)
                    {
                        break;
                    }

                    string[] spstring = sampleString.Split('/');
                    if (spstring[0] == textBox1.Text)
                    {
                        for (int i = 0; i < spstring.Length; i++)
                        {
                            int j = i + 1;
                            if (j != spstring.Length)
                            {
                                spstring[i] = spstring[j];
                            }
                        }
                        ListViewItem lvi = new ListViewItem(spstring);
                        listView1.Items.Add(lvi);
                    }
                }
                reader.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult ans = 0;
            if (listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("선택된 항목이 없습니다.");
            }
            else
            {
                ans = MessageBox.Show("예매 취소하시겠습니까?", "취소 확인", MessageBoxButtons.OKCancel);
                if (ans == DialogResult.OK)
                {
                    while (listView1.SelectedItems.Count > 0)
                        listView1.Items.Remove(listView1.SelectedItems[0]);
                }
            }
        }
    }
}
