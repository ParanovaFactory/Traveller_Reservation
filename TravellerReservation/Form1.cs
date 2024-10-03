using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravellerReservation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=predator;Initial Catalog=Db_TravellerReservation;Integrated Security=True;TrustServerCertificate=True");

        void list()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select voyageDeparture, voyageArrival from TblVoyages", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cmbVoyag.Items.Add(reader.GetString(0) + " to " + reader.GetString(1));
            }
            conn.Close();

            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Tbloperations", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TblPersons (porsonName, porsonSurname, porsonIdentityNo, porsonPhone, porsonMail, porsonGender) values(@p1,@p2,@p3,@p4,@p5,@p6)",conn);
            cmd.Parameters.AddWithValue("@p1", txtName.Text);
            cmd.Parameters.AddWithValue("@p2", txtSurname.Text);
            cmd.Parameters.AddWithValue("@p3", mskıdentity.Text);
            cmd.Parameters.AddWithValue("@p4", mskPhone.Text);
            cmd.Parameters.AddWithValue("@p5", txtMail.Text);
            cmd.Parameters.AddWithValue("@p6", cmbGender.SelectedIndex);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TblVoyages (voyageDeparture, voyageArrival, voyageDate, voyageHour, voyageDriver, ticketPreis) values(@p1,@p2,@p3,@p4,@p5,@p6)", conn);
            cmd.Parameters.AddWithValue("@p1", txtDeparture.Text);
            cmd.Parameters.AddWithValue("@p2", txtArrival.Text);
            cmd.Parameters.AddWithValue("@p3", mskDate.Text);
            cmd.Parameters.AddWithValue("@p4", mskHour.Text);
            cmd.Parameters.AddWithValue("@p5", txtDriver.Text);
            cmd.Parameters.AddWithValue("@p6", txtPrice.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TblDrivers (driverNameAndSurname, driverPhone, driverNo) values(@p1,@p2,@p3)", conn);
            cmd.Parameters.AddWithValue("@p1", txtNameAndSurname.Text);
            cmd.Parameters.AddWithValue("@p2", mskDriverPhone.Text);
            cmd.Parameters.AddWithValue("@p3", mskDriverNo.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into TblOperations (voyage, personIdentityNo, seatNo) values(@p1,@p2,@p3)", conn);
            cmd.Parameters.AddWithValue("@p1", cmbVoyag.SelectedIndex + 1);
            cmd.Parameters.AddWithValue("@p2", mskPersonIdentity.Text);
            cmd.Parameters.AddWithValue("@p3", txtSeat.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list();
        }

        private void cmbVoyag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is driver seat");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtSeat.Text = "9";
        }
    }
}
