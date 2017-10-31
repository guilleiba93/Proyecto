using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appGameCenter
{
    public enum Countries
    {
        Spain = 0,
        Italia = 1,
        Portugal = 2,
        Francia = 3,
        Alemania = 4,
        USA = 5,
        Canada = 6,
        Holanda = 7,
        Japon = 8,
        Korea = 9
    }

    public class Player
    {
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private Countries country;

        public Countries Country
        {
            get { return country; }
            set { country = value; }
        }


        public Player(string nickname, string email, Countries country)
        {
            this.nickname = nickname;
            this.email = email;
            this.country = country;
           
        }




        public override bool Equals(object obj)
        {
            if (obj is Player)
            {
                Player aux = (Player)obj;
                return this.Nickname == aux.Nickname;
            }
            else
            {
                return false;
            }
        }




        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Nickname, Email, Country);
        }


    }
}
