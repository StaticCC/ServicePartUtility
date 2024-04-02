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
using Mysqlx.Crud;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Globalization;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Xml.Linq;
using AutoUpdaterDotNET;
using System.Diagnostics;
using System.Linq.Expressions;
using OpenQA.Selenium.DevTools.V120.Debugger;
using MaterialSkin;
namespace PartChecker
{

    public partial class PartInventory : MaterialForm
    {
        public List<Part> parts = new List<Part>();
        Connection con = new Connection();
        BackgroundWorker pwdUpdater;
        public PartInventory()
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/StaticCC/SPUSOURCE/main/update.xml");
            System.Windows.Forms.Timer updateLists = new System.Windows.Forms.Timer();
            updateLists.Interval = (30 * 1000); // 30 secs
            updateLists.Tick += new EventHandler(updateLists_Tick);
            updateLists.Start();
            InitializeComponent();
            UpdateDataInPartList();
            // UpdateDataInRequestList();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            colonialLabel.BackColor = Color.Transparent;
            PartsList.BackColor = Color.FromArgb(80, 80, 80);
            UpdateDetails();

            pwdUpdater = new BackgroundWorker();
            pwdUpdater.WorkerReportsProgress = true;
            pwdUpdater.DoWork += new DoWorkEventHandler(pwdUpdater_DoWork);
            pwdUpdater.RunWorkerCompleted +=
              new RunWorkerCompletedEventHandler(pwdUpdater_RunWorkerCompleted);
            pwdUpdater.ProgressChanged +=
              new ProgressChangedEventHandler(pwdUpdater_ProgressChanged);
            con.Open();
            string date = "";
            string query = "SELECT date,time FROM updatedtime";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    date = row["date"]
                      .ToString();
                    date = date.Substring(0, date.IndexOf(" "));
                    date += " " + row["time"]
                      .ToString();
                }
            }
            row.Close();
            LastUpdateDateTime.Text = "ETA's Last Updated: " + date;
            con.Close();
        }

        private void pwdUpdater_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            GetETAFromPWB(worker);
        }

        private void pwdUpdater_RunWorkerCompleted(object sender,
          RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Value = 0;
            // Handle completion or update UI if needed
            ProgressBar.Visible = false;
            con.Open();
            DateTime dateTime = DateTime.Now;
            string updateTime = "UPDATE updatedtime SET time = \"" +
              dateTime.ToString("hh:mm tt") + "\"";
            con.ExecuteNonQuery(updateTime);
            UpdateTime();
            UpdateROList();
            con.Close();
        }

        public void UpdateROList()
        {
            PartsList.Items.Clear();
            parts.Clear();
            con.Open();
            string query = "SELECT id, partnumber, eta, status FROM parts";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    string id = row["id"]
                      .ToString();
                    string partnum = row["partnumber"]
                      .ToString();
                    string eta = row["eta"]
                      .ToString();
                    string status = row["status"]
                      .ToString();
                    if (ROList.SelectedItems.Count > 0 &&
                      id == ROList.SelectedItems[0].Text)
                    {
                        ListViewItem part = new ListViewItem(partnum);
                        part.SubItems.Add(eta);
                        part.SubItems.Add(status);
                        // No ETA
                        // On Order
                        // Written
                        // Shipped
                        // On Back Order
                        // Received
                        // Cancelled
                        switch (status)
                        {
                            case "Written":
                                part.ForeColor = Color.LightYellow;
                                part.BackColor = Color.Black;
                                break;
                            case "On Order":
                                part.ForeColor = Color.LightSeaGreen;
                                break;
                            case "No ETA":
                                part.ForeColor = Color.Red;
                                part.BackColor = Color.Black;
                                break;
                            case "On Backorder":
                                part.ForeColor = Color.DarkRed;
                                break;
                            case "Shipped":
                                part.ForeColor = Color.Green;
                                break;
                            case "Received":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "Delivered":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "Cancelled":
                                part.ForeColor = Color.Red;
                                break;
                            default:
                                part.ForeColor = Color.Black;
                                break;
                        }
                        Part partAdd = new Part(id, partnum, eta, status);
                        parts.Add(partAdd);
                        PartsList.Items.Add(part);
                    }
                }
            }
        }

        public void UpdateTime()
        {
            con.Open();
            string date = "";
            string query = "SELECT date,time FROM updatedtime";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    date = row["date"]
                      .ToString();
                    date = date.Substring(0, date.IndexOf(" "));
                    date += " " + row["time"]
                      .ToString();
                }
            }
            row.Close();
            LastUpdateDateTime.Text = "ETA's Last Updated: " + date;
            con.Close();
        }

        private void pwdUpdater_ProgressChanged(object sender,
          ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        void updateLists_Tick(object sender, EventArgs e)
        {
            if (!pwdUpdater.IsBusy)
                UpdateROList();
            // UpdateDataInRequestList();
        }
        // Method: UpdateDataInPartList
        // Description: This method updates the data displayed in a ListView control
        // (ROList) by fetching information from a MySQL database table named "parts".
        //              It clears the existing items in the ListView, retrieves data
        //              from the database, and populates the ListView with the fetched
        //              data. Each row in the ListView corresponds to a record in the
        //              "parts" table, displaying the ID and status of each part.
        // Parameters: None
        // Returns: None
        // Steps:
        // 1. Clears all items in the ROList (ListView control).
        // 2. Clears the parts list.
        // 3. Opens a connection to the MySQL database.
        // 4. Constructs a SELECT query to retrieve ID and status columns from the
        // "parts" table.
        // 5. Executes the query and retrieves the result set as a MySqlDataReader
        // object.
        // 6. Checks if the result set has rows.
        // 7. Iterates through each row in the result set.
        // 8. Retrieves the ID and status values from the current row.
        // 9. Constructs a ListViewItem object with the ID and status, adding it to
        // the ROList.
        // 10. Closes the database connection.
        // Note: This method assumes a specific database schema and ListView
        // structure. It populates the ListView with data from the "parts" table.
        public void UpdateDataInPartList()
        {
            ROList.Items.Clear();
            parts.Clear();
            con.Open();
            string query = "SELECT id, partnumber, eta, status FROM parts";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    string id = row["id"]
                      .ToString();

                    string status = row["status"]
                      .ToString();

                    ListViewItem ro = new ListViewItem(id)
                    {
                        Name = id
                    };
                    ro.SubItems.Add(status);

                    // Check if an item with the same id already exists
                    if (!ROList.Items.ContainsKey(id))
                    {
                        // If it doesn't exist, add the new item to the ROList
                        ROList.Items.Add(ro);
                    }
                }
            }

            con.Close();
        }
        // Method: GetETAFromPWB
        // Description: This method retrieves Estimated Time of Arrival (ETA) data for
        // parts from PWB+ (a website) using Chrome WebDriver through Selenium
        // automation.
        //              It iterates over a list of parts, navigates through login
        //              pages, fetches shipment details, and updates the database with
        //              the ETA and status of each part.
        // Parameters:
        //    - worker: A BackgroundWorker object used to report progress to the GUI
        //    thread.
        // Returns: Void Method (None)
        // Steps:
        // 1. Clones the list of parts to avoid updating the main part data until
        // complete.
        // 2. Iterates through each part in the cloned list.
        // 3. Sets up a headless Chrome WebDriver with Selenium for automated
        // browsing.
        // 4. Navigates to the login page of autopartners.net and logs in with
        // provided credentials.
        // 5. Navigates to the purchase orders page on PWB+ for the current part.
        // 6. Waits for the controlNumber element to ensure the page is loaded.
        // 7. Checks if the shipment exists. If not, continues to the next part.
        // 8. Finds and clicks the XMS link to proceed to shipment tracking.
        // 9. Navigates to the shipment tracking URL.
        // 10. Retrieves the status of the shipment and handles different scenarios.
        // 11. Updates the database with the ETA and status of the part.
        // 12. Closes the WebDriver connection for the current part.
        // 13. Reports progress to the GUI thread using the provided BackgroundWorker.
        // 14. Closes and quits the current ChromeDriver connection and loops until
        // complete. Note: This method relies on specific HTML structure and may
        // require adjustments if the structure of the target websites changes.
        public void GetETAFromPWB(BackgroundWorker worker)
        {
            try
            {
                Debug.WriteLine("Running PWB automation");
                List<Part> partsClone = new List<Part>(); // Clone list to not update
                                                          // main part data until complete
                partsClone = parts;
                int count = 0;
                int total = partsClone.Count;
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();
                Debug.WriteLine(currentDirectory);
                string chromeDriverPath =
                  System.IO.Path.Combine(currentDirectory, @"ChromeDriver");
                Debug.WriteLine(chromeDriverPath);
                var options = new ChromeOptions();
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                // Hide commpand prompt window as progress will be reported via the GUI on
                // the WinForm
                service.HideCommandPromptWindow = true;
                options.AddArgument("--headless"); // Start Chrome headless to run in
                                                   // background
                service.DriverServiceExecutableName = "chromedriver.exe"; //Point to executable name for instances 
                                                                          //where the ChromeDriver install cant be found
                service.DriverServicePath = chromeDriverPath;
                //Working directory + executable
                foreach (Part partNumber in partsClone)
                {
                    using (IWebDriver driver = new ChromeDriver(service, options))
                    {
                        IWebElement statusElement = null;
                        // Create the web driver to automate part shipment lookup
                        WebDriverWait wait = new WebDriverWait(
                          driver,
                          TimeSpan.FromSeconds(15)); // Adjust the timeout as needed
                        WebDriverWait wait2 = new WebDriverWait(
                          driver, TimeSpan.FromSeconds(
                            5)); // Adjust the timeout as needed
                                 // Create Wait conditions to wait for page load.
                                 // This is required as page loading can sometimes
                                 // be instant, or, take upwards of 12-15 seconds.
                                 // This being dynamic, allows for quicker part
                                 // shipment data aquisition and faster load times

                        // Navigate to the login page
                        driver.Navigate().GoToUrl(
                          "https://www.autopartners.net/gmentsso/UI/Login?goto=https%3A%2F%2Fdealer.autopartners.net%3A443%2F");

                        // Find username and password fields and fill them with the
                        // credentials
                        var usernameField = driver.FindElement(By.Id("IDToken1"));
                        usernameField.SendKeys("USERNAME");

                        var passwordField = driver.FindElement(By.Id("IDToken2"));
                        passwordField.SendKeys("PASSWORD");

                        // Find and click the login button
                        var loginButton = driver.FindElement(By.Name("Login.Submit"));
                        loginButton.Click();

                        // Optional: Wait for the page to load after login
                        // You might need to adjust the wait time based on your network speed
                        // and website responsiveness Wait until the page is loaded after
                        // login

                        driver.Navigate().GoToUrl(
                          "https://pwbplus.autopartners.net/orders/view/purchase_orders?search=partNumber%3D" +
                          partNumber.PartNum + "%7Cperiod%3Ddays");
                        // Navigate to PWB+ to track PO's

                        System.Threading.Thread.Sleep(7000);

                        Debug.WriteLine("No records element check");
                        IWebElement noRecordsElement = null;
                        try
                        {
                            noRecordsElement = driver.FindElement(By.XPath(
                              "//h2[@class='my-6 text-center' and text()='No records found.']"));

                        }
                        catch
                        {

                        }
                        Debug.WriteLine("After try method executing");
                        if (noRecordsElement != null)
                        {

                            count++;
                            int progressPercentage = (int)(((double)count / total) * 100);
                            progressPercentage = Math.Max(
                              0, Math.Min(progressPercentage,
                                100)); // Clamp progress value to 0-100 range
                            worker.ReportProgress(progressPercentage);
                            con.Open();
                            string updatePart = "UPDATE parts SET eta = \"" + "Not Ordered" +
                              "\", status = \"" + "Not Ordered" +
                              "\" WHERE id = " + partNumber.Id +
                              " AND partnumber = " + partNumber.PartNum;
                            con.ExecuteNonQuery(updatePart);
                            driver.Close();
                            continue;
                        }
                        Debug.WriteLine("Finding col-ControlNumber");

                        // Example of waiting for an element to be clickable
                        IWebElement controlNumber = wait.Until((d) =>
                        {
                            try
                            { // Wait for the controlNumber element to proceed as the page
                              // will be loaded by then
                                var element = d.FindElement(By.ClassName("col-controlNumber"));
                                if (element.Displayed && element.Enabled) return element;
                                return null;
                            }
                            catch (NoSuchElementException)
                            {
                                return null;
                            }
                        });

                        System.Threading.Thread.Sleep(
                          4000); // Sleep just in case the page hasn't fully loaded.
                        IWebElement noShipmentFound = null;
                        try
                        {
                            // Check if the shipment does not exist.
                            noShipmentFound = driver.FindElement(
                              By.CssSelector("h2[style='font-weight: 600;']"));
                        }
                        catch (NoSuchElementException)
                        {
                            // Handle the case where the element is not found
                        }
                        if (noShipmentFound != null)
                        {
                            Debug.WriteLine("NO SHIPMENT FOUND");
                            continue;
                        } // Sleep just in case the shipment is loading
                        System.Threading.Thread.Sleep(4500);

                        Debug.WriteLine("Finding URL to shipment tracking");
                        IWebElement controlHrefElement =
                          controlNumber.FindElement(By.TagName("a"));
                        System.Threading.Thread.Sleep(2500);
                        driver.Navigate().GoToUrl(controlHrefElement.GetAttribute("href"));
                        Debug.WriteLine("Going to PO info!");
                        // Navigate to the shipment tracking URL
                        System.Threading.Thread.Sleep(5000); // Wait for page to load.
                        IWebElement statusColumn = null;
                        // Attempt to grab the status column from the automated web driver to
                        // retrieve the status of the current shipment

                        try
                        { // Pull the current status of the partnumber/shipment
                            statusColumn = driver.FindElement(By.ClassName("col-status"));
                        }
                        catch
                        {

                            Debug.WriteLine("No status found! Skipping.");
                            continue;
                        }
                        // If no ETA available most likely part is on Back Order or not
                        // ordered at all. Skip part
                        Debug.WriteLine("Setting status and No ETA");

                        string status = statusColumn.Text;
                        string shipment = "No ETA";
                        var shipmentNumber =
                          driver.FindElement(By.ClassName("col-shipmentNumber"));
                        // Attempt to find shipment number
                        if (shipmentNumber.Text != "-")
                        {
                            Debug.WriteLine("Going to PWB Shipments URL");

                            // Shipment number is not default value so therefore it must be a
                            // shipment number
                            driver.Navigate().GoToUrl(
                              "https://pwbplus.autopartners.net/orders/view/shipments?search=partNumber%3D" +
                              partNumber.PartNum);
                            System.Threading.Thread.Sleep(5000);
                            IWebElement pageLoadElement = null;
                            try
                            {
                                pageLoadElement =
                                  driver.FindElement(By.ClassName("col-facility"));
                            }
                            catch
                            {

                            }
                            if (pageLoadElement != null)
                            {
                                try
                                {
                                    IWebElement shipmentTracking = null;
                                    try
                                    { // attempt to grab the tracking number off of the shipment
                                      // by col-trackingNumbers
                                        Debug.WriteLine("Grab tracking number");

                                        shipmentTracking =
                                          driver.FindElement(By.ClassName("col-trackingNumbers"));

                                        IWebElement anchorElement =
                                          shipmentTracking.FindElement(By.TagName("a"));
                                        string href =
                                          anchorElement.GetAttribute("href"); // grab the actual URL
                                        if (href.Contains(
                                            "xms.mygmcca"))
                                        { // if a GM tracking website, continue
                                          // and grab ETA
                                            Debug.WriteLine("Navigated to GM XMS tracking");

                                            driver.Navigate().GoToUrl(href);
                                            // col container
                                            IWebElement colContainer = wait.Until((d) =>
                                            {
                                                try
                                                { // Grab time of shipment being shipped
                                                    var element = d.FindElement(By.ClassName("UTCTime"));
                                                    if (element.Displayed && element.Enabled) return element;
                                                    return null;
                                                }
                                                catch (NoSuchElementException)
                                                {
                                                    return null;
                                                }
                                            });
                                            System.Threading.Thread.Sleep(2000);
                                            IWebElement trElement = driver.FindElement(By.XPath("//tr"));
                                            statusElement = null;
                                            try
                                            {
                                                statusElement = trElement.FindElement(By.XPath("//td[contains(@style,'background-color:limegreen;')]"));
                                            }
                                            catch
                                            {
                                                Debug.WriteLine("Not Delievered");
                                            }

                                            if (statusElement == null)
                                            {
                                                try
                                                {
                                                    statusElement = trElement.FindElement(By.XPath("//td[contains(@style,'background-color:dodgerblue;')]"));
                                                }
                                                catch
                                                {
                                                    Debug.WriteLine("Not out for delievery");
                                                }
                                            }

                                            IList<IWebElement> elements = driver.FindElements(
                                              By.XPath("//*[not(self::script) and not(self::style)]"));

                                            // Extract and print text content of each element
                                            foreach (var element in elements)
                                            {
                                                string text = element.Text.Trim();
                                                System.Diagnostics.Debug.WriteLine("\n" + text + "\n");
                                                if (!string.IsNullOrEmpty(text))
                                                {
                                                    // Check if the text contains a date in the format
                                                    // MM/DD/YYYY
                                                    Match dateMatch =
                                                      Regex.Match(text, @"\b\d{1,2}\/\d{1,2}\/\d{4}\b");
                                                    if (dateMatch.Success)
                                                    {

                                                        shipment = dateMatch.Value;
                                                        // You can further process the found date here
                                                    }
                                                }
                                            }
                                        }
                                        else { }
                                    }
                                    catch
                                    {
                                        System.Threading.Thread.Sleep(5000);
                                        // Not found, just list facility col-facility
                                        var facility = driver.FindElement(By.ClassName("col-facility"));
                                        shipment = facility.Text;
                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(
                                      "One or more parts failed to grab Shipment Data!\nError: " +
                                      ex,
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    continue;
                                }
                            }

                            Debug.WriteLine("Done, executing SQL to update parts database");
                            if (statusElement != null)
                                status = statusElement.Text;
                            count++; // Add to counter of parts for the progress bar
                            int progressPercentage = (int)(((double)count / total) * 100);
                            progressPercentage = Math.Max(
                              0, Math.Min(progressPercentage,
                                100)); // Clamp progress value to 0-100 range
                            worker.ReportProgress(
                              progressPercentage); // Report progress to the GUI thread
                            con.Open(); // Open the SQL connection
                            string updatePart = "UPDATE parts SET eta = \"" + shipment +
                              "\", status = \"" + status +
                              "\" WHERE id = " + partNumber.Id +
                              " AND partnumber = " + partNumber.PartNum;
                            // Update the part data to have the new found shipment eta, status,
                            // and info.
                            con.ExecuteNonQuery(updatePart); // Execute the SQL statement
                            driver.Close(); // Close the ChromeDriver connection
                            driver.Quit();                 // Quit the current ChromeDriver instance


                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Else Statement Executed!");
                            IWebElement shipElement = null;
                            System.Threading.Thread.Sleep(2000);
                            try
                            {
                                shipElement =
                                  driver.FindElement(By.ClassName("col-shipmentDate"));
                            }
                            catch
                            {
                                shipment = "No Shipment Info (was this ordered)";
                            }

                            // Get the text inside the element
                            shipment = shipElement.Text;
                            try
                            {
                                statusElement = driver.FindElement(
                                  By.XPath("//span[contains(@class,'p-tag-success')"));
                                status = statusElement.Text;
                            }
                            catch
                            {
                                status = "No Status";
                            }

                            count++;
                            int progressPercentage = (int)(((double)count / total) * 100);
                            progressPercentage = Math.Max(
                              0, Math.Min(progressPercentage,
                                100)); // Clamp progress value to 0-100 range
                            worker.ReportProgress(progressPercentage);
                            con.Open();
                            string updatePart = "UPDATE parts SET eta = \"" + shipment +
                              "\", status = \"" + status +
                              "\" WHERE id = " + partNumber.Id +
                              " AND partnumber = " + partNumber.PartNum;
                            con.ExecuteNonQuery(updatePart);
                            driver.Close(); // Close the current browser window
                            driver.Quit();
                        }
                        driver.Quit();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!\n" + ex);
            }
        }

        private void AddPart_Click(object sender, EventArgs e)
        {
            // Open the Form to add parts into tracked Repair Order's
            AddPart addPartFrm = new AddPart();
            addPartFrm.ShowDialog();
        }

        private void AddRequest_Click(object sender, EventArgs e)
        {
            // Obsolete
            AddRequest addRequest = new AddRequest();
            addRequest.ShowDialog();
        }
        // Method: materialButton1_Click
        // Description: This method is an event handler for the click event of a
        // material button.
        //              It prompts the user with a warning message about the
        //              potentially long process. If the user chooses to continue, it
        //              initiates an asynchronous operation to update ETA data from
        //              PWB. It also updates the last updated time in the database and
        //              refreshes the GUI accordingly.
        // Parameters:
        //    - sender: The object that raised the event (materialButton1).
        //    - e: An EventArgs object containing event data.
        // Returns: None
        // Steps:
        // 1. Displays a warning message to the user indicating the potentially long
        // process and prompts for confirmation.
        // 2. If the user chooses to continue:
        //    a. Checks if the asynchronous operation to update ETA's is already in
        //    progress. If yes, returns to avoid duplicate updates. b. Initiates the
        //    asynchronous operation (pwdUpdater.RunWorkerAsync()) to update ETA data.
        //    c. Makes the progress bar visible.
        //    d. Opens a connection to the SQL database.
        //    e. Retrieves the current time and constructs an SQL query to update the
        //    last updated time. f. Executes the SQL query to update the last updated
        //    time in the database. g. Calls UpdateTime() method to update the GUI
        //    with the new time. h. Closes the SQL connection.
        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Check ETA
            DialogResult prompt = MessageBox.Show(
              "This is can be long process.\nMay take up to 20 minutes to complete on a long RO.\nDo you want to continue?",
              "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (prompt == DialogResult.Yes)
            {
                // If we are already updating ETA's, return as we don't want to update
                // again while updating.
                if (pwdUpdater.IsBusy) return;
                // Grab the PWB data from our part's list
                pwdUpdater.RunWorkerAsync();
                ProgressBar.Visible = true;
                con.Open(); // Open an SQL Connection to the database
                DateTime dateTime = DateTime.Now; // Grab the current time
                string updateTime = "UPDATE updatedtime SET time = \"" +
                  dateTime.ToString("hh:mm tt") + "\"";
                con.ExecuteNonQuery(updateTime); // Update the time we have updated the
                                                 // ETA's for Repair Orders
                UpdateTime(); // Update on the GUI
                con.Close(); // Close the SQL connection
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
              "Created by Cory Green © GNU Public 2024\n\nFrequently Asked Questions:\nNo ETA and No Status means order has not shipped.\n\nIf no ETA is provided, shipment source is given.\n006 - PA, usually 1-2 days\n075 - Pontiac Michigan, 6-7 days\n058 - Willow Run, MI, 7 days\n076 - Lansing, MI, 6-7 days",
              "FAQ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Method: ROList_SelectedIndexChanged
        // Description: This method is an event handler for the SelectedIndexChanged
        // event of the ROList ListView control.
        //              It clears the items in the PartsList ListView, clears the
        //              parts list, and retrieves data from the "parts" table in the
        //              MySQL database. It then populates the PartsList ListView with
        //              parts data based on the selected Repair Order (RO) in the
        //              ROList. Each row in the PartsList corresponds to a part in the
        //              selected RO, displaying part number, ETA, and status. It also
        //              assigns colors to the rows based on the status of the parts
        //              for better visualization.
        // Parameters:
        //    - sender: The object that raised the event (ROList ListView control).
        //    - e: An EventArgs object containing event data.
        // Returns: None
        // Steps:
        // 1. Clears all items in the PartsList ListView.
        // 2. Clears the parts list.
        // 3. Opens a connection to the MySQL database.
        // 4. Constructs a SELECT query to retrieve ID, partnumber, eta, and status
        // columns from the "parts" table.
        // 5. Executes the query and retrieves the result set as a MySqlDataReader
        // object.
        // 6. Checks if the result set has rows.
        // 7. Iterates through each row in the result set.
        // 8. Retrieves ID, part number, ETA, and status values from the current row.
        // 9. Checks if any item is selected in the ROList and if the ID matches the
        // ID of the selected item.
        // 10. Constructs a ListViewItem object with part number, ETA, and status, and
        // assigns colors based on the status.
        // 11. Adds the constructed ListViewItem to the PartsList ListView.
        // 12. Adds the retrieved part data to the parts list.
        // 13. Closes the database connection.
        // Note: This method assumes a specific database schema and ListView
        // structure. It populates the PartsList based on the selected RO in the
        // ROList.
        private void ROList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pwdUpdater.IsBusy) return;
            PartsList.Items.Clear();
            parts.Clear();
            con.Open();
            string query = "SELECT id, partnumber, eta, status FROM parts";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    string id = row["id"]
                      .ToString();
                    string partnum = row["partnumber"]
                      .ToString();
                    string eta = row["eta"]
                      .ToString();
                    string status = row["status"]
                      .ToString();
                    if (ROList.SelectedItems.Count > 0 &&
                      id == ROList.SelectedItems[0].Text)
                    {
                        ListViewItem part = new ListViewItem(partnum);
                        part.SubItems.Add(eta);
                        part.SubItems.Add(status);
                        // No ETA
                        // On Order
                        // Written
                        // Shipped
                        // On Back Order
                        // Received
                        // Cancelled
                        switch (status)
                        {
                            case "Written":
                                part.ForeColor = Color.LightYellow;
                                part.BackColor = Color.Black;
                                break;
                            case "On Order":
                                part.ForeColor = Color.LightSeaGreen;
                                break;
                            case "No ETA":
                                part.ForeColor = Color.Red;
                                part.BackColor = Color.Black;
                                break;
                            case "On Backorder":
                                part.ForeColor = Color.DarkRed;
                                break;
                            case "Shipped":
                                part.ForeColor = Color.Green;
                                break;
                            case "Received":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "Delivered":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "In Transit":
                                part.ForeColor = Color.LightBlue;
                                part.BackColor = Color.DarkBlue;
                                break;
                            case "Cancelled":
                                part.ForeColor = Color.Red;
                                break;
                            default:
                                part.ForeColor = Color.Black;
                                break;
                        }
                        Part partAdd = new Part(id, partnum, eta, status);
                        parts.Add(partAdd);
                        PartsList.Items.Add(part);
                    }
                }
            }
        }
        // Method: ROList_ItemActivate
        // Description: This method is an event handler for the ItemActivate event of
        // the ROList ListView control.
        //              It clears the items in the PartsList ListView, clears the
        //              parts list, and retrieves data from the "parts" table in the
        //              MySQL database. It then populates the PartsList ListView with
        //              parts data based on the activated item in the ROList. Each row
        //              in the PartsList corresponds to a part in the activated Repair
        //              Order (RO), displaying part number, ETA, and status. It also
        //              assigns colors to the rows based on the status of the parts
        //              for better visualization.
        // Parameters:
        //    - sender: The object that raised the event (ROList ListView control).
        //    - e: An EventArgs object containing event data.
        // Returns: None
        // Steps:
        // 1. Clears all items in the PartsList ListView.
        // 2. Clears the parts list.
        // 3. Opens a connection to the MySQL database.
        // 4. Constructs a SELECT query to retrieve ID, partnumber, eta, and status
        // columns from the "parts" table.
        // 5. Executes the query and retrieves the result set as a MySqlDataReader
        // object.
        // 6. Checks if the result set has rows.
        // 7. Iterates through each row in the result set.
        // 8. Retrieves ID, part number, ETA, and status values from the current row.
        // 9. Checks if any item is activated in the ROList and if the ID matches the
        // ID of the activated item.
        // 10. Constructs a ListViewItem object with part number, ETA, and status, and
        // assigns colors based on the status.
        // 11. Adds the constructed ListViewItem to the PartsList ListView.
        // 12. Adds the retrieved part data to the parts list.
        // 13. Closes the database connection.
        // Note: This method assumes a specific database schema and ListView
        // structure. It populates the PartsList based on the activated RO item in the
        // ROList.
        private void ROList_ItemActivate(object sender, EventArgs e)
        {
            if (pwdUpdater.IsBusy) return;
            PartsList.Items.Clear();
            parts.Clear();
            con.Open();
            string query = "SELECT id, partnumber, eta, status FROM parts";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    string id = row["id"]
                      .ToString();
                    string partnum = row["partnumber"]
                      .ToString();
                    string eta = row["eta"]
                      .ToString();
                    string status = row["status"]
                      .ToString();
                    if (ROList.SelectedItems.Count > 0 &&
                      id == ROList.SelectedItems[0].Text)
                    {
                        ListViewItem part = new ListViewItem(partnum);
                        part.SubItems.Add(eta);
                        part.SubItems.Add(status);
                        // No ETA
                        // On Order
                        // Written
                        // Shipped
                        // On Back Order
                        // Received
                        // Cancelled
                        switch (status)
                        {
                            case "Written":
                                part.ForeColor = Color.LightYellow;
                                part.BackColor = Color.Black;
                                break;
                            case "On Order":
                                part.ForeColor = Color.LightSeaGreen;
                                break;
                            case "No ETA":
                                part.ForeColor = Color.Red;
                                part.BackColor = Color.Black;
                                break;
                            case "On Backorder":
                                part.ForeColor = Color.DarkRed;
                                break;
                            case "Shipped":
                                part.ForeColor = Color.Green;
                                break;
                            case "Received":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "Delivered":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "In Transit":
                                part.ForeColor = Color.LightBlue;
                                part.BackColor = Color.DarkBlue;
                                break;
                            case "Cancelled":
                                part.ForeColor = Color.Red;
                                break;
                            default:
                                part.ForeColor = Color.Black;
                                break;
                        }
                        Part partAdd = new Part(id, partnum, eta, status);
                        parts.Add(partAdd);
                        PartsList.Items.Add(part);
                    }
                }
            }
        }

        private void PartInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            // Set the FileName property to the command you want to run
            psi.FileName = "cmd.exe";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.CreateNoWindow = true;
            // Set the Arguments property to the command arguments
            //Kill all instances of ChromeDriver utilities to not have ChromeDriver proccesses running after program close
            psi.Arguments = "/C /S taskkill /f /im chromedriver.exe"; // /C carries out the command and then terminates


            Process.Start(psi);
            psi.Arguments = "/C /S taskkill /f /im chrome.exe";
            Process.Start(psi);
            psi.Arguments = "/C /S taskkill /f /im chromium.exe";
            Process.Start(psi);
            psi.Arguments = "/C /S taskkill /f /im backgroundTaskHost.exe";
            Process.Start(psi);
        }

        private void ROList_MouseDown(object sender, MouseEventArgs e)
        {
            bool match = false;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (ListViewItem item in ROList.Items)
                {
                    if (item.Bounds.Contains(new System.Drawing.Point(e.X, e.Y)))
                    {
                        MenuItem[] mi = new MenuItem[] {
              new MenuItem("Delete"),
                new MenuItem("Move up"),
                new MenuItem("Move down")
            };
                        ROList.ContextMenu = new ContextMenu(mi);
                        match = true;
                        break;
                    }
                }
                if (match)
                {
                    ROList.ContextMenu.MenuItems[0].Click += (s, ea) =>
                    {
                        // Delete logic
                        if (ROList.SelectedItems.Count > 0)
                        {
                            foreach (ListViewItem item in ROList.SelectedItems)
                            {
                                con.Open();
                                string itemDeleteQuery = "DELETE FROM `parts` WHERE `id` = " + item.Text;
                                con.ExecuteNonQuery(itemDeleteQuery);
                                con.Close();

                                ROList.Items.Remove(item);
                            }

                        }
                    };

                    ROList.ContextMenu.MenuItems[1].Click += (s, ea) =>
                    {
                        foreach (ListViewItem lvi in ROList.SelectedItems)
                        {
                            if (lvi.Index > 0)
                            {
                                int index = lvi.Index - 1;
                                ROList.Items.RemoveAt(lvi.Index);
                                ROList.Items.Insert(index, lvi);
                            }
                        }
                    };

                    ROList.ContextMenu.MenuItems[2].Click += (s, ea) =>
                    {
                        foreach (ListViewItem lvi in ROList.SelectedItems)
                        {
                            if (lvi.Index > 0)
                            {
                                int index = lvi.Index + 1;
                                ROList.Items.RemoveAt(lvi.Index);
                                ROList.Items.Insert(index, lvi);
                            }
                        }
                    };

                    ROList.ContextMenu.Show(ROList, new System.Drawing.Point(e.X, e.Y));
                }
                else
                {
                    //Show listViews context menu
                }
            }
        }

        private void CheckETAAll_Click(object sender, EventArgs e)
        {

        }

        public void UpdateDetails()
        {
            
        }

        private void ROList_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (pwdUpdater.IsBusy) return;
            PartsList.Items.Clear();
            parts.Clear();
            con.Open();
            string query = "SELECT id, partnumber, eta, status FROM parts";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    string id = row["id"]
                      .ToString();
                    string partnum = row["partnumber"]
                      .ToString();
                    string eta = row["eta"]
                      .ToString();
                    string status = row["status"]
                      .ToString();
                    if (ROList.SelectedItems.Count > 0 &&
                      id == ROList.SelectedItems[0].Text)
                    {
                        ListViewItem part = new ListViewItem(partnum);
                        part.SubItems.Add(eta);
                        part.SubItems.Add(status);
                        // No ETA
                        // On Order
                        // Written
                        // Shipped
                        // On Back Order
                        // Received
                        // Cancelled
                        switch (status)
                        {
                            case "Written":
                                part.ForeColor = Color.LightYellow;
                                part.BackColor = Color.Black;
                                break;
                            case "On Order":
                                part.ForeColor = Color.LightSeaGreen;
                                break;
                            case "No ETA":
                                part.ForeColor = Color.Red;
                                part.BackColor = Color.Black;
                                break;
                            case "On Backorder":
                                part.ForeColor = Color.DarkRed;
                                break;
                            case "Shipped":
                                part.ForeColor = Color.Green;
                                break;
                            case "Received":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "Delivered":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "In Transit":
                                part.ForeColor = Color.LightBlue;
                                part.BackColor = Color.DarkBlue;
                                break;
                            case "Cancelled":
                                part.ForeColor = Color.Red;
                                break;
                            default:
                                part.ForeColor = Color.Black;
                                break;
                        }
                        Part partAdd = new Part(id, partnum, eta, status);
                        parts.Add(partAdd);
                        PartsList.Items.Add(part);
                    }
                }
            }
        }

        private void ROList_MouseDown_1(object sender, MouseEventArgs e)
        {
            bool match = false;

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (ListViewItem item in ROList.Items)
                {
                    if (item.Bounds.Contains(new System.Drawing.Point(e.X, e.Y)))
                    {
                        MenuItem[] mi = new MenuItem[] {
              new MenuItem("Delete"),
                new MenuItem("Move up"),
                new MenuItem("Move down")
            };
                        ROList.ContextMenu = new ContextMenu(mi);
                        match = true;
                        break;
                    }
                }
                if (match)
                {
                    ROList.ContextMenu.MenuItems[0].Click += (s, ea) =>
                    {
                        // Delete logic
                        if (ROList.SelectedItems.Count > 0)
                        {
                            foreach (ListViewItem item in ROList.SelectedItems)
                            {
                                con.Open();
                                string itemDeleteQuery = "DELETE FROM `parts` WHERE `id` = " + item.Text;
                                con.ExecuteNonQuery(itemDeleteQuery);
                                con.Close();

                                ROList.Items.Remove(item);
                            }

                        }
                    };

                    ROList.ContextMenu.MenuItems[1].Click += (s, ea) =>
                    {
                        foreach (ListViewItem lvi in ROList.SelectedItems)
                        {
                            if (lvi.Index > 0)
                            {
                                int index = lvi.Index - 1;
                                ROList.Items.RemoveAt(lvi.Index);
                                ROList.Items.Insert(index, lvi);
                            }
                        }
                    };

                    ROList.ContextMenu.MenuItems[2].Click += (s, ea) =>
                    {
                        foreach (ListViewItem lvi in ROList.SelectedItems)
                        {
                            if (lvi.Index > 0)
                            {
                                int index = lvi.Index + 1;
                                ROList.Items.RemoveAt(lvi.Index);
                                ROList.Items.Insert(index, lvi);
                            }
                        }
                    };

                    ROList.ContextMenu.Show(ROList, new System.Drawing.Point(e.X, e.Y));
                }
                else
                {
                    //Show listViews context menu
                }
            }
        }

        private void ROList_ItemActivate_1(object sender, EventArgs e)
        {
            if (pwdUpdater.IsBusy) return;
            PartsList.Items.Clear();
            parts.Clear();
            con.Open();
            string query = "SELECT id, partnumber, eta, status FROM parts";
            MySqlDataReader row;
            row = con.ExecuteReader(query);
            if (row.HasRows)
            {
                while (row.Read())
                {
                    string id = row["id"]
                      .ToString();
                    string partnum = row["partnumber"]
                      .ToString();
                    string eta = row["eta"]
                      .ToString();
                    string status = row["status"]
                      .ToString();
                    if (ROList.SelectedItems.Count > 0 &&
                      id == ROList.SelectedItems[0].Text)
                    {
                        ListViewItem part = new ListViewItem(partnum);
                        part.SubItems.Add(eta);
                        part.SubItems.Add(status);
                        // No ETA
                        // On Order
                        // Written
                        // Shipped
                        // On Back Order
                        // Received
                        // Cancelled
                        switch (status)
                        {
                            case "Written":
                                part.ForeColor = Color.LightYellow;
                                part.BackColor = Color.Black;
                                break;
                            case "On Order":
                                part.ForeColor = Color.LightSeaGreen;
                                break;
                            case "No ETA":
                                part.ForeColor = Color.Red;
                                part.BackColor = Color.Black;
                                break;
                            case "On Backorder":
                                part.ForeColor = Color.DarkRed;
                                break;
                            case "Shipped":
                                part.ForeColor = Color.Green;
                                break;
                            case "Received":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "Delivered":
                                part.ForeColor = Color.DarkGreen;
                                part.BackColor = Color.LightSeaGreen;
                                break;
                            case "In Transit":
                                part.ForeColor = Color.LightBlue;
                                part.BackColor = Color.DarkBlue;
                                break;
                            case "Cancelled":
                                part.ForeColor = Color.Red;
                                break;
                            default:
                                part.ForeColor = Color.Black;
                                break;
                        }
                        Part partAdd = new Part(id, partnum, eta, status);
                        parts.Add(partAdd);
                        PartsList.Items.Add(part);
                    }
                }
            }
        }
    }
}