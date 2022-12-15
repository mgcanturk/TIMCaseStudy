using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIM.BubbleShortAlgorithm.Abstract;

namespace TIM.BubbleShortAlgorithm.Concrete
{
    public class BubbleSort : IBubbleSort
    {
        /// <summary>
        /// Dizi elemanlarını değiştiren methodum
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void SwapElement(int[] array, int i, int j)
        {
            (array[j], array[i]) = (array[i], array[j]);
        }
        /// <summary>
        /// О(n²) Optimize edilmemiş bubble sort algoritması
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSortWithoutAnyOptimization(int[] array)
        {
            int nLength = array.Length;
            int totalLoopCount = 0;
            // İlk elemandan başlayarak dizi boyunca döngü oluşturdum
            for (int i = 0; i < nLength - 1; i++)
            {
                // Baştan başlayarak dizi boyunca döngü oluşturdum
                for (int j = 0; j < nLength - 1; j++)
                {
                    // Geçerli değer sonraki değerden büyükse, onları değiştirdim
                    if (array[j] > array[j + 1])
                        SwapElement(array, j, j + 1);
                    totalLoopCount++;//Kaç kez karşılaştırma yaptığını buluyorum
                }
            }
            Console.WriteLine($"Total loop count: {totalLoopCount:00} | Array:  {string.Join(",", array)} | BubbleSortWithoutAnyOptimization");
        }
        /// <summary>
        /// Her döngüde en büyük sayı dizinin en sonuna gittiği için ikinci kontrolde en son elemanı kontrol etmedim. Sonraki kontrollerde son iki elemanı...
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSortWithOptimization_V1(int[] array)
        {
            int nLength = array.Length;
            int totalLoopCount = 0;
            // İlk elemandan başlayarak dizi boyunca döngü oluşturdum
            for (int i = 0; i < nLength - 1; i++)
            {
                // Baştan başlayarak dizi boyunca döngü oluşturdum
                for (int j = 0; j < nLength - 1 - i; j++)// Son elemana bakmaması için - i yaptım
                {
                    // Geçerli değer sonraki değerden büyükse, onları değiştirdim
                    if (array[j] > array[j + 1])
                        SwapElement(array, j, j + 1);
                    totalLoopCount++;//Kaç kez karşılaştırma yaptığını buluyorum
                }
            }
            Console.WriteLine($"Total loop count: {totalLoopCount:00} | Array:  {string.Join(",", array)} | BubbleSortWithOptimization_V1");
        }
    }
}
