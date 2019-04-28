using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace two_way_list
{
    public class My_list<Type>
    {
        public Element<Type> Head { get; private set; }
        public Element<Type> Last { get; private set; }
        public Element<Type> Iteratorforward;
        public Element<Type> Iteratorbackward;

        public int ItemCounter { get; private set; }
        public My_list() { Head =Last= null; }
        public class Element<Type>
        {
            public Element<Type> next, prev;
            public Type data { get; set; }

            public static Element<Type> operator ++(Element<Type> actual)
            {
                return actual.next;
            }
            public static Element<Type> operator --(Element<Type> actual)
            {
                return actual.prev;
            }
            public Element(Type data)
            {
                this.next = null;
                this.prev = null;
                this.data = data;
            }
        }
        public void InsertFront(Type data)
        {
            Element<Type> newNode = new Element<Type>(data);
            if (Head == null)
            {
                Head = newNode;

                if (Last == null)
                {
                    Last = newNode;
                }
                ItemCounter++;
                return;
            }
            if (Head != null)
            {
                Element<Type> first_node = Head;
                Head = newNode;
                Head.next = first_node;
                first_node.prev = Head;
            }

            ItemCounter++;
        }
        public void InsertAfter(Element<Type> actual, Type data)
        {
            if (actual == null)
            {
                Console.WriteLine("Podełeś nieziainicjalizowany element");
                return;
            }
            Element<Type> newNode = new Element<Type>(data);
            newNode.next = actual.next;
            actual.next = newNode;
            newNode.prev = actual;
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
            else { Last = newNode; }
            ItemCounter++;
        }
        public void InsertLast( Type data)
        {
            ItemCounter++;
            Element<Type> newNode = new Element<Type>(data);
            if (Head == null)
            {
                newNode.prev = null;
                Head = newNode;
                Last = newNode;
                return;
            }
            Element<Type> lastNode =Last;
            lastNode.next = newNode;
            newNode.prev = lastNode;
            Last = newNode;
        }
        public void DeleteNodebyKey( Type key)
        {
            Element<Type> actual = Head;
            if (actual != null && actual.data.Equals(key))
            {
                Head = actual.next;
                Head.prev = null;
                if (actual == Last)
                    Last = actual.prev;///null
                ItemCounter--;
                return;
            }

            while (actual != null && !actual.data.Equals(key))
            {
                actual = actual.next;
            }
            if (actual == null)
            {
                return;
            }
            if (actual.next != null)
            {
                actual.next.prev = actual.prev;
            }
            else////UWaga
            {
                Last=actual.prev;
            }
            if (actual.prev != null)
            {
                actual.prev.next = actual.next;
            }
            else
            {
                Head = actual.next;
            }

            ItemCounter--;
        }
        public void DeleteThisNode(Element<Type> actual)
        {
            if (actual == null)
                return;
            if (actual == Last)
                Last = actual.prev;
            if (actual == Head)
                Head = actual.next;

            if (actual.next != null)
            {
                actual.next.prev = actual.prev;
            }
            if (actual.prev != null)
            {
                actual.prev.next = actual.next;
            }
            ItemCounter--;
        }

    }
}
