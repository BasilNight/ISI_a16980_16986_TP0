/*
 Autor: Luís Miguel Carvalho Martins
 Nº: 16980
 
*/


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Exercicio1
{
    class Program
    {

        /// <summary>
        /// Abre e lê conteudos do ficheiro "locais.csv"
        /// </summary>
        /// <param name="ficheiro"></param>
        /// <returns></returns>
        static Dictionary<int, string> LerLocais(string ficheiro)
        {

            Dictionary<int, string> dicLocais = new Dictionary<int, string>();

            // Expressão Regular para instanciar objeto Regex
            String erString = @"^[0-9]{7},[123],([1-9]?\d,){2}[A-Z]{3},([^,\n]*)$";



            // Ciclo para percorrer as linha do ficheiro uma a uma para encontrar correspondências entre a ER e o ficheiro
            Regex g = new Regex(erString);
            using (StreamReader r = new StreamReader("locais.csv"))
            {
                string line;
                
                while ((line = r.ReadLine()) != null)
                {
                    // Tenta corresponder ER com ficheiro
                    Match m = g.Match(line);
                    if (m.Success)
                    {
                        //  estrutura de cada linha com correspondência:
                        //  globalIdLocal,idRegiao,idDistrito,idConcelho,idAreaAviso,local
                        //  separar pelas vírgulas...
                        string[] campos =  m.Value.Split(',');
                        int codLocal = int.Parse(campos[0]);
                        string cidade = campos[5];
                        // Guardar na estrutura de dados dicionário
                        // dicLocais.Add( CHAVE ,  VALOR )
                        dicLocais.Add(codLocal, cidade);
                    }
                    else
                    {
                        Console.WriteLine($"Linha inválida: {line}" );
                    }
                }
            }
            return dicLocais;
        }


        static PrevisaoIPMA LerFicheiroPrevisao(int globalIdLocal)
        {
            String jsonString = null;
            using (StreamReader reader =
                       new StreamReader("data_forecast/" + globalIdLocal  + ".json"))
            {
                jsonString = reader.ReadToEnd();
            }
            PrevisaoIPMA obj = JsonConvert.DeserializeObject<PrevisaoIPMA>(jsonString);
            return obj;
        }

        static void Main(string[] args)
        {
            string json;
            string pathDest = @"C:\Users\Luís Martins\Documents\GitHub\TrabalhoExtra1\Exercicio1\output\";


            Dictionary<int, string> dicLocais = LerLocais(@".. /../locais.csv");

            // Apenas para mostrar o conteúdo da estrutura dicinário...
            foreach (KeyValuePair<int, string> kv in dicLocais)
            {
                Console.WriteLine($"globalIdLocal= {kv.Key} cidade= {kv.Value}");
              
                // para cada linha do ficheiro CSV ... 
                PrevisaoIPMA previsaoIPMA = LerFicheiroPrevisao(kv.Key);
               
                previsaoIPMA.local = kv.Value;

                json = JsonConvert.SerializeObject(previsaoIPMA);

                if (!File.Exists(pathDest +kv.Key + "-detalhe.json"))
                {
                    File.Delete(pathDest + kv.Key + "-detalhe.json");
                    File.WriteAllText(pathDest + kv.Key + "-detalhe.json", json);
                }
                
            }

            Console.ReadKey();

        }
    }
}
