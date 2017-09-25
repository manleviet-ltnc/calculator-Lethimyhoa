using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        bool istypingnumber = false;
        enum PhepToan { Cong, Tru, Nhan, Chia };
        PhepToan pheptoan;

        double nho;

        private void Nhapso(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Nhapso(btn.Text);
        }

        private void Nhapso(string so)


        {
            if (istypingnumber)
                lbldisplay.Text = lbldisplay.Text + so;
            else
            {
                lbldisplay.Text = so;
                istypingnumber = true;
            }
        }

        private void NhapPhepToan(object sender, EventArgs e)
        {
            TinhKetQua();

            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong; break;
                case "-": pheptoan = PhepToan.Tru; break;
                case "*": pheptoan = PhepToan.Nhan; break;
                case "/": pheptoan = PhepToan.Chia; break;
            }

            nho = double.Parse(lbldisplay.Text);
            istypingnumber = false;


        }

        private void TinhKetQua()
        {
            //tinh toan dua tren : nho, pheptoan, lbldisplay.Text
            double tam = double.Parse(lbldisplay.Text);
            double ketqua = 0.0;
            switch (pheptoan)
            {
                case PhepToan.Cong: ketqua = nho + tam; break;
                case PhepToan.Tru: ketqua = nho - tam; break;
                case PhepToan.Nhan: ketqua = nho * tam; break;
                case PhepToan.Chia: ketqua = nho / tam; break;
            }

            // gan ket qua tinh duoc len lbldisplay
            lbldisplay.Text = ketqua.ToString();
        }

        private void btncan_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            istypingnumber = false;
        }

        private void btnbang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            istypingnumber = false;
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    Nhapso("" + e.KeyChar);
                    break;
            }



        }
        private void btnCan_Click(object sender, EventArgs e)
        {
            lbldisplay.Text = (Math.Sqrt(Double.Parse(lbldisplay.Text))).ToString();
        }

        private void btnDoiDau_Click(object sender, EventArgs e)
        {
            lbldisplay.Text = (-1 * (double.Parse(lbldisplay.Text))).ToString();
        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            lbldisplay.Text = ((double.Parse(lbldisplay.Text) / 100)).ToString();
        }
    }
}
