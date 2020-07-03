using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceDAL.ServicesDal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace IceCreamShopView
{
    public partial class FormCreateBooking : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public readonly IIceCreamService serviceP;

        public readonly MainService serviceM;
        private readonly IClientLogic serviceC;

        public FormCreateBooking(IIceCreamService serviceP,
        MainService serviceM, IClientLogic serviceC)
        {
            InitializeComponent();
            this.serviceP = serviceP;
            this.serviceM = serviceM;
            this.serviceC = serviceC;
        }
        private void comboBoxIceCream_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void CalcSum()
        {
            if (comboBoxIceCream.SelectedValue != null &&
            !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxIceCream.SelectedValue);
                    IceCreamViewModel iceCream = serviceP.Read(new IceCreamBindingModel
                    { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * iceCream?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void FormCreateBooking_Load(object sender, EventArgs e)
        {
            try
            {
                List<IceCreamViewModel> listP = serviceP.Read(null);
                if (listP != null)
                {
                    comboBoxIceCream.DisplayMember = "IceCreamName";
                    comboBoxIceCream.ValueMember = "Id";
                    comboBoxIceCream.DataSource = listP;
                    comboBoxIceCream.SelectedItem = null;
                }
                var listClients = serviceC.Read(null);
                if (listClients != null)
                {
                    comboBoxClients.DisplayMember = "ClientFIO";
                    comboBoxClients.DataSource = listClients;
                    comboBoxClients.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClients.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxIceCream.SelectedValue == null)
            {
                MessageBox.Show("Выберите мороженое", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.CreateBooking(new CreateBookingBindingModel
                {
                    IceCreamId = Convert.ToInt32(comboBoxIceCream.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),
                    ClientId = (comboBoxClients.SelectedItem as ClientViewModel).Id,
                    ClientFIO = (comboBoxClients.SelectedItem as ClientViewModel).ClientFIO
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
        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}