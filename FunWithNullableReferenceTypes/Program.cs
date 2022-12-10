using FunWithNullableReferenceTypes;

string? nullableString = null;
TestClass? myNullableClass = null;

// Предупреждение CS8600 Преобразование литерала null или возможного значения null в тип, не допускающий null
TestClass myNonNullableClass = myNullableClass;

#nullable disable
TestClass anotherNullableClass = null;

//Предупреждение CS8632 Заметка для ссылочных типов, допускающих значение null, должна использоваться только в коде внутри аннотаций #nullable
TestClass? badDefinition = null;

//Предупреждение CS8632 Заметка для ссылочных типов, допускающих значение null, должна использоваться только в коде внутри аннотаций #nullable
string? anotherNullableString = null;
#nullable restore