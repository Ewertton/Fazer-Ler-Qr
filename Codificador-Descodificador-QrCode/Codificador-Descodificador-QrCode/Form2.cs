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
    public partial class Decoder : Form
    {
        public Decoder()
        {
            InitializeComponent();
        }

        private FilterInfoCollection Dispositivos;

        private VideoCaptureDevice Video;

        private void Decoder_Load(object sender, EventArgs e)
        {
            Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo x in Dispositivos)
            {
                comboBox1.Items.Add(x.Name);
            }

            comboBox1.SelectedIndex = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Video = new VideoCaptureDevice(Dispositivos[comboBox1.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = Video;
            videoSourcePlayer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            videoSourcePlayer1.SignalToStop();
        }

      /*  private void timer1_Tick(object sender, EventArgs e)
                    if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                string[] resultado = BarcodeReader.read(img, BarcodeReader.QRCODE);
                img.Dispose();

                if (resultado != null && resultado.Count() > 0)
                {
                    listBox1.Items.Add(resultado[0]);
                }
            }
        }
        */
        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                string[] resultado = BarcodeReader.read(img, BarcodeReader.QRCODE);
                img.Dispose();

                if (resultado != null && resultado.Count() > 0)
                {
                    listBox1.Items.Add(resultado[0]);
                }
            }
        }
    }
}
