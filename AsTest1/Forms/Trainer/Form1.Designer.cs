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
            TrainerFeedbackLabel = new Label();
            textFeedback = new TextBox();
            btnSendFeedback = new Button();
            FeedbackTypecheckedListBox = new CheckedListBox();
            TypeFeedbacklabel = new Label();
            label1 = new Label();
            txtTrainerName = new TextBox();
            TrainerNameLabel = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(TrainerFeedbackLabel);
            panel1.Location = new Point(-7, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1674, 156);
            panel1.TabIndex = 0;
            // 
            // TrainerFeedbackLabel
            // 
            TrainerFeedbackLabel.AutoSize = true;
            TrainerFeedbackLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TrainerFeedbackLabel.Location = new Point(38, 48);
            TrainerFeedbackLabel.Name = "TrainerFeedbackLabel";
            TrainerFeedbackLabel.Size = new Size(625, 65);
            TrainerFeedbackLabel.TabIndex = 0;
            TrainerFeedbackLabel.Text = "Feedback To Administration ";
            // 
            // textFeedback
            // 
            textFeedback.BackColor = SystemColors.InactiveBorder;
            textFeedback.Location = new Point(49, 284);
            textFeedback.Multiline = true;
            textFeedback.Name = "textFeedback";
            textFeedback.Size = new Size(1026, 459);
            textFeedback.TabIndex = 1;
            // 
            // btnSendFeedback
            // 
            btnSendFeedback.BackColor = Color.LightSteelBlue;
            btnSendFeedback.Location = new Point(1101, 651);
            btnSendFeedback.Name = "btnSendFeedback";
            btnSendFeedback.Size = new Size(264, 92);
            btnSendFeedback.TabIndex = 2;
            btnSendFeedback.Text = "Send Feedback";
            btnSendFeedback.UseVisualStyleBackColor = false;
            // 
            // FeedbackTypecheckedListBox
            // 
            FeedbackTypecheckedListBox.FormattingEnabled = true;
            FeedbackTypecheckedListBox.Items.AddRange(new object[] { "Genaeral", "Suggestion", "complaint" });
            FeedbackTypecheckedListBox.Location = new Point(1101, 494);
            FeedbackTypecheckedListBox.Name = "FeedbackTypecheckedListBox";
            FeedbackTypecheckedListBox.Size = new Size(206, 112);
            FeedbackTypecheckedListBox.TabIndex = 3;
            // 
            // TypeFeedbacklabel
            // 
            TypeFeedbacklabel.AutoSize = true;
            TypeFeedbacklabel.Font = new Font("Segoe UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TypeFeedbacklabel.Location = new Point(49, 196);
            TypeFeedbacklabel.Name = "TypeFeedbacklabel";
            TypeFeedbacklabel.Size = new Size(539, 59);
            TypeFeedbacklabel.TabIndex = 4;
            TypeFeedbacklabel.Text = "Type your feedback below :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1101, 418);
            label1.Name = "label1";
            label1.Size = new Size(230, 45);
            label1.TabIndex = 5;
            label1.Text = "Feedback Type";
            // 
            // txtTrainerName
            // 
            txtTrainerName.Location = new Point(1101, 350);
            txtTrainerName.Name = "txtTrainerName";
            txtTrainerName.Size = new Size(370, 39);
            txtTrainerName.TabIndex = 6;
            // 
            // TrainerNameLabel
            // 
            TrainerNameLabel.AutoSize = true;
            TrainerNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TrainerNameLabel.Location = new Point(1101, 284);
            TrainerNameLabel.Name = "TrainerNameLabel";
            TrainerNameLabel.Size = new Size(218, 45);
            TrainerNameLabel.TabIndex = 7;
            TrainerNameLabel.Text = "Trainer Name ";
            // 
            // FeedBackForm1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1660, 814);
            Controls.Add(TrainerNameLabel);
            Controls.Add(txtTrainerName);
            Controls.Add(label1);
            Controls.Add(TypeFeedbacklabel);
            Controls.Add(FeedbackTypecheckedListBox);
            Controls.Add(btnSendFeedback);
            Controls.Add(textFeedback);
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
        private Label TrainerFeedbackLabel;
        private TextBox textFeedback;
        private Button btnSendFeedback;
        private CheckedListBox FeedbackTypecheckedListBox;
        private Label TypeFeedbacklabel;
        private Label label1;
        private TextBox txtTrainerName;
        private Label TrainerNameLabel;
    }
}