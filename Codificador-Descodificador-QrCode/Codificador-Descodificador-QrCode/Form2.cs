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
using System.Security;
using System.Security.Cryptography;

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

      
        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }

        string desc;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                string[] resultado = BarcodeReader.read(img, BarcodeReader.QRCODE);
                img.Dispose();

                if (resultado != null && resultado.Count()>0)
                {
                    listBox1.Items.Add(resultado[0]);
                     desc = resultado[0];
                }

               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBox1.Text = Decodificar(desc);
        }

        public static string Decodificar(string entrada)
        {
            TripleDESCryptoServiceProvider tripledescryptoserviceprovider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5cryptoserviceprovider = new MD5CryptoServiceProvider();

            try
            {
                if (entrada.Trim() != "")
                {
                    string chave = "asdfg";
                    tripledescryptoserviceprovider.Key = md5cryptoserviceprovider.ComputeHash(Encoding.Default.GetBytes(chave));
                    tripledescryptoserviceprovider.Mode = CipherMode.ECB;
                    ICryptoTransform desdencrypt = tripledescryptoserviceprovider.CreateDecryptor();
                    byte[] buff = Convert.FromBase64String(entrada);

                    return Encoding.Default.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                }
                else
                {
                    return "";
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro" + exception.Message);
                throw exception;
            }
            finally
            {
                tripledescryptoserviceprovider = null;
                md5cryptoserviceprovider = null;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
