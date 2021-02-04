namespace BinaryTreePathFinder
{
    using BinaryTreePathFinder.Classes;

    public class Program
    {
        public static void Main()
        {
            var binaryTree = new BinaryTree(Data.NodeValues);
            binaryTree.FindMaxSumPath();
            binaryTree.PrintResult();
        }
    }
}
