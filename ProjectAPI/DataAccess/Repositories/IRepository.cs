using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public interface IRepository<TEntity>
		where TEntity : Entity
	{
		public Task CreateAsync(TEntity entity);
		public Task<List<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] properties);
		public Task UpdateAsync(TEntity entity);
		public Task<TEntity?> GetAync(int id);
	}
}
