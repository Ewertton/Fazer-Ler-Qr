using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using BarcodeLib.BarcodeReader;
using MessagingToolkit.QRCode.Codec;

namespace Codificador_Descodificador_QrCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ler_Click(object sender, EventArgs e)
        {
            Decoder read = new Decoder();

            read.ShowDialog();
        }

        private void criar_Click(object sender, EventArgs e)
        {
            Encoder write = new Encoder();

            write.ShowDialog();
        }
    }
}
