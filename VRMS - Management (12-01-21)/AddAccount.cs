using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace VRMS___Management__12_01_21_
{
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
        }
        OdbcConnection con = new OdbcConnection("dsn=capstone");

        private void AddAccount_Load(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "OSAS")
            {
                try
                {
                    Random rn = new Random();
                    int temp;
                    label8.Text = "AD-" + rn.Next(6000, 10000).ToString();
                    con.Open();
                    OdbcCommand command = new OdbcCommand("SELECT count(admin_id) FROM accounts WHERE admin_id = '" + label8.Text + "' ", con);
                    int exist = Convert.ToInt32(command.ExecuteScalar());
                    con.Close();
                    if (exist == null)
                    {
                        temp = 1;
                    }
                    else
                    {
                        con.Open();
                        OdbcCommand cmd = new OdbcCommand();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "INSERT INTO accounts(admin_id,fullname,username,password,level,isApprove,Checker_FP)VALUES(?,?,?,?,?,?,?);";
                        cmd.Parameters.Add("@admin_id", OdbcType.VarChar).Value = label8.Text;
                        cmd.Parameters.Add("@fullname", OdbcType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@username", OdbcType.VarChar).Value = textBox2.Text;
                        cmd.Parameters.Add("@password", OdbcType.VarChar).Value = textBox3.Text;
                        cmd.Parameters.Add("@level", OdbcType.VarChar).Value = comboBox1.Text;
                        cmd.Parameters.Add("@isApprove", OdbcType.VarChar).Value = "YES";
                        cmd.Parameters.Add("@Checker_FP", OdbcType.Int).Value = 0;
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            String display = "Admin Id: " + label8.Text + "\nFullname" + textBox1.Text + "\nLevel: " + comboBox1.Text;
                            MessageBox.Show(display);
                        }
                        con.Close();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
            else
            {
                try
                {
                    Random rn = new Random();
                    int temp;
                    label8.Text = "SG-" + rn.Next(6000, 10000).ToString();
                    con.Open();
                    OdbcCommand command = new OdbcCommand("SELECT count(admin_id) FROM accounts WHERE admin_id = '" + label8.Text + "' ", con);
                    int exist = Convert.ToInt32(command.ExecuteScalar());
                    con.Close();
                    if (exist == null)
                    {
                        temp = 1;
                    }
                    else
                    {
                        con.Open();
                        OdbcCommand cmd = new OdbcCommand();
                        cmd = con.CreateCommand();
                        cmd.CommandText = "INSERT INTO accounts(admin_id,fullname,username,password,level,isApprove,Checker_FP)VALUES(?,?,?,?,?,?,?);";
                        cmd.Parameters.Add("@admin_id", OdbcType.VarChar).Value = label8.Text;
                        cmd.Parameters.Add("@fullname", OdbcType.VarChar).Value = textBox1.Text;
                        cmd.Parameters.Add("@username", OdbcType.VarChar).Value = textBox2.Text;
                        cmd.Parameters.Add("@password", OdbcType.VarChar).Value = textBox3.Text;
                        cmd.Parameters.Add("@level", OdbcType.VarChar).Value = comboBox1.Text;
                        cmd.Parameters.Add("@isApprove", OdbcType.VarChar).Value = "YES";
                        cmd.Parameters.Add("@Checker_FP", OdbcType.Int).Value = 0;
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            String display = "Admin Id: "+label8.Text+"\nFullname"+textBox1.Text+"\nLevel: "+comboBox1.Text;
                            MessageBox.Show(display);
                        }
                        con.Close();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    con.Close();
                }
            }
        }
    }
}
