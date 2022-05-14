using System.Diagnostics;
namespace larionov_lab_5_one_dimensional_arrays_1
{
    class TasksInfo
    {
        public const string TASK_6_1 = "В одномерном массиве, состоящем из п вещественных элементов, вычислить:\n" +
        "1) минимальный элемент массива;\n" + 
        "2) сумму элементов массива, расположенных между первым и последним положительными элементами.\n\n" +  

        "Преобразовать массив таким образом, чтобы: \n" +
        "сначала располагались все элементы, равные нулю, а потом — все остальные.";

        public const string TASK_16_2 = "В одномерном массиве, состоящем из п вещественных элементов, вычислить:\n" +
        "1) количество отрицательных элементов массива; \n" +
        "2) сумму модулей элементов массива, расположенных после минимального по модулю элемента.\n\n" + 

        "Заменить все отрицательные элементы массива их квадратами и\n" + 
        "упорядочить элементы массива по возрастанию.";

        public const string TASK_6_3 = "Дана целочисленная прямоугольная матрица.\n" + 
        "Определить:\n" + 
        "1) сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент;\n" + 
        "2) номера строк и столбцов всех седловых точек матрицы.";

        public const string TASK_16_4 = "Упорядочить строки целочисленной прямоугольной матрицы по возрастанию\n" +
        "количества одинаковых элементов в каждой строке.\n\n" + 

        "Найти номер первого из столбцов, не содержащих ни одного отрицательного элемента.\n";
    }

    class MyInput
    {
        public int inputCount(string text, int maxValue, int defaultValue)
        {

            string xStr = "";
            bool isNumber = false;
            int x = 0;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (xStr == "")
                    return defaultValue;

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else if (x <= 0 || x > maxValue)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите число в промежутке от 0 до {maxValue} включительно!\n");
                }
                else
                    break;
            }

