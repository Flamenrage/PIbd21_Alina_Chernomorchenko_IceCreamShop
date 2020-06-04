namespace IceCreamShopView
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ингредиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мороженоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокМороженогоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИнгредиентовПоМороженомуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИнгредиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИнгредиентовПоСкладамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonСreateBooking = new System.Windows.Forms.Button();
            this.ButtonPayBooking = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem,
            this.запускРаботToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1208, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ингредиентыToolStripMenuItem,
            this.мороженоеToolStripMenuItem,
            this.складыToolStripMenuItem,
            this.клиентыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // ингредиентыToolStripMenuItem
            // 
            this.ингредиентыToolStripMenuItem.Name = "ингредиентыToolStripMenuItem";
            this.ингредиентыToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.ингредиентыToolStripMenuItem.Text = "Ингредиенты";
            this.ингредиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // мороженоеToolStripMenuItem
            // 
            this.мороженоеToolStripMenuItem.Name = "мороженоеToolStripMenuItem";
            this.мороженоеToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.мороженоеToolStripMenuItem.Text = "Мороженое";
            this.мороженоеToolStripMenuItem.Click += new System.EventHandler(this.мороженоеToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокМороженогоToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.списокИнгредиентовПоМороженомуToolStripMenuItem,
            this.списокИнгредиентовToolStripMenuItem,
            this.списокИнгредиентовПоСкладамToolStripMenuItem,
            this.списокСкладовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокМороженогоToolStripMenuItem
            // 
            this.списокМороженогоToolStripMenuItem.Name = "списокМороженогоToolStripMenuItem";
            this.списокМороженогоToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.списокМороженогоToolStripMenuItem.Text = "Список мороженого";
            this.списокМороженогоToolStripMenuItem.Click += new System.EventHandler(this.списокМороженогоToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // списокИнгредиентовПоМороженомуToolStripMenuItem
            // 
            this.списокИнгредиентовПоМороженомуToolStripMenuItem.Name = "списокИнгредиентовПоМороженомуToolStripMenuItem";
            this.списокИнгредиентовПоМороженомуToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.списокИнгредиентовПоМороженомуToolStripMenuItem.Text = "Список ингредиентов по мороженому";
            this.списокИнгредиентовПоМороженомуToolStripMenuItem.Click += new System.EventHandler(this.списокИнгредиентовПоМороженомуToolStripMenuItem_Click);
            // 
            // списокИнгредиентовToolStripMenuItem
            // 
            this.списокИнгредиентовToolStripMenuItem.Name = "списокИнгредиентовToolStripMenuItem";
            this.списокИнгредиентовToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.списокИнгредиентовToolStripMenuItem.Text = "Список ингредиентов";
            this.списокИнгредиентовToolStripMenuItem.Click += new System.EventHandler(this.списокИнгредиентовToolStripMenuItem_Click);
            // 
            // списокИнгредиентовПоСкладамToolStripMenuItem
            // 
            this.списокИнгредиентовПоСкладамToolStripMenuItem.Name = "списокИнгредиентовПоСкладамToolStripMenuItem";
            this.списокИнгредиентовПоСкладамToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.списокИнгредиентовПоСкладамToolStripMenuItem.Text = "Список ингредиентов по складам";
            this.списокИнгредиентовПоСкладамToolStripMenuItem.Click += new System.EventHandler(this.списокИнгредиентовПоСкладамToolStripMenuItem_Click);
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(363, 26);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 28);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(984, 378);
            this.dataGridView.TabIndex = 1;
            // 
            // ButtonСreateBooking
            // 
            this.ButtonСreateBooking.Location = new System.Drawing.Point(1009, 55);
            this.ButtonСreateBooking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonСreateBooking.Name = "ButtonСreateBooking";
            this.ButtonСreateBooking.Size = new System.Drawing.Size(168, 36);
            this.ButtonСreateBooking.TabIndex = 2;
            this.ButtonСreateBooking.Text = "Создать заказ";
            this.ButtonСreateBooking.UseVisualStyleBackColor = true;
            this.ButtonСreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // ButtonPayBooking
            // 
            this.ButtonPayBooking.Location = new System.Drawing.Point(1009, 233);
            this.ButtonPayBooking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonPayBooking.Name = "ButtonPayBooking";
            this.ButtonPayBooking.Size = new System.Drawing.Size(168, 36);
            this.ButtonPayBooking.TabIndex = 5;
            this.ButtonPayBooking.Text = "Заказ оплачен";
            this.ButtonPayBooking.UseVisualStyleBackColor = true;
            this.ButtonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Location = new System.Drawing.Point(1009, 293);
            this.ButtonRef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(168, 36);
            this.ButtonRef.TabIndex = 6;
            this.ButtonRef.Text = "Обновить список";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.исполнителиToolStripMenuItem.Text = "исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 415);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonPayBooking);
            this.Controls.Add(this.ButtonСreateBooking);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMain";
            this.Text = "Лавка Мороженого";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ингредиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мороженоеToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonСreateBooking;
        private System.Windows.Forms.Button ButtonPayBooking;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокМороженогоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИнгредиентовПоМороженомуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИнгредиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИнгредиентовПоСкладамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;  
    }
}

