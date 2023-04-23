using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eda
{
    internal class Client
    {
        public double money = 0;
        public string type = "Б";

        public void CheckType()
        {
            Console.WriteLine("Выбирете класс: 1 - Богач, 2 - Бедняк");
            string? typet = Console.ReadLine();
            
            if (typet == "1")
            {
                type = "А";
            }
            else if (typet == "2")
            {
                type = "Б";
            }
            else throw new ArgumentOutOfRangeException(nameof(typet), "Check your answer pls and try again!");
            
        }

        public double CheckMoney(double sum)
        {
            double newsum = sum;
            if (sum > this.money)
            {
                double tsum = sum - this.money, tsum1 = tsum;
                if (this.type == "А") {
                    if (tsum < sum * 0.2)
                    {
                        Console.WriteLine($"У вас есть {this.money} рублей, стоимость заказа: {sum} рублей \nПожалуйста донесите {tsum} рублей в следующий раз. \nХорошего дня!!!");
                    }
                    else { Console.WriteLine($"У вас есть {this.money} рублей, стоимость заказа: {sum} рублей \nПожалуйста попробуйте сделать другой заказ.");
                        newsum = 0;
                    }
                }
                else
                {
                    Console.WriteLine($"У вас есть {this.money} рублей, стоимость заказа: {sum} рублей \nВы можете отработать оставшиеся {tsum} рублей на кухне по часовая оплата" +
                        $" 100 рублей + (количество проработанных часов, но не больше 20) \n или попробуйте изменить состав заказа \n 1 - Отработать, 2 - Изменить заказ");
                    string? typet = Console.ReadLine();

                    if (typet == "1")
                    {
                        int hours = 0;
                        int i = 0;
                        while (tsum > 0) {
                            tsum -= 100 + i;
                            if (i < 20) i++;
                            hours++;
                        }
                        Console.WriteLine($"Вам надо отработать {tsum1} рублей, что составляет {hours} часов. \nВсё необходимое выдадут на кухне. \nХорошего дня!!!");
                    }
                    else if (typet == "2")
                    {
                        sum = 0;
                    }
                    else throw new ArgumentOutOfRangeException(nameof(typet), "Check your answer pls and try again!");
                }
            }
            return newsum;
        }
        public void SMoney() {
            Console.WriteLine("В какую сумму собираетесь уложиться: ");
            money = Int32.Parse(Console.ReadLine());
        }
        public string GType()
        {
            return type;
        }

        public double GMoney()
        {
            return money;
        }
    } 

}
