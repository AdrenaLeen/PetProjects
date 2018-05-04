using System.ServiceModel;

namespace MathServiceLibrary
{
    [ServiceContract]
    public interface IBasicMath
    {
        [OperationContract]
        int Add(int x, int y);
    }
}
