using System;

namespace AppForLoggingMessage
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tableTabPage = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.treeViewTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewParameters = new System.Windows.Forms.DataGridView();
            this.treeView = new System.Windows.Forms.TreeView();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxTransId = new System.Windows.Forms.TextBox();
            this.comboBoxChannelCode = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeIdentification = new System.Windows.Forms.ComboBox();
            this.textBoxMachineName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMachineName = new System.Windows.Forms.Label();
            this.labelTypeIdentification = new System.Windows.Forms.Label();
            this.labelChannelCode = new System.Windows.Forms.Label();
            this.labelTransId = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.maskedTextBoxDateTo = new System.Windows.Forms.MaskedTextBox();
            this.labelDateTo = new System.Windows.Forms.Label();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.maskedTextBoxDateFrom = new System.Windows.Forms.MaskedTextBox();
            this.labelSpid = new System.Windows.Forms.Label();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.textBoxSpid = new System.Windows.Forms.TextBox();
            this.labelContent = new System.Windows.Forms.Label();
            this.checkBoxRememberSearch = new System.Windows.Forms.CheckBox();
            this.contextMenuStripCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripOpenInSqlStudio = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openInMSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callInMSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxDateFrom = new System.Windows.Forms.CheckBox();
            this.checkBoxDateTo = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tableTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.treeViewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStripCopy.SuspendLayout();
            this.contextMenuStripOpenInSqlStudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tableTabPage);
            this.tabControl.Controls.Add(this.treeViewTabPage);
            this.tabControl.Location = new System.Drawing.Point(3, 128);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(862, 417);
            this.tabControl.TabIndex = 0;
            // 
            // tableTabPage
            // 
            this.tableTabPage.Controls.Add(this.dataGridView);
            this.tableTabPage.Location = new System.Drawing.Point(4, 22);
            this.tableTabPage.Name = "tableTabPage";
            this.tableTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tableTabPage.Size = new System.Drawing.Size(854, 391);
            this.tableTabPage.TabIndex = 0;
            this.tableTabPage.Text = "Table";
            this.tableTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(854, 391);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_MouseClick);
            // 
            // treeViewTabPage
            // 
            this.treeViewTabPage.Controls.Add(this.splitContainer1);
            this.treeViewTabPage.Location = new System.Drawing.Point(4, 22);
            this.treeViewTabPage.Name = "treeViewTabPage";
            this.treeViewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.treeViewTabPage.Size = new System.Drawing.Size(854, 391);
            this.treeViewTabPage.TabIndex = 1;
            this.treeViewTabPage.Text = "TreeView";
            this.treeViewTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewParameters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView);
            this.splitContainer1.Size = new System.Drawing.Size(851, 391);
            this.splitContainer1.SplitterDistance = 283;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridViewParameters
            // 
            this.dataGridViewParameters.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewParameters.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewParameters.Name = "dataGridViewParameters";
            this.dataGridViewParameters.Size = new System.Drawing.Size(283, 391);
            this.dataGridViewParameters.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(3, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(558, 391);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(12, 4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(108, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxTransId
            // 
            this.textBoxTransId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTransId.Location = new System.Drawing.Point(3, 3);
            this.textBoxTransId.Name = "textBoxTransId";
            this.textBoxTransId.Size = new System.Drawing.Size(271, 20);
            this.textBoxTransId.TabIndex = 1;
            this.textBoxTransId.TextChanged += new System.EventHandler(this.textBoxTransId_TextChanged_1);
            // 
            // comboBoxChannelCode
            // 
            this.comboBoxChannelCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChannelCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannelCode.FormattingEnabled = true;
            this.comboBoxChannelCode.Location = new System.Drawing.Point(3, 25);
            this.comboBoxChannelCode.Name = "comboBoxChannelCode";
            this.comboBoxChannelCode.Size = new System.Drawing.Size(271, 21);
            this.comboBoxChannelCode.TabIndex = 2;
            // 
            // comboBoxTypeIdentification
            // 
            this.comboBoxTypeIdentification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTypeIdentification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeIdentification.FormattingEnabled = true;
            this.comboBoxTypeIdentification.Location = new System.Drawing.Point(3, 47);
            this.comboBoxTypeIdentification.Name = "comboBoxTypeIdentification";
            this.comboBoxTypeIdentification.Size = new System.Drawing.Size(271, 21);
            this.comboBoxTypeIdentification.TabIndex = 3;
            // 
            // textBoxMachineName
            // 
            this.textBoxMachineName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMachineName.Location = new System.Drawing.Point(3, 69);
            this.textBoxMachineName.Name = "textBoxMachineName";
            this.textBoxMachineName.Size = new System.Drawing.Size(271, 20);
            this.textBoxMachineName.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.labelMachineName, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelTypeIdentification, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTransId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMachineName, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxChannelCode, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTypeIdentification, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelChannelCode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTransId, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(396, 89);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // labelMachineName
            // 
            this.labelMachineName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMachineName.AutoSize = true;
            this.labelMachineName.Location = new System.Drawing.Point(280, 66);
            this.labelMachineName.Name = "labelMachineName";
            this.labelMachineName.Size = new System.Drawing.Size(113, 23);
            this.labelMachineName.TabIndex = 9;
            this.labelMachineName.Text = "Machine Name";
            // 
            // labelTypeIdentification
            // 
            this.labelTypeIdentification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTypeIdentification.AutoSize = true;
            this.labelTypeIdentification.Location = new System.Drawing.Point(280, 44);
            this.labelTypeIdentification.Name = "labelTypeIdentification";
            this.labelTypeIdentification.Size = new System.Drawing.Size(113, 22);
            this.labelTypeIdentification.TabIndex = 8;
            this.labelTypeIdentification.Text = "Type Identification";
            // 
            // labelChannelCode
            // 
            this.labelChannelCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChannelCode.AutoSize = true;
            this.labelChannelCode.Location = new System.Drawing.Point(280, 22);
            this.labelChannelCode.Name = "labelChannelCode";
            this.labelChannelCode.Size = new System.Drawing.Size(113, 22);
            this.labelChannelCode.TabIndex = 7;
            this.labelChannelCode.Text = "Channel Code";
            // 
            // labelTransId
            // 
            this.labelTransId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTransId.AutoSize = true;
            this.labelTransId.Location = new System.Drawing.Point(280, 0);
            this.labelTransId.Name = "labelTransId";
            this.labelTransId.Size = new System.Drawing.Size(113, 22);
            this.labelTransId.TabIndex = 6;
            this.labelTransId.Text = "Trans ID";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Controls.Add(this.maskedTextBoxDateTo, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelDateTo, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelDateFrom, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.maskedTextBoxDateFrom, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelSpid, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxContent, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxSpid, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelContent, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(457, 33);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(396, 89);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // maskedTextBoxDateTo
            // 
            this.maskedTextBoxDateTo.Enabled = false;
            this.maskedTextBoxDateTo.Location = new System.Drawing.Point(3, 69);
            this.maskedTextBoxDateTo.Mask = "0000-00-00 00:00:00.000";
            this.maskedTextBoxDateTo.Name = "maskedTextBoxDateTo";
            this.maskedTextBoxDateTo.Size = new System.Drawing.Size(271, 20);
            this.maskedTextBoxDateTo.TabIndex = 8;
            // 
            // labelDateTo
            // 
            this.labelDateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDateTo.AutoSize = true;
            this.labelDateTo.Location = new System.Drawing.Point(280, 66);
            this.labelDateTo.Name = "labelDateTo";
            this.labelDateTo.Size = new System.Drawing.Size(113, 23);
            this.labelDateTo.TabIndex = 7;
            this.labelDateTo.Text = "Date To";
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Location = new System.Drawing.Point(280, 44);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(113, 22);
            this.labelDateFrom.TabIndex = 6;
            this.labelDateFrom.Text = "Date From";
            // 
            // maskedTextBoxDateFrom
            // 
            this.maskedTextBoxDateFrom.Enabled = false;
            this.maskedTextBoxDateFrom.Location = new System.Drawing.Point(3, 47);
            this.maskedTextBoxDateFrom.Mask = "0000-00-00 00:00:00.000";
            this.maskedTextBoxDateFrom.Name = "maskedTextBoxDateFrom";
            this.maskedTextBoxDateFrom.Size = new System.Drawing.Size(271, 20);
            this.maskedTextBoxDateFrom.TabIndex = 1;
            // 
            // labelSpid
            // 
            this.labelSpid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpid.AutoSize = true;
            this.labelSpid.Location = new System.Drawing.Point(280, 22);
            this.labelSpid.Name = "labelSpid";
            this.labelSpid.Size = new System.Drawing.Size(113, 22);
            this.labelSpid.TabIndex = 5;
            this.labelSpid.Text = "SPID";
            // 
            // textBoxContent
            // 
            this.textBoxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxContent.Location = new System.Drawing.Point(3, 3);
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(271, 20);
            this.textBoxContent.TabIndex = 5;
            // 
            // textBoxSpid
            // 
            this.textBoxSpid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSpid.Location = new System.Drawing.Point(3, 25);
            this.textBoxSpid.Name = "textBoxSpid";
            this.textBoxSpid.Size = new System.Drawing.Size(271, 20);
            this.textBoxSpid.TabIndex = 6;
            this.textBoxSpid.TextChanged += new System.EventHandler(this.textBoxSpid_TextChanged);
            // 
            // labelContent
            // 
            this.labelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(280, 0);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(113, 22);
            this.labelContent.TabIndex = 4;
            this.labelContent.Text = "Content";
            // 
            // checkBoxRememberSearch
            // 
            this.checkBoxRememberSearch.AutoSize = true;
            this.checkBoxRememberSearch.Location = new System.Drawing.Point(126, 8);
            this.checkBoxRememberSearch.Name = "checkBoxRememberSearch";
            this.checkBoxRememberSearch.Size = new System.Drawing.Size(114, 17);
            this.checkBoxRememberSearch.TabIndex = 8;
            this.checkBoxRememberSearch.Text = "Remember Search";
            this.checkBoxRememberSearch.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripCopy
            // 
            this.contextMenuStripCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStripCopy.Name = "contextMenuStripCopy";
            this.contextMenuStripCopy.Size = new System.Drawing.Size(103, 26);
            this.contextMenuStripCopy.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem1.Text = "Copy";
            // 
            // contextMenuStripOpenInSqlStudio
            // 
            this.contextMenuStripOpenInSqlStudio.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openInMSQLToolStripMenuItem,
            this.callInMSQLToolStripMenuItem});
            this.contextMenuStripOpenInSqlStudio.Name = "contextMenuStripOpenInSqlStudio";
            this.contextMenuStripOpenInSqlStudio.Size = new System.Drawing.Size(184, 48);
            // 
            // openInMSQLToolStripMenuItem
            // 
            this.openInMSQLToolStripMenuItem.Name = "openInMSQLToolStripMenuItem";
            this.openInMSQLToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openInMSQLToolStripMenuItem.Text = "Open script in MSQL";
            this.openInMSQLToolStripMenuItem.Click += new System.EventHandler(this.openInMSQLToolStripMenuItem_Click);
            // 
            // callInMSQLToolStripMenuItem
            // 
            this.callInMSQLToolStripMenuItem.Name = "callInMSQLToolStripMenuItem";
            this.callInMSQLToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.callInMSQLToolStripMenuItem.Text = "Call in MSQL";
            this.callInMSQLToolStripMenuItem.Click += new System.EventHandler(this.callInMSQLToolStripMenuItem_Click);
            // 
            // checkBoxDateFrom
            // 
            this.checkBoxDateFrom.AutoSize = true;
            this.checkBoxDateFrom.Location = new System.Drawing.Point(439, 83);
            this.checkBoxDateFrom.Name = "checkBoxDateFrom";
            this.checkBoxDateFrom.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDateFrom.TabIndex = 9;
            this.checkBoxDateFrom.UseVisualStyleBackColor = true;
            this.checkBoxDateFrom.CheckedChanged += new System.EventHandler(this.checkBoxDateFrom_CheckedChanged);
            // 
            // checkBoxDateTo
            // 
            this.checkBoxDateTo.AutoSize = true;
            this.checkBoxDateTo.Location = new System.Drawing.Point(439, 105);
            this.checkBoxDateTo.Name = "checkBoxDateTo";
            this.checkBoxDateTo.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDateTo.TabIndex = 10;
            this.checkBoxDateTo.UseVisualStyleBackColor = true;
            this.checkBoxDateTo.CheckedChanged += new System.EventHandler(this.checkBoxDateTo_CheckedChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(865, 545);
            this.Controls.Add(this.checkBoxDateTo);
            this.Controls.Add(this.checkBoxDateFrom);
            this.Controls.Add(this.checkBoxRememberSearch);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tableTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.treeViewTabPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewParameters)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.contextMenuStripCopy.ResumeLayout(false);
            this.contextMenuStripOpenInSqlStudio.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBoxTransId_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tableTabPage;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabPage treeViewTabPage;
        private System.Windows.Forms.CheckBox checkBoxRememberSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelDateTo;
        private System.Windows.Forms.Label labelDateFrom;
        private System.Windows.Forms.Label labelSpid;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.TextBox textBoxSpid;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelMachineName;
        private System.Windows.Forms.Label labelTypeIdentification;
        private System.Windows.Forms.TextBox textBoxTransId;
        private System.Windows.Forms.TextBox textBoxMachineName;
        private System.Windows.Forms.ComboBox comboBoxChannelCode;
        private System.Windows.Forms.ComboBox comboBoxTypeIdentification;
        private System.Windows.Forms.Label labelTransId;
        private System.Windows.Forms.Label labelChannelCode;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.DataGridView dataGridViewParameters;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOpenInSqlStudio;
        private System.Windows.Forms.ToolStripMenuItem openInMSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callInMSQLToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDateFrom;
        private System.Windows.Forms.CheckBox checkBoxDateFrom;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDateTo;
        private System.Windows.Forms.CheckBox checkBoxDateTo;
    }
}