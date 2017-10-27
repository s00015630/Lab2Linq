using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample
{
    public class Player
    {
        //gobal unique identifier
        Guid _id;
        string _name;
        int _xp;
        public Guid Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int Xp
        {
            get
            {
                return _xp;
            }

            set
            {
                _xp = value;
            }
        }
        public override string ToString()
        {
            return _id.ToString() + _xp.ToString();
        }
    }
    class Program
        {
           static List<Player> players = new List<Player>()
            {
                new Player { Id = Guid.NewGuid(), Name="Peter Runner", Xp=99 },
                new Player { Id = Guid.NewGuid(), Name="Mary Redding", Xp=100 },
                new Player { Id = Guid.NewGuid(), Name="Owen Miller", Xp=88 },
                new Player { Id = Guid.NewGuid(), Name="Peter Bunner", Xp=7 }
            };
        
        static void Main(string[] args)
        {
            //return the first occurance of the match or null
            Player found = players.FirstOrDefault(p => p.Name == "Peter Runner");
            if(found != null)
                Console.WriteLine("{0}", found.ToString());
            else Console.WriteLine("Not found");

            //returns the first occurance of the same record
            Player found1 = players.FirstOrDefault(p => p.Name.Contains ("Peter"));
            if (found != null)
                Console.WriteLine("First found: {0}", found.ToString());
            else Console.WriteLine("Not found");

            // Return all those with an XP value over 99
            List<Player> topPlayers = players.Where(plr => plr.Xp >= 99).ToList();

            if(topPlayers.Count > 0)
            foreach (var item in topPlayers)
            {
                Console.WriteLine("{0}", item.ToString());
            }
            else Console.WriteLine("No match found");

            // Produce a scoreboard of Player names and scores
            Console.WriteLine("Top Scores");
            var ScoreBoard = players
                            .OrderByDescending(o => o.Xp)
                            .Select(scores => new { scores.Name, scores.Xp });
            foreach (var item in ScoreBoard)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Xp);
            }

            Console.ReadKey();
        }
    }
}
