using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIM.BubbleShortAlgorithm.Abstract
{
    public interface IBubbleSort
    {
        void BubbleSortWithoutAnyOptimization(int[] array);
        void BubbleSortWithOptimization_V1(int[] array);
        void BubbleSortWithOptimization_V2(int[] array);
    }
}
