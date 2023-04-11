using ConsoleApp71;
using System.Net;

const  string  host   = "https://localhost:5001";
Console.WriteLine("я программа для теста фпи");
Console.WriteLine("введите ваше имя");
var name = Console.ReadLine();

Console.WriteLine("Введите логин");
var l = Console.ReadLine();
Console.WriteLine("Введите пороль");
var p = Console.ReadLine();

try
{
    ApiService apiService = new ApiService();   
    var res = apiService.HelloApi(host, name);
    Console.WriteLine(res);

    if (apiService.Aut(host, l, p))
        Console.WriteLine("Вы авторизированы");
    else 
        Console.WriteLine("Ошибка авторизации");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);  
}


 
