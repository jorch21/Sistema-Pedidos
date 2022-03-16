using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfazGUI.ServiceReference1;

namespace InterfazGUI
{
    public partial class frmConsultas : Form
    {
        AsignacionesClient servicioAsignaciones = new AsignacionesClient();
        HistorialesClient servicioHistorial = new HistorialesClient();
        public frmConsultas()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void listarAsignaciones()
        {
            dgAsignaciones.DataSource = servicioAsignaciones.LISTADEASIGNACIONES().Tables["LISTA"];
        }
        void listarHistorial()
        {
            dgHistorial.DataSource = servicioHistorial.LISTAHISTORIAL().Tables["LISTA"];
        }
        private void frmConsultas_Load(object sender, EventArgs e)
        {
            listarAsignaciones();
            listarHistorial();
        }

        private void btnExportar1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets[1];
            worksheet.Name = "ASIGNACIONES";
            for(int i=1;i<dgAsignaciones.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgAsignaciones.Columns[i - 1].HeaderText;
                worksheet.Cells[1, i].Font.Bold = true;
                worksheet.Cells[1, i].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                worksheet.Cells[1, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
            }
            for(int i = 0; i < dgAsignaciones.Rows.Count; i++)
            {
                for(int j = 0; j < dgAsignaciones.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgAsignaciones.Rows[i].Cells[j].Value.ToString();
                }
            }
            app.Visible = true;
        }

        private void btnExportar2_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets[1];
            worksheet.Name = "HISTORIAL PEDIDOS";
            for (int i = 1; i < dgHistorial.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dgHistorial.Columns[i - 1].HeaderText;
                worksheet.Cells[1, i].Font.Bold = true;
                worksheet.Cells[1, i].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                worksheet.Cells[1, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
            }
            for (int i = 0; i < dgHistorial.Rows.Count; i++)
            {
                for (int j = 0; j < dgHistorial.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgHistorial.Rows[i].Cells[j].Value.ToString();
                }
            }
            app.Visible = true;
        }
    }
}
