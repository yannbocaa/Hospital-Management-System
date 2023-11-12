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

namespace Health_Care_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnNewPatientRecord_Click(object sender, EventArgs e)
        {
            lblIndicator1.ForeColor = System.Drawing.Color.Red;
            lblIndicator2.ForeColor = System.Drawing.Color.Black;
            lblIndicator3.ForeColor = System.Drawing.Color.Black;
            lblIndicator4.ForeColor = System.Drawing.Color.Black;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            lblIndicator2.ForeColor = System.Drawing.Color.Red;
            lblIndicator1.ForeColor = System.Drawing.Color.Black;
            lblIndicator3.ForeColor = System.Drawing.Color.Black;
            lblIndicator4.ForeColor = System.Drawing.Color.Black;
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        
        }

        private void btnPatientHistory_Click(object sender, EventArgs e)
        {
            lblIndicator3.ForeColor = System.Drawing.Color.Red;
            lblIndicator1.ForeColor = System.Drawing.Color.Black;
            lblIndicator2.ForeColor = System.Drawing.Color.Black;
            lblIndicator4.ForeColor = System.Drawing.Color.Black;
            
            panel3.Visible= true;
            panel2.Visible= false;
            panel1 .Visible = false;

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=LAPTOP-7VV0IVTQ;Initial Catalog=hospital;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "select * from AddPatient inner join AddDiagnosis on AddPatient.Patient_ID = AddDiagnosis.patientID";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridViewFullHistory.DataSource = dataSet.Tables[0];
        }

        private void btnHospitalInfo_Click(object sender, EventArgs e)
        {
            lblIndicator4.ForeColor = System.Drawing.Color.Red;
            lblIndicator1.ForeColor = System.Drawing.Color.Black;
            lblIndicator2.ForeColor = System.Drawing.Color.Black;
            lblIndicator3.ForeColor = System.Drawing.Color.Black;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }
    

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {

            try
            {
                String name = txtboxName.Text;
                String address = txtBoxAddress.Text;
                Int64 contact = Convert.ToInt64(txtBoxContactNum.Text);
                int age = Convert.ToInt32(txtBoxAge.Text);
                String gender = comboBoxGender.Text;
                String bloodGroup = txtBoxBloodGroup.Text;
                String anyDisease = txtBoxAnyDisease.Text;
                int patientID = Convert.ToInt32(txtBoxPatientID.Text);

                SqlConnection connection = new SqlConnection();
                // connection.ConnectionString = "data source = LAPTOP-7VV0IVTQ\\SQLEXPRESS; database hospital; integrated security = True";
                connection.ConnectionString = "Data Source=LAPTOP-7VV0IVTQ;Initial Catalog=hospital;Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO AddPatient VALUES ('" + name + "','" + address + "'," + contact + "," + age + ",'" + gender + "','" + bloodGroup + "','" + anyDisease + "'," + patientID + ")";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            MessageBox.Show("Data is saved!");

            txtboxName.Clear();
            txtBoxAddress.Clear();
            txtBoxContactNum.Clear();
            txtBoxAge.Clear();
            comboBoxGender.ResetText();
            txtBoxBloodGroup.Clear();
            txtBoxAnyDisease.Clear();
            txtBoxPatientID.Clear();

        }

        private void btnGoBackToLogin_Click(object sender, EventArgs e)
        {
            Form1 initialForm = new Form1(); // Create an instance of Form1
            initialForm.Show(); // Show the initial form
            this.Close(); // Close the current form
        }

        private void txtbPatientIdDiagnosis_TextChanged(object sender, EventArgs e)
        {
            if (txtbPatientIdDiagnosis.Text != "") 
            {
                int patientID = Convert.ToInt32(txtbPatientIdDiagnosis.Text);

                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=LAPTOP-7VV0IVTQ;Initial Catalog=hospital;Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "select * from AddPatient where Patient_ID = " + patientID + "";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridViewDiagnosis.DataSource = dataSet.Tables[0]; 
            }

            
        }

        private void btnSaveDiagnosis_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(txtbPatientIdDiagnosis.Text);
                String symptom = txtBoxSymptoms.Text;
                String diagnosis = txtBoxDiagnosis.Text;
                String medicines = txtBoxMedicines.Text;
                String ward_requirement = comboBoxRequiredWard.Text;
                String ward_type = comboBoxTypeWard.Text;

                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = "Data Source=LAPTOP-7VV0IVTQ;Initial Catalog=hospital;Integrated Security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "insert into AddDiagnosis values (" + pid + ",'" + symptom + "','" + diagnosis + "','" + medicines + "','" + ward_requirement + "','" + ward_type + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
            MessageBox.Show("Diagnosis Saved!");

            txtbPatientIdDiagnosis.Clear();
            txtBoxSymptoms.Clear();
            txtBoxDiagnosis.Clear();
            txtBoxMedicines.Clear();
            comboBoxRequiredWard.ResetText();
            comboBoxTypeWard.ResetText();

                        
        }
    }
}
