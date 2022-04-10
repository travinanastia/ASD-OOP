using System;

namespace Lab1_ASD
{
    class Program
    {
        
        static void LinearForArray(int[] MainArray)
        {
            Console.WriteLine("Пошук елемента у масиві методом перебору (лінійного пошуку)");
            int key;
            int i = 0;
            Console.WriteLine("Введіть елемент для пошуку");
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введіть елемент для пошуку");
            }
            bool Found = false;
            DateTime Start = DateTime.Now;
            while (i < MainArray.Length && !Found)
            {
                if (MainArray[i] == key)
                {
                    Found = true;
                }
                i++;
            }
            if (Found)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс = {i - 1}");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }

            else
            {
                Console.WriteLine("Елемент не знайдено");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
        }

        static void LinearForList(LinkedList head)
        {
            
            Console.WriteLine("Пошук елемента у зв'язному списку методом перебору (лінійного пошуку)");
            Console.WriteLine("Введіть елемент для пошуку");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введіть елемент для пошуку");
            }
            bool Found = false;
            DateTime Start = DateTime.Now;
            int i = 0;
            while (head != null && !Found)
            {
                if (head.Data == key)
                {
                    Found = true;
                }
                i++;
                head = head.Next;
            }
            if (Found)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс = {i - 1}");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
        }

        static void BarrierForArray(int[] MainArray, int Length)
        {
            int key;
            Console.WriteLine("Пошук елемента у масиві методом лінійного пошуку з бар'єром");
            Console.WriteLine("Введіть елемент для пошуку");
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введіть елемент для пошуку");
            }
            Array.Resize(ref MainArray, Length + 1);
            MainArray[Length] = key;
            DateTime Start = DateTime.Now;
            int i = 0;
            while (MainArray[i] != key) i++;

            if (i == Length)
            {
                Console.WriteLine("Елемент не знайдено");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
            else
            {
                Console.WriteLine($"Елемент знайдено. Його індекс = {i}");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }

        }

