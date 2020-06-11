using System;
using System.Diagnostics;
/*
  Wykonanie Michał Wolny i Patryk Tomaszewski
*/
namespace ConsoleApp1
{
    class Program
    {
        /// <summary>
        /// Generowanie Losowej tablicy
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public static int[] Losowa(int capacity)
        {
           Random rand = new Random();
            int[] tab = new int[capacity];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = rand.Next();
            }
            return tab;
        }

        /// <summary>
        /// Generowanie rosnącej tablicy
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>

        public static int[] Rosnaca(int capacity)
        {
            int[] tab = new int[capacity];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = i;
            }
            return tab;
        }

        /// <summary>
        ///  Generowanie tablicy malejącej
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>

        public static int[] Malejaca(int capacity)
        {
            int[] tab = new int[capacity];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[tab.Length - 1 - i] = i;
            }
            return tab;
        }

        /// <summary>
        ///  Generowanie tablicy stałej
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public static int[] Stala(int capacity)
        {
            int[] tab = new int[capacity];
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = 1;
            }
            return tab;
        }

        /// <summary>
        /// Generowanie tablicy V-kształtnej
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>

        public static int[] V_ksztaltna(int capacity)
        {
            int[] tab = new int[capacity];
            for (int i = 0; i < tab.Length; i++)
            {
                if (i < capacity / 2)
                {
                    tab[i] = capacity / 2 - i;
                }
                else
                {
                    tab[i] = -capacity / 2 + i;
                }
            }
            return tab;
        }

        /// <summary>
        /// Generowanie tablicy A-kształtnej
        /// </summary>
        /// <param name="args"></param>
        /// 

        public static int[] A_ksztaltna(int capacity)
        {
            int[] tab = new int[capacity];
            for (int i = 0; i < tab.Length; i++)
            {
                if (i < capacity / 2)
                {
                    tab[i] = i;
                }
                else
                {
                    tab[i] = capacity - i;
                }
            }
            return tab;
        }

        /// <summary>
        /// SELECTION SORT
        /// </summary>
        /// <param name="args"></param>
        /// 

        public void selectionSort(int[] tab)
        {
            uint k;
            for (uint i = 0; i < (tab.Length - 1); i++)
            {
                int temp = tab[i];
                k = i;
                for (uint j = i + 1; j < tab.Length; j++)
                    if (tab[j] < temp)
                    {
                        k = j;
                        temp = tab[j];
                    }

                tab[k] = tab[i];
                tab[i] = temp;
            }
        }

        /// <summary>
        /// INSERTION SORT
        /// </summary>
        /// <param name="args"></param>
        /// 

        public void insertionSort(int[] tab)
        {
            for (uint i = 1; i < tab.Length; i++)
            {
                uint j = i;
                int temp = tab[j];
                while ((j > 0) && (tab[j - 1] > temp))
                {
                    tab[j] = tab[j - 1];
                    j--;
                }
                tab[j] = temp;
            }

        }

        /// <summary>
        /// COCKTAIL SORT
        /// </summary>
        /// <param name="args"></param>
        /// 

        public void cocktailSort(int[] tab)
        {
            int left = 1, right = tab.Length - 1, k = tab.Length - 1;
            do
            {
                for (int j = right; j >= left; j--)
                    if (tab[j - 1] > tab[j])
                    {
                        int temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                        k = j;
                    }

                left = k + 1;
                for (int j = left; j <= right; j++)
                    if (tab[j - 1] > tab[j])
                    {
                        int temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                        k = j;
                    }

                right = k - 1;
            } while (left <= right);
        }

        /// <summary>
        /// HEAP SORT
        /// </summary>
        /// <param name="args"></param>
        /// 

        public void heapSort(int[] tab)
        {
            int left = tab.Length / 2;
            int right = tab.Length - 1;
            while (left > 0)
            {
                left--;
                heapify(ref tab, left, right);
            }

            while (right > 0)
            {
                int temp = tab[left];
                tab[left] = tab[right];
                tab[right] = temp;
                right--;
                heapify(ref tab, left, right);
            }
        }

        private void heapify(ref int[] tab, int left, int right)
        {
            int i = left,
                j = 2 * i + 1;
            int temp = tab[i];
            while (j <= right)
            {
                if (j < right)
                    if (tab[j] < tab[j + 1])
                        j++;
                if (temp >= tab[j]) break;
                tab[i] = tab[j];
                i = j;
                j = 2 * i + 1;
            }

            tab[i] = temp;
        }

        
       
        static void Main(string[] args)
        {
            Program sortowanie = new Program();
            Stopwatch stopWatch = new Stopwatch();
            
            double elapsed = 0;

            for (int i = 50000; i < 200000; i += 5000)
            {
                int[] los = Losowa(i);
                stopWatch.Reset();
                stopWatch.Start();

                // SORTOWANIE
                sortowanie.selectionSort(los);
                sortowanie.insertionSort(los);
                sortowanie.cocktailSort(los);
                sortowanie.heapSort(los);

                stopWatch.Stop();
                elapsed = stopWatch.ElapsedMilliseconds;
                Console.WriteLine(elapsed + ";");
            }



            for (int i = 50000; i < 200000; i += 5000)
            {
                int[] ros = Rosnaca(i);
                stopWatch.Reset();
                stopWatch.Start();

                // SORTOWANIE
                sortowanie.selectionSort(ros);
                sortowanie.insertionSort(ros);
                sortowanie.cocktailSort(ros);
                sortowanie.heapSort(ros);

                stopWatch.Stop();
                elapsed = stopWatch.ElapsedMilliseconds;
                Console.WriteLine(elapsed + ";");
            }




            for (int i = 50000; i < 200000; i += 5000)
            {
                int[] mal = Malejaca(i);
                stopWatch.Reset();
                stopWatch.Start();

                // SORTOWANIE
                sortowanie.selectionSort(mal);
                sortowanie.insertionSort(mal);
                sortowanie.cocktailSort(mal);
                sortowanie.heapSort(mal);

                stopWatch.Stop();
                elapsed = stopWatch.ElapsedMilliseconds;
                Console.WriteLine(elapsed + ";");

            }
            
            
            for (int i = 50000; i < 200000; i += 5000)
            {   
                int[] st = Stala(i);
                stopWatch.Reset();
                stopWatch.Start();

                // SORTOWANIE
                sortowanie.selectionSort(st);
                sortowanie.insertionSort(st);
                sortowanie.cocktailSort(st);
                sortowanie.heapSort(st);

                stopWatch.Stop();
                elapsed = stopWatch.ElapsedMilliseconds;
                Console.WriteLine(elapsed + ";");
            }

            for (int i = 50000; i < 200000; i += 5000)
            {
                int[] vshape = V_ksztaltna(i);
                stopWatch.Reset();
                stopWatch.Start();

                // SORTOWANIE
                sortowanie.selectionSort(vshape);
                sortowanie.insertionSort(vshape);
                sortowanie.cocktailSort(vshape);
                sortowanie.heapSort(vshape);

                stopWatch.Stop();
                elapsed = stopWatch.ElapsedMilliseconds;
                Console.WriteLine(elapsed + ";");
            }

            Console.WriteLine("Koniec Programu");
            Console.ReadKey();
        }
    }
}
