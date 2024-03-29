﻿namespace FunWithLinqExpressions
{
    class ProductInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int NumberInStock { get; set; }

        public override string ToString() => $"Название={Name}, Описание={Description}, Количество в магазине={NumberInStock}";
    }
}
