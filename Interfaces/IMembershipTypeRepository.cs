using System.Collections.Generic;
using LibApp.Models;

namespace LibApp.Interfaces
{
    public interface IMembershipTypeRepository
    {
        IEnumerable<MembershipType> GetMembershipTypes();
        MembershipType Get(int id);
        void Add(MembershipType item);
        void Remove(int id);
        void Update(MembershipType item);
        void Save();

    }
}
