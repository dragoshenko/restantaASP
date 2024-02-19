namespace Restanta.Models.Dtos
{
    public class ActoriFilmeDto
    {
        public Guid ActorId { get; set; }

        public Actor Actor { get; set; }

        public Guid FilmId { get; set; }

        public Film Film { get; set; }
    }
}
