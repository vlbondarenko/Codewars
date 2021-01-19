using System;
using System.Collections.Generic;

namespace ASCIIEncodingAndDecoding
{
    public static class StringExtention
    {
        //Расширяющий метод, кодирующий строку
        public static string ToASCII85(this string sourceLine)
        {
            byte[][] bytesGroups = ConvertStringToBytesGroups(sourceLine, true, out int numberofExtraChars);
            sourceLine = "";

            for (int i = 0; i < bytesGroups.GetLength(0); i++)
            {
                //Преобразуем каждую группу в десятичное число, которое, в свою очередь, преобразуется
                //в массив 85-ричных чисел. Если полученное число равно 0, то байтовая группа пуста, к результирующей строке добавляется один символ 'z'.  
                var groupAsNumber = ConvertArrayToDecimal(bytesGroups[i], 2);
                if (groupAsNumber != 0)
                {
                    //К каждому числу в массиве прибавляется 33, число преобразуется в символ и прибавляется к результирующей строке
                    byte[] numberAsArrOf85Numbers = ConvertTo85NumberSystem(groupAsNumber);
                    foreach (var num in numberAsArrOf85Numbers)
                    {
                        var ch = num + 33;
                        sourceLine += (char)ch;
                    }
                }
                else
                {
                    sourceLine += (char)122;
                    break;
                }
            }
            sourceLine = "<~" + sourceLine;

            //Удаляются лишние символы, добавленные при формировании байтовых групп
            sourceLine = sourceLine.Remove(sourceLine.Length - numberofExtraChars, numberofExtraChars);
            return sourceLine + "~>";
        }

        //Расширяющий метод, декодирующий строку
        public static string FromASCII85(this string sourceLine)
        {
            //Удаляются спецсимволы "<~ ~>" из начала и конца строки
            sourceLine = sourceLine.Substring(2, sourceLine.Length - 4);
            byte[][] bytesGroups = ConvertStringToBytesGroups(sourceLine, false, out int numberofExtraChars);
            sourceLine = "";

            //Процесс декодирования аналогичен процессу кодирования, только в обртном порядке
            for (int i = 0; i < bytesGroups.GetLength(0); i++)
            {
                for(int j=0;j<5;j++)
                {
                    bytesGroups[i][j]-=(byte)33;
                }
                uint groupAsNumber = ConvertArrayToDecimal(bytesGroups[i], 85);

                //Здесь каждый байт десятичного числа преобразуется в символ и прибавляется к результирующей строке
                for (int k = sizeof(uint); k >0 ; k--)
                {
                    byte b = (byte)(groupAsNumber>>((k-1)*8));
                    
                        sourceLine+=(char) b;
                    
                }
            }

            //Удаляются лишние символы
            sourceLine = sourceLine.Remove(sourceLine.Length - numberofExtraChars, numberofExtraChars);
            return sourceLine;
        }



