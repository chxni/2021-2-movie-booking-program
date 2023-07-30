using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 윈프_과제_홀수반_정찬희
{
    public partial class movie_select : Form
    {
        public movie_select()
        {
            InitializeComponent();
        }

        time_seat_select select = new time_seat_select();
        private void button1_Click(object sender, EventArgs e)
        {
            time_seat_select.movie = "하울의 움직이는 성";
            select.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            time_seat_select.movie = "벼랑 위의 포뇨";
            select.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            time_seat_select.movie = "해리포터와 마법사의 돌";
            select.ShowDialog();
        }
    }
}
