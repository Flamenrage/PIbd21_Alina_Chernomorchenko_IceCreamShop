namespace IceCreamShopView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer Ingredients = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Ingredients != null))
            {
                Ingredients.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокИнгредиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ингредиентыПоМороженомуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ингредиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мороженоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iceCreamIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iceCreamNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateImplementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookingViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCreateBooking = new System.Windows.Forms.Button();
            this.buttonTakeBookingInWork = new System.Windows.Forms.Button();
            this.buttonBookingReady = new System.Windows.Forms.Button();
            this.buttonPayBooking = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчетыToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1147, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокИнгредиентовToolStripMenuItem,
            this.ингредиентыПоМороженомуToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокИнгредиентовToolStripMenuItem
            // 
            this.списокИнгредиентовToolStripMenuItem.Name = "списокИнгредиентовToolStripMenuItem";
            this.списокИнгредиентовToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.списокИнгредиентовToolStripMenuItem.Text = "Список ингредиентов";
            this.списокИнгредиентовToolStripMenuItem.Click += new System.EventHandler(this.списокИнгредиентовToolStripMenuItem_Click);
            // 
            // ингредиентыПоМороженомуToolStripMenuItem
            // 
            this.ингредиентыПоМороженомуToolStripMenuItem.Name = "ингредиентыПоМороженомуToolStripMenuItem";
            this.ингредиентыПоМороженомуToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.ингредиентыПоМороженомуToolStripMenuItem.Text = "Ингредиенты по мороженому";
            this.ингредиентыПоМороженомуToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыПоМороженомуToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(305, 26);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ингредиентыToolStripMenuItem,
            this.мороженоеToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // ингредиентыToolStripMenuItem
            // 
            this.ингредиентыToolStripMenuItem.Name = "ингредиентыToolStripMenuItem";
            this.ингредиентыToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ингредиентыToolStripMenuItem.Text = "Ингредиенты";
            this.ингредиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // мороженоеToolStripMenuItem
            // 
            this.мороженоеToolStripMenuItem.Name = "мороженоеToolStripMenuItem";
            this.мороженоеToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.мороженоеToolStripMenuItem.Text = "Мороженое";
            this.мороженоеToolStripMenuItem.Click += new System.EventHandler(this.мороженоеToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.iceCreamIdDataGridViewTextBoxColumn,
            this.iceCreamNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.dateCreateDataGridViewTextBoxColumn,
            this.dateImplementDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.bookingViewModelBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 42);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(887, 415);
            this.dataGridView.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // iceCreamIdDataGridViewTextBoxColumn
            // 
            this.iceCreamIdDataGridViewTextBoxColumn.DataPropertyName = "IceCreamId";
            this.iceCreamIdDataGridViewTextBoxColumn.HeaderText = "IceCreamId";
            this.iceCreamIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iceCreamIdDataGridViewTextBoxColumn.Name = "iceCreamIdDataGridViewTextBoxColumn";
            this.iceCreamIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.iceCreamIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.iceCreamIdDataGridViewTextBoxColumn.Visible = false;
            this.iceCreamIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // iceCreamNameDataGridViewTextBoxColumn
            // 
            this.iceCreamNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iceCreamNameDataGridViewTextBoxColumn.DataPropertyName = "IceCreamName";
            this.iceCreamNameDataGridViewTextBoxColumn.HeaderText = "Мороженое";
            this.iceCreamNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iceCreamNameDataGridViewTextBoxColumn.Name = "iceCreamNameDataGridViewTextBoxColumn";
            this.iceCreamNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.iceCreamNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.countDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            this.countDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            this.sumDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.sumDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            this.sumDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dateCreateDataGridViewTextBoxColumn
            // 
            this.dateCreateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateCreateDataGridViewTextBoxColumn.DataPropertyName = "DateCreate";
            this.dateCreateDataGridViewTextBoxColumn.HeaderText = "Дата создания";
            this.dateCreateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateCreateDataGridViewTextBoxColumn.Name = "dateCreateDataGridViewTextBoxColumn";
            this.dateCreateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dateImplementDataGridViewTextBoxColumn
            // 
            this.dateImplementDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateImplementDataGridViewTextBoxColumn.DataPropertyName = "DateImplement";
            this.dateImplementDataGridViewTextBoxColumn.HeaderText = "Дата выполнения";
            this.dateImplementDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateImplementDataGridViewTextBoxColumn.Name = "dateImplementDataGridViewTextBoxColumn";
            this.dateImplementDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateImplementDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // bookingViewModelBindingSource
            // 
            this.bookingViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.BookingViewModel);
            // 
            // buttonCreateBooking
            // 
            this.buttonCreateBooking.Location = new System.Drawing.Point(907, 42);
            this.buttonCreateBooking.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateBooking.Name = "buttonCreateBooking";
            this.buttonCreateBooking.Size = new System.Drawing.Size(224, 39);
            this.buttonCreateBooking.TabIndex = 2;
            this.buttonCreateBooking.Text = "Создать заказ";
            this.buttonCreateBooking.UseVisualStyleBackColor = true;
            this.buttonCreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // buttonTakeBookingInWork
            // 
            this.buttonTakeBookingInWork.Location = new System.Drawing.Point(907, 89);
            this.buttonTakeBookingInWork.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTakeBookingInWork.Name = "buttonTakeBookingInWork";
            this.buttonTakeBookingInWork.Size = new System.Drawing.Size(224, 39);
            this.buttonTakeBookingInWork.TabIndex = 3;
            this.buttonTakeBookingInWork.Text = "Отдать на выполнение";
            this.buttonTakeBookingInWork.UseVisualStyleBackColor = true;
            this.buttonTakeBookingInWork.Click += new System.EventHandler(this.buttonTakeBookingInWork_Click);
            // 
            // buttonBookingReady
            // 
            this.buttonBookingReady.Location = new System.Drawing.Point(907, 135);
            this.buttonBookingReady.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBookingReady.Name = "buttonBookingReady";
            this.buttonBookingReady.Size = new System.Drawing.Size(224, 39);
            this.buttonBookingReady.TabIndex = 4;
            this.buttonBookingReady.Text = "Заказ готов";
            this.buttonBookingReady.UseVisualStyleBackColor = true;
            this.buttonBookingReady.Click += new System.EventHandler(this.buttonBookingReady_Click);
            // 
            // buttonPayBooking
            // 
            this.buttonPayBooking.Location = new System.Drawing.Point(907, 182);
            this.buttonPayBooking.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPayBooking.Name = "buttonPayBooking";
            this.buttonPayBooking.Size = new System.Drawing.Size(224, 39);
            this.buttonPayBooking.TabIndex = 5;
            this.buttonPayBooking.Text = "Заказ оплачен";
            this.buttonPayBooking.UseVisualStyleBackColor = true;
            this.buttonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(907, 229);
            this.buttonRef.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(224, 39);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 460);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayBooking);
            this.Controls.Add(this.buttonBookingReady);
            this.Controls.Add(this.buttonTakeBookingInWork);
            this.Controls.Add(this.buttonCreateBooking);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Лавка мороженого";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ингредиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мороженоеToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateBooking;
        private System.Windows.Forms.Button buttonTakeBookingInWork;
        private System.Windows.Forms.Button buttonBookingReady;
        private System.Windows.Forms.Button buttonPayBooking;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.BindingSource bookingViewModelBindingSource;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerFIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iceCreamIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iceCreamNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateImplementDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокИнгредиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ингредиентыПоМороженомуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
    }
}

