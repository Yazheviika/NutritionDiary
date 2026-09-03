using NutritionDiary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionDiary.Application.Interfaces
{
    public interface IDiaryEntryRepository
    {
        void Add(DiaryEntry entry);
        Task<DiaryEntry?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
