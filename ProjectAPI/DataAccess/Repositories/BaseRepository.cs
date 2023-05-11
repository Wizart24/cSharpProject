using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
	public abstract class BaseRepository<TEntity> : IRepository<TEntity>
		where TEntity : Entity
	{
		protected GameDbContext Context;
		protected DbSet<TEntity> Entities;

		public BaseRepository(GameDbContext context)
		{
			Context = context;
			Entities = Context.Set<TEntity>();
		}

		public async Task CreateAsync(TEntity entity)
		{
			await Context.AddAsync(entity);
			await Context.SaveChangesAsync();
		}

		public async Task<List<TEntity>> ListAsync(params Expression<Func<TEntity, object>>[] properties)
		{
			IQueryable<TEntity> query = Entities;

			foreach (var property in properties)
			{
				query = query.Include(property);
			}

			return await query.ToListAsync();
		}

		public async Task UpdateAsync(TEntity entity)
		{
			Context.Update(entity);
			await Context.SaveChangesAsync();
		}

		public async Task<TEntity?> GetAync(int id)
		{
			return await Entities
			.FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
