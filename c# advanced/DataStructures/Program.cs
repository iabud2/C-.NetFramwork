using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;


namespace MyCustomCollection
{
    class PriorityQueueNode
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public PriorityQueueNode(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }
    }

    class MinHeapPriorityQueue
    {
        private List<PriorityQueueNode> _Queue = new List<PriorityQueueNode>();

        public void Insert(string name, int priority)
        {
            var newNode = new PriorityQueueNode(name, priority);
            _Queue.Add(newNode);
            HeapifyUp(_Queue.Count - 1);
        }

        public void HeapifyUp(int Index)
        {
            while(Index > 0)
            {
                int ParentIndex = (Index - 1) / 2;
                if (_Queue[Index].Priority >= _Queue[ParentIndex].Priority)
                    break;
                (_Queue[Index], _Queue[ParentIndex]) = (_Queue[ParentIndex], _Queue[Index]);
                Index = ParentIndex;
            }
        }

        public void DisplayQueue()
        {
            Console.WriteLine("\nPriority Queue Elements:");
            foreach (var node in _Queue)
            {
                Console.WriteLine($"Name: {node.Name}, Priority: {node.Priority}");
            }
        }

        public PriorityQueueNode ExtractMin()
        {
            if(_Queue.Count == 0)
                throw new InvalidOperationException("Priority Queue is empty.");

            var MinNode = _Queue[0];    
            _Queue.RemoveAt(0);

            HeapifyDown(0);
            return MinNode;

        }

        public void HeapifyDown(int index)
        {
            while(index < _Queue.Count)
            {
                int left_Child_Index = 2 * index + 1;
                int right_Child_Index = 2 * index + 2;
                int SmallestIndex = index;
                if (left_Child_Index < _Queue.Count && _Queue[left_Child_Index].Priority < _Queue[SmallestIndex].Priority)
                    SmallestIndex = left_Child_Index;
                if (right_Child_Index < _Queue.Count && _Queue[right_Child_Index].Priority < _Queue[SmallestIndex].Priority)
                    SmallestIndex = right_Child_Index;
                if (SmallestIndex == index)
                    break;
                (_Queue[index], _Queue[SmallestIndex]) = (_Queue[SmallestIndex], _Queue[index]);
                index = SmallestIndex;
            }
        }

        public PriorityQueueNode Peek()
        {
            if(_Queue.Count == 0)
                throw new InvalidOperationException("Priority Queue is empty.");
            return _Queue[0];
        }
    }

    class MinHeap
    {
        private List<int> _heap = new List<int>();

        public void Insert(int value)
        {
            _heap.Add(value);
            HeapifyUp(_heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while(index > 0)
            {
                int ParentIndex = (index - 1) / 2;

                if (_heap[index] >= _heap[ParentIndex])
                    break;

                (_heap[index], _heap[ParentIndex]) = (_heap[ParentIndex], _heap[index]);

                index = ParentIndex;
            }
        }

        public void DisplayHeap()
        {
            Console.WriteLine("\nHeap Elements: ");
            foreach (int value in _heap)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

        public int Peek()
        {
            if(_heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            return _heap[0];
        }

    }

    class MaxHeap
    {
        private List<int> _heap = new List<int>();

        public void Insert(int value)
        {
            _heap.Add(value);

            HeapifyUp(_heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int ParentIndex = (index - 1) / 2;

                if (_heap[index] <= _heap[ParentIndex])
                    break;
                (_heap[index], _heap[ParentIndex]) = (_heap[ParentIndex], _heap[index]);

                index = ParentIndex;

            }
        }
    
    
        public void DisplayHeap()
        {
            Console.WriteLine("\nHeap Elements:");
            foreach (int value in _heap)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

        public int Peak()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");
            return _heap[0];
        }
        
        public void Remove(int index)
        {
            while(index < _heap.Count)
            {
                int left_Child_Index = 2 * index + 1;
                int right_Child_Index = 2 * index + 2;

                int LargestIndex = index;

            }
        }


        public int ExtractMax()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            int MaxValue = _heap[0];

            _heap[0] = _heap[_heap.Count - 1];

            _heap.RemoveAt(_heap.Count - 1);

            HeapifyDown(0);
            return MaxValue;
        }

        private void HeapifyDown(int index)
        {
            while(index < _heap.Count)
            {
                int left_Child_Index = 2 * index + 1;
                int right_Child_Index = 2 * index + 2;
                int LargestIndex = index;
                
                //1
                if (left_Child_Index < _heap.Count && _heap[left_Child_Index] > _heap[LargestIndex])
                    LargestIndex = left_Child_Index;
                
                //2
                if (right_Child_Index < _heap.Count && _heap[right_Child_Index] > _heap[LargestIndex])
                    LargestIndex = right_Child_Index;
                //3
                if (LargestIndex == index)
                    break;

                //4
                (_heap[index], _heap[LargestIndex]) = (_heap[LargestIndex], _heap[index]);
                
                //5
                index = LargestIndex;

            }
        }
    }

    class Graph
    {
        public enum enGraphDirectionType {Directed, Undirected }
        
        private int[,] _AdjacencyMatrix;
        
        private Dictionary<string, int> _verticesDictionary;

        private int _numOfVertices;

        private enGraphDirectionType _GraphDirectionType = enGraphDirectionType.Directed;


        public Graph(List<string> vertices, enGraphDirectionType GraphDirectionType)
        {
            _GraphDirectionType = GraphDirectionType;

            _numOfVertices = vertices.Count;

            _AdjacencyMatrix = new int[_numOfVertices, _numOfVertices];

            _verticesDictionary = new Dictionary<string, int>();

            for (int i = 0; i < vertices.Count; i++)
            {
                _verticesDictionary[vertices[i]] = i;
            }
        }

        public void AddEdge(string source, string destination, int weight)
        {    

            if(_verticesDictionary.ContainsKey(source) && _verticesDictionary.ContainsKey(destination))
            {
                int sourceIndex = _verticesDictionary[source];
                int destinationIndex = _verticesDictionary[destination];
                
                _AdjacencyMatrix[sourceIndex, destinationIndex] = weight;

                if(_GraphDirectionType == enGraphDirectionType.Undirected)
                {
                    _AdjacencyMatrix[destinationIndex, sourceIndex] = weight;
                }  
            }
            else
            {
                Console.WriteLine("Source or Destination vertex not found in the graph.");
            }
        }


        public void RemoveEdge(string source, string destination)
        {
            if(_verticesDictionary.ContainsKey(source) && _verticesDictionary.ContainsKey(destination))
            {
                int sourceIndex = _verticesDictionary[source];
                int destinationIndex = _verticesDictionary[destination];

                _AdjacencyMatrix[sourceIndex, destinationIndex] = 0;
                if(_GraphDirectionType == enGraphDirectionType.Undirected)
                {
                    _AdjacencyMatrix[destinationIndex, sourceIndex] = 0;
                }
            }
            else
            {
                Console.WriteLine("Source or Destination vertex not found in the graph.");
            }
        }

        public void PrintGraph()
        {
            Console.WriteLine("Adjacency Matrix:");
            Console.Write("  ");
            foreach (var vertex in _verticesDictionary.Keys)
            {
                Console.Write(vertex + " ");
            }
            Console.WriteLine();

            foreach (var vertex in _verticesDictionary)
            {

                Console.Write(vertex.Key + " ");
                for(int i = 0; i< _numOfVertices; i++)
                {
                    Console.Write(_AdjacencyMatrix[vertex.Value, i] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool IsEdge(string source, string destination)
        {
            if(_verticesDictionary.ContainsKey(source) && _verticesDictionary.ContainsKey(destination))
            {
                int sourceIndex = _verticesDictionary[source];
                int destinationIndex = _verticesDictionary[destination];

                return _AdjacencyMatrix[sourceIndex, destinationIndex] < 0;
            }


            return false;
        }

        public int GetInDegree(string source, string destination)
        {
            int InDegree = 0;

            if(_verticesDictionary.ContainsKey(source) && _verticesDictionary.ContainsKey(destination))
            {
                int VertixIndex = _verticesDictionary[destination];

                for(int i = 0; i < _numOfVertices; i++)
                {
                    if(_AdjacencyMatrix[i, VertixIndex] > 0)
                    {
                        InDegree++;
                    }
                }
            }
            return InDegree;
        }
    
    
        public int GetOutDegree(string source, string destination)
        {
            int OutDegree = 0;

            if(_verticesDictionary.ContainsKey(source) && _verticesDictionary.ContainsKey(destination))
            {
                int VertixIndex = _verticesDictionary[source];
                for(int i = 0; i < _numOfVertices; i++)
                {
                    if(_AdjacencyMatrix[VertixIndex, i] > 0)
                    {
                        OutDegree++;
                    }
                }
            }
            return OutDegree;
        }
    }

    class Graph2
    {
        public enum enGraphDirectionType { Directed, Undirected }   

        private Dictionary<string, List<Tuple<string, int>>> _adjacencyList;

        private Dictionary<string, int> _vertexDictionary;

        private int _numOfVertices;

        private enGraphDirectionType _graphDirectionType = enGraphDirectionType.Directed;
   
    
        public Graph2(List<string> vertices, enGraphDirectionType graphDirectionType)
        {
            _graphDirectionType = graphDirectionType;
         
            _numOfVertices = vertices.Count;
            
            _adjacencyList = new Dictionary<string, List<Tuple<string, int>>>();
            
            _vertexDictionary = new Dictionary<string, int>();
            
            foreach (var vertex in vertices)
            {
                _adjacencyList[vertex] = new List<Tuple<string, int>>();
                _vertexDictionary[vertex] = 0;
            }
        }

        public void AddEdge(string source, string destination, int weight)
        {
            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                _adjacencyList[source].Add(new Tuple<string, int>(destination, weight));

                if (_graphDirectionType == enGraphDirectionType.Undirected)
                {
                    _adjacencyList[destination].Add(new Tuple<string, int>(source, weight));
                }
            }
            else
            {
                // If either vertex is invalid, show an error message
                Console.WriteLine($"\n\nIgnored: Invalid vertices. {source} ==> {destination}\n\n");
            }
        }

        public void RemoveEdge(string source, string destination)
        {
            if(_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                _adjacencyList[source].RemoveAll(edge => edge.Item1 == destination);
                
                if(_graphDirectionType == enGraphDirectionType.Undirected)
                {
                    _adjacencyList[destination].RemoveAll(edge => edge.Item1 == source);
                }
            }
            else
            {
                Console.WriteLine("Invalid Vertices");
            }
        }

        public void DisplayGraph(string Message)
        {
            Console.WriteLine($"\n{Message}\n");
            foreach(var vertex in _adjacencyList)
            {
                Console.Write(vertex.Key + "  ->  ");
                foreach(var edge in vertex.Value)
                {
                    Console.Write($"({edge.Item1}, {edge.Item2})   ");
                }
                Console.WriteLine();
            }
        }

        public bool IsEdge(string source, string destination)
        {

            if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
            {
                foreach (var edge in _adjacencyList[source])
                {
                    if (edge.Item1 == destination)
                    {
                        return true;

                    }
                }
            }

            return false;
        }

        public int GetInDegree(string vertex)
        {
            int degree = 0;
            if (_vertexDictionary.ContainsKey(vertex))
            {
                foreach (var source in _adjacencyList)
                {
                    foreach (var edge in source.Value)
                    {
                        if (edge.Item1 == vertex)
                            degree++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Vertex Not Found");
            }
            return degree;
        }

        public int GetOutDegree(string vertex)
        {
            int degree = 0;
            if (_vertexDictionary.ContainsKey(vertex))
            {
                degree = _adjacencyList[vertex].Count;
            }
            else
            {
                Console.WriteLine("Vertex Not Found");
            }
            return degree;
        }
    }

    public class MyCollection<T> : IList<T>
    {
        private List<T> items = new List<T>();

        public T this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }
        public int Count => items.Count;

        public bool IsReadOnly => false;


        public void Add(T item)
        {
            items.Add(item);
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }
        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public class Person :IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public int CompareTo(Person person)
        {
            if (person == null) return 1;
            return this.Age.CompareTo(person.Age);
        }

    }

    public class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T Value)
        {
            this.Value = Value;
            this.Children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

        public TreeNode<T> Find(T Value)
        {
            if (EqualityComparer<T>.Default.Equals(this.Value, Value))
                return this;

            foreach (var item in Children)
            {
                var found = item.Find(Value);
                if (found != null)
                    return found;
            }

            return null;
        }



    }

    public class Tree<T>
    {
        public TreeNode<T> Root { get; set; }

        public Tree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }

        public void PrintTree(string indent = " ")
        {
            PrintTree(this.Root, indent);
        }

        private static void PrintTree<T>(TreeNode<T> node, string indent = " ")
        {
            Console.WriteLine(indent + node.Value);
            foreach (var child in node.Children)
            {
                PrintTree(child, indent + "  ");
            }
        }


    }

    public class BinaryTreeNode<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }


    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(T Value)
        {
            var newNode = new BinaryTreeNode<T>(Value);
            if (Root == null)
            {
                Root = newNode;
                return;
            }

            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(Root);
        
            while(queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Left == null)
                {
                    current.Left = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null)
                {
                    current.Right = newNode;
                    break;
                }
                else
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        public void PrintTree()
        {
            PrintTree(Root, 0);
        }

        private void PrintTree(BinaryTreeNode<T> Root, int space)
        {
            int Count = 10;
            if (Root == null)
                return;

            space += Count;
            PrintTree(Root.Right, space);
            Console.WriteLine();
            for (int i = Count; i < space; i++)
                Console.Write(" ");
            Console.WriteLine(Root.Value);
            PrintTree(Root.Left, space);
        }

        private void PreOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Value + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(Root);
            Console.WriteLine();
        }

        private void PostOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Value + " ");
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(Root);
        }

        private void InOrderTraversal(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversal(node.Right);
            }
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(Root);
        }

    }
 
    
    class Program
    {
        
        static void Main(string[] args)
        {
            MinHeapPriorityQueue  priorityQueue = new MinHeapPriorityQueue();

            Console.WriteLine("Inserting elements into the priority queue...");
            priorityQueue.Insert("Task 1", 3);
            priorityQueue.Insert("Task 2", 1);
            priorityQueue.Insert("Task 3", 2);
            priorityQueue.Insert("Task 4", 5);

            Console.WriteLine("Displaying the priority queue:");
            priorityQueue.DisplayQueue();

            var extractedNode = priorityQueue.ExtractMin();
            Console.WriteLine("Extracted Element: Name = " + extractedNode.Name + ", Priority = " + extractedNode.Priority);

            extractedNode = priorityQueue.ExtractMin();
            Console.WriteLine("Extracted Element: Name = " + extractedNode.Name + ", Priority = " + extractedNode.Priority);

            extractedNode = priorityQueue.ExtractMin();
            Console.WriteLine("Extracted Element: Name = " + extractedNode.Name + ", Priority = " + extractedNode.Priority);


            priorityQueue.DisplayQueue();
            Console.ReadKey();
        }

            
    };  
}





