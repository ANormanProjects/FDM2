namespace LambdasExcercise
{
    public class Cd
    {
        public string title { get; set; }
        public string artist { get; set; }
        public int length { get; set; }
        public int numberOfTracks { get; set; }

        public Cd(string Title, string Artist, int Length, int NumberOfTracks)
        {
            title = Title;
            artist = Artist;
            length = Length;
            numberOfTracks = NumberOfTracks;
        }
    }
}
