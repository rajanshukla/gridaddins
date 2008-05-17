/*
 * Created by SharpDevelop.
 * user: Robertux
 * Date: 14/05/2008
 * Time: 01:29 p.m.
 * 
 * 
 */

using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace GridAddIns
{
	/// <summary>
	/// Description of iGrid.
	/// </summary>
	public class iGrid: DataGridView
	{
		#region Campos
				
		private int _actualPage;
		private int _rowsPerPage;
		private List<object[]> _allRows;
		private DataGridViewLinkColumn colEditar;
		private DataGridViewLinkColumn colBorrar;
		private bool _showColEdit;
		private bool _showColDelete;
		
		#endregion
		
		#region Propiedades
		
		[Browsable(true)]
		[Category("iGrid")]
		public int ActualPage
		{
			get { return this._actualPage; }
			set { this._actualPage = value; this.UpdateVisibleRows(); }
		}
		
		[Browsable(true)]
		[Category("iGrid")]
		public int RowsPerPage
		{
			get { return this._rowsPerPage; }
			set { this._rowsPerPage = value; }
		}
		
		[Browsable(true)]
		[Category("iGrid")]
		public bool ShowEditCollumn
		{
			get { return this._showColEdit; }
			set { this._showColEdit = value; }
		}
		
		[Browsable(true)]
		[Category("iGrid")]
		public bool ShowDeleteCollumn
		{
			get { return this._showColDelete; }
			set { this._showColDelete = value; }
		}
		
		public int TotalPages
		{
			get { return (int)Math.Ceiling(double.Parse((this.AllRows.Count / this.RowsPerPage).ToString())); }
		}
		
		public List<object[]> AllRows
		{
			get { return this._allRows; }
			set { this._allRows =  value; }
		}
		
		#endregion
		
		#region Metodos
		
		public iGrid(): base()
		{
			this.AllRows = new List<object[]>();
			this.colBorrar = new DataGridViewLinkColumn();
			this.colEditar = new DataGridViewLinkColumn();
			this.ActualPage = 0;
			this.RowsPerPage = 10;
			this.FormatGrid();
		}
		
		public void FormatGrid()
		{
			this.AllowUserToAddRows = false;
			this.AllowUserToDeleteRows = false;
			this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
			this.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MultiSelect = false;
			this.ReadOnly = true;
			this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.colBorrar.HeaderText = "Borrar";
			this.colEditar.HeaderText = "Editar";
		}
		
		public void UpdateVisibleRows()
		{
			this.Rows.Clear();
			for(int i = (this.ActualPage * this.RowsPerPage); i < ((this.ActualPage + 1) * this.RowsPerPage); i++)
			{
				try{
					this.Rows.Add(this.AllRows[i]);
				}
				catch(ArgumentOutOfRangeException) { /* pass */}
				catch(IndexOutOfRangeException) { /*pass*/ }
			}
		}
		
		public void ShowNext()
		{
			if(this.ActualPage < this.TotalPages)
				this.ActualPage++;
		}
		
		public void ShowPrev()
		{
			if(this.ActualPage > 0)
				this.ActualPage--;
		}
		
		public void ShowFirst()
		{
			this.ActualPage = 0;
		}
		
		public void ShowLast()
		{
			this.ActualPage = this.TotalPages - 1;
		}
		
		#endregion
	}
}
