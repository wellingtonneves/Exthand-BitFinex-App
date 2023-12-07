using System;
using System.Threading.Tasks;

namespace Best.Buy.Repository
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _context;
        private GenericRepository<DTO.Models.Product> _productsRepository;
        private GenericRepository<DTO.Models.Category> _categoryRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

        }
        public GenericRepository<DTO.Models.Product> ProductsRepository
        {
            get
            {

                if (_productsRepository == null)
                    _productsRepository = new GenericRepository<DTO.Models.Product>(_context);

                return _productsRepository;
            }
        }

        public GenericRepository<DTO.Models.Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new GenericRepository<DTO.Models.Category>(_context);

                return _categoryRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
