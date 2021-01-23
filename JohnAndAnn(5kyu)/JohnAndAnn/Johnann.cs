using System.Collections.Generic;
using System.Linq;

namespace JohnAndAnn
{
    public class Johnann
    {
        public static List<int> John(int days)
        {
            //Иициализируем коллекции согласно начальным условиям
            var johnKata = new List<int> { 0 };
            var annKata = new List<int> { 1 };

            //Рассчитываем количество ката для каждого дня
            //Расчет количества ката, решенных другим персонажем, вынесен в отдельный метод
            for (int n = 1; n < days; n++)
            {
                var item = n - KataOfAnotherPerson(johnKata[n - 1], annKata, johnKata);
                johnKata.Add(item);
            }

            return johnKata;
        }
        public static List<int> Ann(int days)
        {
            var annKata = new List<int> { 1 };
            var johnKata = new List<int> { 0 };
            for (int n = 1; n < days; n++)
            {
                var item = n - KataOfAnotherPerson(annKata[n - 1], johnKata, annKata);
                annKata.Add(item);
            }
            return annKata;
        }

        //Метод для расчета количества решенных ката другим персонажем.
        //kataOfFirstPerson - коллекция с данными о решенных ката по дням для того самого "другого персонажа"
        //kataOfSecondPerson - коллекция с данными о решенных ката по дням для персонажа, для которого ведется расчет в вызывающем методе
        //day - день, по которому необходимы данные для вызывающего метода
        private static int KataOfAnotherPerson(int day, IList<int> kataOfFirstPerson, IList<int> kataOfSecondPerson)
        {
            //Определяем, есть ли уже в коллекции данные о дне day. Если нет, то вычисляем количество ката для дня day и добавляем в коллекцию
            //Если данные уже есть, то пропускаем эту часть и просто возвращаем данные по дню day
            if (kataOfFirstPerson.Count <= day)
            {
                var item = day - kataOfSecondPerson[kataOfFirstPerson[day - 1]];
                kataOfFirstPerson.Add(item);
            }

            return kataOfFirstPerson[day];
        }

        //Вычисление суммарного количества ката, решенных персонажем за days дней
        public static int SumJohn(int days)
        {
            return John(days).Sum();
        }
        public static int SumAnn(int days)
        {
            return Ann(days).Sum();
        }
    }
}
