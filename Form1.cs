using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso_Parcial
{
    public partial class frmprincipal : Form
    {
        Comidas oComidas;
        DataTable tCom;
        MeGustan oMeGustan;
        DataTable tGus; 
        Personas oPersonas;
        DataTable tPer; 
        public frmprincipal()
        {
            InitializeComponent();
        }

        private void frmprincipal_Load(object sender, EventArgs e)
        {
            oComidas = new Comidas();
            tCom = oComidas.getData();
            
            oPersonas = new Personas();
            tPer = oPersonas.getData();

            oMeGustan = new MeGustan();
            tGus = oMeGustan.getData();
            cboPersonas.DisplayMember = "nombre";
            cboPersonas.ValueMember = "dni";
            cboPersonas.DataSource = tPer; 
        }

        private void cboPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TENER EN CUENTA!!!
            dgvGrilla.Rows.Clear(); 
            foreach (DataRow fGus in tGus.Rows) 
            {
                if (fGus["dni"].ToString()==cboPersonas.SelectedValue.ToString())
                {
                    DataRow fCom = tCom.Rows.Find(fGus["comida"]);
                    dgvGrilla.Rows.Add(fCom["comida"], fCom["nombre"]);
                }
            } 
        }
    }
}
