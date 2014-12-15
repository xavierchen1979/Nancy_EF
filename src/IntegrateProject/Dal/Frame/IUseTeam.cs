namespace IntegrateProject.Dal.Frame
{
    using System.Collections.Generic;
    using IntegrateProject.Dal.Model;

    public interface IUseTeam : IUseBase<Team>
    {
        IEnumerable<Team> GetALLTeam();
        IEnumerable<Team> GetTeamByID(int id);
        IEnumerable<Team> GetTeamByName(string name);
        void Add(Team t);
    }
}