namespace IntegrateProject.Dal.Frame
{
    using System.Collections.Generic;
    using IntegrateProject.Dal.Model;
    using IntegrateProject.Dal.Frame;
    using System.Data.Entity;
    using System.Linq;

    public class UseMember : UseBase<Member>, IMember
    {
        public IEnumerable<Member> GetALLMember()
        {
            var GetMember = new ProjectEntityDB();
            var tt = from cc in GetMember.MemberSet.Include("Team")
                     select cc;

            return tt;
        }
        public IEnumerable<Member> GetMemberByID(int id)
        {
            var GetMember = new ProjectEntityDB();
            var tt = from cc in GetMember.MemberSet.Include("Team")
                     where cc.TeamID == id
                     select cc;

            return tt;
        }

        public void Add(Member t)
        {
            var GetMember = new ProjectEntityDB();
            GetMember.MemberSet.Add(t);
            GetMember.SaveChanges();
        }
    }
}