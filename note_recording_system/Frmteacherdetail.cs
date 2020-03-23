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
    public partial class Frmteacherdetail : Form
    {
        public Frmteacherdetail()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3VB3SSC;Initial Catalog=DBNOTKAYIT;Integrated Security=True");
        private void Frmteacherdetail_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBNOTKAYITDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dBNOTKAYITDataSet.TBLDERS);
            situation();


        }
        void situation()
        {
            int count = dataGridView1.RowCount - 2;
            int failures = 0, passes = 0;
            for(int i=0;i<=count;i++)
            {
                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "False")
                {
                    failures++;
                }
                else
                    passes++;
            }
            lblpass.Text = passes.ToString();
            lblfail.Text = failures.ToString();
        }

        private void btnogrekle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into tblders (ogrno,ograd,ogrsoyad) values (@p1,@p2,@p3)", connection);
            command.Parameters.AddWithValue("@p1", mskno.Text);
            command.Parameters.AddWithValue("@p2", txtad.Text);
            command.Parameters.AddWithValue("@p3", txtsoyad.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully");
            this.tBLDERSTableAdapter.Fill(this.dBNOTKAYITDataSet.TBLDERS);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a =dataGridView1.SelectedCells[0].RowIndex;
            txts1.Text = dataGridView1.Rows[a].Cells[4].Value.ToString();
            txts2.Text = dataGridView1.Rows[a].Cells[5].Value.ToString();
            txts3.Text = dataGridView1.Rows[a].Cells[6].Value.ToString();
            mskno.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[a].Cells[3].Value.ToString();

        }

        private void btnnotguncelle_Click(object sender, EventArgs e)
        {
            double average, e1, e2, e3;
            string situation;
            e1 = Convert.ToDouble(txts1.Text);
            e2 = Convert.ToDouble(txts2.Text);
            e3 = Convert.ToDouble(txts3.Text);
            
            average = (e1 + e2 + e3) / 3;
            lblave.Text = average.ToString();
            if (average >= 50)
            {
                situation = "True";


            }
            else
                situation = "False";
            connection.Open();
            SqlCommand command = new SqlCommand("update tblders set ogrs1 = @p1,ogrs2=@p2,ogrs3=@p3,ortalama = @p4,durum = @p5 where ogrno =@p6", connection);
            command.Parameters.AddWithValue("@p1", txts1.Text);
            command.Parameters.AddWithValue("@p2", txts2.Text);
            command.Parameters.AddWithValue("@p3", txts3.Text);
            command.Parameters.AddWithValue("@p4", decimal.Parse(lblave.Text));
            command.Parameters.AddWithValue("@p5", situation);
            command.Parameters.AddWithValue("@p6", mskno.Text);

            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Successfully");
            this.tBLDERSTableAdapter.Fill(this.dBNOTKAYITDataSet.TBLDERS);
            



        }

    }
}
