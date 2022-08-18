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
            var author = new Entities.Author() { UserName = newAuthor.UserName, DateRegistr = DateTime.Now, DateLastUpdate = DateTime.Now };
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();

            return author.Id;
        }

        public Author[] GetAll()
        {
            var autors = _dbContext.Authors.AsNoTracking().ToArray();
            return _mapper.Map<Entities.Author[], Author[]>(autors);
        }

        public Author Get(int idAccount)
        {
            var author = _dbContext.Authors.AsNoTracking().SingleOrDefault(x => x.Id == idAccount);
            return _mapper.Map<Entities.Author, Author>(author);
        }

        public Author Update(int idAccount, Result<Author> updateAuthor)
        {
            var author = _dbContext.Authors.AsNoTracking().SingleOrDefault(x => x.Id == idAccount);

            author.UserName = updateAuthor.Value.UserName;
            author.DateLastUpdate = DateTime.Now;
            // Тут дата регистрации по часам прыгает при каждом обновлении

            _dbContext.Update(author);
            _dbContext.SaveChanges();

            return _mapper.Map<Entities.Author, Author>(author);
        }

        public string Delete(int idAccount)
        {
            var author = _dbContext.Authors.AsNoTracking().SingleOrDefault(x => x.Id == idAccount);

            _dbContext.Remove(author);
            _dbContext.SaveChanges();

            return $"Delete {author.UserName} with Id = {author.Id}";
        }
    }
}
