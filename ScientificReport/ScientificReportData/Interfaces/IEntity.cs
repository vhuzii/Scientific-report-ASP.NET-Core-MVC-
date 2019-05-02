using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Interfaces 
{
	/// <summary>
	/// Інтерфейс для моделі
	/// </summary>
	/// <typeparam name="T">Тип ідентифікатора</typeparam>
	public interface IEntity<T>
	{
		T Id { get; set; }
	}
}
