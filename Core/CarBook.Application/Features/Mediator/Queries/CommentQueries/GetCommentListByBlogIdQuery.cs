using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentListByBlogIdQuery:IRequest<List<GetCommentListByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCommentListByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
