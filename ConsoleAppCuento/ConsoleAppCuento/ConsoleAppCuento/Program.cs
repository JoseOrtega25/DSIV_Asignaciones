// See https://aka.ms/new-console-template for more information
string routeStory = @"C:\\Users\\jorte\\OneDrive\\Documentos\\Cuento2.txt";
string ResultadosCuentoRuta = "C:\\Users\\jorte\\OneDrive\\Documentos\\DSIV_Asiganciones\\DSIV_Asignaciones\\ConsoleAppCuento\\ConsoleAppCuento\\ConsoleAppCuento\\bin\\Debug\\net8.0\\ResultadosCuento.txt";
string contentStory = File.ReadAllText(routeStory);

Console.WriteLine(contentStory);
using (StreamWriter sr = new StreamWriter(ResultadosCuentoRuta))
{
    // Método local para imprimir y guardar al mismo tiempo
    void Print(string mensaje)
    {
        Console.WriteLine(mensaje);
        sr.WriteLine(mensaje);
    }
    //Creacion y Conversión
    //1. Buscar el nombre Bitín -----------------------------------------
    int indexIn = contentStory.IndexOf("Bitín");
    string nombreBitin = contentStory.Substring(indexIn, "Bitín".Length);
    string exploradorTxt = "Explorador";
    string concatenacion1 = string.Concat(nombreBitin, " es un ", exploradorTxt);
    Print("1-Buscar el nombre 'Bitin' en el cuento y lo concatenamos con la palabra ' explorador'");
    Print(concatenacion1);
    Print("-----------------------------------------------------------------------");

    //-------------------------------------------------------------------
    //2. string.Join
    string copyStory = File.ReadAllText(routeStory);
    string[] cuentoSeparado = copyStory.Split('.', StringSplitOptions.RemoveEmptyEntries);
    Print("2-Primero separamos el cuento por cada punto que tiene y colocamos las oraciones en un arreglo," +
        " para luego unirlas con un separador '|', donde antes habia un punto, con la función string.Join");

    foreach (string oracion in cuentoSeparado)
    {
        Print(oracion);
        Print("--------------------------------------------------------------------");
    }
    Print("----------------Cuento Separado por puntos--------------------");
    string cuentoUnido = string.Join(" | ", cuentoSeparado);
    Print(cuentoUnido);
    Print("-------------------------Cuento unido con separador---------------------");
    Print("-------------------------------------------------------------------------------------------------------");

    //3. string.Format
    string[] palabrasDelCuento = contentStory.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    int caracteresCuento = contentStory.Length;
    string resultadoConFormat = "";
    int numpalabras = palabrasDelCuento.Length;

    resultadoConFormat = string.Format("El cuento tiene {0} caracteres y {1} palabras", caracteresCuento, numpalabras);
    Print("3-Utilizamos 'string.Format' para configurar una cadena ");

    Print(resultadoConFormat);
    Print("-------------------------------------------------------------------------------------------------------");

    //4. string Interpolation
    string metaProtagonista = "explorar más allá de los límites de su servidor";
    Print("4-Utilizamos 'string Interpolation' para optimizar la concatenacion de cadenas con variables");

    Print($"El protagonista del cuento es {nombreBitin} y su objetivo es {metaProtagonista}");
    Print("-------------------------------------------------------------------------------------------------------");

    //5.Convert.ToString
    string charStoryString = Convert.ToString(caracteresCuento);
    Print("Convertimos a string una variable 'int' que contiene el numero de caracteres del cuento utilizando 'Convert.ToString'");
    Print($"{charStoryString} es la cantidad de caracteres del cuento convertida a una cadena");

    Print("-------------------------------------------------------------------------------------------------------");

    //Busqueda y Localizacion 
    // 6. IndexOf() buscar primera concurrrencia de la palabra "Mundo"

    int indexMundo = contentStory.IndexOf("mundo");
    Print("6- Utilizamos IndexOf() buscar el indice de la primera concurrrencia de la palabra 'Mundo''");
    Print($"{indexMundo} es la posicion de la primera concurrencia de la palabram (Mundo) ");
    char[] arrayCuento = contentStory.ToCharArray();
    //Print("Palabras del cuento");
    //int i = 0;
    /*foreach (char c in arrayCuento)
    {
        i++;
        Print($"{i}.{c}");
        Print("-------------------------");
    }*/
    Print("-------------------------------------------------------------------------------------------------------");

    //7. LastIndexOF
    int lastIndex = contentStory.LastIndexOf("ceros");
    Print("7-Utilizamos LastIndexOf() buscar el indice de la ultima concurrrencia de la palabra 'ceros'");

    Print($"{lastIndex} Ultima concurrecia de la palabra (ceros)");
    Print("-------------------------------------------------------------------------------------------------------");

    //8.Contains();

    bool contieneNubes = contentStory.Contains("Nube");
    Print("8-Utilizamos 'Contains()' para verificar si el cuento tiene la palabra 'Nube'");
    string mensajeNube = (contieneNubes) ? "El cuento tiene la palabra 'Nube'" : "El cuento no tiene la palabra 'Nube'";
    Print(mensajeNube);
    Print("-------------------------------------------------------------------------------------------------------");
    //9. StarsWith

    bool inicioCuento = contentStory.StartsWith("En el vasto universo");
    string mensajeInicio = (inicioCuento) ? "Si inicia con la frase 'En el vasto universo'" : "No inicia con la frase 'En el vasto Universo";
    Print("9-Se utiliza 'StarsWith' para verificar si inica con la frase'En el vasto universo'");
    Print(mensajeInicio);
    //10. EndsWith
    Print("-------------------------------------------------------------");
    bool finalCuento = contentStory.EndsWith("ceros y unos.");
    string mensajeFinal = (inicioCuento) ? "Si finaliza con la frase 'ceros y uno'" : "No finaliza con la frase 'ceros y uno";
    Print("10-Se utiliza 'StarsEnd' para verificar si finaliza con la frase'ceros y uno'");
    Print(mensajeFinal);
    Print("-------------------------------------------------------------------------------------------------------");
    // Manipulacion de contenido
    //11.Substring
    int index = contentStory.IndexOf("ciudades luminosas");

    string subcadena = contentStory.Substring(88, "ciudades luminosas".Length);
    Print("11-Utilizamos 'Substring' para sacar la cadena 'ciudades luminosas' del cuento");
    Print(subcadena);
    Print("-------------------------------------------------------------------------------------------------------");
    //12.Remove
    string cortarCuento = copyStory.Remove(0, 15);
    Print("12.Utilizamos 'Remove()' para quitar los primeros 15 caracteres del cuento");
    Print(cortarCuento);
    Print("-------------------------------------------------------------------------------------------------------");
    //13.Replace
    string remplazar = contentStory.Replace("Bitín", "ProgramaX");
    Print("12-Utilizamos'Replace' para reemplazar la palabra 'Bitin' por 'ProgramaX'");
    Print(remplazar);
    Print("-------------------------------------------------------------------------------------------------------");
    //14.Insert
    int indexFirewall = contentStory.LastIndexOf("firewall") + "firewall".Length;
    Print("14-Utilizamos la funcion 'Insert() para insertar la palabra 'IMPORTANTE' despues de la palabra 'firewall'");
    string insertar = contentStory.Insert(indexFirewall, " IMPORTANTE");
    Print(insertar);
    Print("-------------------------------------------------------------------------------------------------------");
    //15.PadLeft
    string padLeftBitin = "Bitin".PadLeft(10, '*');
    Print("15-Utilizamos PadLeft() para completar con '*' 10 caracteres en la palabra 'Bitin' ");
    Print(padLeftBitin);
    Print("-------------------------------------------------------------------------------------------------------");

    //16.PadRight
    string padRightNube = "Nube".PadRight(12, '-');
    Print("16-Utilizamos PadLeft() para completar con '-' 12 caracteres en la palabra 'Nube' ");

    Print(padRightNube);
    Print("-------------------------------------------------------------------------------------------------------");

    //17.Trim
    Print("17-Utilizamos la funcion Trim() para quitar los espacios de la palabra '    firewall          ' ");
    Print($"      firewall         ".Trim());
    Print("-------------------------------------------------------------------------------------------------------");
    //18.TrimStart
    Print("18-Utilizamos la funcion TrimStar() para quitar los espacios al inicio de la frase ' Mundo Binario' ");

    Print(" Mundo Binario".TrimStart());
    Print("-------------------------------------------------------------------------------------------------------");
    //19. TrimEnd
    Print("19-Utilizamos la funcion TrimStar() para quitar los espacios al final de la frase 'Bitin explorador     ");

    Print("Bitín explorador ".TrimEnd());
    Print("-------------------------------------------------------------------------------------------------------");
    //20.Split()
    Print("20- Utilizamos 'Split()' para dividir el cuento por palabras tomando como separador cada espacio en blanco ");

    string[] splitCuento = contentStory.Split(' ');
    for (int i3 = 0; i3 <= 10; i3++)
    {
        Print(splitCuento[i3]);
    }
    Print("-------------------------------------------------------------------------------------------------------");
    //21.Equals()
    Print("21-Utilizamos 'Equals' para comparar si 2 palabras son iguales tomando en cuenta mayusculas y minusculas");
    bool resultadoEqual = String.Equals("Nube", "nube");
    Print("¿'Nube y 'nube' son iguales ? = " + resultadoEqual);
    Print("-------------------------------------------------------------------------------------------------------");

    //22. Compare

    int compararAlfa = String.Compare("Bitin", "firewall", StringComparison.OrdinalIgnoreCase);
    Print("21-Utilizamos String.Compare() para comparar el orden alfabetico de 2 string permitiendo  ignorar mayusculas y utilizando otras reglas para comparar");
    if (compararAlfa == 0)
    {
        Print("Son iguales");
    }
    else if (compararAlfa > 0)
    {
        Print("La palabra 'Bitín' va primero");
    }
    else if (compararAlfa < 0)
    {
        Print("La palabra 'firewal' va primero");
    }
    Print("-------------------------------------------------------------------------------------------------------");

    //23.CompareTo
    Print("23-Utilizamos CompareTo() para comparar el orden alfabetico de  2 cadenas tomando en cuenta mayusculas ");
    Print("int resultado = string1.CompareTo(string2)");
    Print("< 0 → string1 es menor que string2");
    Print("0 → string1 es igual a string2");
    Print("> 0 → string1 es mayor que string2");
    Print("-----------------------------------------------");
    string a = "Nube";
    string b = "Cielo";
    int resultCompareTo = a.CompareTo(b);
    if (resultCompareTo == 0)
    {
        Print("Son iguales");
    }
    else if (resultCompareTo > 0)
    {
        Print("La palabra 'Nube' va primero");
    }
    else if (compararAlfa < 0)
    {
        Print("La palabra 'Cielo' va primero");
    }
    Print("-------------------------------------------------------------------------------------------------------");
    //24.IsNullOrEmty
    string cadenaVacia = null;
    Print("23-Declaramos una cadena vacia y utilizamos 'IsNullOrEmty' para verificar si es nula o vacia");
    Print("La cadena es: " + String.IsNullOrEmpty(cadenaVacia));
    Print("-------------------------------------------------------------------------------------------------------");

    //25.IsNullOrWhiteSpace
    string cadenaEspacio = "                ";
    Print("24-Declaramos una cadena Con espacios y utilizamos 'IsNullOrWhiteSpace' para verifica si es nula, vacia o simplemente tiene espacios en blanco");
    Print("La cadena con espacios es: " + String.IsNullOrWhiteSpace(cadenaEspacio));
    Print("-------------------------------------------------------------------------------------------------------");
    //26.ToLower
    string cuentoMinus = contentStory.ToLower();
    Print("25-Cuento a minusculas con 'ToLower()'----------------------------------------------");
    Print(cuentoMinus);
    Print("-------------------------------------------------------------------------------------------------------");

    //27.ToUpper
    string cuentoMayus = contentStory.ToUpper();
    Print("26- Con 'ToUpper()' Cuento a mayusculas------------------------------------------------");
    Print(cuentoMayus);
    Print("-------------------------------------------------------------------------------------------------------");

    //28. ToLowerInvariant
    string nubeString = "NUBE";
    Print("27-Utilizamos ToLowerInvariant para convertir la palabra 'NUBE' a minusculas: " + nubeString.ToLowerInvariant());
    Print("-------------------------------------------------------------------------------------------------------");
    //29.ToUpperInvariant
    string bitinString = "bitin";
    Print("28-Utilizamos ToUpperInvariant para convertir la palabra 'bitin' a minusculas: " + bitinString.ToUpperInvariant());
    Print("-------------------------------------------------------------------------------------------------------");



}
