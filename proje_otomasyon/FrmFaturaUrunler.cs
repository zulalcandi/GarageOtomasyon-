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
    public partial class FrmFaturaUrunler : Form
    {
        public FrmFaturaUrunler()
        {
            InitializeComponent();
        }

        public string id;
        sqlBaglantisi bgl = new sqlBaglantisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURADETAY where FATURAID='" + id + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource= dt;

        }
        private void FrmFaturaUrunler_Load(object sender, EventArgs e)
        {
            listele();


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDuzenle fr = new FrmFaturaUrunDuzenle();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.urunid = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }

    }
}
