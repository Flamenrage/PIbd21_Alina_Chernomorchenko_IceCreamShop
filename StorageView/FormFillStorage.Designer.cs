namespace StorageView
{
    partial class FormFillStorage
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.comboBoxIngredient = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelcount = new System.Windows.Forms.Label();
            this.labelingredient = new System.Windows.Forms.Label();
            this.labelstorage = new System.Windows.Forms.Label();
            this.labelStorage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(173, 93);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(88, 26);
            this.ButtonCancel.TabIndex = 11;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(91, 93);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(79, 26);
            this.ButtonSave.TabIndex = 10;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // 
            // 
            this.comboBoxIngredient.FormattingEnabled = true;
            this.comboBoxIngredient.Location = new System.Drawing.Point(97, 33);
            this.comboBoxIngredient.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxIngredient.Name = "comboBoxIngredient";
            this.comboBoxIngredient.Size = new System.Drawing.Size(165, 21);
            this.comboBoxIngredient.TabIndex = 9;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(97, 60);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(165, 20);
            this.textBoxCount.TabIndex = 8;
            // 
            // 
            // 
            this.labelcount.AutoSize = true;
            this.labelcount.Location = new System.Drawing.Point(8, 63);
            this.labelcount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelcount.Name = "labelcount";
            this.labelcount.Size = new System.Drawing.Size(69, 13);
            this.labelcount.TabIndex = 7;
            this.labelcount.Text = "Количество:";
            // 
            // 
            // 
            this.labelingredient.AutoSize = true;
            this.labelingredient.Location = new System.Drawing.Point(9, 36);
            this.labelingredient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelingredient.Name = "labelingredient";
            this.labelingredient.Size = new System.Drawing.Size(66, 13);
            this.labelingredient.TabIndex = 6;
            this.labelingredient.Text = "Ингредиент:";
            // 
            // labelstorage
            // 
            this.labelstorage.AutoSize = true;
            this.labelstorage.Location = new System.Drawing.Point(9, 10);
            this.labelstorage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelstorage.Name = "labelstorage";
            this.labelstorage.Size = new System.Drawing.Size(41, 13);
            this.labelstorage.TabIndex = 12;
            this.labelstorage.Text = "Склад:";
            // 
            // 
            // 
            this.labelStorage.AutoSize = true;
            this.labelStorage.Location = new System.Drawing.Point(101, 10);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(0, 13);
            this.labelStorage.TabIndex = 13;
            // 
            // FormFillStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 140);
            this.Controls.Add(this.labelStorage);
            this.Controls.Add(this.labelstorage);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.comboBoxIngredient);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelcount);
            this.Controls.Add(this.labelingredient);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormFillStorage";
            this.Text = "Пополнить склад";
            this.Load += new System.EventHandler(this.FormFillStorage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.ComboBox comboBoxIngredient;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelcount;
        private System.Windows.Forms.Label labelingredient;
        private System.Windows.Forms.Label labelstorage;
        public System.Windows.Forms.Label labelStorage;
    }
}