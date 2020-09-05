using System;


namespace Task_19
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fullName = { "Федоров Валерий Иванович", "Иванов Антон Иванович", "Сидиров Григорий Андреевич","Кузнецов Виктор Степанович", "Петров Иван Иванович"};
            string[] position = { "Слесарь", "Кассир", "Монтажник", "Парикмахер", "Ученый"};

            bool enterOrExit = true;

            while (enterOrExit)
            {
                Console.WriteLine("Выберите нужный пункт меню");
                Console.Write("\n1 - добавить досье\n\n2 - вывести все досье\n\n3 - удалить досье\n\n4 - поиск по фамилии\n\n5 - выход.\n\n");
                
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        //добавить
                        AddFullNameAndPosition(ref fullName, ref position);
                        break;
                    case 2:
                        //вывести все досье
                        OutputFullNameAndPosition(fullName, position);
                        break;
                    case 3:
                        //удалить
                        fullName = DeleteDossier(fullName, position);
                        break;
                    case 4:
                        //поиск
                        SearchSurname(fullName, position);
                        break;
                    case 5:
                        //выход
                        enterOrExit = false;
                        break;
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }            
        }

        private static string[] DeleteDossier(string[] fullName, string[] position)
        {
            string[] tempFullName = new string[fullName.Length - 1];
            string[] tempPosition = new string[position.Length - 1];

            int indexDossier;

            indexDossier = SearchSurname(fullName, position);

            if (indexDossier > -1)
            {
                fullName = DeleteByIndex(fullName, tempFullName, indexDossier);
                fullName = DeleteByIndex(position, tempPosition, indexDossier);
            }

            return fullName;
        }

        private static string[] DeleteByIndex(string[] fullName, string[] tempFullName, int indexDossier)
        {
            for (int i = 0; i < indexDossier; i++)
            {
                tempFullName[i] = fullName[i];
            }
            for (int i = indexDossier; i < tempFullName.Length; i++)
            {
                tempFullName[i] = fullName[i + 1];
            }
            fullName = tempFullName;
            return fullName;
        }

        static void AddFullNameAndPosition(ref string[] fullName, ref string[] position)
        {
            string[] tempFullName = new string[fullName.Length + 1];
            string[] tempPosition = new string[position.Length + 1];

            for (int i = 0; i < fullName.Length; i++)
            {
                tempFullName[i] = fullName[i];
            }
            for (int i = 0; i < position.Length; i++)
            {
                tempPosition[i] = position[i];
            }
            Console.Write("Введите фио : ");
            tempFullName[fullName.Length +1] = Console.ReadLine();
            fullName = tempFullName;

            Console.Write("Введите должность : ");
            tempPosition[position.Length +1] = Console.ReadLine();
            position = tempPosition;

            Console.WriteLine();
        }

        static void OutputFullNameAndPosition(string[] fullName, string[] position)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                for (int j = 0; j < position.Length; j++)
                {
                    if (i == j)
                    {
                        Console.Write($"{i} {fullName[i]} - {position[j]} ");
                    }
                }
            }
            Console.WriteLine();
        }

        static int SearchSurname(string[] fullName, string[] position, int value = -1)
        {
            string surname;
            bool surnameIsFind = false;
            Console.Write("Введите фамилию : ");
            surname = Console.ReadLine();

            for (int i = 0; i < fullName.Length; i++)
            {
                if (fullName[i].Contains(surname))
                {
                    Console.WriteLine($"{i} {fullName[i]} {position[i]}.");
                    value = i;
                    surnameIsFind = true;
                    return value;
                }                
            }
            if (surnameIsFind == false)
            {
                Console.WriteLine("Фамилия не найдена");
                
            }
            return value;
        }
    }
}
