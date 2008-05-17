/*
 * 
/////////////////IrrJ\\\\\\\\\\\\\\\\\\
Archivo de código fuente desarrollado
por IrrJ en SharpDevelop 1.2
 * Date: 01/01/2001
/////////////////IrrJ\\\\\\\\\\\\\\\\\\
 * 
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace GridAddIns
{
	/// <summary>
	/// Control capaz de clasificar y filtrar los datos de un DataGridView
	/// </summary>
	[Serializable]
	public class GridClassifier: TreeView
	{
		#region Campos
		
		/// <summary>
		/// Los nombres de las columnas con los cuales generar la lista jerarquizada de criterios para clasificar los datos del DataGridView
		/// </summary>
		private System.Collections.ObjectModel.Collection<string> _criterios;
		/// <summary>
		/// El nombre del DataGridView asociado con el control
		/// </summary>
		private string _nombreDataGridView;
		/// <summary>
		/// Si debe generar automaticamente o no, la opcion 'todos los criterios'
		/// </summary>
		private bool _generarOpcionTodos;
		
		#endregion
		
		#region Propiedades
		
		/// <summary>
		/// Devuelve o establece los nombres de las columnas con los cuales generar la lista jerarquizada de criterios para clasificar los datos del DataGridView
		/// </summary>
		[Browsable(true)]
		[Category("GridClassifier")]
		[Description("Los nombres de las columnas de los cuales generar la lista jerarquizada de criterios para clasificar los datos del DataGridView")]
		public System.Collections.ObjectModel.Collection<string> Criterios
		{
			get { return this._criterios; }
			set { this._criterios = value; }
		}
		
		/// <summary>
		/// Devuelve o establece el nombre del DataGridView asociado con el control
		/// </summary>
		[Browsable(true)]
		[Category("GridClassifier")]
		[Description("El nombre del DataGridView asociado con el control")]
		public string NombreDataGridView
		{
			get { return this._nombreDataGridView; }
			set { this._nombreDataGridView = value; }
		}
		
		/// <summary>
		/// Devuelve o establece si debe generar automaticamente o no, la opcion 'todos los criterios'
		/// </summary>
		[Browsable(true)]
		[Category("GridClassifier")]
		[Description("Si debe generar automaticamente o no, la opcion 'todos los criterios'")]
		public bool GenerarOpcionTodos
		{
			get { return this._generarOpcionTodos; }
			set { this._generarOpcionTodos = value; }
		}
		
		#endregion
		
		#region Metodos
		
		/// <summary>
		/// Crea una nueva instancia de la clase GridClassifier
		/// </summary>
		public GridClassifier()
		{
			this._criterios = new System.Collections.ObjectModel.Collection<string>();
			this.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.NodeClick); 
			this.Size = new Size(150, 250);
		}
		
		/// <summary>
		/// Inicializa el control
		/// </summary>
		protected override void InitLayout()
		{
			//Lo hice en este metodo porque es invocado una vez que el control se vuelve parte del formulario
			//y hasta ese entonces es posible que reconozca al formulario como su padre, y de esta forma
			//conocer a sus otros controles como el DataGridView asociado
			base.InitLayout();
			((Form)this.Parent).Load += new EventHandler(this.Cargar);
		}
		
		/// <summary>
		/// Metodo disparado cuando el formulario asociado con el control y todos sus "hijos" han sido cargados
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Cargar(object sender, EventArgs e)
		{
			if (this.NombreDataGridView != null)
			{
				if (this.Parent != null)
				{
					if (this.Parent.Controls.ContainsKey(this.NombreDataGridView))
					{
						DataGridView dgvOrigen = ((DataGridView)this.Parent.Controls[this.NombreDataGridView]);
						this.Nodes.Clear();
						foreach(string criterio in this.Criterios)
						{
							List<string> valoresCriterio = new List<string>();
							if (dgvOrigen.Columns.Contains(criterio))
							{
								foreach(DataGridViewRow fila in dgvOrigen.Rows)
								{
									//MessageBox.Show(dgvOrigen.Rows.Count.ToString());
									if (!valoresCriterio.Contains(fila.Cells[criterio].ToString()))
									{
										if (fila.Cells[criterio].Value != null)
										{
											valoresCriterio.Add(fila.Cells[criterio].Value.ToString());
											this.Nodes.Add(fila.Cells[criterio].Value.ToString());
											//TODO: Rellenar el TreeView con la jerarquia de nodos en base a los criterios
										}
									}									
								}
							}
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Metodo disparado cada vez que un nodo ha sido seleccionado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void NodeClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			//TODO: aqui filtrar las filas del DataGridView igual que como las filtra el GridManager, en base al criterio seleccionado
		}
		
		
		#endregion
	}
}
