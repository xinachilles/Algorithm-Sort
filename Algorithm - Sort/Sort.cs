using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Algorithm_Sort
{
    class Sort
    {



        //switch two element in the array

        private void MySwitch(ref int[] array, int first, int second)
        {
            if ((array.Length > 0) && (array.Length >= first) && (array.Length >= second))
            {
                int temp = array[first];
                array[first] = array[second];
                array[second] = temp;

            }
        }

        public void BubbleSort(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)

                    if (array[j] < array[i])
                    {
                        MySwitch(ref array, j, i);
                    }

            }

        }




        public void InsertSort(ref int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int index = i;
                while ((index > 0))
                {
                    // swithc the two word 
                    if (array[index - 1] > array[index])
                    {

                        MySwitch(ref array, index - 1, index);

                    }
                    index--;

                }


            }
        }

        #region Merge Sort

        private void Merge(ref int[] array, int s, int mid, int e)
        {
            int n1 = mid - s + 1;
            int n2 = e - mid;
            int i;

            int[] l1 = new int[n1];
            int[] r1 = new int[n2];



            for (i = 0; i < n1; i++)
            {
                l1[i] = array[s + i];
            }

            for (i = 0; i < n2; i++)
            {
                r1[i] = array[mid + i + 1];
            }

            i = 0;
            int j = 0;

            for (int k = s; k <= e; k++)
            {

                if (i >= l1.Length)
                {

                    array[k] = r1[j];
                    j++;
                }
                else if (j >= r1.Length)
                {

                    array[k] = l1[i];
                    i++;
                }

                else if (l1[i] <= r1[j])
                {
                    array[k] = l1[i];
                    i++;

                }
                else
                {

                    array[k] = r1[j];
                    j++;

                }

            }
        }

        public void MergeSort(ref int[] array, int s, int e)
        {
            if (s < e)
            {
                int mid = (int)Math.Floor((double)(e + s) / 2);
                MergeSort(ref array, s, mid);
                MergeSort(ref array, mid + 1, e);
                Merge(ref array, s, mid, e);

            }

        }
        #endregion

        public void SelectSort(ref int[] array)
        {
            int min_index;


            for (int i = 0; i < array.Length; i++)
            {
                /* assume the min is the first element */
                min_index = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min_index])
                    {
                        min_index = j;
                    }


                }

                if (min_index != i)
                {
                    MySwitch(ref array, min_index, i);

                }
            }

        }

        /*not work*/
        public void NewSelectSort(ref int[] array)
        {
            int max_index;


            for (int i = 1; i < array.Length; i++)
            {
                /* assume the min is the first element */
                max_index = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[j] > array[max_index])
                    {
                        max_index = j;
                    }


                }

                if (max_index != i)
                {
                    MySwitch(ref array, max_index, i);

                }
            }

        }

        public int Partition(ref int[] array, int p, int r)
        {
            int x = array[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (array[j] <= x)
                {
                    i = i + 1;
                    MySwitch(ref array, i, j);
                }

            }

            MySwitch(ref array, i + 1, r);
            return i + 1;

        }

        public void CountingSort(int[] a, ref int[] b, int k)
        {
            int[] c = new int[k];
            for (int i = 0; i < a.Length; i++)
            {
                c[a[i]] = c[a[i]] + 1;
            }

            for (int i = 1; i < k; i++)
            {
                c[i] = c[i] + c[i - 1];
            }

            for (int j = a.Length - 1; j >= 0; j--)
            {
                b[c[a[j]] - 1] = a[j];
                c[a[j]] = c[a[j]] - 1;
            }

        }

        #region 11.1
        // 11.1 You are given two sorted arrays, A and B, where A has a large enough buffer at the
        //end to hold B. Write a method to merge B into A in sorted order.
        public void MergeTwoArray(int[] a, int[] b, ref int[] c)
        {
            int last_a = a.Length - 1;
            int last_b = b.Length - 1;
            int last_merage = last_a + last_b + 1;


            while (last_a >= 0 && last_b >= 0)
            {
                if (a[last_a] >= b[last_b])
                {
                    c[last_merage] = a[last_a];
                    last_merage = last_merage - 1;
                    last_a = last_a - 1;

                }
                else
                {

                    c[last_merage] = b[last_a];
                    last_merage = last_merage - 1;
                    last_b = last_b - 1;

                }
            }

            //  copy the remain item 
            while (last_b >= 0)
            {
                c[last_merage] = b[last_b];
                last_merage = last_merage - 1;
                last_b = last_b - 1;
            }

            while (last_a >= 0)
            {
                c[last_merage] = a[last_a];
                last_merage = last_merage - 1;
                last_a = last_a - 1;
            }
        }
        #endregion

        #region 11.2
        //   Write a method to sort an array of strings so that all the anagrams are next to each
        //   other.

        //  You may notice that the algorithm above is a modification of bucket sort.


        //This problem asks us to group the strings in an array such that the anagrams appear

        class StringComparator : IComparer<string>
        {

            public String sort(String s)
            {
                char[] letters = s.ToCharArray();
                Array.Sort(letters);
                return new String(letters);
            }

            public int Compare(String s1, String s2)
            {
                return sort(s1).CompareTo(sort(s2));
            }
        }
        
        private string[] AnagramsSortA(String[] arr)
        {

            if (arr == null || arr.Length == 0 || arr.Length == 1)
            { return arr; }

            Array.Sort(arr, new StringComparator());

            return arr;

        }

        // solution 2 

        //        This may be the best we can do for a general sorting algorithm, but we don't actually
        //need to fully sort the array. We only need to group the strings in the array by anagram.
        //We can do this by using a hash table which maps from the sorted version of a word to
        //a list of its anagrams. So, for example, acre will map to the list {acre, race, care}.
        //Once we've grouped all the words into these lists by anagram, we can then put them
        //back into the arra

    
        public void AnagramsSort(ref string[] array)
        {
            Hashtable hash = new Hashtable();
            StringComparator sc = new StringComparator();

            /* Group words by anagram */
            foreach (var s in array)
            {
                String key = sc.sort(s);
                if (!hash.Contains(key))
                {
                    hash.Add(key, new LinkedList<string>());
                }

                LinkedList<String> anagrams = (LinkedList<String>)hash[key];
                //LinkedList<string> anagrams = new LinkedList<string>((LinkedList<String>)hash[key]);
                anagrams.AddFirst(s);
            }

            /* Convert hash table to array */
            int index = 0;
            foreach (string key in hash.Keys)
            {
                LinkedList<String> list = (LinkedList<String>)hash[key];
                foreach (var s in list)
                {
                    array[index] = s;
                    index++;
                }

            }
        }




        #endregion


        #region 11.8
      /*move this question to binary search tree part */

        #endregion


    }
}
