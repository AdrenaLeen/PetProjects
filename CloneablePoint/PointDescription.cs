namespace CloneablePoint
{
    // Этот класс описывает точку.
    class PointDescription
    {
        public string PetName { get; set; }
        public Guid PointID { get; set; }

        public PointDescription()
        {
            PetName = "Безымянный";
            PointID = Guid.NewGuid();
        }
    }
}
