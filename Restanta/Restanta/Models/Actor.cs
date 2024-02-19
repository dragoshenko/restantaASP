using Restanta.Models.Base;

namespace Restanta.Models
{
    public class Actor : BaseEntity
    {
        public string numeActor {  get; set; }

        public ICollection<ActoriFilme> ActoriFilme { get; set; }
    }
}
