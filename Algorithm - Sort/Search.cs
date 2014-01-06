using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Sort
{
    class Serarch
    {
        #region Binary Search
        public int BinarySearch(int[] data, int item)
        {

            int min = 0;
            int max = data.Length - 1;
            do
            {
                int mid = (min + max) / 2;
                if (data[mid] == item)
                    return mid;
                else if (item > data[mid])   min = mid + 1;
                else max = mid - 1;
               

            } while (min <= max);
            return -1;
        }
        #endregion

        #region 9.3

        //A magic index in an array A[l.. .n-l] is defined to be an index such that A[i] =i. Given a sorted array of

        public int BinarySearchMagicIndex(int[] data)
        {
            int min = 0;
            int max = data.Length - 1;
            int mid = 0;
            while (min <= max)
            {

                mid = (min + max) / 2;
                if (data[mid] == mid)
                {
                    return mid;

                }
                else if (data[mid] > mid)
                {
                    max = (mid - 1);

                }
                else
                {

                    min = (mid + 1) ;
                }



            }

            return -1;
        }


        public int BinarySearchMagicIndexRecursion(int[] data, int end, int start)
        {
            if (end < start || start < 0 || end >= data.Length) { return -1; }
            int mid = (end + start) / 2;
            if (data[mid] == mid) { return mid; }
            else if (data[mid] < mid) { return BinarySearchMagicIndexRecursion(data, mid - 1, start); }
            else
            {
                return BinarySearchMagicIndexRecursion(data, end, start + 1);

            }

        }

        #endregion

        #region 11.3
        //Given a sorted array of n integers that has been rotated an unknown number of
        //times, write code to find an element in the array. You may assume that the array was
        //originally sorted in increasing order.


        public int RotatedBinarySearch(int[] data, int x, int left, int right)
        {
            int mid = (left + right) / 2;
            if (data[mid] == x)
            {
                return x;
            }

            if (data[left] < data[mid])
            {
                // left is normal order
                if (x < data[mid] && x >= data[left])
                {
                    return RotatedBinarySearch(data, x, left, mid - 1);

                }
                else
                {
                    return RotatedBinarySearch(data, x, mid + 1, right);

                }

            } // end left noraml 

            else if (data[left] > data[mid])
            {
                // right is normal order
                if (x > data[mid] && x <= data[right])
                {
                    return RotatedBinarySearch(data, x, mid + 1, right);

                }
                else
                {
                    return RotatedBinarySearch(data, x, left, mid - 1);
                }

            } // end right normal



            else if (data[left] == data[mid])
            {
                // left half is repeat 

                if (data[right] != data[mid])
                {
                    // search the right part 
                    return RotatedBinarySearch(data, x, mid + 1, right);

                }
                else
                {
                    // search the both part 

                    int result = RotatedBinarySearch(data, x, left, mid - 1);
                    if (result == -1) { return RotatedBinarySearch(data, x, mid + 1, right); }
                    else { return result; }

                }
            }


            return -1;
        }
        #endregion

        #region 11.5
        //11.5 Given a sorted array of strings which is interspersed with empty strings, write a
        //method to find the location of a given string.


        public int StringR(string[] strings, string str, int first, int last)
        {
            if (first > last)
            {
                return -1;

            }

            int mid = (first + last) / 2;
            if (strings[mid] == null)
            {

                int left = mid - 1;
                int right = mid + 1;

                while (true)
                {

                    // just one char in the string and it is empty
                    if (left < first && right > last)
                    {
                        return -1;
                    }
                    else if (right <= last && strings[right] != null)
                    {
                        mid = right;
                        break;
                    }
                    else if (left >= first && strings[left] != null)
                    {
                        mid = left;
                        break;
                    }

                    left = left - 1;
                    right = right + 1;

                }
            }

            if (strings[mid].Equals(str))
            {
                return mid;
            }
            else if (strings[mid].CompareTo(str) < 0)
            {// go to right 
                return StringR(strings, str, mid + 1, last);
            }
            else
            {
                return StringR(strings, str, first, mid - 1);
            }






        }// end class




        #endregion

        #region 11.6
        //Given an MX N matrix in which each row and each column is sorted in ascending
        //order, write a method to find an element.
        //start with [0, n]

        // solution 1
        public bool FindFlement(int[,] matrix, int elem)
        {
            int row = 0;
            int col = matrix.GetLength(1) - 1;
            while (row < matrix.Length && col >= 0)
            {
                if (matrix[row, col] == elem)
                {
                    return true;
                }
                else if (matrix[row, col] > elem)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return false;
        }

        // solution 2: binary search 

    public class Coordinate
        {
            public int row;
            public int column;
            public Coordinate(int r, int c)
            {
                row = r;
                column = c;
            }

            public bool inbounds(int[,] matrix)
            {
                return row >= 0 && column >= 0 && row < matrix.GetLength(0) && column < matrix.GetLength(1);
            }

            public bool isBefore(Coordinate p)
            {
                return row <= p.row && column <= p.column;
            }

            public Object clone()
            {
                return new Coordinate(row, column);
            }
            public void setToAverage(Coordinate min, Coordinate max)
            {
                row = (min.row + max.row) / 2;
                column = (min.column + max.column) / 2;
            }
        }


        private Coordinate FindElement(int[,] matrix, Coordinate origin, Coordinate dest, int x)
        {
            if (!origin.inbounds(matrix) || ! dest.inbounds(matrix))
            {
                return null;
            }
            if (matrix[origin.row, origin.column] == x)
            {
                return origin;
            }
            else if (!origin.isBefore(dest))
            {
                return null;
            }

            /* Set start to start of diagonal and end to the end of the
             * diagonal. Since the grid may not be square, the end of the
             * diagonal may not equal dest. */
            Coordinate start = (Coordinate)origin.clone();
            int diagDist = Math.Min(dest.row - origin.row, dest.column - origin.column);
            Coordinate end = new Coordinate(start.row + diagDist, start.column + diagDist);
            Coordinate p = new Coordinate(0, 0);

            /* Do binary search on the diagonal, looking for the first
            * element greater than x */
            while (start.isBefore(end))
            {
                p.setToAverage(start, end);
                if (x > matrix[p.row, p.column])
                {
                    start.row = p.row + 1;

                    start.column = p.column + 1;
                }
                else
                {
                    end.row = p.row - 1;
                    end.column = p.column - 1;
                }
            }

            /* Split the grid into quadrants. Search the bottom left and the
            * top right. */
            return partitionAndSearch(matrix, origin, dest, start, x);
        }

     private Coordinate partitionAndSearch(int[,] matrix, Coordinate origin, Coordinate dest, Coordinate pivot, int elem)
        {
            Coordinate one = new Coordinate(pivot.row, origin.column);
            Coordinate two = new Coordinate(dest.row, pivot.column - 1);
            Coordinate three = new Coordinate(origin.row, pivot.column);
            Coordinate four = new Coordinate(pivot.row - 1, dest.column);

            Coordinate lowerLeft = FindElement(matrix, one, two, elem);
            if (lowerLeft == null)
            {
                return FindElement(matrix, three, four, elem);
            }
            return lowerLeft;
        }

        public Coordinate FindElementTwo(int[,] matrix, int x)
        {
            Coordinate origin = new Coordinate(0, 0);
            Coordinate dest = new Coordinate(matrix.GetLength(0) - 1, matrix.GetLength(1) - 1);
            return FindElement(matrix, origin, dest, x);
        }

        #endregion

        #region 11.7
        // A circus is designing a tower routine consisting of people standing atop one another's
        //shoulders. For practical and aesthetic reasons, each person must be both shorter
        //and lighter than the person below him or her. Given the heights and weights of
        //each person in the circus, write a method to compute the largest possible number
        //of people in such a tower.

        /*
         1. sort the array, (compared the height first, then compared the wid
         2. find the logest increst subsequence for each item 
             2.1 if the there exist (isbeofre() item from 0 - (i-1) ), the find the LIS from( 0- (i-1)) 
         3. find the logest increst subsequence for the whole array
         */

        public List<HtWt> GetIncreasingSequence(List<HtWt> items)
        {
            items.Sort();
            return longestIncreasingSubsequence(items);
        } // end getIncrease

        private void longestIncreasingSubsequence(List<HtWt> array,ref List<HtWt>[] solutions, int current_index = 0)
        {
            if (current_index >= array.Count || current_index < 0) return;
            HtWt current_element = (HtWt)array[current_index];

            /* Find longest sequence we can append current_element to */
            List<HtWt> best_sequence = null;
            for (int i = 0; i < current_index; i++)
            {
                if (((HtWt)array[i]).isBefore(current_element))
                {
                    best_sequence = seqWithMaxLength(best_sequence, solutions[i]);
                }
            }

            /* Append current_element */
            List<HtWt> new_solution = new List<HtWt>();
            if (best_sequence != null)
            {
                new_solution.AddRange(best_sequence);
            }
            new_solution.Add(current_element);

            /* Add to list and recurse */
            solutions[current_index] = new_solution;
            longestIncreasingSubsequence(array, ref solutions, current_index + 1);




        } // end longestIncrease


        private List<HtWt> longestIncreasingSubsequence(List<HtWt> array)
        {
            List<HtWt>[] solutions = new List<HtWt>[array.Count];
            longestIncreasingSubsequence(array, ref solutions);

            List<HtWt> best_sequence = null;
            for (int i = 0; i < array.Count; i++)
            {
                best_sequence = seqWithMaxLength(best_sequence, solutions[i]);
            }

            return best_sequence;
        }


        /* Returns longer sequence */
        private List<HtWt> seqWithMaxLength(List<HtWt> seql, List<HtWt> seq2)
        {
            if (seql == null) return seq2;
            if (seq2 == null) return seql;
            return seql.Count > seq2.Count ? seql : seq2;
        }

        public class HtWt : IComparable
        {
            /* declarations, etc */
            public int Ht;
            public int Wt;

            /* used for sort method */
            public int CompareTo(Object s)
            {
                HtWt second = (HtWt)s;
                if (this.Ht != second.Ht)
                {
                    return ((int)this.Ht).CompareTo(second.Ht);
                }
                else
                {
                    return ((int)this.Wt).CompareTo(second.Wt);
                }
            } // end compareTo

            /* Returns true if "this" should be lined up before "other."
               Note that it's possible that this.isBefore(other) and
               other.isBefore(this) are both false. This is different from
               the compareTo method, where if a < b then b > a. */

            public bool isBefore(HtWt other)
            {
                if (this.Ht < other.Ht && this.Wt < other.Wt) return true;
                else return false;
            }

            public HtWt(int h, int w)
            {
                Ht = h;
                Wt = w;

            }


        } // end class




        #endregion



    }
}
