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
    public partial class AddRequest : MaterialForm
    {
        Connection con = new Connection();
        public AddRequest()
        {
            InitializeComponent();
        }

        private void AddRequestButton_Click(object sender, EventArgs e)
        {
            if (ROIDInput.Text != "" && Description.Text != "" && PartNumberServiceInput.Text != "" && NotesTextbox.Text != "")
            {
                try
                {
                    con.Open();
                    string addRequest = "INSERT INTO requests(id, descript, note, partnumber) VALUES('" + ROIDInput.Text + "','" + Description.Text + "','" + NotesTextbox.Text + "','" + PartNumberServiceInput.Text + "')";
                    con.ExecuteNonQuery(addRequest);
                    con.Close();

                    Program.partInventory.UpdateDataInPartList();
                    //Program.partInventory.UpdateDataInRequestList();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add request! \nError: " + ex, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields to add a part.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
