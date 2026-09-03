using NutritionDiary.Application.Interfaces;
using NutritionDiary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NutritionDiary.Infrastructure.Persistence.Repositories
{
    public class DiaryEntryRepository : IDiaryEntryRepository
    {
        private readonly NutritionDbContext _context;
        public DiaryEntryRepository(NutritionDbContext context)
        {
            _context = context;
        }

        public void Add(DiaryEntry entry)
        {
            _context.DiaryEntries.Add(entry);
        }

        public Task<DiaryEntry?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return _context.DiaryEntries.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }
    }
}
