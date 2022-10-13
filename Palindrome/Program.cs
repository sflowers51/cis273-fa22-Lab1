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
        // are the first and alst items the same?
        // if so, move toward the middle
        return true;
    }
}

