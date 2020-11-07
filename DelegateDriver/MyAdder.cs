namespace DelegateDriver
{
    public class MyAdder
    {
        private readonly AdderDelegate _adderDelegate;
        private readonly IAdder _adder;

        public MyAdder(AdderDelegate adderDelegate, IAdder adder)
        {
            _adderDelegate = adderDelegate;
            _adder = adder;
        }

        public double AddViaDelegate(double l, double r)
        {
            return _adderDelegate(l, r);
        }

        public double AddViaInterface(double l, double r)
        {
            return _adder.Add(l, r);
        }
    }
}
