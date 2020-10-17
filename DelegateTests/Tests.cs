using System;
using NUnit.Framework;

namespace DelegateTests
{
    public class Tests
    {
        private delegate int MyIntFunction(int x);

        private delegate void MyAction(ref bool value);

        private static int Square(int x)
        {
            return x * x;
        }

        private static int Add(int x)
        {
            return x + x;
        }

        private static int MyIntExecutor(MyIntFunction myIntFunction, int value)
        {
            return myIntFunction(value);
        }

        private static int MyIntInvoker(MyIntFunction myIntFunction, int value)
        {
            return myIntFunction.Invoke(value);
        }

        private static void Toggle(ref bool value)
        {
            value = !value;
        }


        [Test]
        public void MyIntFunctionTest()
        {
            int LocalSquare(int x)
            {
                return x * x;
            }

            MyIntFunction square1 = Square;

            // evolution of the lambda (fat arrow =>) function 
            MyIntFunction square2 = delegate(int x) { return x * x; };
            MyIntFunction square3 = x => { return x * x; };
            MyIntFunction square4 = x => x * x;

            MyIntFunction square5 = LocalSquare;


            Assert.AreEqual(9, Square(3), $"{nameof(Square)} failed.");
            Assert.AreEqual(9, LocalSquare(3), $"{nameof(LocalSquare)} failed.");
            Assert.AreEqual(9, square1(3), $"{nameof(square1)} failed.");
            Assert.AreEqual(9, square2(3), $"{nameof(square2)} failed.");
            Assert.AreEqual(9, square3(3), $"{nameof(square3)} failed.");
            Assert.AreEqual(9, square4(3), $"{nameof(square4)} failed.");
            Assert.AreEqual(9, square5(3), $"{nameof(square5)} failed.");

            Assert.AreEqual(9, MyIntExecutor(square1, 3), $"{nameof(MyIntExecutor)} failed.");
            Assert.AreEqual(6, MyIntInvoker(Add, 3), $"{nameof(Add)} failed.");

            Assert.AreEqual(9, MyIntInvoker(i => i + i + i, 3));
        }

        [Test]
        public void MyActionTest()
        {
            MyAction toggle = Toggle;

            var value = true;

            toggle(ref value);

            Assert.IsFalse(value);
        }

        [Test]
        public void MyActionMultiCastTest()
        {
            var value = true; // true

            MyAction toggles = Toggle; // false
            toggles += Toggle; // true
            toggles += Toggle; // false
            toggles += (ref bool b) => b = !b; //true 

            toggles(ref value);

            Assert.IsTrue(value); //actions are invoked in the order they were added
        }

        [Test]
        public void FuncTest()
        {
            int LocalFunc()
            {
                return 5;
            }

            Func<int> localFunc = LocalFunc;
            Func<int> func = () => 5;
            Func<int, int> func1 = i => i * 5;
            Func<int, int, int> func2 = (i, j) => i + j; // last type is the return type

            Assert.Multiple(() =>
            {
                Assert.AreEqual(5, localFunc());
                Assert.AreEqual(5, func());
                Assert.AreEqual(25, func1(5));
                Assert.AreEqual(10, func2(5, 5));
            });
        }

        [Test]
        public void ActionTest()
        {
            //custom assertions example
            Action<string> AssertIsHelloWorld = s => Assert.IsTrue(s.Equals("Hello World"));
            Action<string, int> AssertHelloWorldSize = (s, i) => Assert.AreEqual(s.Length, i);

            AssertIsHelloWorld("Hello World");
            AssertHelloWorldSize("Hello World", 11);
        }
    }
}
