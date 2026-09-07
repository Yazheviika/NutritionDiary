using MediatR;
using NutritionDiary.Application.Common.Mapping;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Application.Interfaces;

namespace NutritionDiary.Application.DiaryEntries.Queries
{
    public class GetDiaryEntriesForUserQueryHandler : IRequestHandler<GetDiaryEntriesForUserQuery, List<DiaryEntryResponse>>
    {
        private readonly IDiaryEntryRepository _diaryEntryRepository;
        private readonly DiaryEntryMapper _diaryEntryMapper;

        public GetDiaryEntriesForUserQueryHandler(IDiaryEntryRepository diaryEntryRepository, DiaryEntryMapper diaryEntryMapper)
        {
            _diaryEntryRepository = diaryEntryRepository;
            _diaryEntryMapper = diaryEntryMapper;
        }

        public async Task<List<DiaryEntryResponse>> Handle(GetDiaryEntriesForUserQuery request, CancellationToken cancellationToken)
        {
            var entries = await _diaryEntryRepository.GetByUserAndDateAsync(request.UserId, request.Date, cancellationToken);
            return entries.Select(_diaryEntryMapper.ToResponse).ToList();
        }
    }
}