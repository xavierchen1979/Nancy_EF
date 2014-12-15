namespace IntegrateProject.Dal.Frame
{
    using System.Linq;

    public interface IUseBase<T>  
    { 
       // void Add(T d);

        void Update(T d);

        void Delete(T d);

        void Delete(int id);

    }
}
