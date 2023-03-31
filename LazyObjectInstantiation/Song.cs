namespace LazyObjectInstantiation
{
    // Представляет одиночную композицию.
    class Song
    {
        public string Artist { get; set; } = string.Empty;
        public string TrackName { get; set; } = string.Empty;
        public double TrackLength { get; set; }
    }
}
