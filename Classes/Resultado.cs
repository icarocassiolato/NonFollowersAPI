namespace NonFollowersAPI.Classes
{
    public class Resultado
    {
        public int Seguindo { get; set; }
        public int Seguidores { get; set; }
        public List<ExternalUser> NaoSeguidores { get; set; }
    }
}
