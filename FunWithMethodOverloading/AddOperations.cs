namespace FunWithMethodOverloading
{
    public static class AddOperations
    {
        public static int Add(int x, int y) => x + y;

        public static int Add(int x, int y, int z = 0) => x + (y * z);

        public static double Add(double x, double y) => x + y;

        public static long Add(long x, long y) => x + y;
    }
}
