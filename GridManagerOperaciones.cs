/*
 * 
/////////////////IrrJ\\\\\\\\\\\\\\\\\\
Archivo de código fuente desarrollado
por IrrJ en SharpDevelop 1.2
 * Date: 01/01/2001
 * Time: 2:56
/////////////////IrrJ\\\\\\\\\\\\\\\\\\
 * 
*/

using System;

namespace GridAddIns
{
	/// <summary>
	/// Posibles operaciones que se pueden realizar con un GridManager
	/// </summary>
	public enum GridManagerOperaciones
	{
		/// <summary>
		/// Solo se mostraran en el grid las columnas que coincidan con el valor
		/// </summary>
		Filtrado,
		/// <summary>
		/// Se seleccionaran automaticamente las columnas que coincidan con el valor
		/// </summary>
		Busqueda,
		/// <summary>
		/// Se marcaran con otro color de fondo las columnas que coincidan con el valor
		/// </summary>
		Resaltado,
	}
}
