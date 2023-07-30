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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            movie_select ms = new movie_select();
            ms.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            booking_check bc = new booking_check();
            bc.ShowDialog();
        }
    }
}
