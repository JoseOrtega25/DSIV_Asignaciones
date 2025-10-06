// See https://aka.ms/new-console-template for more information
using ConsoleAppPOO;
using ConsoleAppPOO.Models;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static ConsoleAppPOO.Models.SuperPoder;

var superman = new SuperHeroe(
    id: 1,
    nombre: "   Superman    ",
    identidadSecreta: "Clark Kent",
    ciudad: "Metropolis",
    puedeVolar: true,
    superPoderes: new List<SuperPoder>()
);
ImprimirInfo.ImprimirSuperHeroe(superman);

var wolverine = new AntiHeroe
{
    Id = 2,
    Nombre = "Wolverine",
    IdentidadSecreta = "Logan",
    Ciudad = "New York",
    PuedeVolar = false,
    SuperPoderes = new List<SuperPoder>(),
};

string accionAntiHeroe = wolverine.RealizarAccionDeAntiheroe("Ataca a la policia");
Console.WriteLine(accionAntiHeroe);

SuperPoder poderVolar = new SuperPoder(
    nombre: "Volar",
    descripcion: "Capacidad para volar y planear en el aire.",
    nivel: NivelPoder.NivelDos
);

SuperPoder superfuerza = new SuperPoder(
    nombre: "Superfuerza",
    descripcion: null,
    nivel: NivelPoder.NivelTres
);

// Crea una instancia de Superpoder para "Regeneración"
SuperPoder regeneracion = new SuperPoder(
    nombre: "Regeneración",
    descripcion: null, // No se proporciona descripción
    nivel: NivelPoder.NivelTres
);

// Crea una lista de superpoderes y la asigna a Wolverine
List<SuperPoder> poderesWolverine = new List<SuperPoder> { regeneracion, superfuerza };
wolverine.SuperPoderes = poderesWolverine;



// Crea una lista de superpoderes y la asigna a Superman
List<SuperPoder> poderesSuperman = new List<SuperPoder> { poderVolar, superfuerza };
superman.SuperPoderes = poderesSuperman;
string resultSalvarAlMundo = superman.SalvarElMundo();
string resultSalvarLaTierra = superman.SalvarLaTierra();

// Impresión de prueba
Console.WriteLine($"Id: {superman.Id}");
Console.WriteLine($"Nombre: {superman.Nombre}");
Console.WriteLine($"Identidad Secreta: {superman.IdentidadSecreta}");
Console.WriteLine($"Ciudad: {superman.Ciudad}");
Console.WriteLine($"Puede Volar: {superman.PuedeVolar}");
Console.WriteLine("Superpoderes:");
Console.WriteLine(resultSalvarAlMundo);
Console.WriteLine(resultSalvarLaTierra);
foreach (var poder in superman.SuperPoderes)
{
    Console.WriteLine($"- {poder.Nombre} (Nivel: {poder.Nivel})" +
        (string.IsNullOrEmpty(poder.Descripcion) ? "" : $", Descripción: {poder.Descripcion}"));
}


Console.WriteLine($"Id: {wolverine.Id}");
Console.WriteLine($"Nombre: {wolverine.Nombre}");
Console.WriteLine($"Identidad Secreta: {wolverine.IdentidadSecreta}");
Console.WriteLine($"Ciudad: {wolverine.Ciudad}");
Console.WriteLine($"Puede Volar: {wolverine.PuedeVolar}");
Console.WriteLine("Superpoderes:");
foreach (var poder in wolverine.SuperPoderes)
{
    Console.WriteLine($"- {poder.Nombre} (Nivel: {poder.Nivel})" +
        (string.IsNullOrEmpty(poder.Descripcion) ? "" : $", Descripción: {poder.Descripcion}"));
}


public record SuperHeroeRecord(int Id, string Nombre, string IdentidadSecreta);



