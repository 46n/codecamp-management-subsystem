namespace APUCC_Project.Forms.Trainer
{
    partial class FeedBackForm1
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
            panel1 = new Panel();
            lblTitle = new Label();
            txtMessage = new TextBox();
            btnSendFeedback = new Button();
            chkFeedbackType = new CheckedListBox();
            lblInstruction = new Label();
            lblFeedbackType = new Label();
            txtTrainerName = new TextBox();
            lblTrainerName = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(25, 25, 25);
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1180, 156);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(38, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(708, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Feedback To Administration ";
            // 
            // txtMessage
            // 
            txtMessage.BackColor = SystemColors.ControlLight;
            txtMessage.Location = new Point(49, 284);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(760, 493);
            txtMessage.TabIndex = 1;
            txtMessage.Text = "aine";
            txtMessage.Enter += txtMessage_Enter;
            txtMessage.Leave += txtMessage_Leave;
            // 
            // btnSendFeedback
            // 
            btnSendFeedback.BackColor = Color.LightSteelBlue;
            btnSendFeedback.Location = new Point(850, 685);
            btnSendFeedback.Name = "btnSendFeedback";
            btnSendFeedback.Size = new Size(280, 92);
            btnSendFeedback.TabIndex = 2;
            btnSendFeedback.Text = "Send Feedback";
            btnSendFeedback.UseVisualStyleBackColor = false;
            btnSendFeedback.Click += btnSendFeedback_Click;
            // 
            // chkFeedbackType
            // 
            chkFeedbackType.FormattingEnabled = true;
            chkFeedbackType.Items.AddRange(new object[] { "Genaeral", "Suggestion", "complaint" });
            chkFeedbackType.Location = new Point(850, 486);
            chkFeedbackType.Name = "chkFeedbackType";
            chkFeedbackType.Size = new Size(280, 184);
            chkFeedbackType.TabIndex = 3;
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInstruction.Location = new Point(49, 196);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(539, 59);
            lblInstruction.TabIndex = 4;
            lblInstruction.Text = "Type your feedback below :";
            // 
            // lblFeedbackType
            // 
            lblFeedbackType.AutoSize = true;
            lblFeedbackType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFeedbackType.Location = new Point(850, 416);
            lblFeedbackType.Name = "lblFeedbackType";
            lblFeedbackType.Size = new Size(230, 45);
            lblFeedbackType.TabIndex = 5;
            lblFeedbackType.Text = "Feedback Type";
            lblFeedbackType.Click += lblFeedbackType_Click;
            // 
            // txtTrainerName
            // 
            txtTrainerName.Location = new Point(850, 350);
            txtTrainerName.Name = "txtTrainerName";
            txtTrainerName.Size = new Size(280, 39);
            txtTrainerName.TabIndex = 6;
            // 
            // lblTrainerName
            // 
            lblTrainerName.AutoSize = true;
            lblTrainerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTrainerName.Location = new Point(850, 284);
            lblTrainerName.Name = "lblTrainerName";
            lblTrainerName.Size = new Size(218, 45);
            lblTrainerName.TabIndex = 7;
            lblTrainerName.Text = "Trainer Name ";
            // 
            // FeedBackForm1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1180, 814);
            Controls.Add(lblTrainerName);
            Controls.Add(txtTrainerName);
            Controls.Add(lblFeedbackType);
            Controls.Add(lblInstruction);
            Controls.Add(chkFeedbackType);
            Controls.Add(btnSendFeedback);
            Controls.Add(txtMessage);
            Controls.Add(panel1);
            Name = "FeedBackForm1";
            Text = "FeedbackToAdminForm";
            Load += FeedBackForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private TextBox txtMessage;
        private Button btnSendFeedback;
        private CheckedListBox chkFeedbackType;
        private Label lblInstruction;
        private Label lblFeedbackType;
        private TextBox txtTrainerName;
        private Label lblTrainerName;
    }
}
