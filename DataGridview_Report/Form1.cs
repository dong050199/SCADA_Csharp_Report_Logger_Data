using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridview_Report
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        DataTable dtdisplay = new DataTable();
        Timer UpdateTimer = new Timer();
        DataTable dataBBMR = new DataTable();

        public Form1()
        {
            InitializeComponent();

            dt.Columns.Add("TimeStamp");
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");

            dtdisplay.Columns.Add("TimeStamp");
            dtdisplay.Columns.Add("Key");
            dtdisplay.Columns.Add("Value");

            UpdateTimer.Interval = 1000;
            UpdateTimer.Tick += UpdateTimer_Tick;
            UpdateTimer.Start();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            dt.Rows.Add(DateTime.Now, "true", "dong dep trai");
            if (dt.Rows.Count > 10)
            {
                dt.Rows.RemoveAt(0);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dtdisplay.Rows.Clear();

            string filter = $"TimeStamp > '{dateTimePicker1.Value}' AND TimeStamp <= '{dateTimePicker2.Value}'";
            
            DataRow[] resule = dt.Select(filter);

            for (int i = 0; i < resule.Length; i++)
            {

                string[] data = new string[] { $"{ resule[i]["TimeStamp"]}", $"{resule[i]["Key"]}", $"{resule[i]["Value"]}" };
                //dtdisplay.Rows.Add(data);
                dtdisplay.Rows.Add(resule[i]);
            }

            dataGridView1.DataSource = dtdisplay;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dt.Rows.Count > 10)
            {
                dt.Rows.RemoveAt(0);
            }
        }
    }
}
