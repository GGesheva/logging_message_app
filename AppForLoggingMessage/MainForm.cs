using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;

namespace AppForLoggingMessage
{
    public partial class MainForm : Form
    {
        private bool ForceClose = true;

        public string uniqueName;
        public string conString;
        public string proc_name;

        public TreeNode transNode = null;

        public Dictionary<string, TreeNode> lastNodes = new Dictionary<string, TreeNode>();
   
        public MainForm(string connectionString, string name)
        {
            conString = connectionString;
            uniqueName = name;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fillingComboBoxChannelCode();
            fillingComboBoxLoggingTypeIdentificaiton();
 
            maskedTextBoxDateFrom.Text = string.Empty;
            maskedTextBoxDateTo.Text = string.Empty;

            //maskedTextBoxDateFrom.Text = string.Format("{0:yyyy/MM/dd HH:mm:ss.fff}", DateTime.Now);
            //maskedTextBoxDateTo.Text = string.Format("{0:yyyy/MM/dd HH:mm:ss.fff}", DateTime.Now);

            if (File.Exists(string.Format("{0}.txt", uniqueName)))
            {
                string line = string.Empty;

                System.IO.StreamReader file = new System.IO.StreamReader(string.Format("{0}.txt", uniqueName));

                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("textBoxTransId= "))
                    {
                        line = line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1);
                        textBoxTransId.Text = line;
                    }

                    if (line.Contains("comboBoxChannelCode= "))
                    {
                        line = line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1);
                        comboBoxChannelCode.Text = line;
                    }

