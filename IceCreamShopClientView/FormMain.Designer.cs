namespace IceCreamShopClientView
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
            this.dataGridViewClientOrders = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьЗаказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьПрофильToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьСписокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientOrders)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridViewClientOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientOrders.Location = new System.Drawing.Point(2, 26);
            this.dataGridViewClientOrders.Name = "dataGridView";
            this.dataGridViewClientOrders.Size = new System.Drawing.Size(700, 700);
            this.dataGridViewClientOrders.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(646, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьЗаказToolStripMenuItem,
            this.редактироватьПрофильToolStripMenuItem,
            this.обновитьСписокЗаказовToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // создатьЗаказToolStripMenuItem
            // 
            this.создатьЗаказToolStripMenuItem.Name = "создатьЗаказToolStripMenuItem";
            this.создатьЗаказToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.создатьЗаказToolStripMenuItem.Text = "Создать заказ";
            this.создатьЗаказToolStripMenuItem.Click += CreateOrderToolStripMenuItem_Click;
            // 
            // редактироватьПрофильToolStripMenuItem
            // 
            this.редактироватьПрофильToolStripMenuItem.Name = "редактироватьПрофильToolStripMenuItem";
            this.редактироватьПрофильToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.редактироватьПрофильToolStripMenuItem.Text = "Редактировать профиль";
            this.редактироватьПрофильToolStripMenuItem.Click += UpdateDataToolStripMenuItem_Click;
            // 
            // обновитьСписокЗаказовToolStripMenuItem
            // 
            this.обновитьСписокЗаказовToolStripMenuItem.Name = "обновитьСписокЗаказовToolStripMenuItem";
            this.обновитьСписокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.обновитьСписокЗаказовToolStripMenuItem.Text = "Обновить список заказов";
            this.обновитьСписокЗаказовToolStripMenuItem.Click += RefreshOrderListToolStripMenuItem_Click;
            // 
            // FormMainClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 900);
            this.Controls.Add(this.dataGridViewClientOrders);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMainClient";
            this.Text = "Клиент";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientOrders)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewClientOrders;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьЗаказToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьПрофильToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обновитьСписокЗаказовToolStripMenuItem;
    }
}