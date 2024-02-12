namespace SimpleSerialize
{
    public class Car
    {
        public Radio theRadio = new();
        public bool isHatchBack;
        public override string ToString() => $"IsHatchback:{isHatchBack} Radio:{theRadio}";
    }
}
