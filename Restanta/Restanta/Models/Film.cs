using Restanta.Models.Base;

namespace Restanta.Models
{
    public class Film : BaseEntity
    {
        public string numeFilm { get; set; }

        public ICollection<ActoriFilme> ActoriFilme { get; set; }
    }
}
