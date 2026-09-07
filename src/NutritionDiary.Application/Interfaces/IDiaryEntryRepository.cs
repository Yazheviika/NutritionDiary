using NutritionDiary.Application.DTOs;
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
        Task<List<DiaryEntry>> GetByUserAndDateAsync(string userId, DateOnly date, CancellationToken cancellationToken);
    }
}
