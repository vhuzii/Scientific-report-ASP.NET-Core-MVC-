using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Interfaces 
{
	public interface IEntity<T>
	{
		T Id { get; set; }
	}
}
