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

        private Dictionary<int, (string, int)> iceCreamIngredients;

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
                    IceCreamViewModel view = service.Read(new IceCreamBindingModel
                    { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.IceCreamName;
                        textBoxPrice.Text = view.Price.ToString();
                        iceCreamIngredients = view.IceCreamIngredients;
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
                iceCreamIngredients = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
             try
            {
                if (iceCreamIngredients != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in iceCreamIngredients)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1,
                        pc.Value.Item2 });
                    }
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
                if (iceCreamIngredients.ContainsKey(form.Id))
                {
                    iceCreamIngredients[form.Id] = (form.IngredientName, form.Count);
                }
                else
                {
                    iceCreamIngredients.Add(form.Id, (form.IngredientName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormIceCreamIngredient>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = iceCreamIngredients[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    iceCreamIngredients[form.Id] = (form.IngredientName, form.Count);
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
                        iceCreamIngredients.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
            if (iceCreamIngredients == null || iceCreamIngredients.Count == 0)
            {
                MessageBox.Show("Заполните ингредиенты", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                service.CreateOrUpdate(new IceCreamBindingModel
                {
                    Id = id,
                    IceCreamName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    IceCreamIngredients = iceCreamIngredients
                });
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
