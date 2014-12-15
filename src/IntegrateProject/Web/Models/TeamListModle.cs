namespace IntegrateProject.Web.Models
{
    using Nancy;
    using IntegrateProject.Dal.Frame;
    using System.Linq;
    using System.Collections.Generic;
    using Nancy.ModelBinding;
    using IntegrateProject.Dal.Model;

    public class TeamListModle : baseModel
    {
        //private readonly IUseTeam UseTeam;

        public class BlogPost
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public List<string> Tags { get; set; }

            public BlogPost()
            {
                Tags = new List<string>();
            }
        }

        public TeamListModle(IUseTeam UseTeam)
        {
            Get["/"] = e =>
            {
                //UseTeam.GetALLTeam();
                //return "hello";

                ////return Json
                //return Response.AsJson(UseTeam.GetALLTeam().Select(x => new
                //{
                //    name = x.TeamName,
                //    count = x.TeamMemberCount
                //}));
                return View["index.sshtml",UseTeam.GetALLTeam().Select(x => new 
                {
                    id=x.TeamID,
                    name = x.TeamName,
                    count = x.TeamMemberCount,
                    cdate =x.CreateDate
                })];

                //return Response.AsJson(UseTeam.GetALLTeam().Select(x => new
                //{
                //    desc = x.ToString()
                //}));
                
            };

            Get["view/{ID}"] = e =>
            {
                int id = e.ID;
                return View["index.sshtml", UseTeam.GetTeamByID(id).Select(x => new
                {
                    id = x.TeamID,
                    name = x.TeamName,
                    count = x.TeamMemberCount,
                    cdate = x.CreateDate
                })];
            };

            Post["/add/"] = e =>
            {
                BlogPost blogPost = this.Bind<BlogPost>();
                 

                Team teamNew = new Team()
                {
                    TeamName = blogPost.Title

                };

                UseTeam.Add(teamNew);

                return View["index.sshtml", UseTeam.GetALLTeam().Select(x => new
                {
                    id = x.TeamID,
                    name = x.TeamName,
                    count = x.TeamMemberCount,
                    cdate = x.CreateDate
                })];

            };
            Get["/add/"] = e =>
            {
                return View["add.sshtml"];
            };
        }
    }
}