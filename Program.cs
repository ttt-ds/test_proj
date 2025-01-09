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

        static int GetBullCount(int trueNumber, int askNumber) {
            // Возвращает количество "быков" (Игра "Быки и коровы")
            int bullCount = 0;
            string trueNumberString = Convert.ToString(trueNumber);
            string askNumberString = Convert.ToString(askNumber);

            for (int i = 0; i <= trueNumberString.Length; i++) {
                if (trueNumberString[i] == askNumberString[i]) {
                    bullCount++;
                }
            }
            return bullCount;
        }

        static int GetCowCount(int trueNumber, int askNumber) {
            // Возвращает количество "коров" (Игра "Быки и коровы")
            int cowCount = 0;
            string trueNumberString = Convert.ToString(trueNumber);
            string askNumberString = Convert.ToString(askNumber);

            for (int i = 0; i <= trueNumberString.Length; i++) {
                for (int j = 0; j <= trueNumberString.Length; j++) {
                    if (i != j) {
                        if (trueNumberString[i] == askNumberString[j]) {
                            cowCount++;
                        }
                    }
                }
            }
            return cowCount;
        }

        static void BullCowGame(int trueNumber, int askNumber) {
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

        static void Main(string[] args)
        {   
            // int cycleMin = Convert.ToInt32(Console.ReadLine());
            // int magicNumber = 7;
            // string inputString = Console.ReadLine();
            string inputString = Console.ReadLine();
            int num = Convert.ToInt32(Console.ReadLine());
            
            
            Console.WriteLine(CezarCypher(inputString, num));
            
        }
            
    }
}