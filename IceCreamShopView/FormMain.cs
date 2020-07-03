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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MainService service;
        private readonly IBookingService bookingService;
        private readonly ReportLogic reportLogic;
        private readonly WorkModeling modeling;
        private readonly BackUpAbstractLogic backUpLogic;

        public FormMain(MainService service, IBookingService bookingService, ReportLogic reportLogic, WorkModeling modeling, BackUpAbstractLogic backUpLogic)
        {
            InitializeComponent();
            this.service = service;
            this.bookingService = bookingService;
            this.reportLogic = reportLogic;
            this.modeling = modeling;
            this.backUpLogic = backUpLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(bookingService.Read(null), dataGridView);
                dataGridView.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void ингредиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIngredients>();
            form.ShowDialog();
        }

        private void мороженоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIceCreams>();
            form.ShowDialog();
        }
        private void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateBooking>();
            form.ShowDialog();
            LoadData();
        }
        private void buttonPayBooking_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.PayBooking(new ChangeStatusBindingModel { BookingId = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ingredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.SaveIceCreamsToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void iceCreamIngredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportIceCreamIngredients>();
            form.ShowDialog();
        }

        private void orderDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modeling.DoWork(); 
        }

        private void сообщенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMessages>();
            form.ShowDialog(); 
        }

        private void создатьБэкапToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpLogic != null)
                {
                    var dialog = new FolderBrowserDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        backUpLogic.CreateArchive(dialog.SelectedPath);
                        MessageBox.Show("Бэкап создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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