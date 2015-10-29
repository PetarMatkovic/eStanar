using System.Collections.Generic;
using eStanar.Domain.Entities;

namespace eStanar.Domain.Abstract
{
    public interface IEStanarRepository
    {
        IEnumerable<Account> Accounts { get; }
        IEnumerable<City> Cities { get; }
        IEnumerable<Document> Documents { get; }
        IEnumerable<Entrance> Entrances { get; }
        IEnumerable<EntranceType> EntranceTypes { get; }
        IEnumerable<Meeting> Meetings { get; }
        IEnumerable<MeetingType> MeetingTypes { get; }
        IEnumerable<Notice> Notices { get; }
        IEnumerable<NoticeComment> NoticeComments { get; }
        IEnumerable<NoticeType> NoticeTypes { get; }
        IEnumerable<Occupant> Occupants { get; }
        IEnumerable<Owner> Owners { get; }
        IEnumerable<Person> Persons { get; }
        IEnumerable<Poll> Polls { get; }
        IEnumerable<PollOption> PollOptions { get; }
        IEnumerable<PollVote> PollVotes { get; }
        IEnumerable<Representative> Representatives { get; }
        IEnumerable<Structure> Structures { get; }
        IEnumerable<StructurePart> StructureParts { get; }
        IEnumerable<StructurePartType> StructurePartTypes { get; }
        IEnumerable<StructureType> StructureTypes { get; }
    }
}
