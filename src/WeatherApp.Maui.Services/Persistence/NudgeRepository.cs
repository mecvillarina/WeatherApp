using Poc.Domain.Persistence;
using Poc.Models.Contracts;
using Poc.Models.Entities;

namespace Poc.Maui.Services.Persistence
{
    public class NudgeRepository : RepositoryBase, INudgeRepository
    {
        public NudgeRepository(IAppDatabase db) : base(db)
        {
        }

        public async Task DeleteAllNudgesAsync()
        {
            await DB.DeleteAllAsync<Nudge>();
        }

        public async Task InsertNudgesAsync(List<NudgeContract> nudges)
        {
            var mappedNudges = new List<Nudge>();

            foreach (var nudge in nudges)
            {
                mappedNudges.Add(new Nudge()
                {
                    NudgeId = nudge.NudgeId,
                    DateSent = nudge.DateSent,
                    SenderName = nudge.Sender.Email,
                    //SenderName = $"{nudge.Sender.FirstName} {nudge.Sender.LastName} ({nudge.Sender.Email})",
                    Message = nudge.Message,
                    Title = nudge.Title
                });
            }

            if (mappedNudges.Any())
            {
                await DB.InsertAllAsync<Nudge>(mappedNudges);
            }
        }

        public async Task<List<Nudge>> GetAllNudgesAsync()
        {
            return await DB.ToListAsync<Nudge>();
        }
    }

}
