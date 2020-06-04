namespace IceCreamShopView
{
    partial class FormImplementers
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
            this.dataGridViewImplementers = new System.Windows.Forms.DataGridView();
            this.buttonAddImplementer = new System.Windows.Forms.Button();
            this.buttonUpdateImplementer = new System.Windows.Forms.Button();
            this.buttonDeleteImplementer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImplementers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImplementers
            // 
            this.dataGridViewImplementers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImplementers.Location = new System.Drawing.Point(1, 2);
            this.dataGridViewImplementers.Name = "dataGridViewImplementers";
            this.dataGridViewImplementers.Size = new System.Drawing.Size(315, 278);
            this.dataGridViewImplementers.TabIndex = 0;
            // 
            // buttonAddImplementer
            // 
            this.buttonAddImplementer.Location = new System.Drawing.Point(327, 11);
            this.buttonAddImplementer.Name = "buttonAddImplementer";
            this.buttonAddImplementer.Size = new System.Drawing.Size(88, 24);
            this.buttonAddImplementer.TabIndex = 1;
            this.buttonAddImplementer.Text = "Добавить";
            this.buttonAddImplementer.UseVisualStyleBackColor = true;
            this.buttonAddImplementer.Click += new System.EventHandler(this.buttonAddImplementer_Click);
            // 
            // buttonUpdateImplementer
            // 
            this.buttonUpdateImplementer.Location = new System.Drawing.Point(327, 41);
            this.buttonUpdateImplementer.Name = "buttonUpdateImplementer";
            this.buttonUpdateImplementer.Size = new System.Drawing.Size(88, 26);
            this.buttonUpdateImplementer.TabIndex = 2;
            this.buttonUpdateImplementer.Text = "Изменить";
            this.buttonUpdateImplementer.UseVisualStyleBackColor = true;
            this.buttonUpdateImplementer.Click += new System.EventHandler(this.buttonUpdateImplementer_Click);
            // 
            // buttonDeleteImplementer
            // 
            this.buttonDeleteImplementer.Location = new System.Drawing.Point(327, 73);
            this.buttonDeleteImplementer.Name = "buttonDeleteImplementer";
            this.buttonDeleteImplementer.Size = new System.Drawing.Size(88, 23);
            this.buttonDeleteImplementer.TabIndex = 3;
            this.buttonDeleteImplementer.Text = "Удалить";
            this.buttonDeleteImplementer.UseVisualStyleBackColor = true;
            this.buttonDeleteImplementer.Click += new System.EventHandler(this.buttonDeleteImplementer_Click);
            // 
            // FormImplementers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 282);
            this.Controls.Add(this.buttonDeleteImplementer);
            this.Controls.Add(this.buttonUpdateImplementer);
            this.Controls.Add(this.buttonAddImplementer);
            this.Controls.Add(this.dataGridViewImplementers);
            this.Name = "FormImplementers";
            this.Text = "Кондитеры";
            this.Load += new System.EventHandler(this.FormImplementers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImplementers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewImplementers;
        private System.Windows.Forms.Button buttonAddImplementer;
        private System.Windows.Forms.Button buttonUpdateImplementer;
        private System.Windows.Forms.Button buttonDeleteImplementer;
    }
}