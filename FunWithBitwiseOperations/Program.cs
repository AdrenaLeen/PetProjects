using FunWithBitwiseOperations;

Console.WriteLine("***** Перечисления, флаги и побитовые операции *****");

Console.WriteLine($"6 & 4 = {6 & 4} | {Convert.ToString(6 & 4, 2)}");
Console.WriteLine($"6 | 4 = {6 | 4} | {Convert.ToString(6 | 4, 2)}");
Console.WriteLine($"6 ^ 4 = {6 ^ 4} | {Convert.ToString(6 ^ 4, 2)}");
Console.WriteLine($"6 << 1 = {6 << 1} | {Convert.ToString(6 << 1, 2)}");
Console.WriteLine($"6 >> 1 = {6 >> 1} | {Convert.ToString(6 >> 1, 2)}");
Console.WriteLine($"~6 = {~6} | {Convert.ToString(~6, 2)}");
Console.WriteLine($"Int.MaxValue {Convert.ToString(int.MaxValue, 2)}");
Console.WriteLine();

ContactPreferenceEnum emailAndPhone = ContactPreferenceEnum.Email | ContactPreferenceEnum.Phone;

Console.WriteLine($"None? {(emailAndPhone | ContactPreferenceEnum.None) == emailAndPhone}");
Console.WriteLine($"Email? {(emailAndPhone | ContactPreferenceEnum.Email) == emailAndPhone}");
Console.WriteLine($"Phone? {(emailAndPhone | ContactPreferenceEnum.Phone) == emailAndPhone}");
Console.WriteLine($"Text? {(emailAndPhone | ContactPreferenceEnum.Text) == emailAndPhone}");

Console.ReadLine();