        static void BarrierForList(LinkedList head)
        {
            
            Console.WriteLine("Пошук елемента у зв'язному списку методом лінійного пошуку з бар'єром");
            Console.WriteLine("Введіть елемент для пошуку");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введіть елемент для пошуку");
            }
            LinkedList newNode = new LinkedList(key, null);
            LinkedList temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            temp = head;
            DateTime Start = DateTime.Now;
            int i = 0;
            while (temp.Data != key)
            {
                temp = temp.Next;
                i++;
            }
            if (temp.Next == null)
            {
                Console.WriteLine("Елемент не знайдено");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
            else
            {
                Console.WriteLine($"Елемент знайдено. Його індекс = {i}");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
            while (head.Next.Next != null)
            {
                head = head.Next;
            }
            head.Next = null;
        }

        static void BinaryForArray(int[] MainArray)
        {
            Console.WriteLine("Пошук елемента методом бінарного пошуку");
            Console.WriteLine($"Відсортуємо масив:");
            quicksort(MainArray, 0, MainArray.Length - 1);
            for (int i = 0; i < MainArray.Length; i++)
            {
                Console.Write(MainArray[i] + " ");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Введіть елемент для пошуку");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введіть елемент для пошуку");
            }
            int Left = 0, Right = MainArray.Length - 1;
            int Mid = 0;
            DateTime Start = DateTime.Now;
            while (Left < Right)
            {
                Mid = (Left + Right) / 2;
                if (key > MainArray[Mid])
                {
                    Left = Mid + 1;
                }
                else
                {
                    Right = Mid;
                }
            }
            if (MainArray[Right] == key)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс = {Right}");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
        }
        static void BinaryGoldenRationForArray(int[] MainArray)
        {
            Console.WriteLine("Пошук елемента методом бінарного пошуку згідно з правилом золотого перерізу");
            Console.WriteLine($"Відсортуємо масив:");
            quicksort(MainArray, 0, MainArray.Length - 1);
            for (int i = 0; i < MainArray.Length; i++)
            {
                Console.Write(MainArray[i] + " ");
            }
            double goldenration = (Math.Sqrt(5) + 1) / 2;
            Console.WriteLine("Введіть елемент для пошуку");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введіть елемент для пошуку");
            }
            int Left = 0, Right = MainArray.Length - 1;
            int Mid = 0;
            bool Found = false;
            DateTime Start = DateTime.Now;
            while (Left <= Right && !Found)
            {
                Mid = (int)((Left + goldenration * Right) / (1 + goldenration));
                if (key == MainArray[Mid])
                {
                    Found = true;
                }
                else if (key > MainArray[Mid])
                {
                    Left = Mid + 1;
                }
                else
                {
                    Right = Mid - 1;
                }
            }
            if (Found)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс = {Mid}");
                Console.WriteLine($"Час виконання = {DateTime.Now - Start}");
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
                Console.WriteLine($"Час виконання = {Start - DateTime.Now}");
            }
        }

        static void BinaryForList( int[] MainArray)
        {
            int first = 0;
            int last = MainArray.Length - 1;
            quicksort(MainArray, first, last);
            LinkedList head = LinkedList.GetList(MainArray);
            Console.WriteLine("Бiнарний пошук в лiнiйно-зв'язному списку");          
            Console.WriteLine("Введіть елемент для пошуку");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введіть елемент для пошуку");
            }
            int Left = 0;
            int Right = LinkedList.GetLength(head);
            int Mid;
            LinkedList nodeLeft = head, nodeRight = null, nodeMid;
            DateTime Start = DateTime.Now;
            while (nodeRight == null || nodeLeft.Data != nodeRight.Data)
            {
                 Mid = (Left + Right) / 2;
                nodeMid = LinkedList.GetElement(nodeLeft, Mid - Left);
                if (key > nodeMid.Data)
                {
                    Left = Mid+ 1;
                    nodeLeft = nodeMid.Next;
                }
                else
                {
                    Right = Mid;
                    nodeRight = nodeMid;
                }
            }
            if (key == nodeRight.Data)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс = {Right}");
                Console.WriteLine($"Час роботи алгоритму = {Start - DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
                Console.WriteLine($"Час роботи алгоритму = {Start - DateTime.Now}");
            }
        }
        static void BinaryGoldenRationForList(int[] MainArray)
        {
            int first = 0;
            int last = MainArray.Length - 1;
            quicksort(MainArray, first, last);
            double goldenration = (Math.Sqrt(5) + 1) / 2;
            LinkedList head = LinkedList.GetList(MainArray);
            Console.WriteLine("Пошук елемента методом бінарного пошуку згідно з правилом золотого перерізу");
            Console.WriteLine("Введіть елемент для пошуку");
            int key;
            while (!Int32.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введіть елемент для пошуку");
            }
            int Left = 0;
            int Right = LinkedList.GetLength(head);          
            LinkedList nodeLeft = head, nodeRight = null, nodeMid;
            DateTime Start = DateTime.Now;
            while (nodeRight == null || nodeLeft.Data != nodeRight.Data)
            {
                int Mid = (int)((Left + goldenration * Right) / (1 + goldenration));
                nodeMid = LinkedList.GetElement(nodeLeft, Mid - Left);
                if (key > nodeMid.Data)
                {
                    Left = Mid + 1;
                    nodeLeft = nodeMid.Next;
                }
                else
                {
                    Right = Mid;
                    nodeRight = nodeMid;
                }
            }
            if (key == nodeRight.Data)
            {
                Console.WriteLine($"Елемент знайдено. Його індекс = {Right}");
                Console.WriteLine($"Час роботи алгоритму = {Start - DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Елемент не знайдено.");
                Console.WriteLine($"Час роботи алгоритму = {Start - DateTime.Now}");
            }
        }
        static int[] generate()
        {
            Console.WriteLine("Введіть кількість елементів масиву");
            int size;
            while (!Int32.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Введіть кількість елементів масиву");
            }

            Console.WriteLine("Згенерований масив:");
            int[] MainArray = new int[size];
            Random aRand = new Random();
            for (int i = 0; i < MainArray.Length; i++)
            {
                MainArray[i] = aRand.Next(-50, 50);
                Console.Write(MainArray[i] + " ");
            }
            Console.WriteLine(" ");
            return MainArray;
        }

        static int[] create()
        {
            Console.WriteLine("Введіть кількість елементів масиву");
            int size;
            while (!Int32.TryParse(Console.ReadLine(), out size) || size <= 0)
            {
                Console.WriteLine("Введіть кількість елементів масиву");
            }
            int[] MainArray = new int[size];
            Console.WriteLine("Введіть елементи масиву");
            for (int i = 0; i < MainArray.Length; i++)
            {
                MainArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Введений масив:");
            for (int i = 0; i < MainArray.Length; i++)
            {
                Console.Write(MainArray[i] + " ");
            }
            Console.WriteLine(" ");
            return MainArray;
        }

        static void quicksort(int[] mas, int first, int last)
        {
            int mid, temp;
            int f = first, l = last;
            int el = (f + l) / 2;
            mid = mas[el];
            do
            {
                while (mas[f] < mid)
                    f++;
                while (mas[l] > mid)
                    l--;
                if (f <= l)
                {
                    temp = mas[f];
                    mas[f] = mas[l];
                    mas[l] = temp;
                    f++;
                    l--;
                }
            } while (f < l);
            if (first < l) quicksort(mas, first, l);
            if (f < last) quicksort(mas, f, last);
        }

        static void output(LinkedList head)
        {
            while (head != null)
            {
                Console.Write(head.Data + " ");
                head = head.Next;
            }
        }
        static void next()
        {
            Console.WriteLine("\n" + "----------------------------------------");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Лабораторна робота №1. Травiна Анастасiя iПЗ-11");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Випадкова генерація нового масиву");
            Console.WriteLine("2. Пошук перебором");
            Console.WriteLine("3. Пошук з бар'єром ");
            Console.WriteLine("4. Бінарний пошук");
            Console.WriteLine("5. Бінарний пошук згідно з правилом золотого перерізу");
            bool end = true;
            int[] MainArray = create();
            LinkedList head = LinkedList.GetList(MainArray);
            Console.WriteLine("Отриманий список:");
            output(head);
            Console.WriteLine();
            Console.WriteLine();
            int menu;
            while (end)
            {
                Console.WriteLine("Виберіть завдання 1 - 5 для виконання, iншу цифру для завершення: ");
                while (!Int32.TryParse(Console.ReadLine(), out menu))
                {
                    Console.WriteLine("Виберіть завдання 1 - 5 для виконання, iншу цифру для завершення: ");
                }

                switch (menu)
                {
                    case 1:
                        MainArray = generate();
                        next();
                        break;
                    case 2:
                        LinearForArray(MainArray);
                        next();
                        LinearForList(head);
                        break;
                    case 3:
                        BarrierForArray(MainArray, MainArray.Length);
                        next();
                        BarrierForList(head);
                        break;
                    case 4:
                        BinaryForArray(MainArray);
                        next();                      
                        BinaryForList(MainArray);
                        break;
                    case 5:
                        BinaryGoldenRationForArray(MainArray);
                        next();
                        BinaryGoldenRationForList(MainArray);
                        break;
                    default:
                        end = false;
                        break;
                }
            }

        }
    }
}


