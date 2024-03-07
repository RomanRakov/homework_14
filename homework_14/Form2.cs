using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework_14
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Мировые войны")
            {
                LoadXmlFile("worldwars.xml");
            }
            else if (e.Node.Text == "Гражданские войны")
            {
                LoadXmlFile("civilwars.xml");
            }
            else if (e.Node.Text == "Религиозные войны")
            {
                LoadXmlFile("religiouswars.xml");
            }
        }
        private void LoadXmlFile(string fileName)
        {
            string filePath = Path.Combine(Application.StartupPath, "newfolder", fileName);
            if (System.IO.File.Exists(filePath))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePath);

                DataTable dataTable = ds.Tables[0];

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                foreach (DataColumn column in dataTable.Columns)
                {
                    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден: " + filePath);
            }
        }
    }
}
