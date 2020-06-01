using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StorageView
{
    public partial class FormStorage : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<StorageIngredientViewModel> storageIngredients;
        public FormStorage()
        {
            InitializeComponent();
        }
        private void FormStorage_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("Ингредиент", "Ингредиент");
            dataGridView.Columns.Add("Количество", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (id.HasValue)
            {
                try
                {
                    StorageViewModel view = APIStorage.GetRequest<StorageViewModel>($"api/storage/getstorage?storageId={id.Value}");
                    if (view != null)
                    {
                        storageNameTextBox.Text = view.StorageName;
                        storageIngredients = view.StorageIngredients;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                storageIngredients = new List<StorageIngredientViewModel>();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(storageNameTextBox.Text))
            {
                MessageBox.Show("Заполните поле Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                APIStorage.PostRequest("api/storage/createorupdatestorage", new StorageBindingModel
                {
                    Id = id,
                    StorageName = storageNameTextBox.Text
                });

                MessageBox.Show("Склад создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadData()
        {
            try
            {
                if (storageIngredients != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var storageIngredient in storageIngredients)
                    {
                        dataGridView.Rows.Add(new object[] { storageIngredient.Id, storageIngredient.IngredientName, storageIngredient.Count });
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
