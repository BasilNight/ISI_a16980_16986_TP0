/*
*	<copyright file="PrevisaoDia.cs" company="IPCA">
*		Copyright (c) 2020 All Rights Reserved
*	</copyright>
* 	<author>Oscar Ribeiro</author>
*   <date></date>
*	<description></description>
**/

using System;

namespace Exercicio1
{
    /// <summary>
    /// Classe Auxiliar
    /// </summary>
    class PrevisaoIPMA
    {
            public string owner { get; set; }
            public string country { get; set; }
            public PrevisaoDia[] data { get; set; }
            public int globalIdLocal { get; set; }
            public DateTime dataUpdate { get; set; }

          // ---- 
          public string local { get; set; }
    }

       
}

// copiar o conteúdo do ficheiro .Json, 
// e usar a opção Edit > Paste Special  > PAste JSON as classes

    /* 
public class Rootobject
{
    public string owner { get; set; }
    public string country { get; set; }
    public Datum[] data { get; set; }
    public int globalIdLocal { get; set; }
    public DateTime dataUpdate { get; set; }
}

public class Datum
{
    public string precipitaProb { get; set; }
    public string tMin { get; set; }
    public string tMax { get; set; }
    public string predWindDir { get; set; }
    public int idWeatherType { get; set; }
    public int classWindSpeed { get; set; }
    public string longitude { get; set; }
    public string forecastDate { get; set; }
    public int classPrecInt { get; set; }
    public string latitude { get; set; }
}
--------------------------------------  */


