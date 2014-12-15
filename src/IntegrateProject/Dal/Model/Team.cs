namespace IntegrateProject.Dal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            //this.CreateDate = DateTime.Now;
            MemberList = new List<Member>();
        }
        public int TeamID { set; get; }
        public string TeamName { set; get; }
        public int TeamMemberCount { set; get; }

       //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;

        //public DateTime? CreateDate { set; get; }

        public virtual ICollection<Member> MemberList { set; get; }

         
    }
}