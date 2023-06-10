namespace FunWithLinqExpressions
{
    internal class ProductInfoSmall
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public override string ToString() => $"Название={Name}, Описание={Description}";
    }
}
