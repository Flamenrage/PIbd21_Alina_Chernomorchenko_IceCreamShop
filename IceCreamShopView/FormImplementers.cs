using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;


namespace IceCreamShopView
{
    public partial class FormImplementers : Form
    {
        [Dependency]
        public new IUnityContainer Container { set; get; }
        private readonly IImplementerLogic implementerLogic;

        public FormImplementers(IImplementerLogic implementerLogic)
        {
            InitializeComponent();
            this.implementerLogic = implementerLogic;
        }


        private void LoadData()
        {
            dataGridViewImplementers.DataSource = implementerLogic.Read(null);
            dataGridViewImplementers.Columns[0].Visible = false;
        }

        private void buttonAddImplementer_Click(object sender, EventArgs e)
        {
            try
            {
                var form = Container.Resolve<FormImplementer>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    implementerLogic.CreateOrUpdate(new ImplementerBindingModel()
                    {
                        ImplementerFIO = form.ImplementerFIO,
                        WorkingTime = form.ImplementerWorkTime,
                        PauseTime = form.ImplementerDelay
                    });
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdateImplementer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewImplementers.SelectedRows.Count == 1)
                {
                    var form = Container.Resolve<FormImplementer>();
                    form.ImplementerFIO = dataGridViewImplementers.SelectedRows[0].Cells[1].Value.ToString();
                    form.ImplementerWorkTime = Convert.ToInt32(dataGridViewImplementers.SelectedRows[0].Cells[2].Value);
                    form.ImplementerDelay = Convert.ToInt32(dataGridViewImplementers.SelectedRows[0].Cells[3].Value);
                    form.Id = Convert.ToInt32(dataGridViewImplementers.SelectedRows[0].Cells[0].Value);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        implementerLogic.CreateOrUpdate(new ImplementerBindingModel()
                        {
                            Id = form.Id,
                            ImplementerFIO = form.ImplementerFIO,
                            WorkingTime = form.ImplementerWorkTime,
                            PauseTime = form.ImplementerDelay
                        });
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteImplementer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewImplementers.SelectedRows.Count == 1)
                {
                    implementerLogic.Delete(new ImplementerBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridViewImplementers.SelectedRows[0].Cells[0].Value),
                        ImplementerFIO = dataGridViewImplementers.SelectedRows[0].Cells[1].Value.ToString(),
                        WorkingTime = Convert.ToInt32(dataGridViewImplementers.SelectedRows[0].Cells[2].Value),
                        PauseTime = Convert.ToInt32(dataGridViewImplementers.SelectedRows[0].Cells[3].Value)
                    });
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormImplementers_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
