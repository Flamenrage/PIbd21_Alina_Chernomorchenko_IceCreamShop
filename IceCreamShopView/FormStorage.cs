using System;
using System.Windows.Forms;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using Unity;

namespace IceCreamShopView
{
    public partial class FormStorage : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IStorageLogic logic;
        private int? id;
        public FormStorage(IStorageLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormStorage_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.StorageName;
                    }

                    var storageList = logic.GetList();

                    var storageIngredients = storageList[0].StorageIngredients;
                    for (int i = 0; i < storageList.Count; ++i)
                    {
                        if (storageList[i].Id == id)
                        {
                            storageIngredients = storageList[i].StorageIngredients;
                        }
                    }
                    if (storageIngredients != null)
                    {
                        dataGridView.DataSource = storageIngredients;
                        dataGridView.Columns[0].Visible = false;
                        dataGridView.Columns[1].Visible = false;
                        dataGridView.Columns[2].Visible = false;
                        dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    logic.UpdElement(new StorageBindingModel
                    {
                        Id = id.Value,
                        StorageName = textBoxName.Text
                    });
                }
                else
                {
                    logic.AddElement(new StorageBindingModel
                    {
                        StorageName = textBoxName.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}