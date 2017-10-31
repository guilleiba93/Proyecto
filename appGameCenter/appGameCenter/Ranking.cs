using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appGameCenter
{
   public class Ranking
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Score> scores;
        public List<Score> Scores
        {
            get { return scores; }
            set { scores = value; }
        }

        public Ranking(string name, List<Score> scores)
        {
            this.name = name;
            this.scores = scores;

        }

    }
}
