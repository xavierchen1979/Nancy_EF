namespace IntegrateProject.Dal.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema; 

    public class Member
    {
        //public Member()
        //{
        //    this.CreateDate = DateTime.Now; //預設給現在時間
        //}

        public int MemberID { set; get; }
        public string MamberName { set; get; }
        public string MamberEmail { set; get; }
        public int MemberAge { set; get; }
        public int TeamID { set; get; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public DateTime? CreateDate { set; get; }
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
        
        
        
        public virtual Team team { set; get; }
    }
}