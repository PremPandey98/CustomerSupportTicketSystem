namespace CustomerSupportTicketSystem.Desktop.Forms
{
    public partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlLeft;
        private Panel pnlRight;
        private Label lblBranding;
        private Label lblTagline;
        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private CustomerSupportTicketSystem.Desktop.UI.ModernButton btnLogin;
        private Label lblStatus;

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
            this.pnlLeft = new Panel();
            this.lblBranding = new Label();
            this.lblTagline = new Label();
            this.pnlRight = new Panel();
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new CustomerSupportTicketSystem.Desktop.UI.ModernButton();
            this.lblStatus = new Label();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.Primary;
            this.pnlLeft.Controls.Add(this.lblTagline);
            this.pnlLeft.Controls.Add(this.lblBranding);
            this.pnlLeft.Dock = DockStyle.Left;
            this.pnlLeft.Location = new Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new Size(350, 500);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblBranding
            // 
            this.lblBranding.AutoSize = false;
            this.lblBranding.Font = CustomerSupportTicketSystem.Desktop.UI.ModernFonts.H2;
            this.lblBranding.ForeColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.TextLight;
            this.lblBranding.Location = new Point(40, 180);
            this.lblBranding.Name = "lblBranding";
            this.lblBranding.Size = new Size(270, 80);
            this.lblBranding.TabIndex = 0;
            this.lblBranding.Text = "Customer Support\r\nTicket System";
            this.lblBranding.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTagline
            // 
            this.lblTagline.AutoSize = false;
            this.lblTagline.Font = CustomerSupportTicketSystem.Desktop.UI.ModernFonts.BodyLarge;
            this.lblTagline.ForeColor = Color.FromArgb(200, 255, 255, 255);
            this.lblTagline.Location = new Point(40, 270);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new Size(270, 60);
            this.lblTagline.TabIndex = 1;
            this.lblTagline.Text = "Streamline your customer support with powerful ticket management";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.CardBackground;
            this.pnlRight.Controls.Add(this.lblStatus);
            this.pnlRight.Controls.Add(this.btnLogin);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.lblPassword);
            this.pnlRight.Controls.Add(this.txtUsername);
            this.pnlRight.Controls.Add(this.lblUsername);
            this.pnlRight.Controls.Add(this.lblTitle);
            this.pnlRight.Dock = DockStyle.Fill;
            this.pnlRight.Location = new Point(350, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new Padding(50, 120, 50, 50);
            this.pnlRight.Size = new Size(450, 500);
            this.pnlRight.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = CustomerSupportTicketSystem.Desktop.UI.ModernFonts.H3;
            this.lblTitle.ForeColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.TextPrimary;
            this.lblTitle.Location = new Point(50, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(140, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Welcome Back!";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = CustomerSupportTicketSystem.Desktop.UI.ModernFonts.BodyBold;
            this.lblUsername.ForeColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.TextSecondary;
            this.lblUsername.Location = new Point(50, 140);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new Size(61, 15);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
            this.txtUsername.Font = CustomerSupportTicketSystem.Desktop.UI.ModernFonts.BodyLarge;
            this.txtUsername.Location = new Point(50, 160);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(340, 26);
            this.txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = CustomerSupportTicketSystem.Desktop.UI.ModernFonts.BodyBold;
            this.lblPassword.ForeColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.TextSecondary;
            this.lblPassword.Location = new Point(50, 210);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(60, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.Font = CustomerSupportTicketSystem.Desktop.UI.ModernFonts.BodyLarge;
            this.txtPassword.Location = new Point(50, 230);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new Size(340, 26);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // btnLogin
            // 
            this.btnLogin.BorderRadius = 6;
            this.btnLogin.Location = new Point(50, 290);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormalColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.Primary;
            this.btnLogin.HoverColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.PrimaryHover;
            this.btnLogin.Size = new Size(340, 45);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "SIGN IN";
            this.btnLogin.TextColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.TextLight;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Font = CustomerSupportTicketSystem.Desktop.UI.ModernFonts.Small;
            this.lblStatus.ForeColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.TextSecondary;
            this.lblStatus.Location = new Point(50, 345);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(340, 20);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "";
            this.lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = CustomerSupportTicketSystem.Desktop.UI.ModernColors.BackgroundLight;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Name = "LoginForm";
            this.Size = new Size(800, 500);
            this.pnlLeft.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
