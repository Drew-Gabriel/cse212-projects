public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    // Problem 1
    public void Insert(int value)
    {
        if (value == Data)
            return;

        if (value < Data)
        {
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // Problem 2
    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
        {
            if (Left == null)
                return false;

            return Left.Contains(value);
        }
        else
        {
            if (Right == null)
                return false;

            return Right.Contains(value);
        }
    }

    // Problem 4
    public int GetHeight()
    {
        int leftHeight = 0;
        int rightHeight = 0;

        if (Left != null)
            leftHeight = Left.GetHeight();

        if (Right != null)
            rightHeight = Right.GetHeight();

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}