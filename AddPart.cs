using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using Microsoft.SqlServer.Server;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;

namespace PartChecker
{
    public partial class AddPart : MaterialForm
    {
        Connection con = new Connection();
        public AddPart()
        {
            InitializeComponent();
        }

        private void AddPartButton_Click(object sender, EventArgs e)
        {
            //Make sure input fields are not blank

            //You should check for invalid characters, that could lead to SQL injection,
            //but, whos gonna do that. :P
            if (IDNumberInput.Text != "" && PartNumberInput.Text != "" && EtaInput.Text != "")
            {
                try
                {
                    con.Open();
                    string addPart = "INSERT INTO parts(id, partnumber, eta, status) VALUES('" + IDNumberInput.Text + "','" + PartNumberInput.Text + "','" + EtaInput.Text + "','" + StatusCombo.SelectedItem.ToString() + "')";
                    con.ExecuteNonQuery(addPart);
                    con.Close();
                    Program.partInventory.parts.Add(new Part(IDNumberInput.Text, PartNumberInput.Text, EtaInput.Text, StatusCombo.SelectedItem.ToString()));
                    Program.partInventory.UpdateDataInPartList();
                    
                    PartNumberInput.Text = "";

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add part! \nError: " + ex, "Oops", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            } 
            else
            {
                MessageBox.Show("Please fill in all fields to add a part.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