                    if (line.Contains("comboBoxTypeIdentification= "))
                    {
                        line = line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1);
                        comboBoxTypeIdentification.Text = line;
                    }

                    if (line.Contains("textBoxMachineName= "))
                    {
                        line = line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1);
                        textBoxMachineName.Text = line;
                    }

                    if (line.Contains("textBoxContent= "))
                    {
                        line = line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1);
                        textBoxContent.Text = line;
                    }

                    if (line.Contains("textBoxSpid= "))
                    {
                        line = line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1);
                        textBoxSpid.Text = line;
                    }

                    if (line.Contains("dateFrom= "))
                    {
                        line = line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1);
                        maskedTextBoxDateFrom.Text = line;
                        checkBoxDateFrom.Checked = true;
                        maskedTextBoxDateFrom.Enabled = true;
                    }

                    if (line.Contains("dateTo= "))
                    {
                        line = line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1);
                        maskedTextBoxDateTo.Text = line;
                        checkBoxDateTo.Checked = true;
                        maskedTextBoxDateTo.Enabled = true;
                    }
                }

                file.Close();

                StreamWriter strm = File.CreateText(string.Format("{0}.txt", uniqueName));
                strm.Flush();
                strm.Close();
            }
        }

        private void fillingComboBoxChannelCode()
        {
            comboBoxChannelCode.Items.Clear();
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DISTINCT logging_channel_code FROM logging_channel";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBoxChannelCode.Items.Add(dr["logging_channel_code"].ToString());
            }

            if (!comboBoxChannelCode.Items.Contains(""))
            {
                comboBoxChannelCode.Items.Insert(0, "");
                comboBoxChannelCode.SelectedIndex = 0;
            }

            con.Close();
        }

        private void fillingComboBoxLoggingTypeIdentificaiton()
        {
            comboBoxTypeIdentification.Items.Clear();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ref_logging_type";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBoxTypeIdentification.Items.Add(dr["logging_type_id"].ToString() + ".  " + dr["logging_type_desc"].ToString() + ".  " + dr["schema_owner"].ToString() + ".  " + dr["creation_dt"].ToString());
            }

            if (!comboBoxTypeIdentification.Items.Contains(""))
            {
                comboBoxTypeIdentification.Items.Insert(0, "");
                comboBoxTypeIdentification.SelectedIndex = 0;
            }

            con.Close();
        }

        private void textBoxSpid_TextChanged(object sender, EventArgs e) //spid restriction for everything different than numbers
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxSpid.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBoxSpid.Text = textBoxSpid.Text.Remove(textBoxSpid.Text.Length - 1);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            lastNodes.Clear();
            filter();
        }

        private void filter()
        {
            DataSet ds = new DataSet();
            String conStr = conString;
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand com = new SqlCommand("spe__search_logging_message", con);

            if (!string.IsNullOrEmpty(textBoxTransId.Text))
                com.Parameters.AddWithValue("@i_trans_id", textBoxTransId.Text);

            if (!string.IsNullOrEmpty(comboBoxChannelCode.Text))
                com.Parameters.AddWithValue("@i_logging_channel_code", comboBoxChannelCode.Text);

            if (!string.IsNullOrEmpty(comboBoxTypeIdentification.Text))
                com.Parameters.AddWithValue("@i_logging_type_identification", comboBoxTypeIdentification.Text[0]);

            if (!string.IsNullOrEmpty(textBoxMachineName.Text))
                com.Parameters.AddWithValue("@i_machine_name", textBoxMachineName.Text);

            if (!string.IsNullOrEmpty(textBoxContent.Text))
                com.Parameters.AddWithValue("@i_logging_content", textBoxContent.Text);

            if (!string.IsNullOrEmpty(textBoxSpid.Text))
                com.Parameters.AddWithValue("@i_spid", textBoxSpid.Text);

            if (!string.IsNullOrEmpty(maskedTextBoxDateFrom.Text) && checkBoxDateFrom.Checked)
                com.Parameters.AddWithValue("@i_date_from", maskedTextBoxDateFrom.Text);

            if (!string.IsNullOrEmpty(maskedTextBoxDateTo.Text) && checkBoxDateTo.Checked)
                com.Parameters.AddWithValue("@i_date_to", maskedTextBoxDateTo.Text);

            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);

            try
            {
                con.Open();
                da.Fill(ds);
              
                dataGridView.DataSource = ds.Tables[0];

                dataGridView.Columns["creation_dt"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss.fff";

                buildingTreeView(ds);          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }   
        }

        public void buildingTreeView(DataSet ds)
        {
            transNode = null;

            treeView.Nodes.Clear();

            TreeNode node = null;

            List<TreeNode> spareNodes;

            foreach (DataTable table in ds.Tables)
            {
                if (table == ds.Tables[0])
                {
                    continue;
                }

                spareNodes = new List<TreeNode>();

                foreach (DataRow dr in table.Rows)
                {
                    int rowToBePaintedInRed = Convert.ToInt32(dr["logging_type_identification"].ToString());

                    string parentTrans = dr["trans_id"].ToString();
                    string aLoggingIdParent = dr["logging_id_parent"].ToString();
                    string aLoggingId = dr["logging_id"].ToString();

                    TreeNode aTreeNode = new TreeNode(string.Format("{0}", dr["logging_content"].ToString()));

                    aTreeNode.Tag = aLoggingIdParent;
                    aTreeNode.Name = aLoggingId;

                    if (transNode == null || (transNode.Name != parentTrans && treeView.Nodes.Find(parentTrans, false).Length == 0))
                    {
                        transNode = new TreeNode(string.Format("Trans ID: {0}", parentTrans));
                        transNode.Name = parentTrans;
                        transNode.Tag = "0";
                        treeView.Nodes.Add(transNode);
                    }
                    else if (transNode.Name == parentTrans)
                    {

                    }
                    else
                    {
                        transNode = treeView.Nodes.Find(parentTrans, false)[0];
                    }

                    lastNodes.TryGetValue(parentTrans, out node);

                    node = aTreeNode;

                    var parentNodes = transNode.Nodes.Find(aLoggingIdParent, true);                  

                    if (node == null || string.IsNullOrEmpty(aLoggingIdParent))
                    {         
                        transNode.Nodes.Add(node);
                    }
                    else if (parentNodes.Length == 0)
                    {
                        spareNodes.Add(node);
                        continue;    
                    }
                    else
                    {
                        parentNodes[0].Nodes.Add(node);
                    }
                           
                    if(rowToBePaintedInRed == 0)
                    {
                        node.ForeColor = Color.CornflowerBlue;                   
                    }
                     
                    if (rowToBePaintedInRed == 9)
                    {
                        node.ForeColor = Color.Red;
                    }

                    lastNodes[parentTrans] = node;
                }


                while (spareNodes.Count > 0)
                {
                    List<TreeNode> spareSpareNodes = new List<TreeNode>();

                    foreach (TreeNode n in spareNodes)
                    { 
                        var parentNodes = transNode.Nodes.Find(n.Tag.ToString(), true);

                        if (parentNodes.Length == 0)
                        {
                            spareSpareNodes.Add(n);
                            continue;
                        }
                        else
                        {
                            parentNodes[0].Nodes.Add(n);
                        }
                    }
                    spareNodes = spareSpareNodes;
                }            
            }
        }

        public void writeRememberSearchFile()
        {
            if (checkBoxRememberSearch.Checked)
            {
                StreamWriter log;

                log = File.AppendText(string.Format("{0}.txt", uniqueName));

                if (!string.IsNullOrEmpty(textBoxTransId.Text))
                    log.WriteLine("textBoxTransId= " + textBoxTransId.Text);

                if (!string.IsNullOrEmpty(comboBoxChannelCode.Text))
                    log.WriteLine("\ncomboBoxChannelCode= " + comboBoxChannelCode.Text);

                if (!string.IsNullOrEmpty(comboBoxTypeIdentification.Text))
                    log.WriteLine("\ncomboBoxTypeIdentification= " + comboBoxTypeIdentification.Text);

                if (!string.IsNullOrEmpty(textBoxMachineName.Text))
                    log.WriteLine("\ntextBoxMachineName= " + textBoxMachineName.Text);

                if (!string.IsNullOrEmpty(textBoxContent.Text))
                    log.WriteLine("\ntextBoxContent= " + textBoxContent.Text);

                if (!string.IsNullOrEmpty(textBoxSpid.Text))
                    log.WriteLine("\ntextBoxSpid= " + textBoxSpid.Text);

                if (!string.IsNullOrEmpty(maskedTextBoxDateFrom.Text) && checkBoxDateFrom.Checked)
                    log.WriteLine("\ndateFrom= " + maskedTextBoxDateFrom.Text);

                if (!string.IsNullOrEmpty(maskedTextBoxDateTo.Text) && checkBoxDateTo.Checked)
                    log.WriteLine("\ndateTo= " + maskedTextBoxDateTo.Text);

                log.Close();
            }
        }

        public DataSet CreateCommand(string nameOfStoredProc)
        {
            SqlConnection conn = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("SELECT DISTINCT referenced_entity_name FROM sys.sql_expression_dependencies WHERE OBJECT_NAME(referencing_id) = '{0}' AND is_caller_dependent = 1", nameOfStoredProc);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            conn.Close();
            return ds;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ForceClose == true)
            {
                writeRememberSearchFile();
                Application.ExitThread();
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string patternParamName = @"(\w+ = '.*?')|(\w+ = \W*\w+)";
            Regex rgx1 = new Regex(patternParamName);
            string sentence = e.Node.Text;
            List<string> listName = new List<string>();

            foreach (Match match in rgx1.Matches(sentence))
            {
                listName.Add(match.ToString());
            }

            dataGridViewParameters.DataSource = listName.Select(x => new { Value = x }).ToList();
            dataGridViewParameters.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;         
        }

        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node_here = treeView.GetNodeAt(e.X, e.Y);
                treeView.SelectedNode = node_here;

                if (node_here == null)
                    return;

                contextMenuStripCopy.Show(treeView, new Point(e.X, e.Y));
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(treeView.SelectedNode.Text);
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {               
                int currentSelectedColumn = Convert.ToInt32(dataGridView.CurrentCell.ColumnIndex.ToString());       

                if (currentSelectedColumn == 2)
                {
                    proc_name = dataGridView.CurrentCell.Value.ToString();
                    contextMenuStripOpenInSqlStudio.Items[1].Visible = false;
                    contextMenuStripOpenInSqlStudio.Show(dataGridView, new Point(e.X, e.Y));

                }

                if (currentSelectedColumn == 5)
                {                  
                    proc_name = dataGridView.CurrentCell.Value.ToString();
                    int rowInd = Convert.ToInt32(dataGridView.CurrentCell.RowIndex.ToString());               
                    int logging_type_iden = Convert.ToInt32(dataGridView.Rows[rowInd].Cells["logging_type_identification"].Value.ToString());

                    if (logging_type_iden != 9)
                    {
                        string patternParamName = @"(?:Procedure )(\w+\.?\w+)(?:|:|<)";
                        Regex rgx1 = new Regex(patternParamName);
                        string sentence1 = proc_name;
                        proc_name = rgx1.Match(sentence1).Groups[1].ToString();
                        contextMenuStripOpenInSqlStudio.Items[1].Visible = true;
                        contextMenuStripOpenInSqlStudio.Show(dataGridView, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void openInMSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveProcToAFileSourse();
            Process openSQL = new Process();
            openSQL.StartInfo.FileName = "Ssms.exe";
            openSQL.StartInfo.Arguments = "procedureToBeLoaded.sql";
            openSQL.Start();
        }

        private void saveProcToAFileSourse()
        {
            StreamWriter log;

            if (!File.Exists("procedureToBeLoaded.sql"))
            {
                log = new StreamWriter("procedureToBeLoaded.sql");
            }
            else
            {
                log = new StreamWriter(File.Create("procedureToBeLoaded.sql"));
            }

            SqlConnection conn = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = string.Format("EXEC sp_helptext '{0}'", proc_name);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();

            try
            {
                da.Fill(ds);
            }
            catch
            {
                cmd.CommandText = string.Format("SELECT name FROM sys.procedures WHERE name LIKE '%{0}%' AND schema_name(schema_id) = CURRENT_USER;", proc_name);
                da.SelectCommand = cmd;
                DataSet dsForSearchProc = new DataSet();
                da.Fill(dsForSearchProc);

                string new_proc_name = "";

                foreach (DataRow dr in dsForSearchProc.Tables[0].Rows)
                {
                    new_proc_name = dr[0].ToString();
                }

                cmd.CommandText = string.Format("EXEC sp_helptext '{0}'", new_proc_name);
                da.SelectCommand = cmd;

                da.Fill(ds);
            }
            conn.Close();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                log.Write(dr[0]);
            }

            log.Close();
        }

        private void callInMSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentSelectedColumn = Convert.ToInt32(dataGridView.CurrentCell.ColumnIndex.ToString());

            if (currentSelectedColumn == 5)
            {
                saveProcToAFileCall();
                Process openSQL = new Process();
                openSQL.StartInfo.FileName = "Ssms.exe";
                openSQL.StartInfo.Arguments = "procedureToBeCalled.sql";
                openSQL.Start();
            }      
        }

        private void saveProcToAFileCall()
        {
            StreamWriter log;

            if (!File.Exists("procedureToBeCalled.sql"))
            {
                log = new StreamWriter("procedureToBeCalled.sql");
            }
            else
            {
                log = new StreamWriter(File.Create("procedureToBeCalled.sql"));
            }

            string content = dataGridView.CurrentCell.Value.ToString();
            string pattern = @"(\ (.*))";
            Regex rgx1 = new Regex(pattern);
            string sentence = content;
            content = rgx1.Match(sentence).ToString();

            log.WriteLine("EXECUTE" + content);
            log.Close();
        }

        private void textBoxTransId_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxTransId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBoxTransId.Text = textBoxTransId.Text.Remove(textBoxTransId.Text.Length - 1);
            }
        }

        private void checkBoxDateFrom_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDateFrom.Checked)
                maskedTextBoxDateFrom.Enabled = true;
            else
                maskedTextBoxDateFrom.Enabled = false;
        }

        private void checkBoxDateTo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDateTo.Checked)
                maskedTextBoxDateTo.Enabled = true;
            else
                maskedTextBoxDateTo.Enabled = false;
        }
    }
}