using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntegrateProject
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var pp = new IntegrateProject.Dal.Model.ProjectEntityDB())
            {
                var ee = pp.MemberSet.ToList();

                foreach(var ss in ee)
                {
                    Response.Write(ss.MamberEmail + ss.team.TeamName);
                }
            }
        }
    }
}