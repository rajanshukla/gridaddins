/*
 * Created by SharpDevelop.
 * User: rodrigo
 * Date: 22/05/2008
 * Time: 07:54 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TestGridAddIns
{
	partial class TestForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
			this.btnFill = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnGen = new System.Windows.Forms.Button();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.gridManTest = new GridAddIns.GridManager();
			this.iGridTest = new GridAddIns.iGrid();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pnlBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.iGridTest)).BeginInit();
			this.SuspendLayout();
			// 
			// btnFill
			// 
			this.btnFill.Location = new System.Drawing.Point(84, 3);
			this.btnFill.Name = "btnFill";
			this.btnFill.Size = new System.Drawing.Size(75, 23);
			this.btnFill.TabIndex = 2;
			this.btnFill.Text = "Fill Grid...";
			this.btnFill.UseVisualStyleBackColor = true;
			this.btnFill.Click += new System.EventHandler(this.BtnFillClick);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(165, 3);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "Clear Grid...";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
			// 
			// btnGen
			// 
			this.btnGen.Location = new System.Drawing.Point(3, 3);
			this.btnGen.Name = "btnGen";
			this.btnGen.Size = new System.Drawing.Size(75, 23);
			this.btnGen.TabIndex = 4;
			this.btnGen.Text = "Generar";
			this.btnGen.UseVisualStyleBackColor = true;
			this.btnGen.Click += new System.EventHandler(this.BtnGenClick);
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.btnGen);
			this.pnlBottom.Controls.Add(this.btnClear);
			this.pnlBottom.Controls.Add(this.btnFill);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 444);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(839, 31);
			this.pnlBottom.TabIndex = 5;
			// 
			// gridManTest
			// 
			this.gridManTest.CasoSensitivo = false;
			this.gridManTest.Columnas = ((System.Collections.ObjectModel.Collection<string>)(resources.GetObject("gridManTest.Columnas")));
			this.gridManTest.EstiloResaltadoBgColor = System.Drawing.Color.LightBlue;
			this.gridManTest.EstiloResaltadoFgColor = System.Drawing.Color.DarkBlue;
			this.gridManTest.EstiloResaltadoFuente = System.Drawing.FontStyle.Regular;
			this.gridManTest.Location = new System.Drawing.Point(3, 2);
			this.gridManTest.MostrarCombo = false;
			this.gridManTest.Name = "gridManTest";
			this.gridManTest.NombreDataGridView = "";
			this.gridManTest.Operacion = GridAddIns.GridManagerOperaciones.Filtrado;
			this.gridManTest.Size = new System.Drawing.Size(633, 42);
			this.gridManTest.TabIndex = 8;
			this.gridManTest.TabStop = false;
			this.gridManTest.Text = "Buscar...";
			// 
			// iGridTest
			// 
			this.iGridTest.ActualPage = 0;
			this.iGridTest.AllowUserToAddRows = false;
			this.iGridTest.AllowUserToDeleteRows = false;
			this.iGridTest.AllRows = ((System.Collections.Generic.List<object[]>)(resources.GetObject("iGridTest.AllRows")));
			this.iGridTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.iGridTest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
			this.iGridTest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
			this.iGridTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.iGridTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Column1,
									this.Column2,
									this.Column3,
									this.Column4,
									this.Column5});
			this.iGridTest.Location = new System.Drawing.Point(3, 50);
			this.iGridTest.MultiSelect = false;
			this.iGridTest.Name = "iGridTest";
			this.iGridTest.ReadOnly = true;
			this.iGridTest.RowsPerPage = 10;
			this.iGridTest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.iGridTest.ShowDeleteCollumn = false;
			this.iGridTest.ShowEditCollumn = false;
			this.iGridTest.Size = new System.Drawing.Size(824, 388);
			this.iGridTest.TabIndex = 9;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 73;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Column2";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 73;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "Column3";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Width = 73;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "Column4";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Width = 73;
			// 
			// Column5
			// 
			this.Column5.HeaderText = "Column5";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Width = 73;
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(839, 475);
			this.Controls.Add(this.iGridTest);
			this.Controls.Add(this.gridManTest);
			this.Controls.Add(this.pnlBottom);
			this.Name = "TestForm";
			this.Text = "Test iGrid Form";
			this.Load += new System.EventHandler(this.TestFormLoad);
			this.pnlBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.iGridTest)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.Button btnGen;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnFill;
		private GridAddIns.GridManager gridManTest;
		private GridAddIns.iGrid iGridTest;
	}
}
