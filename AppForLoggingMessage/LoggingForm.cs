using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
//using Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;

namespace AppForLoggingMessage
{
    public partial class LoggingForm : Form
    {
        public string uniqueName;
        public LoggingForm()
        {
            InitializeComponent();
        }

        private void addNewConnectionString(string name, string conString)
        {
            ExeConfigurationFileMap oConfigFile = new ExeConfigurationFileMap();
            oConfigFile.ExeConfigFilename = Application.StartupPath + "\\AppForLoggingMessage.exe.config";
            Configuration oConfiguration = ConfigurationManager.OpenMappedExeConfiguration(oConfigFile, ConfigurationUserLevel.None);
            ConnectionStringSettings oConnectionSettings = new ConnectionStringSettings(name, conString);
            oConfiguration.ConnectionStrings.ConnectionStrings.Add(oConnectionSettings);
            oConfiguration.Save(ConfigurationSaveMode.Full);
            MessageBox.Show(string.Format("Connection {0} is added", oConnectionSettings.Name));
        }

        private void LoggingForm_Load(object sender, EventArgs e)
        {
            foreach (System.Configuration.ConnectionStringSettings css in System.Configuration.ConfigurationManager.ConnectionStrings)
            {
                string connectionString = css.ConnectionString;
                comboBoxConfingName.Items.Add(connectionString);

                if (css.Name == "LocalSqlServer")
                {
                    comboBoxConfingName.Items.Remove(connectionString);
                }

                if(!comboBoxConfingName.Items.Contains(""))
                {
                    comboBoxConfingName.Items.Insert(0, "");
                    comboBoxConfingName.SelectedIndex = 0;
                }   
            }
        }

        private bool buildConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = textBoxServerName.Text;
            builder.InitialCatalog = textBoxInitialCatalog.Text;

            if (string.IsNullOrEmpty(comboBoxAuthentication.Text))
            {
                return false;
            }
            if (comboBoxAuthentication.Text == "SQL Server")
            {
                builder.IntegratedSecurity = false;
                builder.UserID = textBoxLogin.Text;
                builder.Password = textBoxPassword.Text;
            }
            else
            {
                builder.IntegratedSecurity = true;
            }

            textBoxConnectionString.Text = builder.ToString();

            if (!verifyConnection())
            {
                return false;
            }                         
            return true;
        }

