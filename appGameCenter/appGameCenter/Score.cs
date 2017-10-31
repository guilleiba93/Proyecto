using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appGameCenter
{
   public class Score
    {
        private string nickname;

        public string  Nickname
        {
            get { return nickname; }
       
        }

        private int points;

        public int Points
        {
            get { if (points > 0) { return points; } else { return 0; } }
            set { points = value; }
        }

        //Constructor
        public Score(string nickname, int points)
        {
            this.nickname = nickname;
            this.points = points; 
           
        }

        //ToString
        public override string ToString()
        {
            return string.Format("{0} - {1}", Nickname, Points);
        }


    }
}
