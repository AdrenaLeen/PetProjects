namespace MIInterfaceHierarchy
{
    interface IPrintable
    {
        void Print();
        
        // Возможен конфликт имён!
        void Draw();
    }
}
