using Microsoft.EntityFrameworkCore;
using ScientificReportData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScientificReportData.Repositories
{
	/// <summary>
	/// Загальний репозиторій. 
	/// </summary>
	/// <typeparam name="T">Тип моделі</typeparam>
	/// <typeparam name="S">Тип id</typeparam>
	class Repository<T, S> : IRepository<T, S> where T : class, IEntity<S>
	{
		private DbContext context;
		protected DbSet<T> dbSet;

		public Repository(DbContext context)
		{
			this.context = context;
			dbSet = context.Set<T>();
		}

		virtual public T Create(T item)
		{
			var newItem = dbSet.Add(item).Entity;
			context.SaveChanges();
			return newItem;
		}

		virtual public T Delete(S id) 
		{
			var deleted = dbSet.Remove(dbSet.Find(id)).Entity;
			context.SaveChanges();
			return deleted;
		}

		virtual public T Get(S id)
		{
			return dbSet.Find(id);
		}

		virtual public IEnumerable<T> GetAll() 
		{
			return dbSet.ToList();
		}

		virtual public T Update(T item)
		{
			var old = dbSet.Find(item.Id);
			var entity = dbSet.Find(item.Id);
			if (entity == null) 
			{
				return old;
			}

			context.Entry(entity).CurrentValues.SetValues(item);
			context.SaveChanges();
			return entity;
		}

	}
}
