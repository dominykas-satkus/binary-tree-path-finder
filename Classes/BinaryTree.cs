namespace BinaryTreePathFinder.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree
    {
        internal List<List<int>> Tree { get; set; } = new List<List<int>>();
        private List<int> MaxSumPath { get; set; } = new List<int>();
        private List<int> CurrentPath { get; set; } = new List<int>();
        internal BinaryTree(List<int> values) => this.InitializeTree(values);
        private void InitializeTree(List<int> nodeValues)
        {
            var level = 1;

            //  Buffer list for nodes on each tree level
            var nodesOnLevel = new List<int>();

            for (var i = 0; i < nodeValues.Count; i++)
            {
                nodesOnLevel.Add(nodeValues[i]);

                //  Node count on level matches level number: first level has one,
                //  ... second has two, etc.
                if (level == nodesOnLevel.Count)
                {
                    //  When level buffer is filled with enough nodes, copy of
                    //  ... the buffer is added as one level of the tree
                    this.Tree.Add(new List<int>(nodesOnLevel));
                    nodesOnLevel.Clear();
                    level++;
                }
            }

            //  The task states that all not leaf nodes have two children
            //  If it changes and the last level might be incomplete
            //  ... the following lines should be uncommented to add it.
            //if (nodesOnLevel.Count > 0)
            //{
            //    this.Tree.Add(new List<int>(nodesOnLevel));
            //}
        }
        public void FindMaxSumPath(int i = 0, int j = 0)
        {
            this.CurrentPath.Add(this.Tree[i][j]);

            // Checking if the last level of the tree was reached.
            if (this.Tree.Count == this.CurrentPath.Count)
            {
                if (this.MaxSumPath.Sum() < this.CurrentPath.Sum())
                {
                    //  If the current path sum is greater, it is saved as
                    //  ... the biggest path by creating a copy of the list.
                    this.MaxSumPath = new List<int>(this.CurrentPath);
                };

                //  Returns one level back
                this.StepBack(i);
                return;
            }

            if (IsNextNodeValid(this.Tree[i][j], this.Tree[i + 1][j]))
            {
                //  If the left children is valid, it continues on it recursively.
                this.FindMaxSumPath(i + 1, j);
            }

            if (IsNextNodeValid(this.Tree[i][j], this.Tree[i + 1][j + 1]))
            {
                //  If the right children is valid, it continues on it recursively.
                this.FindMaxSumPath(i + 1, j + 1);
            }

            this.StepBack(i);
        }

        //  Method checks if one argument is even and another odd. This helps to decide if the following
        //  ... node is valid to continue on according to the task.
        private static bool IsNextNodeValid(int currentNode, int nextNode) => (currentNode % 2) != (nextNode % 2);

        private void StepBack(int i)
        {
            //  Removes the last item on the path list
            this.CurrentPath.RemoveAt(i);
            //  Reduces the level index - steps one level back
            i = i > 0 ? i-- : i;
        }

        internal void PrintResult() => Console.WriteLine(
            "Max sum: {0}\n" +
            "Path: {1}",
            this.MaxSumPath.Sum(),
            string.Join(", ", this.MaxSumPath));
    }
}
