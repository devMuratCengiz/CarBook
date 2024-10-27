using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.AppUserRepositories
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly CarBookContext _context;

		public AppUserRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
		{
			throw new NotImplementedException();
		}
	}
}
