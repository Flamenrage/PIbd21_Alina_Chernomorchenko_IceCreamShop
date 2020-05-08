using IceCreamShopServiceDAL.ServicesDal;
using System;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;

namespace IceCreamShopView
{
    public partial class FormReportStorageIngredient : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly IStorageLogic storageLogic;
        public FormReportStorageIngredient(ReportLogic logic, IStorageLogic storageLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.storageLogic = storageLogic;
        }
        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveStorageIngredientToExcelFile(new ReportBindingModel { FileName = dialog.FileName });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportStorageIngredient_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var dict = storageLogic.GetList();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var storage in dict)
                    {
                        int ingredientSum = 0;
                        dataGridView.Rows.Add(new object[] { storage.StorageName, "", "" });
                        foreach (var ingredient in storage.StorageIngredients)
                        {
                            dataGridView.Rows.Add(new object[] { "", ingredient.IngredientName, ingredient.Count });
                            ingredientSum += ingredient.Count;
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", ingredientSum });
                        dataGridView.Rows.Add(new object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