        private bool verifyConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(textBoxConnectionString.Text))
                {
                    conn.Open();
                    conn.Close();
                }
                return true;              
            }
            catch
            {
                return false;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if(!(string.IsNullOrEmpty(comboBoxConfingName.Text)) && (!(string.IsNullOrEmpty(textBoxServerName.Text)) || !(string.IsNullOrEmpty(comboBoxAuthentication.Text)) || !(string.IsNullOrEmpty(comboBoxAuthentication.Text)) || !(string.IsNullOrEmpty(textBoxInitialCatalog.Text)) || !(string.IsNullOrEmpty(textBoxLogin.Text)) || !(string.IsNullOrEmpty(textBoxPassword.Text))))
            {
                MessageBox.Show("Cannot continue!");
                return;
            }
            if (!(string.IsNullOrEmpty(comboBoxConfingName.Text)))
            {
                foreach (System.Configuration.ConnectionStringSettings css in System.Configuration.ConfigurationManager.ConnectionStrings)
                {
                    if (css.ConnectionString == comboBoxConfingName.Text)
                        uniqueName = css.Name;
                }

                textBoxConnectionString.Text = comboBoxConfingName.Text;
            }
            else
            {
                uniqueName = textBoxServerName.Text + textBoxLogin.Text;

                if (!buildConnectionString())
                {
                    MessageBox.Show("Cannot build connection string!");
                    return;
                }

                if (checkBoxRemember.Checked)
                {
                    addNewConnectionString(uniqueName, textBoxConnectionString.Text);
                }
            }

            createUserFile();
            checkSpeStoredProcedureExistence();
            checkSpiStoredProcedureExistence();

            this.Hide();
            MainForm MainF = new MainForm(textBoxConnectionString.Text, uniqueName);
            MainF.Show();
        }

        private void textBoxServerName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxServerName.Text))
                errorProvider1.SetError(textBoxServerName, "Cannot be empty!");
        }

        private void comboBoxAuthentication_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxAuthentication.SelectedText))
                errorProvider1.SetError(comboBoxAuthentication, "Cannot be empty!");
        }

        private void createUserFile()
        {
            StreamWriter log;

            if (!File.Exists(string.Format("{0}.txt", uniqueName)))
            {
                log = new StreamWriter(string.Format("{0}.txt", uniqueName));
                log.Close();
            }
        }

        public DataSet checkSpeStoredProcedureExistence()
        {
            string connString;

            if (!(string.IsNullOrEmpty(comboBoxConfingName.Text)))
            {
                connString = comboBoxConfingName.Text;
            }
            else
            {
                connString = textBoxConnectionString.Text;
            }

            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM sysobjects WHERE type='P' and name='{0}'", "spe__search_logging_message");
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                executeSpeStoredProcedure(connString);
            }                

            return ds;
        }

        private void executeSpeStoredProcedure(string sqlConnectionString)
        {                       
            FileInfo file = new FileInfo("spe__search_logging_message.sql");
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            SqlCommand command = new SqlCommand(script, conn);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public DataSet checkSpiStoredProcedureExistence()
        {
            string connString;

            if (!(string.IsNullOrEmpty(comboBoxConfingName.Text)))
            {
                connString = comboBoxConfingName.Text;
            }
            else
            {
                connString = textBoxConnectionString.Text;
            }

            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT * FROM sysobjects WHERE type='P' and name='{0}'", "spi__treeview_nodes");
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count == 0)
            {
                executeSpiStoredProcedureSpe(connString);
            }

            return ds;
        }

        private void executeSpiStoredProcedureSpe(string sqlConnectionString)
        {
            FileInfo file = new FileInfo("spi__treeview_nodes.sql");
            string script = file.OpenText().ReadToEnd();
            SqlConnection conn = new SqlConnection(sqlConnectionString);
            SqlCommand command = new SqlCommand(script, conn);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        private void comboBoxConfingName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Check = comboBoxConfingName.SelectedItem.ToString();

            if (!String.IsNullOrEmpty(Check))
            {
                textBoxServerName.Enabled = false;
                comboBoxAuthentication.Enabled = false;
                textBoxInitialCatalog.Enabled = false;
                textBoxLogin.Enabled = false;
                textBoxPassword.Enabled = false;
                checkBoxRemember.Enabled = false;
            }
            else
            {
                textBoxServerName.Enabled = true;
                comboBoxAuthentication.Enabled = true;
                textBoxInitialCatalog.Enabled = true;
                textBoxLogin.Enabled = true;
                textBoxPassword.Enabled = true;
                checkBoxRemember.Enabled = true;
            }                
        }

        private void textBoxServerName_TextChanged(object sender, EventArgs e)
        {
            string Check = textBoxServerName.Text;

            if (!String.IsNullOrEmpty(Check))
            {
                comboBoxConfingName.Enabled = false;
            }
            else
            {
                comboBoxConfingName.Enabled = true;
            }
        }

        private void comboBoxAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Check = comboBoxAuthentication.SelectedItem.ToString();

            if (!String.IsNullOrEmpty(Check))
            {
                comboBoxConfingName.Enabled = false;
            }
            else
            {
                comboBoxConfingName.Enabled = true;
            }
        }

        private void textBoxInitialCatalog_TextChanged(object sender, EventArgs e)
        {
            string Check = textBoxInitialCatalog.Text;

            if (!String.IsNullOrEmpty(Check))
            {
                comboBoxConfingName.Enabled = false;
            }
            else
            {
                comboBoxConfingName.Enabled = true;
            }
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            string Check = textBoxLogin.Text;

            if (!String.IsNullOrEmpty(Check))
            {
                comboBoxConfingName.Enabled = false;
            }
            else
            {
                comboBoxConfingName.Enabled = true;
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            string Check = textBoxPassword.Text;

            if (!String.IsNullOrEmpty(Check))
            {
                comboBoxConfingName.Enabled = false;
            }
            else
            {
                comboBoxConfingName.Enabled = true;
            }
        }
    }
}

