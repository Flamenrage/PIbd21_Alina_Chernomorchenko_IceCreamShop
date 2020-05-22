namespace IceCreamShopView
{
    partial class FormImplementer
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
            this.labelImplementerFIO = new System.Windows.Forms.Label();
            this.textBoxImplementerFIO = new System.Windows.Forms.TextBox();
            this.textBoxWorkTime = new System.Windows.Forms.TextBox();
            this.labelWorkTime = new System.Windows.Forms.Label();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelImplementerFIO
            // 
            this.labelImplementerFIO.AutoSize = true;
            this.labelImplementerFIO.Location = new System.Drawing.Point(60, 18);
            this.labelImplementerFIO.Name = "labelImplementerFIO";
            this.labelImplementerFIO.Size = new System.Drawing.Size(34, 13);
            this.labelImplementerFIO.TabIndex = 0;
            this.labelImplementerFIO.Text = "ФИО";
            // 
            // textBoxImplementerFIO
            // 
            this.textBoxImplementerFIO.Location = new System.Drawing.Point(120, 15);
            this.textBoxImplementerFIO.Name = "textBoxImplementerFIO";
            this.textBoxImplementerFIO.Size = new System.Drawing.Size(129, 20);
            this.textBoxImplementerFIO.TabIndex = 1;
            // 
            // textBoxWorkTime
            // 
            this.textBoxWorkTime.Location = new System.Drawing.Point(120, 41);
            this.textBoxWorkTime.Name = "textBoxWorkTime";
            this.textBoxWorkTime.Size = new System.Drawing.Size(129, 20);
            this.textBoxWorkTime.TabIndex = 3;
            // 
            // labelWorkTime
            // 
            this.labelWorkTime.AutoSize = true;
            this.labelWorkTime.Location = new System.Drawing.Point(12, 44);
            this.labelWorkTime.Name = "labelWorkTime";
            this.labelWorkTime.Size = new System.Drawing.Size(105, 13);
            this.labelWorkTime.TabIndex = 2;
            this.labelWorkTime.Text = "Время выполнения";
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(120, 67);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(129, 20);
            this.textBoxDelay.TabIndex = 5;
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(35, 70);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(79, 13);
            this.labelDelay.TabIndex = 4;
            this.labelDelay.Text = "Время отдыха";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(175, 93);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 6;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(93, 93);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 124);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.textBoxDelay);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.textBoxWorkTime);
            this.Controls.Add(this.labelWorkTime);
            this.Controls.Add(this.textBoxImplementerFIO);
            this.Controls.Add(this.labelImplementerFIO);
            this.Name = "FormImplementer";
            this.Text = "Кондитер";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelImplementerFIO;
        private System.Windows.Forms.TextBox textBoxImplementerFIO;
        private System.Windows.Forms.TextBox textBoxWorkTime;
        private System.Windows.Forms.Label labelWorkTime;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
    }
}