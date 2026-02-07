namespace CustomerSupportTicketSystem.Desktop.Controls
{
    partial class TicketDetailsControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpTicketInfo;
        private System.Windows.Forms.Label lblTicketNumber;
        private System.Windows.Forms.Label lblTicketNumberValue;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblSubjectValue;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblPriorityValue;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblCreatedDateValue;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblCreatedByValue;
        private System.Windows.Forms.Label lblAssignedTo;
        private System.Windows.Forms.Label lblAssignedToValue;
        private System.Windows.Forms.GroupBox grpComments;
        private System.Windows.Forms.DataGridView dgvComments;
        private System.Windows.Forms.Label lblAddComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.CheckBox chkIsInternal;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.GroupBox grpAdminActions;
        private System.Windows.Forms.Label lblAssignToAdmin;
        private System.Windows.Forms.ComboBox cboAssignTo;
        private System.Windows.Forms.Button btnAssignTicket;
        private System.Windows.Forms.Label lblChangeStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblStatusComment;
        private System.Windows.Forms.TextBox txtStatusComment;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnBack;

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
            this.grpTicketInfo = new System.Windows.Forms.GroupBox();
            this.lblAssignedToValue = new System.Windows.Forms.Label();
            this.lblAssignedTo = new System.Windows.Forms.Label();
            this.lblCreatedByValue = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblCreatedDateValue = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPriorityValue = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSubjectValue = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblTicketNumberValue = new System.Windows.Forms.Label();
            this.lblTicketNumber = new System.Windows.Forms.Label();
            this.grpComments = new System.Windows.Forms.GroupBox();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.chkIsInternal = new System.Windows.Forms.CheckBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblAddComment = new System.Windows.Forms.Label();
            this.dgvComments = new System.Windows.Forms.DataGridView();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.grpAdminActions = new System.Windows.Forms.GroupBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.txtStatusComment = new System.Windows.Forms.TextBox();
            this.lblStatusComment = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.lblChangeStatus = new System.Windows.Forms.Label();
            this.btnAssignTicket = new System.Windows.Forms.Button();
            this.cboAssignTo = new System.Windows.Forms.ComboBox();
            this.lblAssignToAdmin = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpTicketInfo.SuspendLayout();
            this.grpComments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).BeginInit();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.grpAdminActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(134, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ticket Details";
            // 
            // grpTicketInfo
            // 
            this.grpTicketInfo.Controls.Add(this.lblAssignedToValue);
            this.grpTicketInfo.Controls.Add(this.lblAssignedTo);
            this.grpTicketInfo.Controls.Add(this.lblCreatedByValue);
            this.grpTicketInfo.Controls.Add(this.lblCreatedBy);
            this.grpTicketInfo.Controls.Add(this.lblCreatedDateValue);
            this.grpTicketInfo.Controls.Add(this.lblCreatedDate);
            this.grpTicketInfo.Controls.Add(this.lblStatusValue);
            this.grpTicketInfo.Controls.Add(this.lblStatus);
            this.grpTicketInfo.Controls.Add(this.lblPriorityValue);
            this.grpTicketInfo.Controls.Add(this.lblPriority);
            this.grpTicketInfo.Controls.Add(this.txtDescription);
            this.grpTicketInfo.Controls.Add(this.lblDescription);
            this.grpTicketInfo.Controls.Add(this.lblSubjectValue);
            this.grpTicketInfo.Controls.Add(this.lblSubject);
            this.grpTicketInfo.Controls.Add(this.lblTicketNumberValue);
            this.grpTicketInfo.Controls.Add(this.lblTicketNumber);
            this.grpTicketInfo.Location = new System.Drawing.Point(20, 60);
            this.grpTicketInfo.Name = "grpTicketInfo";
            this.grpTicketInfo.Size = new System.Drawing.Size(600, 280);
            this.grpTicketInfo.TabIndex = 1;
            this.grpTicketInfo.TabStop = false;
            this.grpTicketInfo.Text = "Ticket Information";
            // 
            // lblTicketNumber
            // 
            this.lblTicketNumber.AutoSize = true;
            this.lblTicketNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTicketNumber.Location = new System.Drawing.Point(15, 25);
            this.lblTicketNumber.Name = "lblTicketNumber";
            this.lblTicketNumber.Size = new System.Drawing.Size(91, 15);
            this.lblTicketNumber.TabIndex = 0;
            this.lblTicketNumber.Text = "Ticket Number:";
            // 
            // lblTicketNumberValue
            // 
            this.lblTicketNumberValue.AutoSize = true;
            this.lblTicketNumberValue.Location = new System.Drawing.Point(150, 25);
            this.lblTicketNumberValue.Name = "lblTicketNumberValue";
            this.lblTicketNumberValue.Size = new System.Drawing.Size(0, 15);
            this.lblTicketNumberValue.TabIndex = 1;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubject.Location = new System.Drawing.Point(15, 50);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(49, 15);
            this.lblSubject.TabIndex = 2;
            this.lblSubject.Text = "Subject:";
            // 
            // lblSubjectValue
            // 
            this.lblSubjectValue.AutoSize = true;
            this.lblSubjectValue.Location = new System.Drawing.Point(150, 50);
            this.lblSubjectValue.Name = "lblSubjectValue";
            this.lblSubjectValue.Size = new System.Drawing.Size(0, 15);
            this.lblSubjectValue.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(15, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(15, 93);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(570, 80);
            this.txtDescription.TabIndex = 5;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPriority.Location = new System.Drawing.Point(15, 185);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(48, 15);
            this.lblPriority.TabIndex = 6;
            this.lblPriority.Text = "Priority:";
            // 
            // lblPriorityValue
            // 
            this.lblPriorityValue.AutoSize = true;
            this.lblPriorityValue.Location = new System.Drawing.Point(150, 185);
            this.lblPriorityValue.Name = "lblPriorityValue";
            this.lblPriorityValue.Size = new System.Drawing.Size(0, 15);
            this.lblPriorityValue.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(15, 210);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(43, 15);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status:";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Location = new System.Drawing.Point(150, 210);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(0, 15);
            this.lblStatusValue.TabIndex = 9;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.AutoSize = true;
            this.lblCreatedDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreatedDate.Location = new System.Drawing.Point(15, 235);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(79, 15);
            this.lblCreatedDate.TabIndex = 10;
            this.lblCreatedDate.Text = "Created Date:";
            // 
            // lblCreatedDateValue
            // 
            this.lblCreatedDateValue.AutoSize = true;
            this.lblCreatedDateValue.Location = new System.Drawing.Point(150, 235);
            this.lblCreatedDateValue.Name = "lblCreatedDateValue";
            this.lblCreatedDateValue.Size = new System.Drawing.Size(0, 15);
            this.lblCreatedDateValue.TabIndex = 11;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreatedBy.Location = new System.Drawing.Point(310, 235);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(68, 15);
            this.lblCreatedBy.TabIndex = 12;
            this.lblCreatedBy.Text = "Created By:";
            // 
            // lblCreatedByValue
            // 
            this.lblCreatedByValue.AutoSize = true;
            this.lblCreatedByValue.Location = new System.Drawing.Point(390, 235);
            this.lblCreatedByValue.Name = "lblCreatedByValue";
            this.lblCreatedByValue.Size = new System.Drawing.Size(0, 15);
            this.lblCreatedByValue.TabIndex = 13;
            // 
            // lblAssignedTo
            // 
            this.lblAssignedTo.AutoSize = true;
            this.lblAssignedTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAssignedTo.Location = new System.Drawing.Point(310, 210);
            this.lblAssignedTo.Name = "lblAssignedTo";
            this.lblAssignedTo.Size = new System.Drawing.Size(73, 15);
            this.lblAssignedTo.TabIndex = 14;
            this.lblAssignedTo.Text = "Assigned To:";
            // 
            // lblAssignedToValue
            // 
            this.lblAssignedToValue.AutoSize = true;
            this.lblAssignedToValue.Location = new System.Drawing.Point(390, 210);
            this.lblAssignedToValue.Name = "lblAssignedToValue";
            this.lblAssignedToValue.Size = new System.Drawing.Size(0, 15);
            this.lblAssignedToValue.TabIndex = 15;
            // 
            // grpComments
            // 
            this.grpComments.Controls.Add(this.btnAddComment);
            this.grpComments.Controls.Add(this.chkIsInternal);
            this.grpComments.Controls.Add(this.txtComment);
            this.grpComments.Controls.Add(this.lblAddComment);
            this.grpComments.Controls.Add(this.dgvComments);
            this.grpComments.Location = new System.Drawing.Point(20, 350);
            this.grpComments.Name = "grpComments";
            this.grpComments.Size = new System.Drawing.Size(600, 280);
            this.grpComments.TabIndex = 2;
            this.grpComments.TabStop = false;
            this.grpComments.Text = "Comments";
            // 
            // dgvComments
            // 
            this.dgvComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComments.Location = new System.Drawing.Point(15, 25);
            this.dgvComments.Name = "dgvComments";
            this.dgvComments.RowTemplate.Height = 25;
            this.dgvComments.Size = new System.Drawing.Size(570, 150);
            this.dgvComments.TabIndex = 0;
            // 
            // lblAddComment
            // 
            this.lblAddComment.AutoSize = true;
            this.lblAddComment.Location = new System.Drawing.Point(15, 185);
            this.lblAddComment.Name = "lblAddComment";
            this.lblAddComment.Size = new System.Drawing.Size(81, 15);
            this.lblAddComment.TabIndex = 1;
            this.lblAddComment.Text = "Add Comment:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(15, 203);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(570, 40);
            this.txtComment.TabIndex = 2;
            // 
            // chkIsInternal
            // 
            this.chkIsInternal.AutoSize = true;
            this.chkIsInternal.Location = new System.Drawing.Point(15, 250);
            this.chkIsInternal.Name = "chkIsInternal";
            this.chkIsInternal.Size = new System.Drawing.Size(122, 19);
            this.chkIsInternal.TabIndex = 3;
            this.chkIsInternal.Text = "Internal Comment";
            this.chkIsInternal.UseVisualStyleBackColor = true;
            // 
            // btnAddComment
            // 
            this.btnAddComment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAddComment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddComment.ForeColor = System.Drawing.Color.White;
            this.btnAddComment.Location = new System.Drawing.Point(475, 246);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(110, 25);
            this.btnAddComment.TabIndex = 4;
            this.btnAddComment.Text = "Add Comment";
            this.btnAddComment.UseVisualStyleBackColor = false;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.dgvHistory);
            this.grpHistory.Location = new System.Drawing.Point(20, 640);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(600, 200);
            this.grpHistory.TabIndex = 3;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "Status History";
            // 
            // dgvHistory
            // 
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(15, 25);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowTemplate.Height = 25;
            this.dgvHistory.Size = new System.Drawing.Size(570, 160);
            this.dgvHistory.TabIndex = 0;
            // 
            // grpAdminActions
            // 
            this.grpAdminActions.Controls.Add(this.btnUpdateStatus);
            this.grpAdminActions.Controls.Add(this.txtStatusComment);
            this.grpAdminActions.Controls.Add(this.lblStatusComment);
            this.grpAdminActions.Controls.Add(this.cboStatus);
            this.grpAdminActions.Controls.Add(this.lblChangeStatus);
            this.grpAdminActions.Controls.Add(this.btnAssignTicket);
            this.grpAdminActions.Controls.Add(this.cboAssignTo);
            this.grpAdminActions.Controls.Add(this.lblAssignToAdmin);
            this.grpAdminActions.Location = new System.Drawing.Point(640, 60);
            this.grpAdminActions.Name = "grpAdminActions";
            this.grpAdminActions.Size = new System.Drawing.Size(340, 280);
            this.grpAdminActions.TabIndex = 4;
            this.grpAdminActions.TabStop = false;
            this.grpAdminActions.Text = "Admin Actions";
            // 
            // lblAssignToAdmin
            // 
            this.lblAssignToAdmin.AutoSize = true;
            this.lblAssignToAdmin.Location = new System.Drawing.Point(15, 25);
            this.lblAssignToAdmin.Name = "lblAssignToAdmin";
            this.lblAssignToAdmin.Size = new System.Drawing.Size(62, 15);
            this.lblAssignToAdmin.TabIndex = 0;
            this.lblAssignToAdmin.Text = "Assign To:";
            // 
            // cboAssignTo
            // 
            this.cboAssignTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAssignTo.FormattingEnabled = true;
            this.cboAssignTo.Location = new System.Drawing.Point(15, 43);
            this.cboAssignTo.Name = "cboAssignTo";
            this.cboAssignTo.Size = new System.Drawing.Size(240, 23);
            this.cboAssignTo.TabIndex = 1;
            // 
            // btnAssignTicket
            // 
            this.btnAssignTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnAssignTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignTicket.ForeColor = System.Drawing.Color.White;
            this.btnAssignTicket.Location = new System.Drawing.Point(260, 43);
            this.btnAssignTicket.Name = "btnAssignTicket";
            this.btnAssignTicket.Size = new System.Drawing.Size(65, 23);
            this.btnAssignTicket.TabIndex = 2;
            this.btnAssignTicket.Text = "Assign";
            this.btnAssignTicket.UseVisualStyleBackColor = false;
            this.btnAssignTicket.Click += new System.EventHandler(this.btnAssignTicket_Click);
            // 
            // lblChangeStatus
            // 
            this.lblChangeStatus.AutoSize = true;
            this.lblChangeStatus.Location = new System.Drawing.Point(15, 85);
            this.lblChangeStatus.Name = "lblChangeStatus";
            this.lblChangeStatus.Size = new System.Drawing.Size(86, 15);
            this.lblChangeStatus.TabIndex = 3;
            this.lblChangeStatus.Text = "Change Status:";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(15, 103);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(240, 23);
            this.cboStatus.TabIndex = 4;
            // 
            // lblStatusComment
            // 
            this.lblStatusComment.AutoSize = true;
            this.lblStatusComment.Location = new System.Drawing.Point(15, 135);
            this.lblStatusComment.Name = "lblStatusComment";
            this.lblStatusComment.Size = new System.Drawing.Size(120, 15);
            this.lblStatusComment.TabIndex = 5;
            this.lblStatusComment.Text = "Comment (optional):";
            // 
            // txtStatusComment
            // 
            this.txtStatusComment.Location = new System.Drawing.Point(15, 153);
            this.txtStatusComment.Multiline = true;
            this.txtStatusComment.Name = "txtStatusComment";
            this.txtStatusComment.Size = new System.Drawing.Size(310, 80);
            this.txtStatusComment.TabIndex = 6;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(15, 239);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateStatus.TabIndex = 7;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(880, 15); // Move to top right or keep absolute but ensure visible
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "← Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // TicketDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true; // Enable AutoScroll
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpAdminActions);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.grpComments);
            this.Controls.Add(this.grpTicketInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "TicketDetailsControl";
            this.Size = new System.Drawing.Size(1000, 850);
            this.Load += new System.EventHandler(this.TicketDetailsControl_Load);
            this.grpTicketInfo.ResumeLayout(false);
            this.grpTicketInfo.PerformLayout();
            this.grpComments.ResumeLayout(false);
            this.grpComments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComments)).EndInit();
            this.grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.grpAdminActions.ResumeLayout(false);
            this.grpAdminActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
