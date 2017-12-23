using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SELab01Example;
using ClassLibrary;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YAMLFile file = new YAMLFile();
            string bill = file.CreateBill();
            String[] words = bill.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length - 6; i += 7)
            {
                dataGridView1.Rows.Add(words[i], words[i + 1], words[i + 2], words[i + 3], words[i + 4], words[i + 5], words[i + 6]);
            }
        }
    }
}
