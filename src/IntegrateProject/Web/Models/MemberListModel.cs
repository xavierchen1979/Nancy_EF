namespace IntegrateProject.Web.Models
{
    using Nancy;
    using IntegrateProject.Dal.Frame;
    using System.Linq;
    using System.Collections.Generic;
    using Nancy.ModelBinding;
    using IntegrateProject.Dal.Model;
    using System;

    public class MemberListModel  : baseModel
    {
        public class mbrList
        {
            public string mName { set; get; }
            public string tName { set; get; }
            public string Email { set; get; }
            public int  Age { set; get; }
        }

        public MemberListModel(IMember UseMember)
        {
            Get["/member"] = e =>
            {
                return View["MemberList.sshtml", UseMember.GetALLMember().Select(s => new
                {
                    mID = s.MemberID,
                    mName = s.MamberName,
                    mEmail = s.MamberEmail,
                    mAge = s.MemberAge,
                    mCdate = s.CreateDate,
                    tName = s.team.TeamName
                })];
            };

            Get["/memberadd"] = e =>
            {
                return View["MemberAdd.sshtml"];
            };

            Post["/memberadd"] = e =>
            {
                mbrList mPost = this.Bind<mbrList>();

                //找Team
                int cTeamID;
                IUseTeam UseTeam = new UseTeam();
                var checkTeam = UseTeam.GetTeamByName(mPost.tName);

                //已經存在就取ID出來，沒有就新增一個
                if (checkTeam.Count() > 0)
                {
                     cTeamID = checkTeam.Select(x=>x.TeamID).First();
                }
                else
                {
                    Team newTeam = new Team{
                        TeamName=mPost.tName,
                        TeamMemberCount=0
                    };
                    UseTeam.Add(newTeam);
                    var nTeam = UseTeam.GetTeamByName(mPost.tName);
                    cTeamID = nTeam.Select(x => x.TeamID).First();
                }

                Member memberNew = new Member
                {
                    MamberEmail = mPost.Email,
                    MamberName = mPost.mName,
                    MemberAge = mPost.Age,
                    TeamID=cTeamID
                };
                //新增一筆成員
                UseMember.Add(memberNew);

                return View["MemberList.sshtml", UseMember.GetALLMember().Select(s => new
                {
                    mID = s.MemberID,
                    mName = s.MamberName,
                    mEmail = s.MamberEmail,
                    mAge = s.MemberAge,
                    mCdate = s.CreateDate,
                    tName = s.team.TeamName
                })];
            };
        }

    }
}