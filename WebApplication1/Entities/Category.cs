using WebApplication1.Entities;

namespace WebApiDemo.Entities
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
