using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eda
{
    internal class Menus
    {
        public string name = "Undefined";
        public int cost = 0;
        public string type = "Undefined";
        public void Print()
        {
            Console.WriteLine($"Название: {name}  Цена: {cost}  Тип {type}");
        }
        public Menus Edit(string[] a)
        {
            Menus m = new Menus();
            if (a.Length == 3)
            {

                m.name = a[0];
                m.cost = Int32.Parse(a[1]);
                m.type = a[2];
            }
            else Console.WriteLine("Некорректные данные ");
            return m;
        }
        public string GType()
        {
            return type;
        }
        public string GName()
        {
            return name;
        }
        public int GCost()
        {
            return cost;
        }


    }

    internal class menus : Menus
    {
        public List<Menus> menu = new List<Menus>();


        void WorkInFile(StreamReader sr)
        {
            String? line;
           
            line = sr.ReadLine();

            while (line != null)
            {
 
                string[] words = line.Split(' ');
                this.menu.Add(Edit(words));

                Console.WriteLine(line);
                
                line = sr.ReadLine();
                
            }
            
        }

        public void WorkWithFile(string PATH)
        {
            StreamReader sr = new StreamReader(PATH);
            List<Menus> newmenu = new List<Menus>();
            WorkInFile(sr);
            
            //close the file
            sr.Close();
            
        }

        public void ShowMenu(List<Menus> menu)
        {

            Console.WriteLine("Что будете заказывать? ");
            int k = 0;
            for (int i = 0; i < menu.Count(); i++){ 
                Console.Write($"{i + 1} - {menu[i].GName()}, ");
            };
            Console.WriteLine($"{menu.Count() + 1} - Завершить заказ");
        }

        public void GetAndShow(string type)
        {
            if (type == "Б") {
                this.ChangeBMenu();
            }
            ShowMenu(menu);
           
        }

        int min(int a, int b)
        {
            return a < b ? a : b;
        }



        void ChangeBMenu()
        {
            List<Menus> Bmenu = new List<Menus>();
            string type = "Б";
            for (int i = 0; i < this.menu.Count(); i++) { 
                if (this.menu[i].type == type)
                {
                    Bmenu.Add(this.menu[i]);
                }
            }
            this .menu = Bmenu;
        }

        public int GCount() { 
            return this.menu.Count();
        }

        double NewCost(int cost, int count)
        {
            return cost * count;
        }
        public double Check_Sale(String type)
        {
            double sum = 0;
            double sum1 = 0;

            foreach (Menus val in this.menu.Distinct())
            {
                int count = this.menu.Where(x => x == val).Count();
                Console.WriteLine(val.GName() + " - " + count + " раз");
                if (type == "А")
                {
                    sum1 += 2 * NewCost(val.GCost(), count);

                }
                else if (count >= 3)
                {
                    sum1 += 0.8 * NewCost(val.GCost(), count);
                    sum += NewCost(val.GCost(), count);
                }
                else if (count == 2)
                {
                    sum1 += 0.9 * NewCost(val.GCost(), count);
                    sum += NewCost(val.GCost(), count);
                }
                else
                {
                    sum1 += NewCost(val.GCost(), count);
                    sum += NewCost(val.GCost(), count);
                }

            }
            if ((type != "A") && (sum > 1000))
            {
                sum1 = 0.7 * sum;
            }

            return sum1;
        }

    }

}
