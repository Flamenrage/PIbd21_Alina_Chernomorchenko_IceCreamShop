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
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.BindingModels;

namespace IceCreamShopView
{
    public partial class FormClients : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IClientLogic logic;

        public FormClients(IClientLogic clientLogic)
        {
            InitializeComponent();
            this.logic = clientLogic;
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(logic.Read(null), dataGridViewClients);                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            if (dataGridViewClients.SelectedRows.Count == 1)
            {
                logic.Delete(new ClientBindingModel()
                {
                    Id = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value)
                });
                LoadData();
            }
        }
    }
}
