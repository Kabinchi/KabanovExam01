using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PlaneAppExam
{
    public class PlaneControl
    {
        private List<Plane> planes = new List<Plane>();

        public void Add(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Clear();
                Console.WriteLine($"Добавление {i + 1}-го самолета:");

                string model = "";
                double range = 0;
                double speed = 0;
                bool flag = true;

                while (flag)
                {
                    Console.Write("Введите модель самолета: ");
                    model = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(model))
                    {
                        Console.WriteLine("Модель не может быть пустой. Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                        flag = false;
                }

                flag = true;
                while (flag)
                {
                    Console.Write("Введите максимальную дальность полета (км): ");
                    if (!(double.TryParse(Console.ReadLine(), out range) && range > 0))
                    {
                        Console.WriteLine("Введите положительное число. Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                        flag = false;
                }

                flag = true;
                while (flag)
                {
                    Console.Write("Введите крейсерскую скорость (км/ч): ");
                    if (!(double.TryParse(Console.ReadLine(), out speed) && speed > 0))
                    {
                        Console.WriteLine("Введите положительное число. Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                        flag = false;
                }

                Plane plane = new Plane(model, range, speed);
                planes.Add(plane);
            }

            Console.Clear();
            Console.WriteLine($"Успешно добавлено самолетов: {planes.Count}");
        }

        public void Sort()
        {
            planes.Sort((x, y) =>
                (y.MaxRange * y.CruiseSpeed).CompareTo(x.MaxRange * x.CruiseSpeed)
            );

            foreach (Plane plane in planes)
            {
                Console.WriteLine($"Модель: {plane.Model}, Дальность: {plane.MaxRange} км, Скорость: {plane.CruiseSpeed} км/ч");
            }
        }

        public bool SaveToFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var plane in planes)
                    {
                        writer.WriteLine($"Модель: {plane.Model}");
                        writer.WriteLine($"Дальность: {plane.MaxRange} км");
                        writer.WriteLine($"Скорость: {plane.CruiseSpeed} км/ч");
                        writer.WriteLine(new string('-', 20)); 
                    }
                }

                return File.Exists(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении в файл: {ex.Message}");
                return false;
            }
        }
    }
}
