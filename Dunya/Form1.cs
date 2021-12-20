using Dunya.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dunya
{
    public partial class Form1 : Form
    {
        DunyaContext db = new DunyaContext();
        Yer secilen = null;
        public Form1()
        {
            InitializeComponent();
            YerleriListele();
        }

        private void YerleriListele()
        {
            trwYerler.Nodes.Clear();
            Yer dunya = db.Yerler.FirstOrDefault(x => x.Ad == "Dünya");
            YerEkle(dunya, trwYerler.Nodes);
            trwYerler.ExpandAll();
        }

        /// <summary>
        /// Verilen bu metod, parametre olarak aldığı yeri bir düğüme dönüştürerek yine parametre olarak aldığı dugumler adındaki koleksiyona ekler. 
        /// </summary>
        /// <param name="yer">Düğün koleksiyonuna eklenmek istenen yer</param>
        /// <param name="dugumler">Yeni düğümün ekleneceği düğümler koleksiyonu</param>
        private void YerEkle(Yer yer, TreeNodeCollection dugumler)
        {
            TreeNode tr = new TreeNode(yer.Ad);
            tr.Tag = yer;
            foreach (Yer altyer in yer.Children)
            {
                YerEkle(altyer, tr.Nodes);
            }
            dugumler.Add(tr);
        }

        private void trwYerler_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtUstYer.Text = e.Node.Text;
            secilen = (Yer)e.Node.Tag;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string yerad = txtYerAd.Text;
            if (yerad == "") return;

            Yer yer = new Yer(yerad);
            secilen.Children.Add(yer);
            db.SaveChanges();
            YerleriListele();
            txtYerAd.Clear();
        }
    }
}
