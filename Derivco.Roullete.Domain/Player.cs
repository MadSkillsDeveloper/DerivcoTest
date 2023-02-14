namespace Derivco.Roullete.Domain
{
    public class Player
    {
        #region Fields
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Methods
        #endregion

        #region Constructors
        public Player()
        {

        }

        public Player(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion
    }
}
