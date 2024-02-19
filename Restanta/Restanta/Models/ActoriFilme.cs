using Restanta.Models.Base;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Restanta.Models
{
    public class ActoriFilme : BaseEntity
    {
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }

        public Guid FilmId { get; set; }

        public Film Film { get; set; }
    }
}
