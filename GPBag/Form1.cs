using GPBag.Models;
using GPBag.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using GPBag.Data.Models;
using GpBag.Service;
using System.Collections;

namespace GPBag
{
    public partial class Form : System.Windows.Forms.Form
    {
        public readonly GpGridService _gridService;
        public Form()
        {
            _gridService = new GpGridService();
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeDateTimePicker()
        {
            this.dateTimePicker1.Format = DateTimePickerFormat.Long;
            this.dateTimePicker1.ShowUpDown = true;
        }
        private void InitializeGrid()
        {
            var baggaageDetails = _gridService.GetBaggageDetails();
            dataGridView.DataSource = baggaageDetails;
            dataGridView.ColumnHeadersHeight = 50;
            decimal width = dataGridView.Width / dataGridView.ColumnCount;
            var columns = dataGridView.ColumnCount;
            for (var i = 0; i < columns; i++)
            {
                dataGridView.Columns[i].Width = (int)Math.Floor(width);
            }

            dataGridView.Columns["Bagsize"].ReadOnly = true;
            dataGridView.Columns["BaggageReceived"].ReadOnly = true;
            dataGridView.Columns["BaggageReturned"].ReadOnly = true;
            dataGridView.Columns["Price"].ReadOnly = true;
            dataGridView.Columns["Price"].HeaderText = "Price to be paid";
            dataGridView.Columns["Id"].Visible = false;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var valueToBeAdded = new BaggageGridModel
            {
                Bagsize = cmb_Size.SelectedItem.ToString(),
                Name = txt_Name.Text,
                Bagtype = txt_Type.Text,
                NoOfBoxes = Convert.ToInt32(txt_No.Text),
                RackNo = txt_PhNo.Text,
                BaggageReceived = dateTimePicker1.Value
            };
            _gridService.AddBaggageDetails(valueToBeAdded);
            var values = _gridService.GetBaggageDetails();

            dataGridView.DataSource = values;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var clickedColumn = senderGrid.Columns[e.ColumnIndex];

            if (clickedColumn is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 0)
            {

                BaggageGridModel rows = (BaggageGridModel)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem;

                if (rows.BaggageReturned == null)
                {
                    rows.BaggageReturned = DateTime.Now;
                }

                var releaseData = rows;

                _gridService.UpdateValues(releaseData);

                InitializeGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var source = (IList<BaggageGridModel>)dataGridView.DataSource;
            dataGridView.DataSource = source.Where(t => t.Name.ToLower().Contains(txtBox_Search.Text.ToLower())).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBox_Search.Text = "";
            InitializeGrid();
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void Checkout_Click(object sender, EventArgs e)
        {
            _gridService.CheckoutCurrentBaggage();
            InitializeGrid();

        }

        private void txt_PhNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            //groupBox3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            // groupBox3.Enabled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            parentclock.Enabled = true;
            timer1.Enabled = true;
            parentclock.Text = Convert.ToString(DateTime.Now);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //pictureBox1.Enabled = true;
            //pictureBox1.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Visible = false;
            //pictureBox1.Enabled=false;
        }

        private void txt_Type_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DownloadExcel_Click(object sender, EventArgs e)
        {

            var archiveDetails = _gridService.GetBaggageArchiveDetails();

            using (SaveFileDialog dialog = new SaveFileDialog() { Filter = "CSV|.csv", FileName = "GpBagDetails" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(new FileStream(dialog.FileName, FileMode.Create), Encoding.UTF8))
                    {

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"Id, Name,Baggage Received, Baggage Returned, Bag Size, BagType, Days, NoOfBoxes, Price, Rack No, RoomNo");

                        foreach (var details in archiveDetails)
                        {
                            sb.AppendLine($"{details.Id},{details.Name},{details.BaggageReceived},{details.BaggageReturned},{details.Bagsize},{details.Bagtype},{details.CalculatedDays},{details.NoOfBoxes},{details.Price},{details.RackNo},{details.RoomNo}");
                        }

                        sw.WriteLine(sb.ToString());

                        MessageBox.Show("File downloaded successfully");
                    }

                }
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = System.IO.Path.GetFullPath(dialog.FileName);
                    if (File.Exists(path))
                    {

                        var valuesFromCSV = File.ReadAllLines(path);

                            foreach(var value in valuesFromCSV.Skip(1).Where(t=>!string.IsNullOrEmpty(t)))
                        {
                            _gridService.AddBaggageDetails(GetValuesFromCSV(value));
                        }
                        InitializeGrid();
                        MessageBox.Show("Data uploaded successfully");

                    }
                }
            }
        }
        

        private BaggageGridModel GetValuesFromCSV(string value)
        {
            var model = value.Split(",");
            BaggageGridModel gridValue = new BaggageGridModel();
            gridValue.Name = model[1];
            gridValue.BaggageReceived = Convert.ToDateTime(model[2]);
            gridValue.BaggageReturned = Convert.ToDateTime(model[3]);
            gridValue.Bagsize = model[4];
            gridValue.Bagtype = model[5];
            Int32.TryParse(model[7], out int result);
            gridValue.NoOfBoxes = result;
            
            gridValue.RackNo = model[9];
            gridValue.RoomNo = model[10];


            return gridValue;

        }
    }
}