        /// <summary>
        /// Преобразует строку произвольной длины в массив байтовых групп
        /// </summary>
        /// <param name="sourceLine">Строка, подлежащая преобразованию</param>
        /// <param name="firstIndex">Размерность нулевого измерения ступенчатого массива (фактически параметр указывает на количество байтовых групп) </param>
        /// <param name="coding">Указывает на тип операции - кодирование или декодирование. Влияет наразмерность байтовой группы</param>
        /// <param name="numberofExtraChars">Данный параметр передает вызывающему методу информацию о количестве лишних символов, добавленных при дозаполнении группы при нехватке символов</param>
        private static byte[][] ConvertStringToBytesGroups(string sourceLine, bool coding,out int numberofExtraChars)
        {
            numberofExtraChars = 0;
            byte[][] bytesGroups;
            byte secondIndex;

            //Определяем размерность байтовой группы
            if (coding)
                secondIndex = 4;
            else
                secondIndex = 5;

            //Определяем количество байтовых групп. Оно зависит от типа операции - кодирование или декодирование
            var firstIndex = sourceLine.Length % secondIndex == 0 ? (sourceLine.Length / secondIndex) : (int)(sourceLine.Length / secondIndex + 1);
            
            //Если передана пустая строка - создаем один массив (группу байтов)
            //В противном случае создаем ступенчатый массив с соответствующим количеством байтовых групп
            if (firstIndex == 0)
            {
                bytesGroups = new byte[1][];
            }
            else
            {
                bytesGroups = new byte[firstIndex][];
            }
            
            //Инициализируем ступенчатый массив группами с заданной размерностью
            for (int k = 0; k < bytesGroups.Length; k++)
                bytesGroups[k] = new byte[secondIndex];

            for (int i = 0; i < bytesGroups.Length; i++)
            {
                //Присваиваем элементам байтовой группы значения, соответствующие значениям символов, приведенным к типу byte
                for (int j = 0; j < bytesGroups[i].Length; j++)
                {
                    var index = i * secondIndex + j;

                    if (index < sourceLine.Length)
                    {
                        bytesGroups[i][j] = (byte)sourceLine[index];
                    }
                    //Если символов непустой строки не хватает для заполнения группы, то дозаполняем ее нулями (при кодировании в ASCII85) 
                    //или байтовыми значениями символа 'u' (при декодировании текста из ASCII85). 
                    //Количество лишних символов запоминаем и передаем вызывающему методу через out-параметр
                    else if (index>=sourceLine.Length&&sourceLine.Length>0)
                    {
                        if(coding)
                            bytesGroups[i][j] = 0;
                        else
                            bytesGroups[i][j] = (byte)'u';
                        numberofExtraChars++;
                    }
                    //Если строка полностью пустая, то заполняем группу нулями
                    else
                    {
                        bytesGroups[i][j] = 0;
                    }
                }
            }
            return bytesGroups;
        }




        /// <summary>
        /// Преобразует массив значений (при кодировании набор состоит из десятиччных чисел, при декодировании - из чисел в 85-ричной сичтеме исчисления) в десятичное 4-х байтовое число
        /// </summary>
        /// <param name="byteArray">Массив, подлежащий преобразованию</param>
        /// <param name="numberSystemOfValues">Основание системы исчесления, в которой представлены числа в массиве</param>
        private static uint ConvertArrayToDecimal(byte[] byteArray, int numberSystemOfValues)
        {
            uint resultNumber = 0;

            //Формально массив десятичных чисел представляет собой единый набор битов - двоичное число.
            //Поэтому можно миновать шаг с преобразованием всех десятичных чисел в единое двоичное число и последующий перевод полученного двоичного числа в единое десятичное.
            //Вместо этих преобразований, просто передаем исходный массив десятичных чисел, а параметру numberSystemOfValues присваиваем значение, равное 2 и получаем единое десятичное число другим способом.
            if (numberSystemOfValues == 2)
            {
                resultNumber= ConvertArrayToDecimal(byteArray);
            }
            else
            {
                for (int k = 0; k < byteArray.Length; k++)
                {
                    resultNumber += byteArray[k] * (uint)Math.Pow(numberSystemOfValues, (byteArray.Length - k - 1));
                }
            }
            return resultNumber;

        }

        private static uint ConvertArrayToDecimal(byte[] byteArray)
        {
            //Объявляем 4-х байтовую переменную без знака и устанавливаем биты в 0
            uint resultNumber = 0;

            //Элементы массива мы используем как битовые маски, устанавливаем биты объявленной переменной и возвращаем ее вызывающему методу
            for (int i = 0; i < sizeof(uint); i++)
            {
                resultNumber = resultNumber | byteArray[i];
                if (i < sizeof(uint)-1)
                    resultNumber <<= 8;
            }
            return resultNumber;

        }



        /// <summary>
        /// Преобразует десятичное число в массив из 4-х 85-ричных чисел
        /// </summary>
        /// <param name="sourceNumber]">Число, подлежащее преобразованию</param>
        private static byte[] ConvertTo85NumberSystem(uint sourceNumber)
        {
            var resultList = new List<byte>(4);
            while ((sourceNumber / 85) >= 1)
            {
                resultList.Add((byte)(sourceNumber % 85));
                sourceNumber = sourceNumber / 85;
            }
            //Добавляем последний элемент в массив
            resultList.Add((byte)(sourceNumber % 85));

            //Заполняем оставшиеся ячейки, если таковые остались, нулями
            if (resultList.Count < 4)
                while (resultList.Count <= 4)
                    resultList.Add(0);

            resultList.Reverse();
            return resultList.ToArray();
        }


    }
}
