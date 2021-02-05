namespace BinaryTreePathFinder
{
    using BinaryTreePathFinder.Classes;

    public class Program
    {
        public static void Main()
        {
            //  Initializing a tree with data from constant.
            var binaryTree = new BinaryTree(Data.NodeValues);
            //  Method for finding and setting the path that has the
            //  ... maximum sum from root to leaves.
            binaryTree.FindMaxSumPath();
            binaryTree.PrintResult();
        }
    }
}
