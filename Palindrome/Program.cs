using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace Palindrome;
public class Program
{
    static void Main(string[] args)
    {
        LinkedList<string> linkedList = new LinkedList<string>();

        linkedList.AddLast("xbx");
        linkedList.AddLast("pka");
        linkedList.AddLast("pka");
        linkedList.AddLast("xbx");

        var reverse = linkedList.Reverse();
        var currentNode = linkedList.First;
        var currentNodeReverse = reverse.First();

        while( currentNode != null)
        {
            currentNode = currentNode.Next;
        }

        foreach( var node in linkedList)
        {
            Console.WriteLine(node);
        }
    }

    public static bool IsPalindrome<T>(LinkedList<T> linkedList)
    {
        var left = linkedList.First;
        var right = linkedList.Last;

        while(left.Value.Equals(right.Value))
        {

            if( left == right || left.Next == right)
            {
                if (left.Value.Equals(right.Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            left = left.Next;
            right = right.Previous;

        }



        return false;
    }
}

