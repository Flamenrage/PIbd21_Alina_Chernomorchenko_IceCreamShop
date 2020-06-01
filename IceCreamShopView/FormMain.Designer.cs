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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonСreateBooking = new System.Windows.Forms.Button();
            this.ButtonTakeBookingInWork = new System.Windows.Forms.Button();
            this.ButtonBookingReady = new System.Windows.Forms.Button();
            this.ButtonPayBooking = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.toolStripMenuItem1,
            this.пополнитьСкладToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(906, 24);
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
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // 
            // 
            this.ингредиентыToolStripMenuItem.Name = "ингредиентыToolStripMenuItem";
            this.ингредиентыToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ингредиентыToolStripMenuItem.Text = "Ингредиенты";
            this.ингредиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // мороженоеToolStripMenuItem
            // 
            this.мороженоеToolStripMenuItem.Name = "мороженоеToolStripMenuItem";
            this.мороженоеToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.мороженоеToolStripMenuItem.Text = "Мороженое";
            this.мороженоеToolStripMenuItem.Click += new System.EventHandler(this.мороженоеToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
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
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокМороженогоToolStripMenuItem
            // 
            this.списокМороженогоToolStripMenuItem.Name = "списокМороженогоToolStripMenuItem";
            this.списокМороженогоToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.списокМороженогоToolStripMenuItem.Text = "Список мороженого";
            this.списокМороженогоToolStripMenuItem.Click += new System.EventHandler(this.списокМороженогоToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // списокИнгредиентовПоМороженомуToolStripMenuItem
            // 
            this.списокИнгредиентовПоМороженомуToolStripMenuItem.Name = "списокИнгредиентовПоМороженомуToolStripMenuItem";
            this.списокИнгредиентовПоМороженомуToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.списокИнгредиентовПоМороженомуToolStripMenuItem.Text = "Список ингредиентов по мороженому";
            this.списокИнгредиентовПоМороженомуToolStripMenuItem.Click += new System.EventHandler(this.списокИнгредиентовПоМороженомуToolStripMenuItem_Click);
            // 
            // списокИнгредиентовToolStripMenuItem
            // 
            this.списокИнгредиентовToolStripMenuItem.Name = "списокИнгредиентовToolStripMenuItem";
            this.списокИнгредиентовToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.списокИнгредиентовToolStripMenuItem.Text = "Список ингредиентов";
            this.списокИнгредиентовToolStripMenuItem.Click += new System.EventHandler(this.списокИнгредиентовToolStripMenuItem_Click);
            // 
            // списокИнгредиентовПоСкладамToolStripMenuItem
            // 
            this.списокИнгредиентовПоСкладамToolStripMenuItem.Name = "списокИнгредиентовПоСкладамToolStripMenuItem";
            this.списокИнгредиентовПоСкладамToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.списокИнгредиентовПоСкладамToolStripMenuItem.Text = "Список ингредиентов по складам";
            this.списокИнгредиентовПоСкладамToolStripMenuItem.Click += new System.EventHandler(this.списокИнгредиентовПоСкладамToolStripMenuItem_Click);
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(2, 23);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(738, 307);
            this.dataGridView.TabIndex = 1;
            // 
            // ButtonСreateBooking
            // 
            this.ButtonСreateBooking.Location = new System.Drawing.Point(757, 45);
            this.ButtonСreateBooking.Name = "ButtonСreateBooking";
            this.ButtonСreateBooking.Size = new System.Drawing.Size(126, 29);
            this.ButtonСreateBooking.TabIndex = 2;
            this.ButtonСreateBooking.Text = "Создать заказ";
            this.ButtonСreateBooking.UseVisualStyleBackColor = true;
            this.ButtonСreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // ButtonTakeBookingInWork
            // 
            this.ButtonTakeBookingInWork.Location = new System.Drawing.Point(757, 89);
            this.ButtonTakeBookingInWork.Name = "ButtonTakeBookingInWork";
            this.ButtonTakeBookingInWork.Size = new System.Drawing.Size(126, 40);
            this.ButtonTakeBookingInWork.TabIndex = 3;
            this.ButtonTakeBookingInWork.Text = "Отдать на выполнение";
            this.ButtonTakeBookingInWork.UseVisualStyleBackColor = true;
            this.ButtonTakeBookingInWork.Click += new System.EventHandler(this.buttonTakeBookingInWork_Click);
            // 
            // ButtonBookingReady
            // 
            this.ButtonBookingReady.Location = new System.Drawing.Point(757, 144);
            this.ButtonBookingReady.Name = "ButtonBookingReady";
            this.ButtonBookingReady.Size = new System.Drawing.Size(126, 29);
            this.ButtonBookingReady.TabIndex = 4;
            this.ButtonBookingReady.Text = "Заказ готов";
            this.ButtonBookingReady.UseVisualStyleBackColor = true;
            this.ButtonBookingReady.Click += new System.EventHandler(this.buttonBookingReady_Click);
            // 
            // ButtonPayBooking
            // 
            this.ButtonPayBooking.Location = new System.Drawing.Point(757, 189);
            this.ButtonPayBooking.Name = "ButtonPayBooking";
            this.ButtonPayBooking.Size = new System.Drawing.Size(126, 29);
            this.ButtonPayBooking.TabIndex = 5;
            this.ButtonPayBooking.Text = "Заказ оплачен";
            this.ButtonPayBooking.UseVisualStyleBackColor = true;
            this.ButtonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Location = new System.Drawing.Point(757, 238);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(126, 29);
            this.ButtonRef.TabIndex = 6;
            this.ButtonRef.Text = "Обновить список";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 337);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonPayBooking);
            this.Controls.Add(this.ButtonBookingReady);
            this.Controls.Add(this.ButtonTakeBookingInWork);
            this.Controls.Add(this.ButtonСreateBooking);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
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
        private System.Windows.Forms.Button ButtonTakeBookingInWork;
        private System.Windows.Forms.Button ButtonBookingReady;
        private System.Windows.Forms.Button ButtonPayBooking;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокМороженогоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИнгредиентовПоМороженомуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИнгредиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИнгредиентовПоСкладамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
    }
}

