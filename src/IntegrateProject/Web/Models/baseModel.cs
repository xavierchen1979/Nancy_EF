namespace IntegrateProject.Web.Models
{
    using Nancy;

    public class baseModel:NancyModule
    {
        public baseModel() : base() {
        }

         

        public baseModel(string basePath) : base(basePath) { }

        

    }
    
}