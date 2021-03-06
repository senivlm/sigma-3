using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4;
    class Vector
    {
        private int[] array;
        public int this[uint index]
        {
            get
            { 
                if(index < array.Length)
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Out of range");
                }
            }
            set 
            {
                array[index] = value;
            }
        }

        public Vector(int[] array)
        {
            this.array = array;
        }

        public Vector(int n)
        {
            array = new int[n];
        }

        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(a, b);
            }
        }

        public void RandomInitialization()
        {
            Random random = new Random();
            int x;
            for (int i = 0; i < array.Length; i++)
            {
                while(array[i] == 0)
                {
                    x = random.Next(1, array.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (x == array[j])
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        array[i] = x;
                        break;
                    }
                }
            }
        }

        public void quickSort(){
            unsafeQuickSort(0, array.Length - 1);
        }

        public void quickSort(int start, int end){
            if(start < 0 || start > array.Length - 1){
                throw new ArgumentException($"invalid argument: start is {start}");
            }
            if(end > array.Length - 1 || end < 0){
                throw new ArgumentException($"invalid argument: end is {end}");
            }
            unsafeQuickSort(start, end);
        }
        
        private void unsafeQuickSort(int start, int end){
            int i = start;
            int j = end;
            int pivot = array[(end + start) / 2];
            Console.WriteLine(ToString());
            while (i <= j){
                while (array[i] < pivot){
                    i++;
                }   
                while (array[j] > pivot){
                    j--;
                }
                if (i <= j){
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            if (start < j){
                unsafeQuickSort(start, j);
            }
            if (i < end){
                unsafeQuickSort(i, end);
            }
        }

        public bool isPalindrom(){
            int median = array.Length / 2;

            for (int i = 0, j = array.Length - 1; i < median; i++, j--)
            {
                if (array[i] != array[j])
                {
                    return false;
                }
            }
            return true;
        }

        public void reverse(){
            Array.Reverse(array);
        }

        public void customReverse(){
             for (int i = 0, j = array.Length - 1; i < array.Length/2; i++, j--)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public int[] getMaxSubSeq()
        {
            
            int maxStart = 0;
            int maxEnd = 0;
            int maxSize = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                int start = i;
                int end = i + 1;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        end = j+1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (maxSize < end - start)
                {
                    maxStart = start;
                    maxEnd = end;
                    maxSize = maxEnd - maxStart;
                }
            }
            return array[maxStart..maxEnd];
        }

        public Pair[] CalculateFreq()
        {
            
            Pair[] pairs = new Pair[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                pairs[i] = new Pair(0,0);

            }
            int countDifference = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if(array[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = array[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append($"|{array[i]}|");
            }
            return sb.ToString();
        }
    }
