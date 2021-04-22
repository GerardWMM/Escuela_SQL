using Escuela.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escuela
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ContextBD bd = new ContextBD();

            //Mostrar los cursos en la comboBox
            CbCursos.DataSource = bd.Cursos.ToList();
            CbCursos.DisplayMember = "Nombre";
        }

        private void CbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContextBD bd = new ContextBD();

            //Mostrar en la DataGridView los alumnos
            Curso cursoSeleccionado = (Curso)CbCursos.SelectedItem;
            List<Alumno> alumnos = bd.Alumnos.Where(Alumnos => Alumnos.IdCurso == cursoSeleccionado.IdCurso).ToList();
            DGAlumnos.DataSource = alumnos;
            DGAlumnos.Columns[0].Visible = false;
            DGAlumnos.Columns[4].Visible = false;
            DGAlumnos.Columns[3].Visible = false;

            Profesore profesor = bd.Profesores.
                Where(Profesores => Profesores.IdProfesor == cursoSeleccionado.IdProfesor).FirstOrDefault();

            txtProfesores.Text = profesor.Nombre.ToString();
       
        }
    }
}
