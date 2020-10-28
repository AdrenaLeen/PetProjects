using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace MyAsmBuilder
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** Динамически сгенерированная сборка *****");
            // Получить домен приложения для текущего потока.
            AppDomain curAppDomain = Thread.GetDomain();

            // Создать динамическую сборку с помощью нашего вспомогательного метода.
            CreateMyAsm(curAppDomain);
            Console.WriteLine("-> Завершено создание MyAssembly.dll.");

            // Загрузить новую сборку из файла.
            Console.WriteLine("-> Загружена MyAssembly.dll из файла.");
            Assembly a = Assembly.Load("MyAssembly");

            // Получить тип HelloWorld.
            Type hello = a.GetType("MyAssembly.HelloWorld");

            // Создать объект HelloWorld и вызвать корректный конструктор.
            Console.Write("-> Введите ссобщение для передачи классу HelloWorld: ");
            string msg = Console.ReadLine();
            object[] ctorArgs = new object[1];
            ctorArgs[0] = msg;
            object obj = Activator.CreateInstance(hello, ctorArgs);

            // Вызвать SayHello и отобразить возвращённую строку.
            Console.WriteLine("-> Вызван SayHello() через позднее связывание.");
            MethodInfo mi = hello.GetMethod("SayHello");
            mi.Invoke(obj, null);

            // Вызвать метод.
            mi = hello.GetMethod("GetMsg");
            Console.WriteLine(mi.Invoke(obj, null));

            Console.ReadLine();
        }

        // Объект AppDomain отправляется вызывающим кодом.
        public static void CreateMyAsm(AppDomain curAppDomain)
        {
            // Установить общие характеристики сборки.
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "MyAssembly";
            assemblyName.Version = new Version("1.0.0.0");

            // Создать новую сборку внутри текущего домена приложения.
            AssemblyBuilder assembly = curAppDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);

            // Поскольку строится однофайловая сборка, имя модуля будет таким же, как у сборки.
            ModuleBuilder module = assembly.DefineDynamicModule("MyAssembly", "MyAssembly.dll");

            // Определить открытый класс по имени HelloWorld.
            TypeBuilder helloWorldClass = module.DefineType("MyAssembly.HelloWorld", TypeAttributes.Public);

            // Определить закрытую переменную-член типа string по имени theMessage.
            FieldBuilder msgField = helloWorldClass.DefineField("theMessage", Type.GetType("System.String"), FieldAttributes.Private);

            // Создать специальный конструктор.
            Type[] constructorArgs = new Type[1];
            constructorArgs[0] = typeof(string);
            ConstructorBuilder constructor = helloWorldClass.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, constructorArgs);
            ILGenerator constructorIL = constructor.GetILGenerator();
            constructorIL.Emit(OpCodes.Ldarg_0);
            Type objectClass = typeof(object);
            ConstructorInfo superConstructor = objectClass.GetConstructor(new Type[0]);
            constructorIL.Emit(OpCodes.Call, superConstructor);
            constructorIL.Emit(OpCodes.Ldarg_0);
            constructorIL.Emit(OpCodes.Ldarg_1);
            constructorIL.Emit(OpCodes.Stfld, msgField);
            constructorIL.Emit(OpCodes.Ret);

            // Создать стандартный конструктор.
            helloWorldClass.DefineDefaultConstructor(MethodAttributes.Public);

            // Создать метод GetMsg().
            MethodBuilder getMsgMethod = helloWorldClass.DefineMethod("GetMsg", MethodAttributes.Public, typeof(string), null);
            ILGenerator methodIL = getMsgMethod.GetILGenerator();
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, msgField);
            methodIL.Emit(OpCodes.Ret);

            // Создать метод SayHello().
            MethodBuilder sayHiMethod = helloWorldClass.DefineMethod("SayHello", MethodAttributes.Public, null, null);
            methodIL = sayHiMethod.GetILGenerator();
            methodIL.EmitWriteLine("Привет из класса HelloWorld!");
            methodIL.Emit(OpCodes.Ret);

            // Выпустить класс HelloWorld.
            helloWorldClass.CreateType();

            // (Дополнительно) сохранить сборку в файле.
            assembly.Save("MyAssembly.dll");
        }
    }
}
