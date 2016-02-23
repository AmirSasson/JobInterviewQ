using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Diagnostics;

namespace Micro.Q1
{
    [TestClass]
    public class Varonis
    {
        [TestMethod]
        public void Single()
        {
            Node n = new Node() { Next = null, Val = 1 };

            ReverseRecursive(n);


        }

        [TestMethod]
        public void ListOf_2()
        {
            Node n2 = new Node() { Next = null, Val = 2 };
            Node n1 = new Node() { Next = n2, Val = 1 };
            PrintList(n1);
            var node = ReverseRecursive(n1);

            PrintList(node);

            Assert.AreEqual(n2.Next.Val, n1.Val);
            Assert.AreEqual(n1.Next, null);

        }

        [TestMethod]
        public void ListOf_5()
        {
            Node n5 = new Node() { Next = null, Val = 5 };
            Node n4 = new Node() { Next = n5, Val = 4 };
            Node n3 = new Node() { Next = n4, Val = 3 };
            Node n2 = new Node() { Next = n3, Val = 2 };
            Node n1 = new Node() { Next = n2, Val = 1 };
            PrintList(n1);
            var node = ReverseRecursive(n1);

            PrintList(node);

            Assert.AreEqual(n2.Next.Val, n1.Val);
            Assert.AreEqual(n1.Next, null);

        }

        [TestMethod]
        public void ListOf5_Iterative()
        {
            Node n5 = new Node() { Next = null, Val = 5 };
            Node n4 = new Node() { Next = n5, Val = 4 };
            Node n3 = new Node() { Next = n4, Val = 3 };
            Node n2 = new Node() { Next = n3, Val = 2 };
            Node n1 = new Node() { Next = n2, Val = 1 };
            PrintList(n1);
            var node = ReverseIterative(n1);

            PrintList(node);

            Assert.AreEqual(n2.Next.Val, n1.Val);
            Assert.AreEqual(n1.Next, null);

        }

        void PrintList(Node node)
        {
            StringBuilder sb = new StringBuilder();
            while (node != null)
            {
                sb.AppendFormat("{0}=>", node.Val);
                node = node.Next;
            }
            sb.Append("null");

            Console.WriteLine(sb.ToString());
            Trace.WriteLine(sb.ToString());
        }

        Node ReverseRecursive(Node head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            Node headReveresed = ReverseRecursive(head.Next);

            head.Next.Next = head;//we set the tail of the reversed to original head
            head.Next = null; // original head is the tail of the revresed

            return headReveresed;

        }
        Node ReverseIterative(Node head)
        {
            Node prev, curr, next;
            prev = null;
            curr = head;
            next = curr.Next;
            while (curr != null && curr.Next != null)
            {
                curr.Next = prev;
                prev = curr;
                curr = next;
                next = next.Next;
            }
            curr.Next = prev;
            return curr;
        }
    }





    //[DebuggerDisplay("",Name ="Val")]
    class Node
    {
        public Node Next { get; set; }

        public int Val { get; set; }
        public override string ToString()
        {
            return Val.ToString();
        }
    }
}
