using BancoExemplo2.Data;

foreach( var s in new BikestoreContext().Staffs)
{
    Console.WriteLine(s.FirstName);
}