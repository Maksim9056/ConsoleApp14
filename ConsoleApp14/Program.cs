using ConsoleApp14;

namespace ConsoleApp14
{
    class BSTNode
    {
        public int key;
        public BSTNode left;
        public BSTNode right;

        public BSTNode(int key)
        {
            this.key = key;
            this.left = null;
            this.right = null;
        }
    }

    class BST
    {
        BSTNode root;

        public void insert(int key)
        {
            root = insertHelper(root, key);
        }

        BSTNode insertHelper(BSTNode root, int key)
        {
            if (root == null)
            {
                return new BSTNode(key);
            }

            if (key < root.key)
            {
                root.left = insertHelper(root.left, key);
            }
            else if (key > root.key)
            {
                root.right = insertHelper(root.right, key);
            }

            return root;
        }

        public void visualize()
        {
            visualizeHelper(root, " ", true);
        }

        private void visualizeHelper(BSTNode node, String prefix, bool isLeft)
        {
            if (node == null)
            {
                return;
            }

            String nodeStr = node.key.ToString();
            String line = prefix + (isLeft ? "├── " : "└── ");
            Console.WriteLine(line + nodeStr);

            String childPrefix = prefix + (isLeft ? "│   " : "    ");
            visualizeHelper(node.left, childPrefix, true);
            visualizeHelper(node.right, childPrefix, false);
        }

        public void inOrderTraversal()
        {
            inOrderTraversalHelper(root);
            Console.WriteLine();
            //   System.out.println();
        }

        private void inOrderTraversalHelper(BSTNode node)
        {
            if (node != null)
            {
                inOrderTraversalHelper(node.left);
               Console.WriteLine(node.key + " ");
                inOrderTraversalHelper(node.right);
            }
        }

        public void preOrderTraversal()
        {
            preOrderTraversalHelper(root);
            //  System.out.println();
        }

        public  void preOrderTraversalHelper(BSTNode node)
        {
            if (node != null)
            {
                Console.WriteLine(node.key + " ");
                preOrderTraversalHelper(node.left);
                preOrderTraversalHelper(node.right);
            }
        }
    } }

    internal class Program
    {
        static void Main(string[] args)
        {
        BST bst = new BST();

        // Insert nodes into the BST
        int[] anArrayNodes = {
                17, 6, 5, 20, 19, 18, 11, 14, 12, 13, 2, 4, 10
        };

        for (int i = 0; i < anArrayNodes.Length; i++)
        {
            bst.insert(anArrayNodes[i]);
        }

        // Visualize the BST
        bst.visualize();

        // In-order traversal of BST
        Console.WriteLine("In-order Traversal: ");
        bst.inOrderTraversal();

        // Pre-order traversal of BST
        Console.WriteLine("Pre-order Traversal: ");
        bst.preOrderTraversal();
        Console.ReadLine();
    }
}
