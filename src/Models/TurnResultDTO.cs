namespace thegame
{
    public class TurnResultDTO
    {
        public int Position {get; set;}
        public int Type {get; set;}
        public bool IsFlipped { get; set; }
        public int PreviousPosition { get; set; }
        public bool IsMatch { get; set; }
    }
}