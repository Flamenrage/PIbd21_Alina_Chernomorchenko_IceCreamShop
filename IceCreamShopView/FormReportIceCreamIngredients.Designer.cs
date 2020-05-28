using System;

namespace IceCreamShopView
{
    partial class FormReportIceCreamIngredients
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
            this.ReportIceCreamIngredientViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportBookingsViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportAssemblyDetailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonToPdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ReportIceCreamIngredientViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBookingsViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportAssemblyDetailViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportIceCreamIngredientViewModelBindingSource
            // 
            this.ReportIceCreamIngredientViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.ReportIceCreamIngredientViewModel);
            // 
            // ReportBookingsViewModelBindingSource
            // 
            this.ReportBookingsViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.ReportBookingsViewModel);
            // 
            // ReportAssemblyDetailViewModelBindingSource
            // 
            this.ReportAssemblyDetailViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.ReportIceCreamIngredientViewModel);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "IceCreamShopView.ReportCream.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(16, 33);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1253, 515);
            this.reportViewer.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1285, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(760, 1);
            this.buttonMake.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(219, 25);
            this.buttonMake.TabIndex = 2;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(1000, 1);
            this.buttonToPdf.Margin = new System.Windows.Forms.Padding(4);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(221, 25);
            this.buttonToPdf.TabIndex = 3;
            this.buttonToPdf.Text = "В PDF";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // FormReportIceCreamIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 559);
            this.Controls.Add(this.buttonToPdf);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormReportIceCreamIngredients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ингредиенты мороженого";
            ((System.ComponentModel.ISupportInitialize)(this.ReportIceCreamIngredientViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBookingsViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportAssemblyDetailViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.BindingSource ReportAssemblyDetailViewModelBindingSource;
        private System.Windows.Forms.BindingSource ReportBookingsViewModelBindingSource;
        private System.Windows.Forms.BindingSource ReportIceCreamIngredientViewModelBindingSource;
    }
}