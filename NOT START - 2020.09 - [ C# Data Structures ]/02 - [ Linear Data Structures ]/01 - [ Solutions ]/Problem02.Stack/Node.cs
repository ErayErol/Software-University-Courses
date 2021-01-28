namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node()
        {
            
        }

        public Node(T value, Node<T> next = null)
        {
            this.Element = value;
            this.Next = next;
        }

        public T Element { get; set; }          // Must have
        
        public Node<T> Next { get; set; }       // Must have
        
        public Node<T> Previous { get; set; }   // Additional
    }
}