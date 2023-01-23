namespace AADWinForms
{
    partial class FSupervisorLogin
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
            this.btnCurrentUserSignIn = new System.Windows.Forms.Button();
            this.btnSupervisorSignIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.lblSupervisorName = new System.Windows.Forms.Label();
            this.lblSupervisorStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCurrentUserSignIn
            // 
            this.btnCurrentUserSignIn.Location = new System.Drawing.Point(150, 133);
            this.btnCurrentUserSignIn.Name = "btnCurrentUserSignIn";
            this.btnCurrentUserSignIn.Size = new System.Drawing.Size(240, 100);
            this.btnCurrentUserSignIn.TabIndex = 0;
            this.btnCurrentUserSignIn.Text = "Current User Sign In";
            this.btnCurrentUserSignIn.UseVisualStyleBackColor = true;
            this.btnCurrentUserSignIn.Click += new System.EventHandler(this.btnCurrentUserSignIn_Click);
            // 
            // btnSupervisorSignIn
            // 
            this.btnSupervisorSignIn.Enabled = false;
            this.btnSupervisorSignIn.Location = new System.Drawing.Point(587, 133);
            this.btnSupervisorSignIn.Name = "btnSupervisorSignIn";
            this.btnSupervisorSignIn.Size = new System.Drawing.Size(240, 100);
            this.btnSupervisorSignIn.TabIndex = 1;
            this.btnSupervisorSignIn.Text = "Supervisor Sign In";
            this.btnSupervisorSignIn.UseVisualStyleBackColor = true;
            this.btnSupervisorSignIn.Click += new System.EventHandler(this.btnSupervisorSignIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Supervisor Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(485, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Status:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(170, 276);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 25);
            this.lblUserName.TabIndex = 6;
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.AutoSize = true;
            this.lblUserStatus.Location = new System.Drawing.Point(175, 344);
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(0, 25);
            this.lblUserStatus.TabIndex = 7;
            // 
            // lblSupervisorName
            // 
            this.lblSupervisorName.AutoSize = true;
            this.lblSupervisorName.Location = new System.Drawing.Point(670, 276);
            this.lblSupervisorName.Name = "lblSupervisorName";
            this.lblSupervisorName.Size = new System.Drawing.Size(0, 25);
            this.lblSupervisorName.TabIndex = 8;
            // 
            // lblSupervisorStatus
            // 
            this.lblSupervisorStatus.AutoSize = true;
            this.lblSupervisorStatus.Location = new System.Drawing.Point(675, 344);
            this.lblSupervisorStatus.Name = "lblSupervisorStatus";
            this.lblSupervisorStatus.Size = new System.Drawing.Size(0, 25);
            this.lblSupervisorStatus.TabIndex = 9;
            // 
            // FSupervisorLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 697);
            this.Controls.Add(this.lblSupervisorStatus);
            this.Controls.Add(this.lblSupervisorName);
            this.Controls.Add(this.lblUserStatus);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSupervisorSignIn);
            this.Controls.Add(this.btnCurrentUserSignIn);
            this.Name = "FSupervisorLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supervisor Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCurrentUserSignIn;
        private System.Windows.Forms.Button btnSupervisorSignIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserStatus;
        private System.Windows.Forms.Label lblSupervisorName;
        private System.Windows.Forms.Label lblSupervisorStatus;
    }
}