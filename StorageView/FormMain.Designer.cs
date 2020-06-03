namespace StorageView
{
    partial class FormMain
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FillStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 26);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 412);
            this.dataGridView.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateStorageToolStripMenuItem,
            this.ChangeStorageToolStripMenuItem,
            this.FillStorageToolStripMenuItem,
            this.DeleteStorageToolStripMenuItem,
            this.UpdateStorageToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // CreateStorageToolStripMenuItem
            // 
            this.CreateStorageToolStripMenuItem.Name = "CreateStorageToolStripMenuItem";
            this.CreateStorageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CreateStorageToolStripMenuItem.Text = "Создать склад";
            this.CreateStorageToolStripMenuItem.Click += new System.EventHandler(this.CreateStorageToolStripMenuItem_Click);
            // 
            // ChangeStorageToolStripMenuItem
            // 
            this.ChangeStorageToolStripMenuItem.Name = "ChangeStorageToolStripMenuItem";
            this.ChangeStorageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ChangeStorageToolStripMenuItem.Text = "Изменить склад";
            this.ChangeStorageToolStripMenuItem.Click += new System.EventHandler(this.ChangeStorageToolStripMenuItem_Click);
            // 
            // FillStorageToolStripMenuItem
            // 
            this.FillStorageToolStripMenuItem.Name = "FillStorageToolStripMenuItem";
            this.FillStorageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FillStorageToolStripMenuItem.Text = "Пополнить склад";
            this.FillStorageToolStripMenuItem.Click += new System.EventHandler(this.FillStorageToolStripMenuItem_Click);
            // 
            // DeleteStorageToolStripMenuItem
            // 
            this.DeleteStorageToolStripMenuItem.Name = "DeleteStorageToolStripMenuItem";
            this.DeleteStorageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteStorageToolStripMenuItem.Text = "Удалить склад";
            this.DeleteStorageToolStripMenuItem.Click += new System.EventHandler(this.DeleteStorageToolStripMenuItem_Click);
            // 
            // UpdateStorageToolStripMenuItem
            // 
            this.UpdateStorageToolStripMenuItem.Name = "UpdateStorageToolStripMenuItem";
            this.UpdateStorageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UpdateStorageToolStripMenuItem.Text = "Обновить список";
            this.UpdateStorageToolStripMenuItem.Click += new System.EventHandler(this.UpdateStorageToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Склады";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateStorageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeStorageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillStorageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteStorageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateStorageToolStripMenuItem;
    }
}