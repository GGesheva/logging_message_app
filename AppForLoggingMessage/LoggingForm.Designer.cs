namespace AppForLoggingMessage
{
    partial class LoggingForm
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
            this.labelConfigName = new System.Windows.Forms.Label();
            this.comboBoxConfingName = new System.Windows.Forms.ComboBox();
            this.labelServerName = new System.Windows.Forms.Label();
            this.labelAuthentication = new System.Windows.Forms.Label();
            this.labelInitialCatalog = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.comboBoxAuthentication = new System.Windows.Forms.ComboBox();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.textBoxInitialCatalog = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxConnectionString = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelConfigName
            // 
            this.labelConfigName.AutoSize = true;
            this.labelConfigName.Location = new System.Drawing.Point(12, 18);
            this.labelConfigName.Name = "labelConfigName";
            this.labelConfigName.Size = new System.Drawing.Size(74, 13);
            this.labelConfigName.TabIndex = 0;
            this.labelConfigName.Text = "Confing Name";
            // 
            // comboBoxConfingName
            // 
            this.comboBoxConfingName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxConfingName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConfingName.FormattingEnabled = true;
            this.comboBoxConfingName.Location = new System.Drawing.Point(95, 15);
            this.comboBoxConfingName.Name = "comboBoxConfingName";
            this.comboBoxConfingName.Size = new System.Drawing.Size(373, 21);
            this.comboBoxConfingName.TabIndex = 1;
            this.comboBoxConfingName.SelectedIndexChanged += new System.EventHandler(this.comboBoxConfingName_SelectedIndexChanged);
            // 
            // labelServerName
            // 
            this.labelServerName.AutoSize = true;
            this.labelServerName.Location = new System.Drawing.Point(12, 52);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(69, 13);
            this.labelServerName.TabIndex = 2;
            this.labelServerName.Text = "Server Name";
            // 
            // labelAuthentication
            // 
            this.labelAuthentication.AutoSize = true;
            this.labelAuthentication.Location = new System.Drawing.Point(12, 85);
            this.labelAuthentication.Name = "labelAuthentication";
            this.labelAuthentication.Size = new System.Drawing.Size(75, 13);
            this.labelAuthentication.TabIndex = 3;
            this.labelAuthentication.Text = "Authentication";
            // 
            // labelInitialCatalog
            // 
            this.labelInitialCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelInitialCatalog.AutoSize = true;
            this.labelInitialCatalog.Location = new System.Drawing.Point(12, 118);
            this.labelInitialCatalog.Name = "labelInitialCatalog";
            this.labelInitialCatalog.Size = new System.Drawing.Size(67, 13);
            this.labelInitialCatalog.TabIndex = 4;
            this.labelInitialCatalog.Text = "InitialCatalog";
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(12, 151);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(33, 13);
            this.labelLogin.TabIndex = 5;
            this.labelLogin.Text = "Login";
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(12, 184);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password";
            // 
            // comboBoxAuthentication
            // 
            this.comboBoxAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAuthentication.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBoxAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAuthentication.FormattingEnabled = true;
            this.comboBoxAuthentication.Items.AddRange(new object[] {
            "",
            "SQL Server",
            "Windows"});
            this.comboBoxAuthentication.Location = new System.Drawing.Point(95, 82);
            this.comboBoxAuthentication.Name = "comboBoxAuthentication";
            this.comboBoxAuthentication.Size = new System.Drawing.Size(373, 21);
            this.comboBoxAuthentication.TabIndex = 3;
            this.comboBoxAuthentication.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuthentication_SelectedIndexChanged);
            this.comboBoxAuthentication.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxAuthentication_Validating);
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxServerName.Location = new System.Drawing.Point(95, 49);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(373, 20);
            this.textBoxServerName.TabIndex = 2;
            this.textBoxServerName.TextChanged += new System.EventHandler(this.textBoxServerName_TextChanged);
            this.textBoxServerName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxServerName_Validating);
            // 
            // textBoxInitialCatalog
            // 
            this.textBoxInitialCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInitialCatalog.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxInitialCatalog.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxInitialCatalog.Location = new System.Drawing.Point(95, 116);
            this.textBoxInitialCatalog.Name = "textBoxInitialCatalog";
            this.textBoxInitialCatalog.Size = new System.Drawing.Size(373, 20);
            this.textBoxInitialCatalog.TabIndex = 4;
            this.textBoxInitialCatalog.TextChanged += new System.EventHandler(this.textBoxInitialCatalog_TextChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxPassword.Location = new System.Drawing.Point(95, 181);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(269, 20);
            this.textBoxPassword.TabIndex = 6;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.textBoxLogin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxLogin.Location = new System.Drawing.Point(95, 149);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(269, 20);
            this.textBoxLogin.TabIndex = 5;
            this.textBoxLogin.TextChanged += new System.EventHandler(this.textBoxLogin_TextChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Location = new System.Drawing.Point(381, 148);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(87, 20);
            this.buttonConnect.TabIndex = 12;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxConnectionString
            // 
            this.textBoxConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConnectionString.Location = new System.Drawing.Point(95, 181);
            this.textBoxConnectionString.Multiline = true;
            this.textBoxConnectionString.Name = "textBoxConnectionString";
            this.textBoxConnectionString.Size = new System.Drawing.Size(269, 20);
            this.textBoxConnectionString.TabIndex = 13;
            this.textBoxConnectionString.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // checkBoxRemember
            // 
            this.checkBoxRemember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRemember.AutoSize = true;
            this.checkBoxRemember.Location = new System.Drawing.Point(381, 182);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new System.Drawing.Size(77, 17);
            this.checkBoxRemember.TabIndex = 14;
            this.checkBoxRemember.Text = "Remember";
            this.checkBoxRemember.UseVisualStyleBackColor = true;
            // 
            // LoggingForm
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 220);
            this.Controls.Add(this.checkBoxRemember);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxInitialCatalog);
            this.Controls.Add(this.textBoxServerName);
            this.Controls.Add(this.comboBoxAuthentication);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelInitialCatalog);
            this.Controls.Add(this.labelAuthentication);
            this.Controls.Add(this.labelServerName);
            this.Controls.Add(this.comboBoxConfingName);
            this.Controls.Add(this.labelConfigName);
            this.Controls.Add(this.textBoxConnectionString);
            this.Name = "LoggingForm";
            this.Text = "Logging";
            this.Load += new System.EventHandler(this.LoggingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelConfigName;
        private System.Windows.Forms.ComboBox comboBoxConfingName;
        private System.Windows.Forms.Label labelServerName;
        private System.Windows.Forms.Label labelAuthentication;
        private System.Windows.Forms.Label labelInitialCatalog;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.ComboBox comboBoxAuthentication;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.TextBox textBoxInitialCatalog;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxConnectionString;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBoxRemember;
    }
}

