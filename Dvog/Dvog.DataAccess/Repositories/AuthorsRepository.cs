using AutoMapper;
using CSharpFunctionalExtensions;
//using Dvog.API.Contracts;
using Dvog.Domain;
using Dvog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dvog.DataAccess.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DvogDbContext _dbContext;
        private readonly IMapper _mapper;

        public AuthorsRepository(DvogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Add(Author newAuthor)
        {
            var author = new Entities.Author() { UserName = newAuthor.UserName, CreatedDate = DateTime.UtcNow, LastUpdateDate = DateTime.Now };
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

            return author.Id;
        }

        public Result<Author[]> GetAll()
        {
            var authors = _dbContext.Authors.AsNoTracking().ToArray();

            if (authors == null)
            {
                return Result.Failure<Author[]>("Авторы недоступны");
            }

            return _mapper.Map<Entities.Author[], Author[]>(authors);
        }

        public Result<Author> Get(int accountId)
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == accountId);
            if (author == null)
            {
                return Result.Failure<Author>("Автор недоступен");
            }

            return _mapper.Map<Entities.Author, Author>(author);
        }

        public Result<Author> Update(int accountId, Author updateAuthor)
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == accountId);

            if (author == null)
            {
                return Result.Failure<Author>("Автор не найден");
            }

            author.UserName = updateAuthor.UserName;
            author.LastUpdateDate = DateTime.UtcNow;

            _dbContext.Update(author);
            _dbContext.SaveChanges();

            return _mapper.Map<Entities.Author, Author>(author);
        }

        public Result<string> Delete(int idAccount)
        {
            var author = _dbContext.Authors.AsNoTracking().SingleOrDefault(x => x.Id == idAccount);

            if (author == null)
            {
                return Result.Failure<string>("Автор не найден");
            }

            _dbContext.Remove(author);
            _dbContext.SaveChanges();

            return $"Delete {author.UserName} with Id = {author.Id}";
        }
    }
}
