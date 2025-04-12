using System.Transactions;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    List<int> tempList = new(); 

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (!tempList.Contains(value)){
            tempList.Add(value);

            if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        }
    }

    public bool Contains(int value)
    {   
        bool result;
        if (value == Data) {
            return true;
        } else {
            if (value < Data) {
            if (Left is null) {
                return false;
            } else {
                result = Left.Contains(value);
            }
        } else if (value > Data) {
            if (Right is null){
                return false;
            } else {
                result = Right.Contains(value);
            }
        } else {
            result = false;
        }
        }

        
        return result;
    }

    public int GetHeight()
    {
        int leftResult = 0;
        int rightResult = 0;
        int finalResult = 0;
        if (this == null) {
            return 0;
        } else {
            
            if (Left is not null){
              leftResult =  Left.GetHeight() + 1;
            } else {
                if (Right is not null){
                    rightResult = Right.GetHeight() + 1;
                } else {
                    return 1;
                }
            }
            if (Right is not null){
                rightResult = Right.GetHeight() + 1;
            } else {
                if (Left is not null){
                    leftResult = Left.GetHeight() + 1;
                } else {
                    return 1;
                }
            }


        }

        if (leftResult > rightResult){
            finalResult = leftResult;
        } else {
            finalResult = rightResult;
        }

        
        return finalResult;
    }
}