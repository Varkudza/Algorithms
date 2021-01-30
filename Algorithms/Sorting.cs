using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// Различные методы сортировки
    /// Анимацию можно посмотреть тут https://www.nookery.ru/wp-content/uploads/2018/01/1tqfmg.gif
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Пузырьковая сортировка
        /// Весьма медленная, с временной сложностью O(N²);
        /// Внешний проход по элементам выполняется за N раз, внутренний — тоже N раз, и в итоге мы получаем N*N, N² итераций
        /// сравнить два числа;
        /// если число слева больше, то поменять их местами;
        /// перейти на одну позицию вправо.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Bubble(int[] arr)
        {

            for (int i = arr.Length - 1; i > 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        /// <summary>
        /// Сортировка методом выбора
        /// Суть алгоритма заключается в последовательном переборе всех чисел и выборе наименьшего элемента, 
        /// который мы возьмём и поменяем местами с крайним элементом слева (0 элементом).
        /// Данный алгоритм превосходит пузырьковую сортировку, 
        /// ведь тут количество необходимых перестановок сокращается с O(N²) до O(N): мы не гоняем один элемент через весь список, 
        /// но тем не менее, количество сравнений остается O(N²).
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] Selection(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            { 
                // внешний обычный  цикл
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                { 
                    // обычный цикл, но с отчетом с сортированных чисел
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                int temp = arr[i];     
                // вставка отссортиованного числа, в положеную ему ячейку
                arr[i] = arr[min];
                arr[min] = temp;
            }
            return arr;
        }

        /// <summary>
        /// Сортировка методом вставки
        /// Суть алгоритма заключается в последовательном переборе всех чисел и выборе наименьшего элемента, 
        /// который мы возьмём и поменяем местами с крайним элементом слева (0 элементом).
        /// Данный алгоритм заключается в выставлении маркера, слева от которого элементы будут уже частично отсортированы между собой. 
        /// На каждом шаге алгоритма будет выбираться один из элементов и помещаться на нужную позицию в уже отсортированной последовательности. 
        /// Таким образом, отсортированная часть будет увеличиваться до тех пор, пока не будут просмотрены все элементы. 
        /// Данный вид сортировки превосходит вышеописанные, так как несмотря на то, что время работы такое же — O(N²), 
        /// этот алгоритм работает вдвое быстрее пузырьковой сортировки и немного быстрее сортировки выбором.
        /// </summary>
        /// <param name="arr"></param>
        public static int[] Insertion(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            { 
                // i - разделяющий маркер
                int temp = arr[i]; 
                // делаем копию помеченного элемента
                int j = i;
                while (j > 0 && arr[j - 1] >= temp)
                { 
                    // пока не будет найден меньший элемент
                    arr[j] = arr[j - 1]; // сдвигаем элементы вправо
                    --j;
                }
                arr[j] = temp;   // вставляем отмеченный элемент, в положеное ему место
            }
            return arr;
        }

        /// <summary>
        /// Сортировка Шелла
        /// На данный момент толком не обоснована эффективность сортировки Шелла, 
        /// так как в разных ситуациях результаты отличаются. 
        /// Оценки, полученные на основании экспериментов, лежат в интервале от O(N3/2) до O(N7/6).
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] ShellSelection(int[] arr)
        {
            int length = arr.Length;
            int step = length / 2;
            while (step > 0)
            {
                for (int numberOfGroup = 0; numberOfGroup < length - step; numberOfGroup++)
                {
                    // проходим по всем нашим группам
                    int j = numberOfGroup;
                    while (j >= 0 && arr[j] > arr[j + step])
                    {
                        //сортировка вставкой внутри группы
                        int temp = arr[j];
                        arr[j] = arr[j + step];
                        arr[j + step] = temp;
                        j--;
                    }
                }
                step = step / 2; // уменьшаем наш шаг
            }
            return arr;
        }

        /// <summary>
        /// Быстрая сортировка
        /// В списке с элементами выбирается опорный элемент — по сути любой элемент, 
        /// относительно которого нужно отсортировать остальные значения. 
        /// Значения меньше его — слева, значения больше — справа.
        /// Далее у правой и левой части также выбирается по опорному элементу и происходит то же самое: 
        /// сортируются значения относительно этих элементов, потом у образовавшихся частей выбираются опорные элементы — 
        /// и так до тех пор, пока мы не получим отсортированный ряд.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>

        public static int[] QuickSorting(int[] arr)
        {
            QuickSorting(arr, 0, arr.Length - 1);
            return arr;
        }

        public static void QuickSorting(int[] arr, int first, int last)
        {
            int p = arr[(last - first) / 2 + first];
            int temp;
            int left = first, right = last;
            while (left <= right)
            {
                while (arr[left] < p && left <= last) ++left;
                while (arr[right] > p && right >= first) --right;
                if (left <= right)
                {
                    temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    ++left; --right;
                }
            }
            if (right > first) QuickSorting(arr, first, right);
            if (left < last) QuickSorting(arr, left, last);
        }

        public static int[] QuickSort(int[] arr)
        {
            Quicksort(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void Quicksort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(arr, start, end);
            Quicksort(arr, start, pivot - 1);
            Quicksort(arr, pivot + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[marker]; // swap
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                } 
            }
            return marker - 1;
        }

        // Generic with Linq
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            if (!list.Any())
            {
                return Enumerable.Empty<T>();
            }
            var pivot = list.First();
            var smaller = list.Skip(1).Where(item => item.CompareTo(pivot) <= 0).QuickSort();
            var larger = list.Skip(1).Where(item => item.CompareTo(pivot) > 0).QuickSort();

            return smaller.Concat(new[] { pivot }).Concat(larger);
        }

        //(тоже самое, но записанное в одну строку, без объявления переменных)

        public static IEnumerable<T> shortQuickSort<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            return !list.Any() ? Enumerable.Empty<T>() : list.Skip(1).Where(
                item => item.CompareTo(list.First()) <= 0).shortQuickSort().Concat(new[] { list.First() })
                    .Concat(list.Skip(1).Where(item => item.CompareTo(list.First()) > 0).shortQuickSort());
        }

        /// <summary>
        /// Пирамидальная сортировка
        /// Алгоритм пирамидальной сортировки в порядке по возрастанию:
        /// Постройте max-heap из входных данных(heapify).
        /// На данном этапе самый большой элемент хранится в корне кучи.Замените его на последний элемент кучи, 
        /// а затем уменьшите ее размер на 1. Наконец, преобразуйте полученное дерево в max-heap с новым корнем.
        /// Повторяйте вышеуказанные шаги, пока размер кучи больше 1.
        /// </summary>
        /// <param name="arr"></param>
        public static void Pyramid(int[] arr)
        {
            int n = arr.Length;

            // Построение кучи (перегруппируем массив)
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // вызываем процедуру heapify на уменьшенной куче
                Heapify(arr, i, 0);
            }
        }

        // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
        // индексом в arr[]. n - размер кучи

        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                Heapify(arr, n, largest);
            }
        }
    }
}
