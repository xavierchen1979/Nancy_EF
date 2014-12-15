namespace IntegrateProject.Dal.Frame
{
    using System.Collections.Generic;
    using IntegrateProject.Dal.Model;
    using IntegrateProject.Dal.Frame;
    using System.Data.Entity;
    using System.Linq;

    public class UseTeam : UseBase<Team>, IUseTeam
    {
         
        public IEnumerable<Team> GetALLTeam()
        {
             var GetTeam = new ProjectEntityDB();
            var tt = from cc in GetTeam.TeamSet
                     select cc;

             return tt;
        }
        public IEnumerable<Team> GetTeamByID(int  id)
        {
            var GetTeam = new ProjectEntityDB();
            var tt = from cc in GetTeam.TeamSet
                     where cc.TeamID==id
                     select cc;

            return tt;
        }
        public IEnumerable<Team> GetTeamByName(string name)
        {
            var GetTeam = new ProjectEntityDB();
            var tt = from cc in GetTeam.TeamSet
                     where cc.TeamName == name
                     select cc;

            return tt;
        }
        public void Add(Team t)
        {
            var GetTeam = new ProjectEntityDB();
            GetTeam.TeamSet.Add(t);
            GetTeam.SaveChanges();
        }
    
    }
}