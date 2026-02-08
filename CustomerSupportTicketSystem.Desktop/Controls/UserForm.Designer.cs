namespace CustomerSupportTicketSystem.Desktop.Controls
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private CustomerSupportTicketSystem.Desktop.UI.ModernPanel pnlForm;
        private System.Windows.Forms.Label lblUsername;
        private CustomerSupportTicketSystem.Desktop.UI.ModernTextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private CustomerSupportTicketSystem.Desktop.UI.ModernTextBox txtPassword;
        private System.Windows.Forms.Label lblFullName;
        private CustomerSupportTicketSystem.Desktop.UI.ModernTextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private CustomerSupportTicketSystem.Desktop.UI.ModernTextBox txtEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cboRole;
        private CustomerSupportTicketSystem.Desktop.UI.ModernButton btnSave;
        private CustomerSupportTicketSystem.Desktop.UI.ModernButton btnCancel;
        private CustomerSupportTicketSystem.Desktop.UI.ModernButton btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlForm = new CustomerSupportTicketSystem.Desktop.UI.ModernPanel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new CustomerSupportTicketSystem.Desktop.UI.ModernTextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new CustomerSupportTicketSystem.Desktop.UI.ModernTextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new CustomerSupportTicketSystem.Desktop.UI.ModernTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new CustomerSupportTicketSystem.Desktop.UI.ModernTextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.btnSave = new CustomerSupportTicketSystem.Desktop.UI.ModernButton();
            this.btnCancel = new CustomerSupportTicketSystem.Desktop.UI.ModernButton();
            this.btnBack = new CustomerSupportTicketSystem.Desktop.UI.ModernButton();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            //
            // btnBack
            //
            this.btnBack.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnBack.BorderRadius = 5;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(500, 20); // Top right or left? Title is at 20,20. Let's put it at Top Right.
            // Wait, Title is at 20,20. 
            // Let's put Back button at Top Right or next to title?
            // AdminDashboard has Back button? No, it's a dashboard.
            // TicketDetails has Back button.
            // Let's put it at Top Right: 440, 20? Form size is 600,600.
            this.btnBack.Location = new System.Drawing.Point(440, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnCancel_Click); // Reusing Cancel logic
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(182, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create New User";
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.BorderRadius = 10;
            this.pnlForm.Controls.Add(this.btnCancel);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.cboRole);
            this.pnlForm.Controls.Add(this.lblRole);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtFullName);
            this.pnlForm.Controls.Add(this.lblFullName);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.lblPassword);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblUsername);
            this.pnlForm.Location = new System.Drawing.Point(20, 70);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(500, 450);
            this.pnlForm.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(20, 20);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 19);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 5;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(20, 45);
            this.txtUsername.Multiline = false;
            this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsername.PlaceholderText = "";
            this.txtUsername.Size = new System.Drawing.Size(460, 34);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(20, 90);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 19);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(20, 115);
            this.txtPassword.Multiline = false;
            this.txtPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.Size = new System.Drawing.Size(460, 34);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFullName.Location = new System.Drawing.Point(20, 160);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(80, 19);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            this.txtFullName.BorderRadius = 5;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(20, 185);
            this.txtFullName.Multiline = false;
            this.txtFullName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtFullName.PlaceholderText = "";
            this.txtFullName.Size = new System.Drawing.Size(460, 34);
            this.txtFullName.TabIndex = 5;
            this.txtFullName.Text = "";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(20, 230);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 19);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(20, 255);
            this.txtEmail.Multiline = false;
            this.txtEmail.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.Size = new System.Drawing.Size(460, 34);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Text = "";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRole.Location = new System.Drawing.Point(20, 300);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(43, 19);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Role:";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(20, 325);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(460, 25);
            this.cboRole.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSave.BorderRadius = 5;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(270, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(110, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.lblTitle);
            this.Name = "UserForm";
            this.Size = new System.Drawing.Size(600, 600);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
