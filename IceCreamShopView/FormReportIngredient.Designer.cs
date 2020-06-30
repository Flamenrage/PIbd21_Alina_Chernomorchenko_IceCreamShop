namespace IceCreamShopView
{
    partial class FormReportIngredient
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportStorageIngredientViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.StorageIngredientViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportStorageIngredientViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StorageIngredientViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(726, 12);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(174, 38);
            this.ButtonToPdf.TabIndex = 1;
            this.ButtonToPdf.Text = "В Pdf";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "IceCreamShopView.ReportStorageIngredient.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(10, 61);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(889, 402);
            this.reportViewer.TabIndex = 2;
            this.reportViewer.Load += new System.EventHandler(this.ReportViewer_Load);
            // 
            // StorageIngredientViewModelBindingSource
            // 
            this.StorageIngredientViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.StorageIngredientViewModel);
            // 
            // FormReportIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 467);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.ButtonToPdf);
            this.Name = "FormReportIngredient";
            this.Text = "Ингредиенты по складам";
            ((System.ComponentModel.ISupportInitialize)(this.ReportStorageIngredientViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StorageIngredientViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ReportStorageIngredientViewModelBindingSource;
        private System.Windows.Forms.Button ButtonToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource StorageIngredientViewModelBindingSource;
    }
}