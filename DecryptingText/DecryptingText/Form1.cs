using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DecryptingText
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenEncFile();
        }

        private static void OpenEncFile()
        {
            var ofd = new OpenFileDialog {Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"};
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            var fileStr = Decrypt.Decoder(Decrypt.FileReader(ofd.FileName));

            var sfd = new SaveFileDialog {Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"};
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            var filename = sfd.FileName;
            var sw = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.Write), Encoding.Unicode);
            foreach (var word in fileStr)
                sw.WriteLine(word);
            sw.Close();
        }
    }
}
