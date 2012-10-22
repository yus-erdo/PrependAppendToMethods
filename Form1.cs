using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace AppendPrependInMethod
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                DialogResult result = openFileDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog1.FileName;
                }
            }

            GetMethodsInFile(txtFilePath.Text);
        }

        private void GetMethodsInFile(string filePath)
        {
            cboxMethod.Items.Clear();

            using (var sr = new StreamReader(filePath))
            {
                foreach (Match match in Regex.Matches(sr.ReadToEnd(), AppendPrepend.MethodRegex))
                {
                    cboxMethod.Items.Add(match.Value.Trim());
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboxMethod.CheckedItems.Count == 0) return;

            var methodSignatures = new List<string>();

            foreach (string s in cboxMethod.CheckedItems)
            {                
                methodSignatures.Add(s);
            }

           
            var ap = new AppendPrepend(txtFilePath.Text);

            ap.Insert(txtPrepend.Text, txtAppend.Text, methodSignatures.ToArray());
        }
    }
}
