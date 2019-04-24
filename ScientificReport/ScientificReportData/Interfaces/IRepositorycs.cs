using System;
using System.Collections.Generic;
using System.Text;

namespace ScientificReportData.Interfaces
{
	public interface IRepository<T, S> where T : class
	{
		IEnumerable<T> GetAll();
		T Get(S id);
		T Create(T item);
		T Update(T item);
		T Delete(S id);
	}
}
