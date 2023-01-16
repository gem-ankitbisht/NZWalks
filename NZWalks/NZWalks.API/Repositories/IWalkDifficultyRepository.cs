using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDIfficulty>> GetAllAsync();
        Task<WalkDIfficulty> GetAsync(Guid id);
        Task<WalkDIfficulty> AddAsync(WalkDIfficulty walkDIfficulty);
        Task<WalkDIfficulty> UpdateAsync(Guid id,WalkDIfficulty walkDIfficulty);
        Task<WalkDIfficulty> DeleteAsync(Guid id);
    }
}
