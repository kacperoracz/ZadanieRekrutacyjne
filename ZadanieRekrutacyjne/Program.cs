using System;

namespace ZadanieRekrutacyjne
{
    class Program
    {
        class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }
        }

        static bool Exists(Node root, int n)
        {
            if (root.Value == n)
                return true;
            for (int counter = 2; true; counter++)
            {
                Node helpNode = root;
                string counterAsBinary = ToBinary(counter);
                for (int j = counterAsBinary.Length - 2; j >= 0; j--)
                {
                    if (counterAsBinary[j] == '0')
                        if (helpNode.Left != null)
                            helpNode = helpNode.Left;
                        else
                            return false;
                    else
                        if (helpNode.Right != null)
                            helpNode = helpNode.Right;
                        else
                            return false;
                }
                if (helpNode.Value == n)
                    return true;
            }
        }

        private static Node CreateSampleTree()
        {
            int[] tab = {5, 8, 4, 3, 9, 1, 2};
            int counter = 2;
            Node root = new Node
            {
                Left = null,
                Right = null,
                Value = tab[0]
            };
            for(int i = 1; i <= tab.Length-1; i++)
            {
                Node helpNode = root;
                string counterAsBinary = ToBinary(counter);
                for (int j = counterAsBinary.Length - 2; j >= 0; j--)
                {
                    if (counterAsBinary[j] == '0')
                        if (helpNode.Left == null)
                        {
                            helpNode.Left = new Node
                            {
                                Left = null,
                                Right = null,
                                Value = tab[i]
                            };
                        }
                        else
                            helpNode = helpNode.Left;
                    else
                        if (helpNode.Right == null)
                        {
                            helpNode.Right = new Node
                            {
                                Left = null,
                                Right = null,
                                Value = tab[i]
                            };
                        }
                        else
                            helpNode = helpNode.Right;
                }
                
                counter++;
            }
            return root;
        }

        private static string ToBinary(int counter)
        {
            string binary = "";
            while (counter != 0)
            {
                binary += $"{counter % 2}";
                counter /= 2;
            }
            return binary;
        }

        static void Main(string[] args)
        {
            int n = 7;
            var tree = CreateSampleTree();
            if (Exists(tree, n))
            {
                Console.WriteLine($"Found value {n} in given tree");
            }
            else
            {
                Console.WriteLine($"Value {n} not found");
            }
        }
    }
}
