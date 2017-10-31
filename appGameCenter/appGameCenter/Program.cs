using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appGameCenter
{
   public class Program
    {
        static void Main(string[] args)
        {


            Dictionary<Platforms, Ranking> dicc1 = new Dictionary<Platforms, Ranking>();
            Dictionary<Platforms, Ranking> dicc2 = new Dictionary<Platforms, Ranking>();


            List<Platforms> plat1 = new List<Platforms>()
            {
                Platforms.PC,
                Platforms.XBOXONE
            };

            List<Platforms> plat2 = new List<Platforms>()
            {
                Platforms.MAC,
                Platforms.PS4
            };



            Player p1 = new Player("Jugador1", "cagon@gmail.com", Countries.Holanda);
            Player p2 = new Player("Jugador2", "benitocamela@jeje.com", Countries.Japon);




            Score score2 = new Score("Jugador1", 150);
            Score score1 = new Score("Jugador 2", 50);

            List<Score> listascore2 = new List<Score>();
            listascore2.Add(score2);

            List<Score> listascore1 = new List<Score>();
            listascore1.Add(score1);

            Ranking ranking1 = new Ranking("Ranking1", listascore1);
            Ranking ranking2 = new Ranking("Ranking2", listascore2);

            dicc1.Add(plat2[1], ranking2);
            dicc1.Add(plat1[0], ranking1);
            
            Game g1 = new Game("Juego1", Genres.MundoAbierto, 2000, plat1, dicc1);
            Game g2 = new Game("Juego2", Genres.Accion, 2015, plat2, dicc1);


            GameServices.Players.Add(p1);
            GameServices.Players.Add(p2);

            GameServices.Games.Add(g1);
            GameServices.Games.Add(g2);

            foreach (Game item in GameServices.Games)
            {
                Console.WriteLine(item);
            }
            GameServices.Export();
            Console.ReadLine();
        }
    }
}
