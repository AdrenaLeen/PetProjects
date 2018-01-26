using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace VehicleDescriptionAttributeReaderLateBinding
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Значение VehicleDescriptionAttribute *****");
            ReflectAttributesUsingLateBinding();
            Console.ReadLine();
        }

        private static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                // Загрузить локальную копию сборки AttributedCarLibrary.
                Assembly asm = Assembly.Load("AttributedCarLibrary");

                // Получить информацию о типе VehicleDescriptionAttribute.
                Type vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");

                // Получить информацию о типе свойства Description.
                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");

                // Получить все типы в сборке.
                Type[] types = asm.GetTypes();

                // Пройти по всем типам и получить любые атрибуты VehicleDescriptionAttributes.
                foreach (Type t in types)
                {
                    object[] objs = t.GetCustomAttributes(vehicleDesc, false);

                    // Пройти по каждому VehicleDescriptionAttribute и вывести описание, используя позднее связывание.
                    foreach (object o in objs) Console.WriteLine($"-> {t.Name}: {propDesc.GetValue(o, null)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
