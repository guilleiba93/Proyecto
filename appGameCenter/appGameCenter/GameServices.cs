using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appGameCenter
{
    public class GameServices
    {
        private const string PATH = "../../Resources/data.txt";

        private static List<Player> players = new List<Player>();
        public static List<Player> Players
        {
            get { return players; }

        }

        private static List<Game> games = new List<Game>();
        public static List<Game> Games
        {
            get { return games; }

        }

        public static void Export()
        {
            // Convertir todos los jugadores en string con el formato
            string playerData = ConvertPlayersToString();
            // Convertir todos los juegos en string con el formato
            string gameData = ConvertGamesToString();
            //Convertir ranking en string
            string rankingGameData = ConvertRankingGameToString();
            // Escribir en el fichero los datos anteriores separados por el patron '*+*+*+*'
            try
            {
                StreamWriter file = File.CreateText(PATH);
                string completeData = playerData + "*+*+*+*\n" + gameData + "*+*+*+*\n" + rankingGameData;
                file.Write(completeData);
                file.Close();
                Console.WriteLine("Datos exportados correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al exportar los datos. " + e);
            }
        }

        private static string ConvertRankingGameToString()
        {
            string res = "";
            foreach (Game game in games)
            {

                foreach (Platforms dataRanking in game.Rankings.Keys)
                {
                    res += string.Format("{0}-", game.Name);
                    foreach (Score dataScore in game.Rankings[dataRanking].Scores)
                    {
                        res += string.Format("{0}-{1}={2},", game.Rankings[dataRanking].Name, dataScore.Nickname, dataScore.Points);

                    }
                }
                res += "\n";
            }

            return res;
        }

        private static string ConvertPlayersToString()
        {
            string data = "";

            foreach (Player player in Players)
            {
                string playerData = "";
                playerData = string.Format("{0}-{1}-{2}", player.Nickname, player.Email, player.Country);
                playerData += "\n";
                data += playerData;
            }

            return data;
        }

        private static string ConvertGamesToString()
        {
            string gameData = "";


            foreach (Game game in Games)
            {

                gameData += string.Format("{0}-{1}-{2}-", game.Name, game.Genres, game.ReleaseDate);


                foreach (Platforms data4 in game.Platforms)
                {
                    gameData += data4 + ",";
                }
                gameData += "\n";

            }

            return gameData;
        }

        //Juego mas viejo de la empresa
        public static Game OldestGame()
        {
            Game oldestGame = null;
            int releaseDate = int.MaxValue;
            foreach (Game game in GameServices.Games)
            {
                int y = game.ReleaseDate;
                if (releaseDate > y)
                {
                    oldestGame = game;
                    releaseDate = y;
                }
            }
            return oldestGame;
        }

        //Busqueda de juegos por genero

        public static int gamesCountByGenre(Genres genre, string gamelist)
        {
            Game res = GetGameByName(gamelist);
            int count = 0;
            foreach (Game game in GameServices.Games)
            {
                if (game.Genres == genre)
                {
                    count++;
                }
            }
            return count;
        }

        //Juego maxima puntuacion
        public static Game MostScore()
        {
            Game aux = null;
            foreach (Game game in Games)
            {
                if ( game == null || aux.Rankings.Values.Count < game.Rankings.Values.Count )
                {
                    aux = game;
                }
            }
            
            
            return aux;
        }




        public static int ScoreCount(string nickname)
        {
            int res = 0;
            foreach (Game game in games)
            {
                foreach (Ranking ranking in game.Rankings.Values)
                {
                    foreach (Score score in ranking.Scores)
                    {
                        if (score.Nickname != nickname)
                        {
                            res++;
                        }
                    }
                }
            }

            return res;

        }

        //Metodo aux
        //Busqueda de juego por nombre

        private static Game GetGameByName(string name)
        {
            Game res = null;
            foreach (Game game in GameServices.Games)
            {
                if (game.Name == name)
                {
                    res = game;
                    break;
                }
            }
            return res;
        }

        //Existe algun juego con la palabra Call en su nombre?
        public static bool ExistGame(string gameName)
        {
            bool res = false;
            foreach (Game game in games)
            {
                if (game.Name.Contains("Call"))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        public static void RealizarTest()
        {
            

            while (true)
            {
                Console.Write("Introduce un comando: ");
                string frase = Console.ReadLine();

                frase = frase.ToLower();

                string[] splitted = frase.Split(' ');
                string comando = splitted[0];
                Genres genres = Genres.Accion;
                string valor = "";
                if (splitted.Length > 1)
                {
                    valor = splitted[1];
                }

                switch (comando)
                {
                    case "import":
                        //Import();
                        break;
                    case "export":
                        Export();
                        break;
                    case "oldest":
                        OldestGame();
                        break;
                    case "scoreCount":
                        ScoreCount(valor);
                        break;
                    case "gamesCountByGenre":
                        gamesCountByGenre(genres,valor);
                        break;
                    case "gamesByPlayer":
                        break;


                }
            }
        }
    }
}

