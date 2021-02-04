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
        internal BinaryTree(List<int> values) => this.SetNodeValues(values);
        private void SetNodeValues(List<int> values)
        {
            var level = 0;
            var indexOnLevel = 0;
            var bufferList = new List<int>();

            for (var i = 0; i < values.Count; i++)
            {
                bufferList.Add(values[i]);
                if (level == indexOnLevel)
                {
                    level++;
                    indexOnLevel = 0;
                    this.Tree.Add(new List<int>(bufferList));
                    bufferList.Clear();
                }
                else
                {
                    indexOnLevel++;
                }
            }
        }
        public void FindMaxSumPath(int i = 0, int j = 0)
        {
            this.CurrentPath.Add(this.Tree[i][j]);

            // Checking if the bottom level was reached
            if (this.Tree.Count == this.CurrentPath.Count)
            {
                if (this.MaxSumPath.Sum() < this.CurrentPath.Sum())
                {
                    this.MaxSumPath = new List<int>(this.CurrentPath);
                };

                this.StepBack(i);
                return;
            }

            // Left child
            if (IsNextNodeValid(this.Tree[i][j], this.Tree[i + 1][j]))
            {
                this.FindMaxSumPath(i + 1, j);
            }

            if (IsNextNodeValid(this.Tree[i][j], this.Tree[i + 1][j + 1]))
            {
                //  Right child
                this.FindMaxSumPath(i + 1, j + 1);
            }

            this.StepBack(i);
        }

        private static bool IsNextNodeValid(int currentNode, int nextNode) => (currentNode % 2) != (nextNode % 2);

        private void StepBack(int i)
        {
            this.CurrentPath.RemoveAt(i);
            i = i > 0 ? i-- : i;
        }

        internal void PrintResult() => Console.WriteLine(
            "Max sum: {0}\n" +
            "Path: {1}",
            this.MaxSumPath.Sum(),
            string.Join(", ", this.MaxSumPath));
    }
}
