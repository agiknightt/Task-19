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
                        Console.Write("Введите номер досье : ");
                        string index = Console.ReadLine();

                        fullName = DeleteDossier(fullName, index);
                        position = DeleteDossier(position, index);
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

        private static string[] DeleteDossier(string[] array, string index)
        {
            if (array.Length > 0)
            {
                string[] tempFullName = new string[array.Length - 1];

                int indexDossier;

                indexDossier = SearchByIndex(array, index);

                if (indexDossier > -1)
                {
                    array = DeleteByIndex(array, tempFullName, indexDossier);
                }
            }
            else
            {
                Console.WriteLine("Массив пустой");
            }            
            return array;
        }

        private static string[] DeleteByIndex(string[] array, string[] tempArray, int indexDossier)
        {
            for (int i = 0; i < indexDossier; i++)
            {
                tempArray[i] = array[i];
            }
            for (int i = indexDossier; i < tempArray.Length; i++)
            {
                tempArray[i] = array[i + 1];
            }
            array = tempArray;
            return array;
        }

        static void AddFullNameAndPosition(ref string[] fullName, ref string[] position)
        {
            fullName = AddDossier(fullName, "Введите фио : ");
            position = AddDossier(position, "Введите должность : ");
            
            Console.WriteLine();
        }

        private static string[] AddDossier(string[] fullName, string text)
        {
            string[] tempArray = new string[fullName.Length + 1];

            for (int i = 0; i < fullName.Length; i++)
            {
                tempArray[i] = fullName[i];
            }
            Console.Write(text);
            tempArray[fullName.Length] = Console.ReadLine();
            fullName = tempArray;
            return fullName;
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

        static int SearchByIndex(string[] array,string index, int value = -1)
        {            
            bool IndexIsFind = false;            

            for (int i = 0; i < array.Length; i++)
            {
                if (Convert.ToInt32(index) == i)
                {
                    value = i;
                    IndexIsFind = true;
                    return value;
                }
            }
            if (IndexIsFind == false)
            {
                Console.WriteLine("Номер не найден");
            }
            return value;
        }
    }
}