            return x;
        }

        public int inputData(string text)
        {

            string xStr = "";
            bool isNumber = false;
            int x = 0;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else
                    break;
            }

            return x;
        }
    }

    class MyArray
    {
        private const int MAX_COUNT = 10000, DEFAULT_VALUE = 10;
        private const int MIN_RANDOM = -100, MAX_RANDOM = 100;

        private bool isQwestionRandom()
        {
            Console.WriteLine("\nХотите сгенерировать данные случайным образом? [y/n]\0");
            return Console.ReadLine()?.ToLower() != "n";
        }

        public int[] createArray()
        {

            bool isRandom = isQwestionRandom();

            MyInput myInput = new MyInput();

            int countValues = myInput.inputCount($"\nСколько нужно чисел? (Для {DEFAULT_VALUE} нажмите ENTER): \0", MAX_COUNT, DEFAULT_VALUE);
            Console.WriteLine(" ");

            Random rnd = new Random();

            int[] array = new int[countValues];

            if (isRandom)
            {

                for (int i = 0; i < countValues; i++)
                    array[i] = rnd.Next(MIN_RANDOM, MAX_RANDOM);

            }
            else
            {
                for (int i = 0; i < countValues; i++)
                {
                    array[i] = myInput.inputData($"Введите число ({i + 1} из {countValues}):");
                    Console.WriteLine(" ");
                }
            }

            return array;
        }

        public int[,] createTwoDimensionalArray()
        {

            bool isRandom = isQwestionRandom();

            MyInput myInput = new MyInput();

            int m = myInput.inputCount($"\nСколько нужно строк? (Для {DEFAULT_VALUE} нажмите ENTER): \0", MAX_COUNT, DEFAULT_VALUE);
            Console.WriteLine(" ");

            int n = myInput.inputCount($"\nСколько нужно столбцов? (Для {DEFAULT_VALUE} нажмите ENTER): \0", MAX_COUNT, DEFAULT_VALUE);
            Console.WriteLine(" ");

            Random rnd = new Random();

            int[,] array = new int[m, n];

            if (isRandom)
            {

                for (int i = 0; i < m; ++i)
                    for (int j = 0; j < n; ++j)
                        array[i, j] = rnd.Next(MIN_RANDOM, MAX_RANDOM);

            }
            else
            {
                int count = 1;

                for (int i = 0; i < m; ++i)
                    for (int j = 0; j < n; ++j) {
                        array[i, j] = myInput.inputData($"Введите число № {count} (строка {i + 1} из {m}; столбец {j + 1} из {n}):");
                        Console.WriteLine(" ");
                        ++count;
                    }
            }

            return array;
        }

        private void printStringArray(int[,] array, int m)
        {

            string str = string.Format("[{0}]\t ", m);

            int countCol = array.GetLength(1);

            for (int j = 0; j < countCol; j++)
                str += string.Format("{0}\t", array[m, j]);

    
            Console.WriteLine(str);
          
        }
        public void printArray(int[,] array)
        {
            int countString = array.GetLength(0);
            int countRow = array.GetLength(1);

            Console.WriteLine($"Строк:    {countString}");
            Console.WriteLine($"Столбцов: {countRow}\n");

            string header = " \t";


            for (int i = 0; i < countRow; i++)
                header += $"[{i}]\t";

            Console.WriteLine(header);

            for (int i = 0; i < countString; i++)
                printStringArray(array, i);
        }
    }

    class MySort
    {
        public const bool INCRASE = true;
        public const bool DESCENDING = false;

        public const string ALGORITM_SELECT = "S";
        public const string ALGORITM_INSERT = "I";
        const string ALGORITM_DEFAULT = ALGORITM_SELECT;

        public const string ORIENATION_STRING = "S";
        public const string ORIENTATION_COL = "C";
        const string ORIENTATION_DEFAULT = ORIENATION_STRING;

        public const string DIRECTION_UP = "U";
        public const string DIRECTION_DOWN = "D";
        const string DIRECTION_DEFAULT = DIRECTION_UP;

        private static void swap(int[] array, int i, int j)
        {
            if (i != j){
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        private string inputData(string text, string case1, string case2, string defaultCase = "")
        {

            string xStr = "";

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine().ToLower();

                if (xStr == "")
                    xStr = defaultCase.ToLower();

                if (xStr != case1.ToLower() && xStr != case2.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод!");
                }
                else
                    break;
            }

            return xStr;
        }

        public struct ModeSort
        {
            public string algoritm;
            public bool direction;
            public string orientation;
        };

        public struct ArrayTime
        {
            public int[] array;
            public long time;
        }

        public ModeSort qwestionsSort(bool isTwoDimension)
        {
            MySort mySort = new MySort();
            ModeSort modeSort = new ModeSort();

            modeSort.algoritm = mySort.inputData(
                $"Какой алгоритм сортировки использовать? (Enter для [{ALGORITM_DEFAULT}])\n" +
                $"[{ALGORITM_SELECT}] - выбором" +
                $"\n[{ALGORITM_INSERT}] - вставкой\0", ALGORITM_SELECT, ALGORITM_INSERT, ALGORITM_DEFAULT);

            Console.WriteLine("");

            modeSort.direction = mySort.inputData(
                $"Отсортировать (Enter для [{DIRECTION_DEFAULT}]):\n" +
                $"[{DIRECTION_UP}] по возрастанию\n" +
                $"[{DIRECTION_DOWN}] по убыванию\0", DIRECTION_UP, DIRECTION_DOWN, DIRECTION_DEFAULT) == DIRECTION_UP.ToLower();

            Console.WriteLine("");

            if (isTwoDimension)
            {
                modeSort.orientation = mySort.inputData(
                   $"Выполнить сортировку (Enter для [{ORIENTATION_DEFAULT}])\n" +
                   $"[{ORIENATION_STRING}] по строкам\n" +
                   $"[{ORIENTATION_COL}] по столбцам\0", ORIENATION_STRING, ORIENTATION_COL, ORIENTATION_DEFAULT);

                Console.WriteLine("");
            }


            return modeSort;
        }
        public ArrayTime selectSort(int[] array, bool direction)
        {

            var startTime = Stopwatch.StartNew();
            //=================

            int size = array.Length;
            int tmp;

            for (int i = 0; i < size - 1; i++)
            {
                //поиск минимального числа или максимального
                int var = i;

                for (int j = i + 1; j < size; j++)
                {
                    if (direction == DESCENDING && array[j] > array[var])
                        var = j;
                    else if (direction == INCRASE && array[j] < array[var])
                        var = j;
                }

                
                swap(array, var, i);    
            }

            //
            startTime.Stop();

            ArrayTime result = new ArrayTime();
            result.array = array;

            
            result.time = startTime.ElapsedMilliseconds;
            return result;
        }

        public ArrayTime insertSort(int[] array, bool direction)
        {
            var startTime = Stopwatch.StartNew();
            //=================

            int x, j;
            int size = array.Length;

            for (int i = 1; i < size; i++){

                x = array[i];
                j = i;

                if (direction)
                { //по возрастанию
                    while (j > 0 && array[j - 1] > x)
                    {
                        swap(array, j, j - 1);
                        --j;
                    }
                }
                else
                {
                    while (j > 0 && array[j - 1] < x)
                    {
                        swap(array, j, j - 1);
                        --j;
                    }
                }

                array[j] = x;
            }

            startTime.Stop();

            ArrayTime result = new ArrayTime();
            result.array = array;

            
            result.time = startTime.ElapsedMilliseconds;
            return result;
        }

        public int[] sort(int[] array, ModeSort modeSort, bool isCheckTime, bool isPrint)
        {

            bool direction = modeSort.direction;
            string algoritm = modeSort.algoritm.ToUpper();
           
            ArrayTime result;
            string strDirection = "по возрастанию";
            string strAlgoritm = "выбором";

            if (!direction)
                strDirection = "по убыванию";

            if (algoritm == ALGORITM_SELECT)
                result = selectSort(array, direction);
            else
            {
                result = insertSort(array, direction);
                strAlgoritm = "Вставкой";
            }

            int size = result.array.Length;

            if (isPrint)
            {
                for (int i = 0; i < size; i++)
                    Console.WriteLine("[{0, 1}] {1, 3}", i, result.array[i]);
            }

            if (isCheckTime)
            {
                Console.WriteLine($"\nСортировка {strAlgoritm} {strDirection} в массиве с {size} элементов");
                Console.WriteLine($"Выполнена за {result.time} мс.");
            }

            return result.array;
        }


        public int[,] sort(int[,] array, ModeSort modeSort, bool isCheckTime, bool isPrint)
        {
            ArrayTime result;

            string strDirection = "по возрастанию";
            string strOrientation = "от первой строки <- ->";
            string strAlgoritm = "выбором";

            bool direction = modeSort.direction;
            string algoritm = modeSort.algoritm.ToUpper();
            string orientation = modeSort.orientation.ToUpper();

            if (!direction)
                strDirection = "по убыванию";

            if(algoritm == ALGORITM_INSERT)
                strAlgoritm = "вставкой";

            int countString = array.GetLength(0);
            int countCol = array.GetLength(1);

            if (orientation == ORIENTATION_COL)
                strOrientation = "от первого столбца  /\\ \\/";

            long sumTime = 0;  
            ArrayTime arrayTime;

            if (orientation == ORIENATION_STRING)
            {
                int[] tmpArray = new int[countCol];

                for (int i = 0; i < countString; i++)
                {
                    for (int j = 0; j < countCol; j++)
                        tmpArray[j] = array[i, j];

                    if(algoritm == ALGORITM_SELECT)
                        arrayTime = selectSort(tmpArray, direction);
                    else
                        arrayTime = insertSort(tmpArray, direction);

                    tmpArray = arrayTime.array;

                    for (int j = 0; j < countCol; j++)
                        array[i, j] = tmpArray[j];

                    sumTime += arrayTime.time;
                }

            }
            else
            {
                int[] tmpArray = new int[countString];

                for (int j = 0; j < countCol; j++)
                {
                    for (int i = 0; i < countString; i++)
                        tmpArray[i] = array[i, j];

                    if (algoritm == ALGORITM_SELECT)
                        arrayTime = selectSort(tmpArray, direction);
                    else
                        arrayTime = insertSort(tmpArray, direction);


                    tmpArray = arrayTime.array;

                    for (int i = 0; i < countString; i++)
                        array[i, j] = tmpArray[i];

                    sumTime += arrayTime.time;
                }
            }
           
            

            if (isPrint)
            {
                Console.WriteLine("");

                string str = "";

                string header = " \t";

                for (int i = 0; i < countCol; i++)
                    header += $"[{i}]\t";

                Console.WriteLine(header);

                for (int i = 0; i < countString; i++)
                {

                    str = string.Format("[{0}]\t", i);

                    for (int j = 0; j < countCol; j++)
                        str += string.Format("{0}\t", array[i, j]);

                    Console.WriteLine(str);
                }
            }

            if (isCheckTime)
            {
                Console.WriteLine($"\nСортировка {strAlgoritm} {strDirection} {strOrientation} в массиве с {countCol * countString} элементов");
                Console.WriteLine($"Выполнена за {sumTime} мс.");
            }

            return array;
        }
    }

    class Task1
    {
        
        private struct Val
        {
            public int index;
            public int value;
        };

        private Val getMin(int[] array)
        {

            int size = array.Length;
            Val min = new Val();

            min.index = 0;
            min.value = array[0];

            for (int i = 1; i < size; i++)
                if (array[i] < min.value){
                    min.value = array[i];
                    min.index = i;
                }

            return min;
        }

        private int getFirstPozitivElemIndex(int[] array)
        {
            int index = -1;
            int size = array.Length;

            for (int i = 0; i < size; ++i)
                if (array[i] > 0)
                    return i;

            return index;
        }

        private int getEndPozitivElemIndex(int[] array)
        {
            int index = -1;
            int size = array.Length;

            for (int i = size - 1; i > 0; --i)
                if (array[i] > 0)
                    return i;

            return index;
        }

        private bool isExistZero(int[] array)
        {
            int size = array.Length;

            for (int i = 0; i < size; ++i)
                if (array[i] == 0)
                    return true;

            return false;
        }

        private int[] sortFirstZero(int[] array)
        {
            Array.Sort(array, (a, b) =>
            {
                if (a == 0 && b != 0) return -1;
                else if (a != 0 && b == 0) return 1;
                return 0;
            });

            return array;
        }


        public void init()
        {

            Console.WriteLine("\nВ одномерном массиве:\0");
            Console.WriteLine("1) Вычислить минимальный элемент массива\0");
            Console.WriteLine("2) Сумму элементов массива расположенных между первым и последним положительными элементами\0");
            Console.WriteLine("3) Преобразовать массив таким образом, чтобы сначала располагались все элементы равные нулю, а потом все остальные\n");

            MyArray myArray = new MyArray();
            int[] array = myArray.createArray();

            Console.ForegroundColor = ConsoleColor.Yellow;

            MySort mySort = new MySort();
            MySort.ModeSort modeSort = mySort.qwestionsSort(false);

            Console.WriteLine("\nИсходный массив чисел:\n");

            Val min = getMin(array);
            int indexMin = min.index;

            int startPozitivElemIndex = getFirstPozitivElemIndex(array);
            int endPozitivElemIndex = getEndPozitivElemIndex(array);

            bool isExistPozitivElements = startPozitivElemIndex != -1 && endPozitivElemIndex != -1;

            string stringSum = "";
            int sum = 0;

            int itemQual = array[0];
            bool isAllElemQual = true;

            int countValues = array.Length;

            for (int i = 0; i < countValues; i++) {

                if(isAllElemQual && array[i] != itemQual)
                    isAllElemQual = false;

                if (isExistPozitivElements && startPozitivElemIndex < i && i < endPozitivElemIndex){
                    sum += array[i];
                    stringSum = "*";
                }
                else
                    stringSum = "";


                if (!isAllElemQual && i == indexMin)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[{0, 1}] {1, 3} " + stringSum + " - первый минимальный элемент массива", i, array[i]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                    Console.WriteLine("[{0, 1}] {1, 3} " + stringSum, i, array[i]);
            }

            if (isAllElemQual)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВсе элементы массива равны");
                Console.ResetColor();
            }


            if (isExistPozitivElements)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nПервый минимальный элемент массива: {min.value} (под индексом {indexMin})\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Первый положительный элемент массива: {array[startPozitivElemIndex]} (под индексом {startPozitivElemIndex})");
                Console.WriteLine($"Последний положительный элемент массива: {array[endPozitivElemIndex]} (под индексом {endPozitivElemIndex})\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Сумма чисел между первым и последним положительным элементом массива: {sum}\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВ массиве нет положительных элементов!\n");
            }

            if (isExistZero(array))
            {
                Console.WriteLine("\nВ массив в котором сначала располагаются нули, а затем все остальные элементы:\n");

                int[] arraySort = sortFirstZero(array);

                for (int i = 0; i < countValues; i++)
                    Console.WriteLine("[{0, 1}] {1, 3}", i, arraySort[i]);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВ массиве нет нулей!\n");
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nОтсортированный массив:");

            mySort.sort(array, modeSort, true, true);
            Console.ResetColor();

        }

    }


    class Task2
    {
        private int getCountNegativeElements(int[] array)
        {
            int count = 0;
            int size = array.Length;

            for (int i = 0; i < size; ++i)
                if (array[i] < 0)
                    ++count;

            return count;
        }

        private int getIndexMinAbs(int[] array)
        {
            int size = array.Length;
            int min = Math.Abs(array[0]);
            int index = 0;

            for (int i = 1; i < size; i++)
                if (Math.Abs(array[i]) < min)
                {
                    min = Math.Abs(array[i]);
                    index = i;
                }

            return index;
        }

        private int getSumAbsAfterIndex(int[] array, int index)
        {
            if(index < 0)
                return 0;

            int size = array.Length;
            int sum = 0;

            for (int i = index + 1; i < size; i++)
                sum += Math.Abs(array[i]);
                    
            return sum;
        }

        public void init()
        {
            Console.WriteLine("\nВ одномерном массиве:\0");
            Console.WriteLine("1) Вычислить количество отрицательных элементов массива\0");
            Console.WriteLine("2) Сумму модулей элементов массива расположенных после минимального по модулю элемента\0");
            Console.WriteLine("3) Заменить все отрицательные элементы массива их квадратами\0");
            Console.WriteLine("4) упорядочить элементы по возрастанию\n");


            MyArray myArray = new MyArray();
            int[] array = myArray.createArray();

            MySort mySort = new MySort();
            MySort.ModeSort modeSort = mySort.qwestionsSort(false);

            Console.WriteLine("\nИсходный массив чисел:\n");

            int indexMinModule = getIndexMinAbs(array);

            int size = array.Length;

            string sign = "";

            for (int i = 0; i < size; ++i){

                if (array[i] < 0)
                    sign = "отрицательное число";
                else
                    sign = "";

                if (i == indexMinModule)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[{0, 1}] {1, 3} " + sign + " - минимальный по модулю элемент массива", i, array[i]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                    Console.WriteLine("[{0, 1}] {1, 3} " + sign, i, array[i]);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nКоличество отрицательных элементов массива: {getCountNegativeElements(array)}\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Сумма модулей элементов массива, расположенных после минимального по модулю элемента: {getSumAbsAfterIndex(array, indexMinModule)}\n");

            Console.ResetColor();

            for (int i = 0; i < size; ++i)
                if (array[i] < 0)
                    array[i] = (int) Math.Pow(array[i], 2);

            mySort.sort(array, modeSort, true, true);
            Console.ResetColor();
        }
    }

    class Task3
    {
        private void printSumInString(int[,] array, int m)
        {
            int sum = 0;
            bool isExistNegative = false;

            string str = string.Format("[{0}]\t ", m);

            int countCol = array.GetLength(1);

            for (int j = 0; j < countCol; j++) {

                sum += array[m, j];
                str += string.Format("{0}\t", array[m, j]);

                if (array[m, j] < 0)
                    isExistNegative = true;

            }

            if (isExistNegative) {
                Console.ForegroundColor = ConsoleColor.Green;
                str += " - Сумма чисел в строке:" + string.Format("{0,5} ", sum);
            }
            else
                Console.ResetColor();

            Console.WriteLine(str);
        }

        private bool isMaxInCol(int[,] array, int i, int j)
        {
            int size = array.GetLength(0);

            for (int n = 0; n < size; ++n)
                if (array[n, j] > array[i, j])
                    return false;
            
            return true;
        }

        private  bool isMinInRow(int[,] array, int i, int j)
        {
            int size = array.GetLength(1);

            for (int n = 0; n < size; ++n)
                if (array[i, n] < array[i, j])
                    return false;

            return true;
        }

        private void printSledPoints(int[,] array)
        {
            int countString = array.GetLength(0);
            int countCol = array.GetLength(1);

            bool isExist = false;

            for (int i = 0; i < countString; i++)
                for (int j = 0; j < countCol; j++)
                    if (isMinInRow(array, i, j) && isMaxInCol(array, i, j)){

                        Console.WriteLine("Элемент [{0}][{1}] {2} - следовый (строка: {3} столбец: {4})", i, j, array[i, j], i + 1, j + 1);
                        isExist = true;
                    }

            if (!isExist)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nСледовых элементов не обнаружено!");
                Console.ResetColor();
            }

        }

        public void init()
        {
            Console.WriteLine("\nВ матрице:");
            Console.WriteLine("1) Определить сумму элементов массива в тех строках, которые содержат хотя бы один отрицательный элемент\0");
            Console.WriteLine("2) Определить номера строк и столбцов всех следовых точек матрицы\n");

            MyArray myArray = new MyArray();
            int[,] array = myArray.createTwoDimensionalArray();

        /*
          int[,] array = {
              {0, 2, 3, 4, 5},
              {1, 1, 1, 1, 1},
              {1, 1, 1, 1, 5},
              {1, 1, 1, 4, 5},
              {1, 1, 3, 4, 5},
              {1, 2, 3, 4, 5},
          };
        */

            /*
              int[,] array = {
                {-1, 0, 2, 1, 4, 3, 6, 5, 7},
                {0, 0, 0, 3, 2, 1, 7, 6, 5},
                {4, 4, 3, 3, 3, 5, 5, 5, 5},
                {6, 6, 0, 6, 6, 6, 6, 6, 6},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {9, 8, 7, 9, 9, 7, 7, 9, 9}
            };
            */

            MySort mySort = new MySort();
            MySort.ModeSort modeSort = mySort.qwestionsSort(true);

            Console.WriteLine("\nИсходный массив чисел:\n");

            int countString = array.GetLength(0);
            int countRow = array.GetLength(1);


            Console.WriteLine($"Строк:    {countString}");
            Console.WriteLine($"Столбцов: {countRow}\n");

            string header = " \t";


            for (int i = 0; i < countRow; i++)
                header += $"[{i}]\t";

            Console.WriteLine(header);

            for (int i = 0; i < countString; i++)
                printSumInString(array, i);


            Console.WriteLine("");
            printSledPoints(array);

            Console.ResetColor();
            mySort.sort(array, modeSort, true, true);
            Console.ResetColor();
        }
    }

    class Task4
    {
        private void printArray(int[,] array)
        {
            int countRow = array.GetLength(0);
            int countCol = array.GetLength(1);


            Console.WriteLine($"Строк:    {countRow}");
            Console.WriteLine($"Столбцов: {countCol}\n");

            string header = " \t";

            for (int i = 0; i < countCol; i++)
                header += $"[{i}]\t";

            Console.WriteLine(header);

            string str = "";

            for (int i = 0; i < countRow; i++)
            {
                str = string.Format("[{0}]\t ", i);

                for (int j = 0; j < countCol; j++)
                    str += string.Format("{0}\t", array[i, j]);

                Console.WriteLine(str);
                str = "";
            }
        }

        private int getIndexFirstPositiveElementCol(int[,] array)
        {
            int countRow = array.GetLength(0);
            int countCol = array.GetLength(1);

            bool isNegative = false;

            for (int j = 0; j < countCol; j++){

                isNegative = false;

                for (int i = 0; i < countRow; i++)
                    if (array[i, j] < 0){
                        isNegative = true;
                        break;
                    }

                if (!isNegative)
                    return j;
            }

            return -1;
        }

        private int[] getRow(int[,] array, int i)
        {
            int countCol = array.GetLength(1);
            int[] result = new int[countCol];

            for(int j = 0; j < countCol; j++)
                result[j] = array[i, j];

            return result;
        }
        private int getCountQualRepeatElements(int[] array)
        {

            //int[] array = {3, 3, 3, 4, 4, 5, 5, 5, 5};

            int size = array.Length;

            MySort.ModeSort modeSort = new MySort.ModeSort();
            modeSort.direction = MySort.INCRASE;
            modeSort.algoritm = MySort.ALGORITM_SELECT;

            int count = 0;
            int qual = array[0];

            int sumCount = 0;


            MySort mySort = new MySort();
            array = mySort.sort(array, modeSort, false, false);

            for (int i = 1; i < size; i++)
            {
                if (qual == array[i])
                    ++count;
                else
                {
                    sumCount += count;

                    if (count != 0)
                        ++sumCount;

                    count = 0;
                }

                qual = array[i];

            }

            if(count != 0)
                sumCount += count +1;

            return sumCount;
        }

        private struct StringsWithRepeat
        {
            public int[] strings;
            public bool isExistRepeat;
        }
        private StringsWithRepeat getStringsWithRepeat(int[,] array)
        {
            int countRow = array.GetLength(0);
            int countQualRepeatElements;

            bool isExistRepeat = false;
            int[] result = new int[countRow];
            int[] tmpArray;

            for (int i = 0; i < countRow; i++) {

                tmpArray = getRow(array, i);
                countQualRepeatElements = getCountQualRepeatElements(tmpArray);

                if (countQualRepeatElements != 0)
                {
                    result[i] = countQualRepeatElements;
                    isExistRepeat = true;
                }

            }

            StringsWithRepeat res = new StringsWithRepeat();
            res.strings = result;
            res.isExistRepeat = isExistRepeat;

            return res;
        }

        private struct TmpMaxCountQual
        {
            public int count;
            public int[] row;
        }

        private int comparsionEqal(TmpMaxCountQual a, TmpMaxCountQual b)
        {
            int countA = a.count;
            int countB = b.count;

            if (countA > countB) return 1;
            if (countA < countB) return -1;
            return 0;
        }

        public void init()
        {
            Console.WriteLine("\nВ матрице:");
            Console.WriteLine("1) Упорядочить строки целочисленной прямоугольной матрицы по возрастанию количества одинаковых элементов в каждой строке\0");
            Console.WriteLine("2) Найти номер первого из столбцов, не содержащих ни одного отрицательного элемента\n");

            MyArray myArray = new MyArray();
            int[,] array = myArray.createTwoDimensionalArray();

            /*
            int[,] array = {
                {0, 2, 3, 4, 5},
                {1, 1, 1, 1, 1},
                {1, 1, 1, 1, 5},
                {1, 1, 1, 4, 5},
                {1, 1, 3, 4, 5},
                {1, 2, 3, 4, 5},
            };
            */

            /*
              int[,] array = {
                {-1, 0, 2, 1, 4, 3, 6, 5, 7},
                {0, 0, 0, 3, 2, 1, 7, 6, 5},
                {4, 4, 3, 3, 3, 5, 5, 5, 5},
                {6, 6, 0, 6, 6, 6, 6, 6, 6},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {9, 8, 7, 9, 9, 7, 7, 9, 9}
            };
            */

            MySort mySort = new MySort();
            MySort.ModeSort modeSort = mySort.qwestionsSort(true);

            Console.WriteLine("\nИсходный массив чисел:\n");

            printArray(array);

            int indexFirstPositiveElementCol = getIndexFirstPositiveElementCol(array);

            if (indexFirstPositiveElementCol == -1)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВсе столбцы содержат минимум один отрицательный элемент!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nНомер первого из столбцов, не содержащих ни одного отрицательного элемента: {indexFirstPositiveElementCol + 1}");
                Console.ResetColor();
            }

            mySort.sort(array, modeSort, true, true);

            StringsWithRepeat stringsWithRepeat = getStringsWithRepeat(array);

            if (!stringsWithRepeat.isExistRepeat)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВ строках нет повторяющихся элементов!");
                Console.ResetColor();
            } 
            else
            {
                int[] maxCountQual = stringsWithRepeat.strings;
                int countRow = array.GetLength(0);
                int countCol = array.GetLength(1);

                List<TmpMaxCountQual> tmpMaxCountQual = new List<TmpMaxCountQual>();
                TmpMaxCountQual itemTmpMaxCountQual;
                List<int> ignoreIndex = new List<int>();
                int[] tmpRow;

                string repeatsInStrings = "";
                int countQual = maxCountQual.Length;

                for (int i = 0; i < countQual; i++)
                {

                    if (maxCountQual[i] != 0)
                    {
                        repeatsInStrings += (i + 1) + ", ";

                        tmpRow = getRow(array, i); 
                        itemTmpMaxCountQual.row = tmpRow;
                        itemTmpMaxCountQual.count = getCountQualRepeatElements(tmpRow);
                        tmpMaxCountQual.Add(itemTmpMaxCountQual);
                        ignoreIndex.Add(i);
                    }
                     
                }

                repeatsInStrings = repeatsInStrings.Remove(repeatsInStrings.Length - 2);
                repeatsInStrings = "\nСтроки с номерами: " + repeatsInStrings + " - содержат повторяющиеся элементы\n";

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(repeatsInStrings);

                tmpMaxCountQual.Sort(comparsionEqal);
                int tmpMaxCountQualSize = tmpMaxCountQual.Count;

                int[,] sortArray = new int[countRow, countCol]; 

                for (int i = 0; i < tmpMaxCountQualSize; i++)
                    for (int j = 0; j < countCol; j++)
                        sortArray[i, j] = tmpMaxCountQual[i].row[j];

                int n = 0;

                for (int i = 0; i < countRow; i++)
                {
                    if (!ignoreIndex.Contains(i))
                    {
                        for (int j = 0; j < countCol; j++)
                            sortArray[tmpMaxCountQualSize + n, j] = array[i, j];

                        ++n;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Матрица с упорядоченными по возрастанию повторяющихся элементов строками");


                //============================================================
                Console.WriteLine($"Строк:    {countRow}");
                Console.WriteLine($"Столбцов: {countCol}\n");

                string header = " \t";

                for (int i = 0; i < countCol; i++)
                    header += $"[{i}]\t";

                Console.WriteLine(header);

                string str = "";
                n = 0;

                for (int i = 0; i < countRow; i++)
                {
                    str = string.Format("[{0}]\t ", i);

                    for (int j = 0; j < countCol; j++)
                        str += string.Format("{0}\t", sortArray[i, j]);

                    if (n < tmpMaxCountQualSize)
                    {
                        str += " - количество одинаковых элементов в строке: " + tmpMaxCountQual[n].count;
                        ++n;
                    }

                    Console.WriteLine(str);
                    str = "";
                }

                //printArray(sortArray);
                //============================================================

            }

            Console.ResetColor();
        }
    }

    class Class1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ларионов Никита Юрьевич. гр. 110з\n");
            Console.WriteLine("Лабораторная работа №5. Одномерный массив. (номера задач \"1\", \"2\")");
            Console.WriteLine("Лабораторная работа №6. Матрица. (номера задач \"3\", \"4\")\n");

            bool isGo = true;
            while (isGo)  ////Цикл с предусловием
            {

                Console.WriteLine("\nВведите номер задачи \"1\", \"2\", \"3\", \"4\": ");
                Console.WriteLine("Для выхода введите \"0\": ");

                string selectStr = Console.ReadLine();

                switch (selectStr)
                {
                    case "1":
                        Task1 task1 = new Task1();
                        task1.init();
                        break;

                    case "2":
                        Task2 task2 = new Task2();
                        task2.init();
                        break;

                    case "3":
                        Task3 task3 = new Task3();
                        task3.init();
                        break;

                    case "4":
                        Task4 task4 = new Task4();
                        task4.init();
                        break;

                    case "0":
                        isGo = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНекорректные данные!");
                        Console.ResetColor();
                        break;

                }
            }
        }

    }
}
