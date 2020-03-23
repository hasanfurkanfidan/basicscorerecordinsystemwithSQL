using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace note_recording_system
{
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmstudentdetail frs = new Frmstudentdetail();
            frs.number = maskedTextBox1.Text;
            frs.Show();


        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text  =="1111")
            {
                Frmteacherdetail frt = new Frmteacherdetail();
                frt.Show();


            }
        }
    }
}
