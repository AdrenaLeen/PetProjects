namespace LambdaExpressions
{
    public class SimpleMath
    {
        public delegate void MathMessage(string msg, int result);
        private MathMessage? mmDelegate;

        public void SetMathHandler(MathMessage target) => mmDelegate = target;

        public void Add(int x, int y) => mmDelegate?.Invoke("Суммирование завершено!", x + y);
    }
}
