namespace MiInterfaceHierarchy
{
    interface IPrintable
    {
        void Print();
        
        // Возможен конфликт имен!
        void Draw();
    }
}
