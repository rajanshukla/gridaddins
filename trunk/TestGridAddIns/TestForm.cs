using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TestGridAddIns
{
	public partial class TestForm : Form
	{
		public List<Prueba> Pruebas = new List<Prueba>();
		
		public TestForm()
		{
			InitializeComponent();
		}
		
		void BtnFillClick(object sender, EventArgs e)
		{
			this.iGridTest.Rows.Clear();
			foreach(Prueba p in this.Pruebas)
			{
				this.iGridTest.Rows.Add(
					new object[]{
					p.Campo1,p.Campo2,p.Campo3,p.Campo4,p.Campo5
					});
			}
		}
		
		void BtnGenClick(object sender, EventArgs e)
		{
			for (int i = 1; i < 200; i++)
			{
				Prueba p = new Prueba(i);
				p.LlenarAleatorio();
				this.Pruebas.Add(p);
			}
		}
		
		void BtnClearClick(object sender, EventArgs e)
		{
			this.iGridTest.Rows.Clear();
		}
	}
}
