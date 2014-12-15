namespace IntegrateProject.Dal.Frame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class UseBase<T> : IUseBase<T> where T : class
    {
          
        //public virtual void Add(T d) { }

        public virtual void Update(T d) { }

        public virtual void Delete(T d) { }

        public virtual void Delete(int id) { }

         
    }
}