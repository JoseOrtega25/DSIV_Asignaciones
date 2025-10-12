using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace opeanai
{
    internal static class Program
    {
        static async Task Main()
        {
            Console.WriteLine("ProyectoLINQOpenAI8 (.NET 8) - descarga de posts y consultas LINQ");

            // 1) Descargar posts
            var posts = await DescargarPostsAsync("https://jsonplaceholder.typicode.com/posts");
            Console.WriteLine($"\nSe descargaron {posts.Count} posts.\n");

            // 2) Ejecutar consultas LINQ (varios ejemplos)
            EjecutarConsultasLINQ(posts);

            // 3) Analizar con OpenAI (opcional)

            await ExplicarConsultasAsync();
            await Task.Delay(20000);

            await ResumirResultadosAsync(posts);
            await Task.Delay(20000);

            await ClasificarPostsAsync(posts);
            await Task.Delay(20000);

            await GenerarConsultasLINQAsync();

            Console.WriteLine("\nListo. Pulsa ENTER para salir.");
            Console.ReadLine();
        }

        static async Task<List<Post>> DescargarPostsAsync(string url)
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Post>>(json) ?? new List<Post>();
        }

        static void EjecutarConsultasLINQ(List<Post> posts)
        {
            Console.WriteLine("=== EJEMPLOS DE CONSULTAS LINQ ===\n");
            //1
            var q1 = posts.Where(p => p.UserId == 1).ToList();
            Console.WriteLine($"1) Posts del usuario 1: {q1.Count}");
            //2
            var q2 = posts.OrderBy(p => p.Title).Take(5);
            Console.WriteLine("\n2) Primeros 5 títulos ordenados alfabéticamente:");
            foreach (var p in q2) Console.WriteLine($" - {p.Title}");
            //3
            var q3 = posts.Where(p => p.Title.Contains("qui", StringComparison.OrdinalIgnoreCase)).Select(p => p.Title);
            Console.WriteLine($"\n3) Títulos que contienen 'qui': {q3.Count()}");
            //4
            var q4 = posts.Where(p => p.Body.Length > 100);
            Console.WriteLine($"\n4) Posts con body > 100 chars: {q4.Count()}");
            //5
            var q5 = posts.GroupBy(p => p.UserId).Select(g => new { g.Key, Count = g.Count() }).OrderBy(x => x.Key);
            Console.WriteLine("\n5) Conteo de posts por userId:");
            foreach (var g in q5) Console.WriteLine($" - user {g.Key}: {g.Count} posts");
            //6
            var maxId = posts.Max(p => p.Id);
            var minId = posts.Min(p => p.Id);
            Console.WriteLine($"\n6) Id máximo: {maxId}, Id mínimo: {minId}");
            //7
            var avgBody = posts.Average(p => p.Body.Length);
            Console.WriteLine($"\n7) Longitud promedio del body: {avgBody:F2} caracteres");
            //8
            var q8 = posts.Where(p => p.Id % 2 == 0).Take(10);
            Console.WriteLine($"\n8) Ejemplo de posts con Id pares (hasta 10): {q8.Count()}");
            //9
            var q9 = string.Join(" | ", posts.OrderBy(p => p.Id).Take(10).Select(p => p.Title));
            Console.WriteLine($"\n9) Concatenación de 10 títulos: {q9.Substring(0, Math.Min(120, q9.Length))}{(q9.Length > 120 ? "..." : "")}");
            //10
            var anyEmptyTitle = posts.Any(p => string.IsNullOrWhiteSpace(p.Title));
            Console.WriteLine($"\n10) ¿Existe título vacío? {anyEmptyTitle}");
            //11
            var q11 = posts.OrderByDescending(p => p.Id).Take(5).Select(p => new { p.Id, p.Title });
            Console.WriteLine("\n11) Últimos 5 posts (Id, Title):");
            foreach (var p in q11) Console.WriteLine($" - {p.Id}: {p.Title}");
            //12
            var countEst = posts.Count(p => p.Title.IndexOf("est", StringComparison.OrdinalIgnoreCase) >= 0);
            Console.WriteLine($"\n12) Títulos que contienen 'est': {countEst}");
            //13 Usuarios con más de 8 posts.

            var userMas8Post = posts.GroupBy(p => p.UserId)
                .Where(grupo => grupo.Count() > 8)
                .Select(grupo => new
            {
                UserId = grupo.Key,
                CantidadPosts = grupo.Count(),
            });
            Console.WriteLine("\n13) Usuarios con mas de 8 posts");
            foreach (var u in userMas8Post)
            {
                Console.WriteLine($"Usuario {u.UserId} tiene {u.CantidadPosts} posts");
            }

            //14 Listar los tres títulos más largos por usuario.

            var Titulos3MasLargos = posts.GroupBy(p => p.UserId)
                .Select(grupo => new
            {
                UserId = grupo.Key,
                Titulos = grupo.
                OrderByDescending(p => p.Title.Length)
                .Take(3)
                .Select(p => p.Title)
                .ToList()
            });
            Console.WriteLine("\n14)3 Titulos mas largos de cada usuario ");

            foreach (var usuario in Titulos3MasLargos)
            {
                Console.WriteLine($"Usuario {usuario.UserId}:");
                foreach (var titulo in usuario.Titulos)
                {
                    Console.WriteLine($"   - {titulo}");
                }
            }

            // 15 Obtener 10  títulos distintos(Distinct).
            var titulosDistintos = posts.Select(p => p.Title).Distinct().Take(10);
            Console.WriteLine("\n15) 10 Títulos distintos: ");
            foreach (var t in titulosDistintos)
            {
                Console.WriteLine(t);
            }

            // 16 Agrupar por número par/ impar de ID.
            var grupos = posts
            .GroupBy(p => p.Id % 2 == 0 ? "Par" : "Impar");
            Console.WriteLine("\n16) Agrupar ID en numero par o impar");

            foreach (var grupo in grupos)
            {
                Console.WriteLine($"ID {grupo.Key}:");
                foreach (var post in grupo)
                {
                    Console.WriteLine($"  {post.Title} (ID: {post.Id})");
                }
            }
            // 17   Combinar filtros de usuario +palabra clave.

            int usuarioFiltro = 1;
            string palabraClave ="qui";
            var resultados = posts
            .Where(p => p.UserId == usuarioFiltro
                        && (p.Title.Contains(palabraClave, StringComparison.OrdinalIgnoreCase)
                            || p.Body.Contains(palabraClave, StringComparison.OrdinalIgnoreCase)))
            .ToList();
            Console.WriteLine("\n17) Se filtra el usuario '1' y se busca si algun , título o en el body , de un posts tiene la palabra 'qui' ");

            // Mostrar resultados
            foreach (var post in resultados)
            {
                Console.WriteLine($"{post.Title} (ID: {post.Id}, UserId: {post.UserId})");
            }

            // 18 Calcular promedio global de longitud del cuerpo.
            double promedioLongitud = posts.Average(p => p.Body.Length);
            Console.WriteLine($"\n18) Promedio global de longitud del Body: {promedioLongitud:F2}");

            // 19 Mostrar proporción de posts largos vs cortos.

            int totalPosts = posts.Count;

            int cortos = posts.Count(p => p.Body.Length < 50);
            int largos = posts.Count(p => p.Body.Length >= 50);

            double proporcionCortos = (double)cortos / totalPosts;
            double proporcionLargos = (double)largos / totalPosts;
            Console.WriteLine("\n19) Mostrar proporción de posts largos vs cortos ");

            Console.WriteLine($"Proporción de posts cortos: {proporcionCortos:P2}");
            Console.WriteLine($"Proporción de posts largos: {proporcionLargos:P2}");

            // 20  Saltar 10 primeros y tomar 5
            Console.WriteLine("\n20) Saltar 10 primeros y tomar 5");
            var skipTake = posts.Skip(10).Take(5);
            foreach (var post in skipTake)
            {
                Console.WriteLine($"ID: {post.Id}, UserId: {post.UserId}, Title: {post.Title}");
            }

            Console.WriteLine("\n--- Fin consultas LINQ ---\n");
            Console.WriteLine("\n--- Analisis con OPENIA ---\n");

        }

        static async Task<string> LlamarOpenAIAsync(string prompt, string system = "Eres un asistente que ayuda con LINQ y C# en español.")
        {
            try
            {
                var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
                if (string.IsNullOrWhiteSpace(apiKey))
                {
                    Console.WriteLine("No se encontró la variable OPENAI_API_KEY.");
                    return null;
                }

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                var payload = new
                {
                    model = "gpt-4o-mini",

                    messages = new[]
                    {
                new { role = "system", content = system },
                new { role = "user", content = prompt }
            },
                    max_tokens = 600,
                    temperature = 0.3
                };

                var json = JsonConvert.SerializeObject(payload);
                using var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var resp = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                var text = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                {
                    // Detectar error de cuota insuficiente
                    if ((int)resp.StatusCode == 429 && text.Contains("insufficient_quota"))
                    {
                        Console.WriteLine("Error: No tienes créditos suficientes en tu cuenta de OpenAI.");
                    }
                    else
                    {
                        Console.WriteLine($"OpenAI API devolvió error ({(int)resp.StatusCode}): {text}");
                    }
                    return null;
                }

                var j = JObject.Parse(text);
                return j["choices"]?.First?["message"]?["content"]?.ToString() ?? "(sin respuesta)";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al llamar a OpenAI: {ex.Message}");
                return null;
            }
        }



        static async Task ExplicarConsultasAsync()
        {
            var consultas = new[]
            {
                "posts.Where(p => p.UserId == 1).ToList();",
                "posts.OrderBy(p => p.Title).Take(5);",
                "posts.Where(p => p.Body.Length > 100);",
                "posts.GroupBy(p => p.UserId).Select(g => new { g.Key, Count = g.Count() });"
            };

            foreach (var c in consultas)
            {
                var explicacion = await LlamarOpenAIAsync(
                    $"Explica brevemente en lenguaje natural qué hace esta consulta LINQ:\n{c}");
                Console.WriteLine($"\n Consulta:\n{c}\n Explicación:\n{explicacion}\n");

                await Task.Delay(5000); // espera 5 segundos entre consultas
            }

        }

        static async Task ResumirResultadosAsync(List<Post> posts)
        {
            var resumenData = posts
                .GroupBy(p => p.UserId)
                .Select(g => $"Usuario {g.Key}: {g.Count()} posts");

            var prompt = "Resume en 3 líneas el contenido general de estos datos:\n" + string.Join("\n", resumenData);
            var resumen = await LlamarOpenAIAsync(prompt);
            Console.WriteLine("\nResumen de resultados:\n" + resumen);
        }

        static async Task ClasificarPostsAsync(List<Post> posts)
        {
            var texto = string.Join("\n", posts.Take(15).Select(p => $"- {p.Title}: {p.Body}"));
            var prompt = $"Clasifica los siguientes posts en temas o categorías generales:\n{texto}";
            var clasificacion = await LlamarOpenAIAsync(prompt);
            Console.WriteLine("\n Clasificación de posts:\n" + clasificacion);
        }



        static async Task GenerarConsultasLINQAsync()
        {
            var prompt = """
                Dado el modelo de datos:
                class Post { public int UserId; public int Id; public string Title; public string Body; }

                Genera 3 consultas LINQ interesantes con su breve explicación.
                """;
            var respuesta = await LlamarOpenAIAsync(prompt);
            Console.WriteLine("\n Consultas generadas por OpenAI:\n" + respuesta);
        }

    }
}

    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
    }

