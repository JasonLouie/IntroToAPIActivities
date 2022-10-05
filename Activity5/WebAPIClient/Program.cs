using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;
using WebAPIClient;
using System.Security.Cryptography.X509Certificates;

namespace WebAPIClient
{
    class Film
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("producer")]
        public string Producer { get; set; }

        [JsonProperty("running_time")]
        public int Duration { get; set; }

        [JsonProperty("rt_score")]
        public int Rating { get; set; }
    }

    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the name of a Studio Ghibli film. Press enter to quit.");

                    var filmName = Console.ReadLine();
                    var filmID = "";

                    if (string.IsNullOrEmpty(filmName))
                    {
                        break;
                    }

                    filmName = filmName.ToLower();

                    if (filmName == "castle in the sky")
                    {
                        filmID = "2baf70d1-42bb-4437-b551-e5fed5a87abe";
                    } else if (filmName == "grave of the fireflies")
                    {
                        filmID = "12cfb892-aac0-4c5b-94af-521852e46d6a";
                    } else if (filmName == "my neighbor totoro")
                    {
                        filmID = "58611129-2dbc-4a81-a72f-77ddfc1b1b49";
                    } else if (filmName == "kiki's delivery service")
                    {
                        filmID = "ea660b10-85c4-4ae3-8a5f-41cea3648e3e";
                    } else if (filmName == "only yesterday")
                    {
                        filmID = "4e236f34-b981-41c3-8c65-f8c9000b94e7";
                    } else if (filmName == "porco rosso")
                    {
                        filmID = "ebbb6b7c-945c-41ee-a792-de0e43191bd8";
                    } else if (filmName == "pom poko")
                    {
                        filmID = "1b67aa9a-2e4a-45af-ac98-64d6ad15b16c";
                    } else if (filmName == "whisper of the heart")
                    {
                        filmID = "ff24da26-a969-4f0e-ba1e-a122ead6c6e3";
                    } else if (filmName == "princess mononoke")
                    {
                        filmID = "0440483e-ca0e-4120-8c50-4c8cd9b965d6";
                    } else if (filmName == "my neighbors the yamadas")
                    {
                        filmID = "45204234-adfd-45cb-a505-a8e7a676b114";
                    } else if (filmName == "spirited away")
                    {
                        filmID = "dc2e6bd1-8156-4886-adff-b39e6043af0c";
                    } else if (filmName == "the cat returns")
                    {
                        filmID = "90b72513-afd4-4570-84de-a56c312fdf81";
                    } else if (filmName == "howl's moving castle")
                    {
                        filmID = "cd3d059c-09f4-4ff3-8d63-bc765a5184fa";
                    } else if (filmName == "tales from earthsea")
                    {
                        filmID = "112c1e67-726f-40b1-ac17-6974127bb9b9";
                    } else if (filmName == "ponyo")
                    {
                        filmID = "758bf02e-3122-46e0-884e-67cf83df1786";
                    } else if (filmName == "arrietty")
                    {
                        filmID = "2de9426b-914a-4a06-a3a0-5e6d9d3886f6";
                    } else if (filmName == "from up on poppy hill")
                    {
                        filmID = "45db04e4-304a-4933-9823-33f389e8d74d";
                    } else if (filmName == "the wind rises")
                    {
                        filmID = "67405111-37a5-438f-81cc-4666af60c800";
                    } else if (filmName == "the tale of the princess kaguya")
                    {
                        filmID = "578ae244-7750-4d9f-867b-f3cd3d6fecf4";
                    }
                    else if (filmName == "when marnie was there")
                    {
                        filmID = "5fdfb320-2a02-49a7-94ff-5ca418cae602";
                    }
                    else if (filmName == "the red turtle")
                    {
                        filmID = "d868e6ec-c44a-405b-8fa6-f7f0f8cfb500";
                    }
                    else if (filmName == "earwig and the witch")
                    {
                        filmID = "790e0028-a31c-4626-a694-86b7a8cada40";
                    }

                    var result = await client.GetAsync("https://ghibliapi.herokuapp.com/films/" + filmID);

                    var resultRead = await result.Content.ReadAsStringAsync();
                    var film = JsonConvert.DeserializeObject<Film>(resultRead);
                    
                    Console.WriteLine("-----");
                    Console.WriteLine("Film Title: " + film.Title);
                    Console.WriteLine("Description: " + film.Description);
                    Console.WriteLine("Year Released: " + film.ReleaseDate);
                    Console.WriteLine("Director: " + film.Director);
                    Console.WriteLine("Producer: " + film.Producer);
                    Console.WriteLine("Duration: " + film.Duration/60 + "hr" + ((film.Duration%60 > 0)?(" " + film.Duration%60 + "min") : ("")));
                    Console.WriteLine("-----");
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid Studio Ghibli film name.");
                }
            }
        }
    }
}