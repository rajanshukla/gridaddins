/*
 * 
/////////////////IrrJ\\\\\\\\\\\\\\\\\\
Archivo de código fuente desarrollado
por IrrJ en SharpDevelop 1.2
 * Date: 01/01/2001
 * Time: 0:02
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
	/// Representa un control capaz de filtrar datos de un DataGridView
	/// </summary>
	[Serializable]
	public class GridManager: GroupBox
	{
		
		#region Campos
		
		/// <summary>
		/// Constante que repreesnta el texto mostrado en el ComboBox para las operaciones con todas las columnas del Grid
		/// </summary>
		public const string ALLCOLS = "<Todas las columnas>";
		/// <summary>
		/// Define si se rellenara automaticamente el ComboBox de columnas con todas las columnas del grid
		/// </summary>
		private bool _autoRellenarComboColumnas;
		/// <summary>
		/// Define si la operacion a realizar sera sensitiva a la escritura en el TextBox de Valores
		/// </summary>
		private bool _sensitivo;
		/// <summary>
		/// Define si se genera automaticamente la opcion "todas las columnas" en el ComboBox
		/// </summary>
		private bool _generarOpcionTodasLasColumnas;
		/// <summary>
		/// El ComboBox donde apareceran las columnas sobre las cuales se puede operar
		/// </summary>
		private ComboBox _cmbColumnas;
		/// <summary>
		/// El TextBox donde escribir el los valores
		/// </summary>
		private TextBox _txtValor;
		/// <summary>
		/// El nombre del DataGridView asociado con el control
		/// </summary>
		private string _nombreDataGridView;
		/// <summary>
		/// Las columnas del DataGridView sobre las cuales operar
		/// </summary>
		private System.Collections.ObjectModel.Collection<string> _columnas;
		/// <summary>
		/// Las posibles operaciones a realizar con el control
		/// </summary>
		private GridManagerOperaciones _operacion;
		/// <summary>
		/// Estilo que poseen normalmente las celdas del DataGridView
		/// </summary>
		private DataGridViewCellStyle _estiloNormal;
		/// <summary>
		/// El estilo para resaltar las celdas en la operacion de resaltado
		/// </summary>
		private DataGridViewCellStyle _estiloResaltado;
		/// <summary>
		/// Si el texto a evaluar para los filtros/busquedas/resaltados debe diferenciar entre mayusculas y minusculas
		/// </summary>
		private bool _casoSensitivo;
		/// <summary>
		/// Si mostrar el ComboBox o no
		/// </summary>
		private bool _mostrarCombo;
		private DateTime _lastStroke;
		
		#endregion
		
		#region Propiedades
		
		/// <summary>
		/// Devuelve o establece si el ComboBox de columnas con todas las columnas del grid
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("Si el ComboBox de columnas con todas las columnas del grid")]
		[DefaultValue(true)]
		public bool AutoRellenarComboColumnas
		{
			get { return this._autoRellenarComboColumnas; }
			set { this._autoRellenarComboColumnas = value; }
		}
		
		/// <summary>
		/// Devuelve o establece si la operacion a realizar sera sensitiva a la escritura en el TextBox de valores
		/// </summary>		
		[Browsable(true)]
		[Category("GridManager")]
		[Description("Si la operacion a realizar sera sensitiva a la escritura en el TextBox de valores")]
		[DefaultValue(true)]
		public bool Sensitivo
		{
			get { return this._sensitivo; }
			set { this._sensitivo = value; }
		}
		
		/// <summary>
		/// Devuelve o establece si se genera automaticamente la opcion "todas las columnas" en el ComboBox
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("Define si se genera automaticamente la opcion 'todas las columnas' en el ComboBox")]
		[DefaultValue(true)]
		public bool GenerarOpcionTodasLasColumnas
		{
			get { return this._generarOpcionTodasLasColumnas; }
			set { this._generarOpcionTodasLasColumnas = value; }
		}
		
		/// <summary>
		/// Devuelve o establece el nombre del DataGridView asociado con el control
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("El nombre del DataGridView asociado con el control")]
		public string NombreDataGridView
		{
			get { return this._nombreDataGridView; }
			set { this._nombreDataGridView = (value != null? value: ""); }
		}
		
		/// <summary>
		/// Devuelve o establece las columnas del DataGridView sobre las cuales operar
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("Las columnas del DataGridView sobre las cuales operar")]
		public System.Collections.ObjectModel.Collection<string> Columnas
		{
			get { return this._columnas; }
			set { this._columnas = value; }
		}
		
		/// <summary>
		/// Devuelve o establece las posibles operaciones a realizar con el control
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("Las posibles operaciones a realizar con el control")]
		public GridManagerOperaciones Operacion
		{
			get { return this._operacion; }
			set { this._operacion = value; }
		}
		
		/// <summary>
		/// Devuelve o establece el color de fondo del estilo para resaltar las filas en la operacion de resaltado
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("El color de fondo del estilo para resaltar las filas en la operacion de resaltado")]		
		public Color EstiloResaltadoBgColor
		{
			get { return this._estiloResaltado.BackColor; }
			set { this._estiloResaltado.BackColor = value; }
		}
		
		/// <summary>
		/// Devuelve o establece el color de frente del estilo para resaltar las filas en la operacion de resaltado
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("El color de frente del estilo para resaltar las filas en la operacion de resaltado")]
		public Color EstiloResaltadoFgColor
		{
			get { return this._estiloResaltado.ForeColor; }
			set { this._estiloResaltado.ForeColor = value; }
		}
		
		/// <summary>
		/// Devuelve o establece el estilo de la fuente para resaltar las filas en la operacion de resaltado
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("El estilo de la fuente para resaltar las filas en la operacion de resaltado")]
		public FontStyle EstiloResaltadoFuente
		{
			get { return this._estiloResaltado.Font.Style; }
			set { this._estiloResaltado.Font = new Font(this._estiloResaltado.Font, value); }
		}
		
		/// <summary>
		/// Devuelve o establece un valor que indica si las comparaciones deben diferenciar entre mayusculas y minusculas
		/// </summary>
		[Browsable(true)]
		[Category("GridManager")]
		[Description("Si las comparaciones entre valores deben diferenciar entre mayusculas y minusculas")]
		public bool CasoSensitivo
		{
			get { return this._casoSensitivo; }
			set { this._casoSensitivo = value; }
		}
		
		[Browsable(true)]
		[Category("GridManager")]
		[Description("Si mostrar el ComboBox de seleccion de columnas del grid donde buscar, o no")]
		public bool MostrarCombo
		{
			get { return this._mostrarCombo; }
			set { this._mostrarCombo = value; this.Formatear(this, new EventArgs()); }
		}
		
		#endregion
		
		#region Metodos
		
		/// <summary>
		/// Crea una nueva instancia de la clase GridFilterer
		/// </summary>
		public GridManager()
		{
			this.NombreDataGridView = "";
			this.Columnas = new System.Collections.ObjectModel.Collection<string>();
			this.CasoSensitivo = false;
			this.Sensitivo = true;			
			this.AutoRellenarComboColumnas = true;
			this.GenerarOpcionTodasLasColumnas = true;
			this._estiloResaltado = new DataGridViewCellStyle();
			this._estiloResaltado.Font = new Font(FontFamily.GenericSansSerif, 5);
			this._estiloResaltado.BackColor = Color.LightBlue;	
			this._estiloResaltado.ForeColor = Color.DarkBlue;
			this._cmbColumnas = new ComboBox();
			this._txtValor = new TextBox();
			this.Controls.Add(this._cmbColumnas);
			this.Controls.Add(this._txtValor);
			
			this.Size = new Size(500, 42);
			this.Formatear(this, new EventArgs());
			this._txtValor.KeyUp += new KeyEventHandler(this.OnTeclaPresionada);
			this._cmbColumnas.SelectedIndexChanged += new EventHandler(this.CambioSeleccionCombo);
			this.Resize += new EventHandler(this.Formatear);			
		}
		
		/// <summary>
		/// Evento disparado cuando cambia la opcion seleccionada en el ComboBox
		/// </summary>
		/// <param name="sender">El objeto que disparo el evento</param>
		/// <param name="e">Parametros genericos relacionados con el evento</param>
		public void CambioSeleccionCombo(object sender, EventArgs e)
		{
			this.EjecutarAccion();
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
			try{
				((Form)this.Parent).Load += new EventHandler(this.Cargar);
			}catch (Exception ex1){
				try{
					((Control)this.Parent).Enter += new EventHandler(this.Cargar);
				}catch (Exception ex2){
					//pass
				}
			}
		}
		
		/// <summary>
		/// Metodo disparado cuando el formulario asociado con el control y todos sus "hijos" han sido cargados
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Cargar(object sender, EventArgs e)
		{
			this.AutoGenerarColumnas();
			if (this.Parent != null)
			{
				if (this.Parent.Controls.ContainsKey(this.NombreDataGridView))
				{
					this._estiloNormal = ((DataGridView)this.Parent.Controls[this.NombreDataGridView]).DefaultCellStyle;
					this._estiloResaltado.Font = new Font(this._estiloNormal.Font, FontStyle.Bold);
				}
			}
			this._lastStroke = DateTime.Now;
		}
		
		/// <summary>
		/// Define posiciones y tamanios de los controles TextBox y ComboBox relativos al tamanio del control
		/// </summary>
		/// <param name="sender">El objeto que disparo el evento</param>
		/// <param name="e">Parametros genericos relacionados con el evento</param>
		public void Formatear(object sender, EventArgs e)
		{
			this._cmbColumnas.Visible = true;
			this._cmbColumnas.Location = new Point(10, 15);
			this._cmbColumnas.Size = new Size((int)(this.Width * 0.4) - 10, 30);
			this._cmbColumnas.DropDownStyle = ComboBoxStyle.DropDownList;
			if(this.MostrarCombo)
			{
				this._txtValor.Location = new Point(this._cmbColumnas.Left + this._cmbColumnas.Width + 10, 15);
				this._txtValor.Size = new Size((int)(this.Width * 0.6) - 20, 30);
			}
			else
			{
				this._cmbColumnas.Visible = false;
				this._txtValor.Location = new Point(10,15);
				this._txtValor.Size = new Size(this.Width - 20, 30);
			}
		}
		
		/// <summary>
		/// Si la opcion AutoGenerarColumnas esta en verdadero, Genera automaticamente los items del ComboBox en base a todas las columnas del DataGridView
		/// </summary>
		public void AutoGenerarColumnas()
		{
			//try
			//{
				if (this.NombreDataGridView != "")
				{
					if (this.Parent != null)
					{
						if (this.Parent.Controls.ContainsKey(this.NombreDataGridView))
						{
							this.Columnas.Clear();
							this._cmbColumnas.Items.Clear();
							DataGridView dgvOrigen = ((DataGridView)this.Parent.Controls[this.NombreDataGridView]);
							foreach(DataGridViewColumn columna in dgvOrigen.Columns)
							{
								this.Columnas.Add(columna.Name);
								this._cmbColumnas.Items.Add(columna.Name);
							}
							if (this.GenerarOpcionTodasLasColumnas)
								this._cmbColumnas.Items.Add(GridManager.ALLCOLS);
							if(this._cmbColumnas.Items.Count > 0)
								this._cmbColumnas.SelectedIndex = this._cmbColumnas.Items.Count - 1;
						}
					}
				}
			//}
			//catch(Exception e)
			//{
				//MessageBox.Show(e.Message);
			//}
		}
		
		/// <summary>
		/// Evento disparado cuando una tecla es presionada en el teclado
		/// </summary>
		/// <param name="sender">El objeto que disparo el evento</param>
		/// <param name="e">Parametros genericos relacionados con el evento</param>
		public void OnTeclaPresionada(object sender, KeyEventArgs e)
		{
			if (!this.Sensitivo && e.KeyCode != Keys.Enter)
				return;
			if((DateTime.Now.Second - this._lastStroke.Second) >= 1)
			{
				this.EjecutarAccion();
			}
			this._lastStroke = DateTime.Now;
		}
		
		/// <summary>
		/// Ejecuta la accion relacionada con este control
		/// </summary>
		public virtual void EjecutarAccion()
		{
			switch(this._operacion)
			{
				case GridManagerOperaciones.Filtrado:
					this.FiltrarGrid();
					break;
				case GridManagerOperaciones.Busqueda:
					this.BuscarEnGrid();
					break;
				case GridManagerOperaciones.Resaltado:
					this.ResaltarEnGrid();
					break;
			}
		}
		
		/// <summary>
		/// Filtra las filas del DataGridView en base a la columna seleccionada en el ComboBox y al valor escrito en el TextBox
		/// </summary>
		public virtual void FiltrarGrid()
		{			
			DataGridView dgvOrigen = ((DataGridView)this.Parent.Controls[this.NombreDataGridView]);
			if (this._txtValor.Text != "")
			{
				foreach(DataGridViewRow fila in dgvOrigen.Rows)
				{
					if (!fila.IsNewRow)
						fila.Visible = false;
					if (this._cmbColumnas.Text == GridManager.ALLCOLS)
					{
						foreach(DataGridViewCell celda in fila.Cells)
						{
							if (celda.Value != null)
							{
								if(this.CasoSensitivo)
								{
									if(celda.Value.ToString().Contains(this._txtValor.Text))
										fila.Visible = true;
								}
								else
								{
									if(celda.Value.ToString().ToUpper().Contains(this._txtValor.Text.ToUpper()))
										fila.Visible = true;
								}
							}
						}
					}
					else
					{
						if (fila.Cells[this._cmbColumnas.Text].Value != null)
						{
							if(this.CasoSensitivo)
							{
								if (fila.Cells[this._cmbColumnas.Text].Value.ToString().Contains(this._txtValor.Text))
									fila.Visible = true;
							}
							else
							{
								if(fila.Cells[this._cmbColumnas.Text].Value.ToString().ToUpper().Contains(this._txtValor.Text.ToUpper()))
									fila.Visible = true;
							}
						}
					}
						
				}
			}
			else
				foreach(DataGridViewRow fila in dgvOrigen.Rows)
					if (!fila.IsNewRow)
						fila.Visible = true;
		}
		
		/// <summary>
		/// Selecciona la primer fila encontrada del DataGridView en base a la columna seleccionada en el ComboBox y al valor escrito en el TextBox
		/// </summary>
		public virtual void BuscarEnGrid()
		{
			DataGridView dgvOrigen = ((DataGridView)this.Parent.Controls[this.NombreDataGridView]);
			if (this._txtValor.Text != "")
			{
				foreach(DataGridViewRow fila in dgvOrigen.Rows)
				{
					if (this._cmbColumnas.Text == GridManager.ALLCOLS)
					{
						foreach(DataGridViewCell celda in fila.Cells)
						{
							if (celda.Value != null)
							{
								celda.Selected = false;
								if(this.CasoSensitivo)
								{
									if(celda.Value.ToString().Contains(this._txtValor.Text))
										celda.Selected = true;
								}
								else
								{
									if(celda.Value.ToString().ToUpper().Contains(this._txtValor.Text.ToUpper()))
										celda.Selected = true;
								}
							}
						}
					}
					else
					{
						if (fila.Cells[this._cmbColumnas.Text].Value != null)
						{
							fila.Cells[this._cmbColumnas.Text].Selected = false;
							if(this.CasoSensitivo)
							{
								if (fila.Cells[this._cmbColumnas.Text].Value.ToString().Contains(this._txtValor.Text))
									fila.Cells[this._cmbColumnas.Text].Selected = true;
							}
							else
							{
								if(fila.Cells[this._cmbColumnas.Text].Value.ToString().ToUpper().Contains(this._txtValor.Text.ToUpper()))
									fila.Cells[this._cmbColumnas.Text].Selected = true;
							}
						}
					}
						
				}
			}
			else
			{
				foreach(DataGridViewRow fila in dgvOrigen.Rows)
				{
					if (!fila.IsNewRow)
					{
						foreach(DataGridViewCell celda in fila.Cells)						
							celda.Selected = false;
					}
				}
			}
		}
		
		/// <summary>
		/// Resalta las filas del DataGridView en base a la columna seleccionada en el ComboBox y al valor escrito en el TextBox
		/// </summary>
		public virtual void ResaltarEnGrid()
		{
			DataGridView dgvOrigen = ((DataGridView)this.Parent.Controls[this.NombreDataGridView]);
			if (this._txtValor.Text != "")
			{
				foreach(DataGridViewRow fila in dgvOrigen.Rows)
				{
					if (this._cmbColumnas.Text == GridManager.ALLCOLS)
					{
						foreach(DataGridViewCell celda in fila.Cells)
						{
							if (celda.Value != null)
							{
								celda.Style = this._estiloNormal;
								if(this.CasoSensitivo)
								{
									if(celda.Value.ToString().Contains(this._txtValor.Text))
										celda.Style = this._estiloResaltado;
								}
								else
								{
									if(celda.Value.ToString().ToUpper().Contains(this._txtValor.Text.ToUpper()))
										celda.Style = this._estiloResaltado;
								}
							}
						}
					}
					else
					{
						if (fila.Cells[this._cmbColumnas.Text].Value != null)
						{
							fila.Cells[this._cmbColumnas.Text].Style = this._estiloNormal;
							if(this.CasoSensitivo)
							{
								if (fila.Cells[this._cmbColumnas.Text].Value.ToString().Contains(this._txtValor.Text))
									fila.Cells[this._cmbColumnas.Text].Style = this._estiloResaltado;
							}
							else
							{
								if(fila.Cells[this._cmbColumnas.Text].Value.ToString().ToUpper().Contains(this._txtValor.Text.ToUpper()))
									fila.Cells[this._cmbColumnas.Text].Style = this._estiloResaltado;
							}
						}
					}
						
				}
			}
			else
			{
				foreach(DataGridViewRow fila in dgvOrigen.Rows)
				{
					if (!fila.IsNewRow)
					{
						foreach(DataGridViewCell celda in fila.Cells)						
							celda.Style = this._estiloNormal;
					}
				}
			}
						
		}
		
		#endregion
		
	}
}
