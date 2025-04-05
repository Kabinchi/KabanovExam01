using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneAppExam
{
    class Program
    {
        static void Main(string[] args)
        {
            PlaneControl planeControl = new PlaneControl();
            int count = 0;
            bool flag = true;

            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Введите количество самолетов, которые хотите добавить: ");
                if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                {
                    Console.WriteLine("Введите целое положительное число!");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    flag = false;
                }
            }

            planeControl.Add(count);

            Console.WriteLine("Отсортированный список самолетов:");
            planeControl.Sort();

            string fileName = "planes.txt";
            if (planeControl.SaveToFile(fileName))
                Console.WriteLine($"Список самолетов успешно сохранен в файле {fileName} (искать в bin/debug)");
            else
                Console.WriteLine("Не удалось сохранить данные в файл.");
        }
    }
}
