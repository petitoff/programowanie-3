using Battleship.Constans;

namespace Battleship.Model
{
    public class Battlefield
    {
        public int[,] Field { get; set; }
        public bool IsEmpty { get; set; }
        public Player Player { get; set; }
        public int Id { get; set; }
    }
}
