// See https://aka.ms/new-console-template for more information
using eda;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;






try
{

    //Pass the file path and file name to the StreamReader constructor
    Client client = new Client();
    menus newmenu = new menus();
    
    newmenu.WorkWithFile(eda.CONSTANTS.PATH);
    client.CheckType();
    client.SMoney();

    newmenu.GetAndShow(client.type);
    int answer = Int32.Parse(Console.ReadLine());
    int sum = 0;

    menus client_menu = new menus();
    while (answer != newmenu.GCount() + 1)
    {
        sum += newmenu.menu[answer - 1].GCost();
        client_menu.menu.Add(newmenu.menu[answer - 1]);

        answer = Int32.Parse(Console.ReadLine());
    }
    Console.WriteLine(sum);
    double sum1 = client_menu.Check_Sale(client.type);
    Console.WriteLine(sum1);
    client.CheckMoney(sum1);
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Executing finally block.");
}




