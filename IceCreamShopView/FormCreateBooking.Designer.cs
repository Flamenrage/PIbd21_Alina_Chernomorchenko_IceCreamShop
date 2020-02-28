namespace IceCreamShopView
{
    partial class FormCreateBooking
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
            this.components = new System.ComponentModel.Container();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.customerViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelIceCream = new System.Windows.Forms.Label();
            this.comboBoxIceCream = new System.Windows.Forms.ComboBox();
            this.iceCreamViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iceCreamViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(400, 122);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(111, 27);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(281, 122);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(111, 27);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelIceCream
            // 
            this.labelIceCream.AutoSize = true;
            this.labelIceCream.Location = new System.Drawing.Point(11, 19);
            this.labelIceCream.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIceCream.Name = "labelIceCream";
            this.labelIceCream.Size = new System.Drawing.Size(88, 17);
            this.labelIceCream.TabIndex = 10;
            this.labelIceCream.Text = "Мороженое:";
            // 
            // comboBoxIceCream
            // 
            this.comboBoxIceCream.DataSource = this.iceCreamViewModelBindingSource;
            this.comboBoxIceCream.DisplayMember = "IceCreamName";
            this.comboBoxIceCream.FormattingEnabled = true;
            this.comboBoxIceCream.Location = new System.Drawing.Point(107, 16);
            this.comboBoxIceCream.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxIceCream.Name = "comboBoxIceCream";
            this.comboBoxIceCream.Size = new System.Drawing.Size(385, 24);
            this.comboBoxIceCream.TabIndex = 11;
            this.comboBoxIceCream.ValueMember = "Id";
            this.comboBoxIceCream.SelectedIndexChanged += new System.EventHandler(this.comboBoxIceCream_SelectedIndexChanged);
            // 
            // iceCreamViewModelBindingSource
            // 
            this.iceCreamViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.IceCreamViewModel);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(11, 48);
            this.labelCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(90, 17);
            this.labelCount.TabIndex = 12;
            this.labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(107, 48);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(385, 22);
            this.textBoxCount.TabIndex = 13;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(11, 75);
            this.labelSum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(54, 17);
            this.labelSum.TabIndex = 14;
            this.labelSum.Text = "Сумма:";
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(107, 78);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(385, 22);
            this.textBoxSum.TabIndex = 15;
            // 
            // FormCreateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 155);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.comboBoxIceCream);
            this.Controls.Add(this.labelIceCream);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCreateBooking";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iceCreamViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelIceCream;
        private System.Windows.Forms.ComboBox comboBoxIceCream;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.BindingSource customerViewModelBindingSource;
        private System.Windows.Forms.BindingSource iceCreamViewModelBindingSource;
    }
}