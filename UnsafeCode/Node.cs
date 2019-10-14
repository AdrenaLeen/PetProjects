namespace UnsafeCode
{
    // Вся эта структура является небезопасной и может использовать только в небезопасном контексте.
    unsafe struct Node
    {
        public int Value;
        public Node* Left;
        public Node* Right;
    }
}
