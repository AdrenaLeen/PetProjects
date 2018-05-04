using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathServiceLibrary
{
    public class MathService : IBasicMath
    {
        public int Add(int x, int y)
        {
            // Для эмуляции длительного запроса.
            System.Threading.Thread.Sleep(5000);
            return x + y;
        }
    }
}
