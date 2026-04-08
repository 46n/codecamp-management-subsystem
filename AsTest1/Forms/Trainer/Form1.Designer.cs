namespace APUCC_Project.Forms.Trainer
{
    partial class FeedBackForm
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
            textFeedback.Location = new Point(69, 186);
            textFeedback.Multiline = true;
            textFeedback.Name = "textFeedback";
            textFeedback.Size = new Size(1026, 459);
            textFeedback.TabIndex = 1;
            // 
            // btnSendFeedback
            // 
            btnSendFeedback.BackColor = Color.LightSteelBlue;
            btnSendFeedback.Location = new Point(69, 692);
            btnSendFeedback.Name = "btnSendFeedback";
            btnSendFeedback.Size = new Size(264, 92);
            btnSendFeedback.TabIndex = 2;
            btnSendFeedback.Text = "Send Feedback";
            btnSendFeedback.UseVisualStyleBackColor = false;
            // 
            // FeedBackForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1660, 814);
            Controls.Add(btnSendFeedback);
            Controls.Add(textFeedback);
            Controls.Add(panel1);
            Name = "FeedBackForm";
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
    }
}