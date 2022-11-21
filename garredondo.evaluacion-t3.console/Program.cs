using garredondo.evaluacion_t3.console.Entities;
using garredondo.evaluacion_t3.console.Utils;
using garredondo.evaluacion_t3.infrastructure.Services;

var networkingService = new NetworkService<Person>();

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

#region Loading-Info
var loader = new Loader(networkingService);
loader.LoadPersons();
loader.LoadConnections();
#endregion

#region UserCommunication
var id1 = GetIDFromUser("1er Nodo (ID)");

var id2 = GetIDFromUser("2do Nodo (ID)");
var idCommon = GetIDFromUser("Nodo en común (ID)");

#endregion

var haveSpecificMutualConnection = networkingService.HaveSpecificMutualConnection(id1, id2, idCommon);

Console.WriteLine(haveSpecificMutualConnection ? "SI" : "NO");
