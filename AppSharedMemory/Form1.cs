using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSharedMemory
{
    public partial class Form1 : Form
    {
        ServiceMetier.Service1Client service = new ServiceMetier.Service1Client();
        public Form1()
        {
            service = new ServiceMetier.Service1Client();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgJury.DataSource=service.GetJurys();


        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            ServiceMetier.Jury jury = new ServiceMetier.Jury();
            jury.Nom = txtNom.Text;
            jury.Prenom = txtPrenom.Text;
            jury.Garde = txtGrade.Text;
            jury.Specialiste = txtSpecialite.Text;
            service.AddJury(jury);
            Effacer();
            
            MessageBox.Show("Jury enregistré avec succès");

        }

        // methode effacer
        private void Effacer()
        {
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtGrade.Text = "";
            txtSpecialite.Text = "";
            dgJury.DataSource = service.GetJurys();
            txtNom.Focus();

        }

    }
}
