using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject
{
    internal class Heap_Sort_Algorithm
    {
        public static void HeapSortAlgorithm(int[] arr)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                MaxHeapify(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Swap(arr, 0, i);
                MaxHeapify(arr, i, 0);
            }
        }

        private static void MaxHeapify(int[] arr, int heapSize, int rootIndex)
        {
            int largest = rootIndex;
            int leftChild = 2 * rootIndex + 1;
            int rightChild = 2 * rootIndex + 2;

            if (leftChild < heapSize && arr[leftChild] > arr[largest])
                largest = leftChild;

            if (rightChild < heapSize && arr[rightChild] > arr[largest])
                largest = rightChild;

            if (largest != rootIndex)
            {
                Swap(arr, rootIndex, largest);
                MaxHeapify(arr, heapSize, largest);
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Main(string[] args)
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            HeapSortAlgorithm(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
