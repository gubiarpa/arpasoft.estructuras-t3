using garredondo.evaluacion_t3.console.Entities;
using garredondo.evaluacion_t3.console.Utils;
using garredondo.evaluacion_t3.infrastructure.Services;

var networkingService = new NetworkService<Person>();

#region Helpers
int GetIDFromUser(string askingText)
{
    var isValidID = false;
    var id = 0;

    while (!isValidID)
    {
        Console.Write($"{askingText}: ");
        var idString = Console.ReadLine();
        if (
            (idString == null) ||
            (!int.TryParse(idString, out id))
            )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ID inválido!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
            isValidID = true;
    }

    return id;
}
#endregion

#region Loading-Info
var loader = new Loader(networkingService);
loader.LoadPersons();
loader.LoadConnections();
#endregion

#region UserCommunication
var id1 = GetIDFromUser("1er Nodo (ID)");
var id2 = GetIDFromUser("2do Nodo (ID)");
var id3 = GetIDFromUser("3er Nodo (ID)");

#endregion

#region Main
var haveSpecificMutualConnection = networkingService.HaveSpecificMutualConnection(id1, id2, id3);
#endregion

#region Response
Console.WriteLine();
Console.WriteLine($"¿Tiene {id1} y {id2} como contacto en común a {id3}?");
Console.Write("-> ");
Console.ForegroundColor = haveSpecificMutualConnection ? ConsoleColor.Green : ConsoleColor.Red;
Console.WriteLine(haveSpecificMutualConnection ? "SI" : "NO");
Console.ForegroundColor = ConsoleColor.White;
#endregion
