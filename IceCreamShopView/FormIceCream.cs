using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace IceCreamShopView
{
    public partial class FormIceCream : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IIceCreamService service;

        private int? id;

        private List<IceCreamIngredientViewModel> IceCreamIngredients;

        public FormIceCream(IIceCreamService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormIceCream_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    IceCreamViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.IceCreamName;
                        textBoxPrice.Text = view.Price.ToString();
                        IceCreamIngredients = view.IceCreamIngredients;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                IceCreamIngredients = new List<IceCreamIngredientViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (IceCreamIngredients != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = IceCreamIngredients;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIceCreamIngredient>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ModelView != null)
                {
                    if (id.HasValue)
                    {
                        form.ModelView.IceCreamId = id.Value;
                    }
                    IceCreamIngredients.Add(form.ModelView);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormIceCreamIngredient>();
                form.ModelView =
                IceCreamIngredients[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    IceCreamIngredients[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                    form.ModelView;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        IceCreamIngredients.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (IceCreamIngredients == null || IceCreamIngredients.Count == 0)
            {
                MessageBox.Show("Заполните ингредиенты", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<IceCreamIngredientBindingModel> IceCreamIngredientBM = new
                List<IceCreamIngredientBindingModel>();
                for (int i = 0; i < IceCreamIngredients.Count; ++i)
                {
                    IceCreamIngredientBM.Add(new IceCreamIngredientBindingModel
                    {
                        Id = IceCreamIngredients[i].Id,
                        IceCreamId = IceCreamIngredients[i].IceCreamId,
                        IngredientId = IceCreamIngredients[i].IngredientId,
                        Count = IceCreamIngredients[i].Count
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new IceCreamBindingModel
                    {
                        Id = id.Value,
                        IceCreamName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        IceCreamIngredients = IceCreamIngredientBM
                    });
                }
                else
                {
                    service.AddElement(new IceCreamBindingModel
                    {
                        IceCreamName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        IceCreamIngredients = IceCreamIngredientBM
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
