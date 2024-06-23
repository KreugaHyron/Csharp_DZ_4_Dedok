namespace Csharp_DZ_4_Dedok
{
    struct Client //для задания 5
    {
        public int ClientCode;
        public string FullName;
        public string Address;
        public string PhoneNumber;
        public int OrdersCount;
        public decimal TotalOrderAmount;
        public Client(int clientCode, string fullName, string address, string phoneNumber, int ordersCount, decimal totalOrderAmount)
        {
            ClientCode = clientCode;
            FullName = fullName;
            Address = address;
            PhoneNumber = phoneNumber;
            OrdersCount = ordersCount;
            TotalOrderAmount = totalOrderAmount;
        }
        public void Print()
        {
            Console.WriteLine($"Код клиента: {ClientCode}");
            Console.WriteLine($"ФИО: {FullName}");
            Console.WriteLine($"Адрес: {Address}");
            Console.WriteLine($"Телефон: {PhoneNumber}");
            Console.WriteLine($"Количество заказов: {OrdersCount}");
            Console.WriteLine($"Общая сумма заказов: {TotalOrderAmount:C}");
        }
    }
    //для задания 6
    struct Request
    {
        public int OrderCode;
        public string ClientName;
        public DateTime OrderDate;
        public string[] OrderedItems;
        public decimal OrderAmount;    
        public Request(int orderCode, string clientName, DateTime orderDate, string[] orderedItems, decimal orderAmount)
        {
            OrderCode = orderCode;
            ClientName = clientName;
            OrderDate = orderDate;
            OrderedItems = orderedItems;
            OrderAmount = orderAmount;
        }
        public void Print()
        {
            Console.WriteLine($"Код заказа: {OrderCode}");
            Console.WriteLine($"Клиент: {ClientName}");
            Console.WriteLine($"Дата заказа: {OrderDate:d}");
            Console.WriteLine("Перечень заказанных товаров:");
            foreach (var item in OrderedItems)
            {
                Console.WriteLine($"- {item}");
            }
            Console.WriteLine($"Сумма заказа: {OrderAmount:C}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task_1 - Создать двумерный массив целых чисел размером 5х4. Заполнить его случайными числами.
            //Найти максимальный и минимальный элемент в массиве. Найти максимальный и минимальный элемент для каждой строки массива.
            Random rand = new Random();
            int[,] array = new int[5, 4];
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    array[i, j] = rand.Next(1, 101);
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            int globalMax = int.MinValue;
            int globalMin = int.MaxValue;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (array[i, j] > globalMax)
                        globalMax = array[i, j];
                    if (array[i, j] < globalMin)
                        globalMin = array[i, j];
                }
            }
            Console.WriteLine($"\nМаксимальный элемент в массиве: {globalMax}");
            Console.WriteLine($"Минимальный элемент в массиве: {globalMin}");
            for (int i = 0; i < 5; i++)
            {
                int rowMax = int.MinValue;
                int rowMin = int.MaxValue;
                for (int j = 0; j < 4; j++)
                {
                    if (array[i, j] > rowMax)
                        rowMax = array[i, j];
                    if (array[i, j] < rowMin)
                        rowMin = array[i, j];
                }
                Console.WriteLine($"Строка {i + 1}: Максимум = {rowMax}, Минимум = {rowMin}");
            }
            //Task_2 - Напишите программу, которая принимает строку от пользователя и меняет регистр всех букв в этой строке на противоположный
            //(то есть большие буквы становятся маленькими, а маленькие буквы - большими).
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            string result = "";
            foreach (char c in input)
            {
                if (char.IsLower(c))
                    result += char.ToUpper(c);
                else if (char.IsUpper(c))
                    result += char.ToLower(c);
                else
                    result += c;
            }
            Console.WriteLine("Строка с измененным регистром:");
            Console.WriteLine(result);
            //Task_3 - Напишите программу, которая принимает строку, содержащую несколько слов, и разделяет ее на отдельные слова.
            Console.WriteLine("Введите строку с несколькими словами:");
            string input_1 = Console.ReadLine();
            string[] words = input_1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Разделенные слова:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            //Task_4 - Дан текст. Верно ли, что в нем есть пять идущих подряд одинаковых символов? Вывести соответствующее сообщение.
            string text = "abcdddeeeeffffggghhhhh";
            bool found = false;
            for (int i = 0; i <= text.Length - 5; i++)
            {
                if (text[i] == text[i + 1] &&
                    text[i] == text[i + 2] &&
                    text[i] == text[i + 3] &&
                    text[i] == text[i + 4])
                {
                    found = true;
                    Console.WriteLine($"В тексте найдены пять идущих подряд одинаковых символов: {text[i]}");
                    break; 
                }
            }
            if (!found)
            {
                Console.WriteLine("В тексте нет пяти идущих подряд одинаковых символов.");
            }
            //Task_5 - Описать структуру Client, содержащую поля: код клиента; ФИО; адрес; телефон;
            //количество заказов, осуществленных клиентом; общая сумма заказов клиента.
            //Включите в структуру конструктор с параметрами и метод Print(). Создать экземпляр структуры.
            Client client1 = new Client(12345, "Иванов Станислав Васильевич", "г. Луцк, ул. Колотушкина, д. 10", "+38 (098) 123-45-67", 3, 2500.75m);
            Console.WriteLine("Информация о клиенте:");
            client1.Print();
            //Task_6 - Описать структуру Request, содержащую поля: код заказа; клиент; дата заказа;
            //перечень заказанных товаров; сумма заказа. Включите в структуру конструктор с параметрами и метод Print(). Создать экземпляр структуры.
            int orderCode = 1001;
            string clientName = "Иванова Аделина";
            DateTime orderDate = DateTime.Now;
            string[] orderedItems = { "Ноутбук", "Мышка", "Клавиатура" };
            decimal orderAmount = 3500.25m;
            Request request1 = new Request(orderCode, clientName, orderDate, orderedItems, orderAmount);
            Console.WriteLine("Информация о заказе:");
            request1.Print();
        }
    }
}
