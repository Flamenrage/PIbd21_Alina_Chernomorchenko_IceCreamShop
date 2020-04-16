using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ServicesDal;
using System;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using Unity;


namespace IceCreamShopView
{
    public partial class FormReportIceCreamIngredients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportIceCreamIngredients(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetIceCreamIngredient();
                ReportDataSource source = new ReportDataSource("DataSetAD", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        [Obsolete]
        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveIceCreamIngredientsToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}