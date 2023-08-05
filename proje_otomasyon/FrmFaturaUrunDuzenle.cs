﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace proje_otomasyon
{
    public partial class FrmFaturaUrunDuzenle : Form
    {
        public FrmFaturaUrunDuzenle()
        {
            InitializeComponent();
        }

        public string urunid;
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmFaturaUrunDuzenle_Load(object sender, EventArgs e)
        {
            TxtUrunId.Text = urunid;
            SqlCommand komut = new SqlCommand("Select * From TBL_FATURADETAY where FATURAURUNID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtFiyat.Text = dr[3].ToString();
                TxtMiktar.Text = dr[2].ToString();
                TxtTutar.Text = dr[4].ToString();
                TxtUrunAd.Text = dr[1].ToString();
                bgl.baglanti().Close();

            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURADETAY set URUNAD=@p1, MIKTAR=@p2, FIYAT=@p3, TUTAR=@p4 where FATURAURUNID=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
            komut.Parameters.AddWithValue("@p5", TxtUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
