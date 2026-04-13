using System.Collections;

namespace lab_8.BST;

public class Tree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> _root;
        
        public void Insert(T element)
        {
            _root = InsertRecursive(_root, element);
        }

        private Node<T> InsertRecursive(Node<T> node, T element)
        {
            if (node == null)
            {
                return new Node<T>(element);
            }

            int comparison = element.CompareTo(node.Data);

            if (comparison < 0)
            {
                node.Left = InsertRecursive(node.Left, element);
            }
            else if (comparison > 0)
            {
                node.Right = InsertRecursive(node.Right, element);
            }
            else
            {
                node.Data = element; 
            }

            return node;
        }
        
        public Node<T> Find(T element)
        {
            return FindRecursive(_root, element);
        }

        private Node<T> FindRecursive(Node<T> node, T element)
        {
            if (node == null) return null;

            int comparison = element.CompareTo(node.Data);

            if (comparison == 0) return node;
            
            if (comparison < 0)
                return FindRecursive(node.Left, element); 
            else
                return FindRecursive(node.Right, element); 
        }
        
        public void Remove(T element)
        {
            _root = RemoveRecursive(_root, element);
        }

        private Node<T> RemoveRecursive(Node<T> node, T element)
        {
            if (node == null) return null;

            int comparison = element.CompareTo(node.Data);

            if (comparison < 0)
            {
                node.Left = RemoveRecursive(node.Left, element);
            }
            else if (comparison > 0)
            {
                node.Right = RemoveRecursive(node.Right, element);
            }
            else
            {
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;
                
                if (node.Right.Left == null)
                {
                    node.Data = node.Right.Data;
                    node.Right = node.Right.Right;
                }
                else
                {
                    Node<T> minNode = FindMin(node.Right);
                    node.Data = minNode.Data;
                    node.Right = RemoveRecursive(node.Right, minNode.Data);
                }
            }
            return node;
        }
        
        private Node<T> FindMin(Node<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return InfixTraverse(_root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> InfixTraverse(Node<T> node)
        {
            if (node != null)
            {
                foreach (var left in InfixTraverse(node.Left))
                {
                    yield return left;
                }
                
                yield return node.Data;
                
                foreach (var right in InfixTraverse(node.Right))
                {
                    yield return right;
                }
            }
        }
    }