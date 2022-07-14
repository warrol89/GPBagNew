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

namespace GPBag
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeDateTimePicker()
        {
            this.dateTimePicker1.Format = DateTimePickerFormat.Time;
            this.dateTimePicker1.ShowUpDown = true;
        }
        private void InitializeGrid()
        {
            dataGridView1.DataSource = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV();
            dataGridView1.Columns["Bagsize"].ReadOnly = true;
            dataGridView1.Columns["BaggageReceived"].ReadOnly = true;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var valueToBeAdded = new BaggageGridModel
            {
                Bagsize = cmb_Size.SelectedItem.ToString(),
                Name = txt_Name.Text,
                NoOfBoxes = Convert.ToInt32(txt_No.Text),
                RackNo = txt_PhNo.Text,
                BaggageReceived = dateTimePicker1.Value
            };

            CSV_Read_Write<BaggageGridModel>.WriteDataToCSV(valueToBeAdded);
            var values = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV();

            dataGridView1.DataSource = values;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var clickedColumn = senderGrid.Columns[e.ColumnIndex];

            if (clickedColumn is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var values = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV();
                var send = sender;
                var rows = ((DataGridView)send).Rows[e.RowIndex];
                var name = (string)rows.Cells[1].Value;
                var RackNo = (string)rows.Cells[2].Value;
                var bagSize =  (string)rows.Cells[3].Value;
                var NoOfBoxes = (int)rows.Cells[4].Value;

                var csvValues = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV();
                var source = (IList<BaggageGridModel>)dataGridView1.DataSource;
                source.Where(t => t.Name == name && t.RackNo == RackNo && t.Bagsize == bagSize && t.NoOfBoxes == NoOfBoxes).FirstOrDefault().BaggageReturned = DateTime.Now;

                File.Delete("bagdata.csv");

                foreach(var item in source)
                {
                    CSV_Read_Write<BaggageGridModel>.WriteDataToCSV(item);
                }
                InitializeGrid();
                var events = e;
            }
        }
    }
}
