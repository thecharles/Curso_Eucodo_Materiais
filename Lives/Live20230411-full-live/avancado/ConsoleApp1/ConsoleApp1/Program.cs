


using ConsoleApp1.Data;
using ConsoleApp1.Models;
using System.ComponentModel.Design;

var contexto = new BikestoreContext();

Console.WriteLine("Digite o nome da brand para inserir");
string brandNova = Console.ReadLine();

Console.WriteLine("Antes inserção");
Console.WriteLine(string.Join(", ", contexto.Brands.Select(t => t.BrandName).ToArray()));

if(contexto.Brands.Where(t=>t.BrandName.ToLower() == brandNova.ToLower()).Count() == 0)
{
    Brand novaBrand = new Brand();
    novaBrand.BrandName = brandNova;
    contexto.Brands.Add(novaBrand);
    contexto.SaveChanges();
}

Console.WriteLine("Após inserção");
Console.WriteLine(string.Join(", ", contexto.Brands.Select(t => t.BrandName).ToArray()));



//while(true)
//{
//    Console.WriteLine("Email do staff");
//    string emailStaff = Console.ReadLine();

//    Console.WriteLine("Senha do staff");
//    string passwordStaff = Console.ReadLine();

//    var staffEncontrado = contexto.Staffs.Where(a => a.Email == emailStaff && a.Password == passwordStaff).FirstOrDefault();

//    if (staffEncontrado != null)
//    {
//        Console.WriteLine("Login feito! " + staffEncontrado.FirstName);
//    }
//    else
//    {
//        Console.WriteLine("Email ou senha inválidos");
//        Console.ReadKey();
//    }
//}

