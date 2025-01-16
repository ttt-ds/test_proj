using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace test_proj
{
    class Program
    {
        static string ReversedBinary(int value) {
            // Возвращает обратное бинарное представление числа
            int n = value;
            string res = "";
            while (n > 0)
                {
                    // Console.Write(n % 2);
                    res+= n % 2;
                    n = n / 2;
                }
            return res;
        }
        static int DigitCountInNum(int value, int targetValue) {
            // Рассчет количества нужной цифры в числе
            int n = value;
            int cnt = 0;
            while (n > 0) {
                int lastDigit = n % 10;
                if (lastDigit == targetValue) {
                    cnt++;
                }
                n/=10;
            }
            return cnt;
        }

        static int DimensionsCount(int value) {
            // Возвращает количество делителей числа
            int n = value;
            int count = 0;
            for (int i = 1; i <= n; i++) {
                if (n % i == 0) {
                    count++;
                }
            }

            return count;
        }

        static int DigitsSum(int value) {
            // Возвращает сумму цифр числа
            int n = value;
            int sum = 0;
            while (n > 0) {
                int lastDigit = n % 10;
                sum += lastDigit;
                n/=10;
            }
            return sum;
        }

        static int MaxDivisionPosValue(int value) {
            // Максимальный делитель положительного числа, отличный от самого числа
            int n = value;
            int res = 1;
            for (int i = n -1; i>=1; i--) {
                if (n % i == 0) {
                    res = i;
                    break;
                }
            }
            
            return res;
        }

        static int LenOfNum(int value) {
            // Считает количество цифр в числе
            int n = value;
            int res = 0;
            while (n > 0) {
                res++;
                n/=10;
            }
            return res;
        }

        static int ReversedNum(int value) {
            // Получение "перевернутого" числа
            int n = value;
            int res = 0;
            for (int i = LenOfNum(n); i >= 1; i--) {
                res += (n % 10) * Convert.ToInt32(Math.Pow(10, i-1));
                n /= 10;
                // Console.WriteLine(res);
            }

            return res;
        }

        static int PosNumPow(int value, int degree) {
            // Возвращает value в неотрицательной степени degree
            int num = value;
            int res = 1;

            if (degree > 0) {
                for (int i = 1; i <= degree; i++) {
                    res*=num;
                }
            }

            return res;
        }

        static int CyfralRoot(int value) {
            // Возвращает "цифровой корень числа" - суммировать все цифры, пока не будет получена одна цифра
            int num = value;

            while (LenOfNum(num) != 1) {
                num = DigitsSum(num);
            }

            return num;
        }

        static void AlphabetBetweenChars(char startValue = 'a', char endValue = 'z') {
            // Выводит весь алфавит между start и end значениями
            for (int i = startValue; i <= endValue; i++) {
                Console.Write((char)i);
                Console.Write(" ");
            }
        }

        static char CharCaseChange(char value) {
            // Меняет регистр буквы на противоположный
            char result;
            int valueCode = (int)value;
            if (valueCode >= 97) {
                result = (char)(valueCode - 32);
            }
            else {
                result = (char)(valueCode + 32);
            }
            return result;
        }

        static int CountWordInString(string sentence, char delimeter = ' ') {
            // Возвращает количество слов, разделенных разделителем
            int count;
            if (sentence.Length > 0) {
                count = 1;
                for (int i = 0; i < sentence.Length; i++) {
                    if (sentence[i] == delimeter) {
                        count++;
                    }
                }
            } else {
                count = 0;
            }
            return count;
        }

        static string ReverseString(string value) {
            // Возвращает перевернутую строку
            string result = "";
            for (int i = value.Length - 1; i >= 0; i--) {
                result += value[i];
            }
            return result;
        }
        static string DropStringCharByIndex(string value, int position) {
            // Возвращает строку без элемента с индексом position-1
            string result = "";
            for (int i = 0; i < value.Length; i++) {
                if (i+1 != position) {
                    result+=value[i];
                }
            }
            return result;
        }

        static char GetFirstDuplicatedChar(string value, char defaultOutput = ' ') {
            // Возвращает первый "дублирующийся" символ. Если такого нет, вернет defaultOutput
            char result = defaultOutput;
            for (int i = 0; i < value.Length; i++) {
                char actChar = value[i];
                string noCharString = DropStringCharByIndex(value: value, position: i+1);
                for (int j = 0; j < noCharString.Length; j++) {
                    if (actChar == noCharString[j]) {
                        result = actChar;
                        break;
                    }
                }

            }
            return result;
        }

        static string DoubleCharReplace(string value, char toReplace = ' ') {
            // Убирает повторения подряд символа toReplace
            string result = "";
            
            bool completed = false;

            string sentence = value;
            while (completed == false) {
                char firstSym = ' ';
                bool markCompleted = true;
                for (int i = 0; i < sentence.Length; i++) {
                    if (sentence[i] == firstSym && sentence[i] == toReplace) {
                        sentence = DropStringCharByIndex(sentence, i);
                        markCompleted = false;
                        break;
                    } else {
                        firstSym = sentence[i];
                    }
                }
                if (markCompleted == true) {
                    completed = true;
                    result = sentence;
                }

            }

            return result;
        }
        
        static int AncientWordDecoder(string value) {
            // Декодер слов в числа из Stepik 5.3.14
            int result = 0;
            for (int i = 0; i < value.Length; i++) {
                switch (value[i])
                    {
                        case '/': result += 10000; break;
                        case '$': result += 1000; break;
                        case '?': result += 100; break;
                        case 'л': result += 10; break;
                        case '|': result += 1; break;
                    }
            }
            return result;
        }

        static void WordsBySentence(string value, char delimeter = ' ') {
            // Вывод с новой строки слов предложения
            string word = "";
            for (int i = 0; i < value.Length; i++) {
                if (value[i] != delimeter) {
                    word += value[i];
                } else {
                    Console.WriteLine(word);
                    word = "";
                }
            }
            // Console.WriteLine(word);
        }

        static int CharCountInWord(string word, char symbol) {
            // Считает количество символов symbol в строке
            int count = 0;
            for (int i = 0; i < word.Length; i++) {
                if (word[i] == symbol) {
                    count++;
                }
            }
            return count;
        }

        static void AllCharCountInWord(string word) {
            // Выводит статистику нахождения букв латинского алфавита в строке
             for (int i = 'a'; i <= 'z'; i++) {
                int count = CharCountInWord(word: word, symbol: (char)i);
                if (count != 0) {
                    Console.WriteLine($"{(char)i} {count}");
                }
            }
        }

        static int CountVowelLetters(string value, string vowels = "aeiouy") {
            // Количество гласных букв в слове
            int count = 0;
            for (int i = 0; i < vowels.Length; i++) {
                count+=CharCountInWord(word: value, symbol: vowels[i]);
            }

            return count;
        }

        static string ReplaceSymbolInWord(string value, char symbol, char replacer) {
            // Заменяет символ в слове
            string result = "";
            for (int i = 0; i < value.Length; i++) {
                if (value[i] != symbol) {
                    result+=value[i];
                }
                else {
                    result+=replacer;
                }
            }
            return result;
        }

        static string ArtozeDecoder(string value) {
            // Декодирует шифр в троичную последовательность
            string result = "";
            string word = value;
            while (word.Length != 0) {
                if (word.Length == 1) {
                    result += "0";
                    break;
                }
                if (word[0..2] == "--") {
                    result += "2";
                    word = word[2..];
                } else if (word[0..2] == "-."){
                    result += "1";
                    word = word[2..];
                } else {
                    result += "0";
                    word = word[1..];
                }
            }

            return result;
        }

        static string RuToEngReplace(string value) {
            // Замена на английскую раскладку
            string result = "";
            string ru =  " йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ\"№;:?.,";
            string eng = " qwertyuiop[]asdfghjkl;\'zxcvbnm,.QWERTYUIOP{}ASDFGHJKL:\"ZXCVBNM<>@#$^&/?";
            char symbol = ' ';

            for (int i = 0; i < value.Length; i++) {
                int position = -1;
                for (int j=0; j< ru.Length; j++) {
                    if (value[i] == ru[j]) {
                        position = j;
                    }
                }
                if (position != -1) {
                    result += eng[position];
                } else {
                    result += value[i];
                }
            }

            return result;
        }

        static string CezarCypher(string value, int shift) {
            //Учебная реализация шифра Цезаря
            string abc = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            string doubleABC = abc + abc;
            string result = "";
            int realShift = shift % abc.Length;
            int oldPos = 999;
            int newPos = 999;
            for (int i = 0; i < value.Length; i++) {
                
                for (int j=0; j< abc.Length; j++) {
                    if (abc[j] == value[i]) {
                        oldPos = j + realShift;
                        break;
                    }
                }
                result += doubleABC[oldPos];

            }            

            return result;
        }

        static int GetBullCount(string trueNumber, string askNumber) {
            // Возвращает количество "быков" (Игра "Быки и коровы")
            int bullCount = 0;
            string trueNumberString = trueNumber;
            string askNumberString = askNumber;

            for (int i = 0; i < trueNumberString.Length; i++) {
                if (trueNumberString[i] == askNumberString[i]) {
                    bullCount++;
                }
            }
            return bullCount;
        }

        static int GetCowCount(string trueNumber, string askNumber) {
            // Возвращает количество "коров" (Игра "Быки и коровы")
            int cowCount = 0;
            string trueNumberString = trueNumber;
            string askNumberString = askNumber;

            for (int i = 0; i < trueNumberString.Length; i++) {
                for (int j = 0; j < trueNumberString.Length; j++) {
                    if (i != j) {
                        if (trueNumberString[i] == askNumberString[j]) {
                            cowCount++;
                        }
                    }
                }
            }
            return cowCount;
        }

        static void BullCowGame(string trueNumber, string askNumber) {
            int bullCount = GetBullCount(trueNumber, askNumber);
            int cowCount = GetCowCount(trueNumber, askNumber);
            int gameSize = Convert.ToString(trueNumber).Length;

            if (bullCount == gameSize) {
                Console.WriteLine("Четыре быка! Ты выиграл!"); // по-хорошему, сюда нужен маппинг "цифра-русское написание цифры"
            } else if (cowCount == gameSize) {
                Console.WriteLine("Четыре коровы. Правильно расставьте цифры");
            } else {
                Console.WriteLine($"Быки-{bullCount}, коровы-{cowCount}");
            }
        }

        static int[] IntOneDimArrayInput(char delimeter = ' ') {
            // Считывание цифр, написанных через delimeter в 1 строку.
            string inputString = Console.ReadLine();
            string[] arrayWords = inputString.Split(' '); 
            
            int[] numbers = new int[arrayWords.Length];
            for (int i=0; i < arrayWords.Length; i++) {
                numbers[i] = Convert.ToInt32(arrayWords[i]);
            }

            return numbers;
        }

        static int[] ReverseIntArray(int[] value) {
            // Возвращает перевернутый массив чисел
            int[] result = new int[value.Length];

            int newIndex = 0;
            for (int i=value.Length-1; i>=0; i--) {
                result[newIndex] = value[i];
                newIndex++;
            }

            return result;
        }

        static bool IsDuplicationsInNumArray(int[] value) {
            // Проверяет, есть ли повторы элементов в массиве
            bool result = false;
            for (int i=0; i < value.Length; i++)  {
                for (int j=0; j < value.Length; j++) {
                    if (i!=j) {
                        if (value[i]==value[j]) {
                            result=true;
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        static int[] GetCountNumArrayUniques(int[] value) {
            // Получение уникальных элементов массива
            string tmpResult = "";

            for (int i=0; i<value.Length; i++) {
                bool isUnique = true;
                for (int j=0; j < value.Length; j++) {
                    if (i!=j) {
                        if (value[i]==value[j]) {
                            isUnique=false;
                            break;
                        }
                    }
                }
                if (isUnique) {
                    tmpResult += $"{value[i]}|";
                }
            }
            // parse result string 
            if (tmpResult != "") {
                tmpResult = tmpResult[..(tmpResult.Length - 1)];
            
                string[] arrayWords = tmpResult.Split('|'); 
                
                int[] numbers = new int[arrayWords.Length];
                for (int i=0; i < arrayWords.Length; i++) {
                    numbers[i] = Convert.ToInt32(arrayWords[i]);
                }
                return numbers;
            } else {
                return new int[0];
            }
        }

        static int[,] TwoDimZeroOneTwoArray (int n) {
            /*
            Возвращает массив вида:
            0 0 1
            0 1 2
            1 2 2
            */
            int[,] result = new int[n,n];
            for (int i=0; i<n; i++) {
               for (int j=0; j<n; j++) {
                if (i < n- 1 - j) {
                    result[i, j] = 0;
                } else if (i > n - 1 -j ) {
                    result[i, j] = 2;
                } else {
                    result[i, j] = 1;
                }
               }
            }

            return result;
        }
        static void TwoDimPrint(int[,] value) {
            // Выводит двумерный массив в лог
            for (int i = 0; i < value.GetLength(0); i++)
            {
                for (int j = 0; j < value.GetLength(1); j++)
                {
                    Console.Write(value[i, j] + " ");
                }
                Console.WriteLine(); // перевод на новую строку
                }

        }

        static int[,] IntTwoDimArrayInput (int n, int m) {
            // Считывание двумерного массива целых чисел
            int[,] result = new int[n,m];
            for (int i=0; i<n; i++) {
                string[] inputString = Console.ReadLine().Split(' ');
                for (int j=0; j<m; j++) {
                    result[i,j] = Convert.ToInt32(inputString[j]);
                }
            }

            return result;
        }

        static char[,] CharTwoDimArrayInput (int n, int m) {
            // Считывание двумерного массива символов
            char[,] result = new char[n,m];
            for (int i=0; i<n; i++) {
                string[] inputString = Console.ReadLine().Split(' ');
                for (int j=0; j<m; j++) {
                    result[i,j] = Convert.ToChar(inputString[j]);
                }
            }

            return result;
        }

        static string[,] StringTwoDimArrayInput (int n, int m) {
            // Считывание двумерного массива строк
            string[,] result = new string[n,m];
            for (int i=0; i<n; i++) {
                string[] inputString = Console.ReadLine().Split(' ');
                for (int j=0; j<m; j++) {
                    result[i,j] = inputString[j];
                }
            }

            return result;
        }
        static bool IsSymmetricalTwoDimArray(int[,] value) {
            /*
            Проверка двумерного массива на соответствие виду:
            1 2 3
            2 8 6
            3 6 9
            */

            for (int i = 0; i < value.GetLength(0); i++)
            {
                for (int j = 0; j < value.GetLength(1); j++) {
                    if (value[i,j] != value[j,i]) {
                        return false;
                    }
                }
            }
            return true;
        }

        static int[,] PifagorTwoDimArray(int n, int m) {
            // Функция построения таблицы Пифагора по заданной размерности
            int[,] result = new int[n,m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) {
                    result[i,j] = (i+1) * (j+1);
                }
            }

            return result;
        }

        static (int, int) GetArraySize() {
            // Получение двух чисел (например, размеров массива), записанных в 1 строку через пробел
            string[] inputString = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(inputString[0]);
            int m = Convert.ToInt32(inputString[1]);
            return (n, m);
        }

        static int[,] PascalTriangle(int n, int m) {
            // Функция рассчета матрицы с треугольником Паскаля: элемент равен сумме двух элементов, стоящих слева и сверху от него.
            int[,] result = new int[n,m];
            for (int i=0; i<n; i++) {
                result[i, 0] = 1;
            }
            for (int i=0; i<m; i++) {
                result[0, i] = 1;
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++) {
                    result[i,j] = result[i-1, j] + result[i, j-1];
                }
            }
            return result;
        }

        static (int, int) GetLineNumWithMaxSum(int[,] value) {
            // Получение номера строки с максимальной суммой элементов и максимальной суммы элементов в ней.
            int lineNum = -99999;
            int maxSum = -999999;
            for (int i=0;i<value.GetLength(0); i++) {
                int actSum = 0;
                for (int j = 0; j < value.GetLength(1); j++) {
                    actSum+=value[i,j];
                }
                if (actSum > maxSum) {
                    maxSum = actSum;
                    lineNum = i;
                }
            }

            return (lineNum, maxSum);
        }

        static int[] GetArrayFromString(string inputString, char delimeter = ' ', bool delimInLineEnd = true) {
            // Разделяет строку на числовой массив
            int[] result = new int[0];
            if (inputString != ""){
                string tmpResult = inputString;

                if (delimInLineEnd) {
                    tmpResult = tmpResult[..(tmpResult.Length - 1)];
                }
                    
                string[] arrayWords = tmpResult.Split(delimeter); 
                
                int[] numbers = new int[arrayWords.Length];
                for (int i=0; i < arrayWords.Length; i++) {
                    numbers[i] = Convert.ToInt32(arrayWords[i]);
                }
                return numbers;
            }

            return result;
        }

        
        static int[] GetAllDivisionableNumsInArray(int[] value, int divisioner = 2) {
            // Возвращает все числа в массиве, делящиеся на divisioner
            string tmpResult = "";

            for (int i=0; i<value.Length; i++) {
                if (value[i] % divisioner == 0) {
                    tmpResult += $"{value[i]}|";
                }
            }
            int[] result = GetArrayFromString(tmpResult, delimeter: '|', delimInLineEnd: true);
            return result;
        }

        static int[] GetNumUniques(int[] value) {
            // Возвращает все уникальные значения массива
            string tmpResult = "";
            for (int i=0; i<value.Length; i++) {
                bool isUnique = true;
                for (int j=0; j<value.Length; j++) {
                    if (i!=j) {
                        if (value[i] == value[j]) {
                            isUnique = false;
                        }
                    }
                }
                if (isUnique) {
                    tmpResult += $"{value[i]}|";
                } else {
                    int[] tmpArray = GetArrayFromString(tmpResult, delimeter: '|', delimInLineEnd: true);
                    bool alreadyInArray = false;
                    for (int r=0; r<tmpArray.Length; r++) {
                        if (value[i]==tmpArray[r]) {
                            alreadyInArray = true;
                            break;
                        }
                    }
                    if (!alreadyInArray) {
                        tmpResult += $"{value[i]}|";
                    }
                }
            }


            return GetArrayFromString(tmpResult, delimeter: '|', delimInLineEnd: true);
        }

        static int GetPositionInSortedArray(int value, int[] sortedArray) {
            // Возвращает позицию, на которой нужно расположить новый элемент в массиве, отсортированном по невозрастанию
            int result = sortedArray.Length;

            for (int i=0; i< sortedArray.Length; i++) {
                    if (value > sortedArray[i]) {
                        result = i;
                        // Console.WriteLine(i);
                        break;
                    }
            }
            return result;  
        }

        static int[] GetIndexesZeroPair(int[] value) {
            // Возвращает индексы элементов, которые "зануляются" при сложении
            string tmpResult = "";
            for (int i=0; i<value.Length; i++) {
                for (int j=i; j<value.Length; j++) {
                    if (j!=i) {
                        if (value[i] != 0 && value[i]+value[j] == 0) {
                            tmpResult += $"{i} {j}";
                        }
                    }
                }
            }


            return GetArrayFromString(tmpResult, delimeter: '|', delimInLineEnd: true);
        }

        static int MinimalRoadSize(int [] value, int height) {
            // Реализация идиотизма из https://stepik.org/lesson/87060/step/7?unit=63457
            int result = value.Length;
            for (int i=0; i<value.Length; i++) {
                if (value[i] > height) {
                    result++;
                }
            }

            return result;
        }

        static bool IsPhotoBlackAndWhite(char[,] value) {
            // Реализация проверки на цветные пиксели из https://stepik.org/lesson/87060/step/8?unit=63457
            bool isBlackNWhite = true;

            for (int i = 0; i<value.GetLength(0); i++) {
                for (int j = 0; j < value.GetLength(1); j++) {
                    // Console.WriteLine($"{value[i,j]}");
                    if ((value[i,j] != 'W') && (value[i,j] != 'B') && (value[i,j] != 'G')) {
                        return false;
                    }
                    
                }
            }
            return isBlackNWhite;
        }

        static int TransformHoursMinsToMinutes(string value) {
            // 10:15 -> 615 минут
            int result = Convert.ToInt32(value.Split(':')[0]) * 60 + Convert.ToInt32(value.Split(':')[1]);
            // Console.WriteLine(result);
            return result;
        }

        static int GetTimedeltaInMinutes(int startValue, int endValue) {
            // Возвращает корректную дельту в минутах между двумя временными значениями
            int delta;
            if (endValue > startValue) {
                delta =  endValue - startValue;
            } else {
                delta = (24 * 60 - startValue)  + endValue;
            }
            // Console.WriteLine(delta);
            return delta;
        }

        static int[,] PathOptimize(int[,] value) {
            // Оптимизация маршрута из https://stepik.org/lesson/87060/step/12?unit=63457
            int[,] result = new int[2,2];
            int verticalAxisWay = 0;
            int horizontalAxisWay = 0;

            for (int i=0; i< value.GetLength(0); i++) {
                if (value[i,0] == 1) {
                    verticalAxisWay+=value[i,1];
                } else if (value[i,0] == 2) {
                    horizontalAxisWay+=value[i,1];
                } else if (value[i,0] == 3) {
                    verticalAxisWay-=value[i,1];
                } else if (value[i,0] == 4) {
                    horizontalAxisWay-=value[i,1];
                }
            }
            result[0,1] = Math.Abs(verticalAxisWay);
            result[1,1] = Math.Abs(horizontalAxisWay);

            if (verticalAxisWay > 0) {
                result[0,0] = 1;
            } else if (verticalAxisWay < 0) {
                result[0,0] = 3;
            } else {
                result[0,0] = 0;
            }

            if (horizontalAxisWay > 0) {
                result[1,0] = 2;
            } else if (horizontalAxisWay < 0) {
                result[1,0] = 4;
            } else {
                result[1,0] = 0;
            }

            return result;
        }

        static int Factorial(int value) {
            int result = 1;
            if (value!=0) {
            }
            for (int i=1; i<=value; i++) {
                result*=i;
            }
            return result;
        }

        static double CombinationsNumber(int n, int k) {
            return (Factorial(n)/(Factorial(k)*Factorial(n-k)));
        }

        static int CountElementInArray(string [,] value, string element) {
            // Подсчет количества элементов в двумерном массиве
            int count = 0;
            for (int i = 0; i<value.GetLength(0); i++) {
                for (int j = 0; j < value.GetLength(1); j++) {
                    if (value[i,j] == element) {
                        count++;
                    }
                }
            }
            return count;
        }

        static int SignFunction(int value) {
            int result = 0;
            if (value != 0) {
                result = value / Math.Abs(value);
            }
            return result;
        }

        static void Main(string[] args)
        {   
            //Console.WriteLine(CombinationsNumber(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())));
            Console.WriteLine(Console.ReadLine().Length * Console.ReadLine().Length);
            // string targetValue = Console.ReadLine();
            // int arrayColumnCount = Convert.ToInt32(Console.ReadLine());
        }
            
    }
}