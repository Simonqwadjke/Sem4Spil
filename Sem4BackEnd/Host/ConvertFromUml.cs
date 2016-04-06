using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Host {
    public partial class ConvertFromUml : Form {
        public ConvertFromUml() {
            InitializeComponent();
        }

        private void btnConvertProperties_Click(object sender, EventArgs e) {
            String[] input = rtbInputProperties.Lines;
            foreach(String line in input) {
                String[] words = line.Split(" ");
                foreach(String word in words) {

                }
            }
        }
    }
}
