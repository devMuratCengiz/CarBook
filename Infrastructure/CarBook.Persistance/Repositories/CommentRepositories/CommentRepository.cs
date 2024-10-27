using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Comment> GetCommentListByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x=>x.BlogId == id).ToList();
        }
    }
}
