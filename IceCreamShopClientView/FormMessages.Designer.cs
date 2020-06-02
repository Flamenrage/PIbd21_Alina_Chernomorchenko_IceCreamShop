namespace IceCreamShopClientView
{
    partial class FormMessages
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
            this.dataGridViewClientMessages = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClientMessages
            // 
            this.dataGridViewClientMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientMessages.Location = new System.Drawing.Point(2, 3);
            this.dataGridViewClientMessages.Name = "dataGridViewClientMessages";
            this.dataGridViewClientMessages.Size = new System.Drawing.Size(500, 345);
            this.dataGridViewClientMessages.TabIndex = 0;
            // 
            // FormMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 351);
            this.Controls.Add(this.dataGridViewClientMessages);
            this.Name = "FormMessages";
            this.Text = "Сообщения";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewClientMessages;
    }
}