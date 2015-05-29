using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CrackingCodingInterviews._3._5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void INOUt()
        {
            CustomQueue test = new CustomQueue();
            test.Enqueue(1);
            test.Enqueue(2);
            Assert.AreEqual(1,test.Dequeue());
            Assert.AreEqual(2,test.Dequeue());
            test.Enqueue(3);
            test.Enqueue(4);
            Assert.AreEqual(3,test.Dequeue());
            Assert.AreEqual(4,test.Dequeue());

        }

        [TestMethod]
        public void exception()
        {
            CustomQueue test = new CustomQueue();

            try
            {
                test.Dequeue();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Empty queue", ex.Message);
            }
        }
    }

    public class CustomQueue 
    { 
        Stack<int> input = new Stack<int>();
        Stack<int> output= new Stack<int>();

        public void Enqueue(int element)
        {
            this.input.Push(element);
        }

        public int Dequeue()
        {
            if (this.output.Count != 0)
            {
                return this.output.Pop();
            }
            else 
            {
                if (this.input.Count != 0)
                {
                    while ( this.input.Count>0)
                    {
                        this.output.Push(this.input.Pop());
                    }
                    return this.output.Pop();
                }
                else 
                {
                    throw new Exception("Empty queue");
                }
            }
        }
    }

}
