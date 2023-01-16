using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private NZWalksDbContext nZWalksDbContext;

        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<WalkDIfficulty> AddAsync(WalkDIfficulty walkDIfficulty)
        {
            walkDIfficulty.Id = Guid.NewGuid();
            await nZWalksDbContext.WalkDIfficulty.AddAsync(walkDIfficulty);
            await nZWalksDbContext.SaveChangesAsync();
            return walkDIfficulty;
        }

        public async Task<WalkDIfficulty> DeleteAsync(Guid id)
        {
            var existingWalkDifficulty = await nZWalksDbContext.WalkDIfficulty.FindAsync(id);
            if(existingWalkDifficulty != null)
            {
                nZWalksDbContext.WalkDIfficulty.Remove(existingWalkDifficulty);
                await nZWalksDbContext.SaveChangesAsync();
                return existingWalkDifficulty;
            }
            return null;
        }

        public async Task<IEnumerable<WalkDIfficulty>> GetAllAsync()
        {
            return await nZWalksDbContext.WalkDIfficulty.ToListAsync();
        }

        public async Task<WalkDIfficulty> GetAsync(Guid id)
        {
            return await nZWalksDbContext.WalkDIfficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDIfficulty> UpdateAsync(Guid id, WalkDIfficulty walkDIfficulty)
        {
            var existingWalkDifficulty = await nZWalksDbContext.WalkDIfficulty.FindAsync(id);
            
            if(existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDIfficulty.Code;
            await nZWalksDbContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }
    }
}
