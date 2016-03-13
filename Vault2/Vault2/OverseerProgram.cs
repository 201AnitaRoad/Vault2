using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2
{
    class OverseerProgram
    {
        static void Main(string[] args)
        {
			GameDirector g = new GameDirector();
			g.dwellers = new List<Dweller>();
			g.dwellers.Add(new Dweller("chad"));
			g.dwellers.Add(new Dweller("steve"));
			g.dwellers.Add(new Dweller("dan"));

			do{
				g.map = new DispositionMap(g.dwellers);
				
				Console.Write("\t");
				for (int i = 0; i < g.dwellers.Count; i++) {
					Console.Write(g.dwellers[i].name+"\t");
				}

				Console.WriteLine();

				for (int j = 0; j < g.dwellers.Count; j++) {
					Console.Write(g.dwellers[j].name + "\t");
					for (int q = 0; q < g.dwellers.Count; q++) {
						Console.Write(g.map.map[j, q].value+"\t");
					}
					Console.WriteLine();
				}

				Console.WriteLine();
				Console.Write("Action? (Format: DWELLER [harm/help] DWELLER)    > ");
				string answer = Console.ReadLine();

				answer = answer.ToLower();
				string[] answers = answer.Split(' ');
				if (answers.Length != 3) {
					Console.WriteLine("LEN ERROR");
				}
				else {
					Dweller A = null;
					int bIndex = -1;
					Dweller B = null;
					for (int k = 0; k < g.dwellers.Count; k++) {
						if (g.dwellers[k].name.Equals(answers[0])) {
							A = g.dwellers[k];
						}
						if (g.dwellers[k].name.Equals(answers[2])){
							B = g.dwellers[k];
							bIndex = k;
						}
					}
					//check to see if A is a dweller
					if (A == null) {
						Console.WriteLine("A NOT FOUND ERROR");
					}
					else {
						if (answers[1].Equals("harm")) {
							Message m = new Message(A, -1, A.name + " hurt " + B.name);
							B.receiveMessage(m);
							g.dwellers[bIndex] = B;
						}
						else if (answers[1].Equals("help")) {
							Message m = new Message(A, 1, A.name + " helped " + B.name);
							B.receiveMessage(m);
							g.dwellers[bIndex] = B;
						}
						else {
							Console.WriteLine("VERB NOT FOUND ERROR");
						}
					}
				}

			} while(true);
        }
    }
}
