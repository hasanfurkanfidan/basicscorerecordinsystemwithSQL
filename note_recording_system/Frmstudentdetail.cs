using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace note_recording_system
{
    public partial class Frmstudentdetail : Form
    {
        public Frmstudentdetail()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3VB3SSC;Initial Catalog=DBNOTKAYIT;Integrated Security=True");
        public string number;
        private void Frmstudentdetail_Load(object sender, EventArgs e)
        {
            lblno.Text = number;
            connection.Open();
            SqlCommand command = new SqlCommand("select * from tblders where ogrno = @p1", connection);
            command.Parameters.AddWithValue("@p1", lblno.Text);
            SqlDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                lblad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lbls1.Text = dr[4].ToString();
                lbls2.Text = dr[5].ToString();
                lbls3.Text = dr[6].ToString();
                lblave.Text = dr[7].ToString();
                lbldur.Text = dr[8].ToString();


            }

        }
    }
}
