using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace appGameCenter
{
    public enum Genres
    {
        Accion = 0,
        Simulation = 1,
        RPG = 2,
        JRPG = 3,
        Deportes = 4,
        Estrategia = 5,
        MundoAbierto = 6,
    }

    public enum Platforms
    {
        PC = 0,
        MAC = 1,
        Linux = 2,
        PS4 = 3,
        XBOXONE = 4,
    }



    public class Game
    {

        private string name;

        public string Name
        {
            get { return name; }
           
        }

        private Genres genres;

        public Genres Genres
        {
            get { return genres; }
            set { genres = value; }
        }

        private List<Platforms> platforms = new List<Platforms>();
        public List<Platforms> Platforms
        {
            get { return platforms; }           
        }

        private int releaseDate;

        public int ReleaseDate
        {
            get { return releaseDate; }
        }
        //Me falta el diccionario

        private static Dictionary<Platforms, Ranking> rankings = new Dictionary<appGameCenter.Platforms, Ranking>();

       

        public Dictionary<Platforms, Ranking> Rankings
        {
            get { return rankings; }
            set { rankings = value; }
        }



        //Constructor



        public Game()
        {


        }
        public Game(string name, Genres genres, int releaseDate, List<Platforms> platforms,Dictionary<Platforms, Ranking> rankings)
        {
            this.name = name;
            this.genres = genres;
            this.releaseDate = releaseDate;
            this.platforms = platforms;
            this.Rankings = rankings;
           
        }



        //Equals

        public override bool Equals(object obj)
        {
            if (obj is Game)
            {
                Game aux = (Game)obj;
                return this.Name == aux.Name;
            }
            else
            {
                return false;
            }
        }
        

        //ToString Regular HECHO
        public override string ToString()
        {

            string s = string.Format("---{0}({1}-)", this.Name, this.ReleaseDate);
            foreach (Platforms plataform in this.Platforms)
            {
                s += string.Format("{0},", plataform);
            }
            s += string.Format("-{0}---", this.Genres);
            foreach (Platforms ranking in this.Rankings.Keys)
            {
                s += string.Format("-{0}({1})", this.Rankings[ranking].Name, this.Rankings[ranking].Scores.Count);
            }
            return s;
        }
    }
}
