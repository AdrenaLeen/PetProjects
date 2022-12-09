namespace FunWithNullableValueTypes
{
    class DatabaseReader
    {
        // Поле данных типа, допускающего null.
        public int? numericValue = null;
        public bool? boolValue = true;

        // Обратите внимание на возвращаемый тип, допускающий null.
        public int? GetIntFromDatabase() => numericValue;

        // Обратите внимание на возвращаемый тип, допускающий null.
        public bool? GetBoolFromDatabase() => boolValue;
    }
}
