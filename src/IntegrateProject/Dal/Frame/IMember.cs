namespace IntegrateProject.Dal.Frame
{
    using System.Collections.Generic;
    using IntegrateProject.Dal.Model;

    public interface IMember:IUseBase<Member>
    {
        IEnumerable<Member> GetALLMember();
        IEnumerable<Member> GetMemberByID(int id);
        void Add(Member t);
    }
}
