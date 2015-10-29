using System.Collections.Generic;
using eStanar.Domain.Abstract;
using eStanar.Domain.Entities;

namespace eStanar.Domain.Concrete
{
    public class eStanarRepository : IEStanarRepository
    {
        private eStanarContext context = new eStanarContext();

        public IEnumerable<Account> Accounts
        {
            get { return context.Accounts; }
        }

        public IEnumerable<City> Cities
        {
            get { return context.Cities; }
        }

        public IEnumerable<Document> Documents
        {
            get { return context.Documents; }
        }

        public IEnumerable<Entrance> Entrances
        {
            get { return context.Entrances; }
        }

        public IEnumerable<EntranceType> EntranceTypes
        {
            get { return context.EntranceTypes; }
        }

        public IEnumerable<Meeting> Meetings
        {
            get { return context.Meetings; }
        }

        public IEnumerable<MeetingType> MeetingTypes
        {
            get { return context.MeetingTypes; }
        }

        public IEnumerable<Notice> Notices
        {
            get { return context.Notices; }
        }

        public IEnumerable<NoticeComment> NoticeComments
        {
            get { return context.NoticeComments; }
        }

        public IEnumerable<NoticeType> NoticeTypes
        {
            get { return context.NoticeTypes; }
        }

        public IEnumerable<Occupant> Occupants
        {
            get { return context.Occupants; }
        }

        public IEnumerable<Owner> Owners
        {
            get { return context.Owners; }
        }

        public IEnumerable<Person> Persons
        {
            get { return context.Persons; }
        }

        public IEnumerable<Poll> Polls
        {
            get { return context.Polls; }
        }

        public IEnumerable<PollOption> PollOptions
        {
            get { return context.PollOptions; }
        }

        public IEnumerable<PollVote> PollVotes
        {
            get { return context.PollVotes; }
        }

        public IEnumerable<Representative> Representatives
        {
            get { return context.Representatives; }
        }

        public IEnumerable<Structure> Structures
        {
            get { return context.Structures; }
        }

        public IEnumerable<StructurePart> StructureParts
        {
            get { return context.StructureParts; }
        }

        public IEnumerable<StructurePartType> StructurePartTypes
        {
            get { return context.StructurePartTypes; }
        }

        public IEnumerable<StructureType> StructureTypes
        {
            get { return context.StructureTypes; }
        }
    }
}
