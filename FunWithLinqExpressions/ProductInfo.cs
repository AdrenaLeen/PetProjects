namespace FunWithLinqExpressions
{
    class ProductInfo
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int NumberInStock { get; set; }

        public override string ToString() => $"Название={Name}, Описание={Description}, Количество в магазине={NumberInStock}";
    }
}
