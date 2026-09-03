using NutritionDiary.Application.Interfaces;

namespace NutritionDiary.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NutritionDbContext _context;
        public UnitOfWork(NutritionDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
