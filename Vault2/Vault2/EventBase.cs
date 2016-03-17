using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class EventBase {
		public List<Event> globals, individuals, pairs;
		public Dweller world;

		public EventBase() {
			globals = new List<Event>();
			individuals = new List<Event>();
			pairs = new List<Event>();
			world = new Dweller("World");
			loadGlobals();
			loadIndividuals();
			loadPairs();
		}

		private void loadGlobals(){
			string[] allLines = File.ReadAllLines("ref\\Vault2-Global.csv");
			foreach (string line in allLines) {
				string[] tokens = line.Split(',');
				// 0 EVENT STRING
				// 1 RESPECT/PITY		(-100, 100)
				// 2 ATTRACTION/DISGUST (-100, 100)
				// 3 TRUST/DISTRUST		(-100, 100)
				// 4 KNOWLEDGE	(0, 100) (REAL QUICK)
				// 5 MATERIAL
				// 6 DWELLERS	(USUALLY 0)
				double[] doubledTokens = new double[4];
				doubledTokens[0] = Convert.ToDouble(tokens[1]);
				doubledTokens[1] = Convert.ToDouble(tokens[2]);
				doubledTokens[2] = Convert.ToDouble(tokens[3]);
				doubledTokens[3] = Convert.ToDouble(tokens[4]);
				Event.Impression baseImpression;
				baseImpression.dweller = world;
				baseImpression.disposition = new Disposition(doubledTokens[0], doubledTokens[1], doubledTokens[2], doubledTokens[3]); 
				Event current = new Event(tokens[0], baseImpression);
				globals.Add(current);
				//Console.WriteLine(line);
			}
		}
		private void loadIndividuals() {
			string[] allLines = File.ReadAllLines("ref\\Vault2-Self.csv");
			foreach (string line in allLines) {
				string[] tokens = line.Split(',');
				// 0 EVENT STRING
				// 1 RESPECT/PITY		(-100, 100)
				// 2 ATTRACTION/DISGUST (-100, 100)
				// 3 TRUST/DISTRUST		(-100, 100)
				// 4 KNOWLEDGE	(0, 100) (REAL QUICK)
				// 5 MATERIAL
				// 6 DWELLERS	(USUALLY 0)
				double[] doubledTokens = new double[4];
				doubledTokens[0] = Convert.ToDouble(tokens[1]);
				doubledTokens[1] = Convert.ToDouble(tokens[2]);
				doubledTokens[2] = Convert.ToDouble(tokens[3]);
				doubledTokens[3] = Convert.ToDouble(tokens[4]);
				Event.Impression baseImpression;
				baseImpression.dweller = world;
				baseImpression.disposition = new Disposition(doubledTokens[0], doubledTokens[1], doubledTokens[2], doubledTokens[3]);
				Event current = new Event(tokens[0], baseImpression);
				individuals.Add(current);
				//Console.WriteLine(line);
			}
		}
		private void loadPairs() {
			string[] allLines = File.ReadAllLines("ref\\Vault2-Targeted.csv");
			foreach (string line in allLines) {
				string[] tokens = line.Split(',');
				// 0 EVENT STRING
				// 1 RESPECT/PITY		(-100, 100)
				// 2 ATTRACTION/DISGUST (-100, 100)
				// 3 TRUST/DISTRUST		(-100, 100)
				// 4 KNOWLEDGE	(0, 100) (REAL QUICK)
				// 5 MATERIAL
				// 6 DWELLERS	(USUALLY 0)
				double[] doubledTokens = new double[4];
				doubledTokens[0] = Convert.ToDouble(tokens[1]);
				doubledTokens[1] = Convert.ToDouble(tokens[2]);
				doubledTokens[2] = Convert.ToDouble(tokens[3]);
				doubledTokens[3] = Convert.ToDouble(tokens[4]);
				Event.Impression baseImpression;
				baseImpression.dweller = world;
				baseImpression.disposition = new Disposition(doubledTokens[0], doubledTokens[1], doubledTokens[2], doubledTokens[3]);
				Event current = new Event(tokens[0], baseImpression);
				pairs.Add(current);
				//Console.WriteLine(line);
			}
		}

		public Event getRandomGlobal() {
			Random seed = new Random();
			int multiplier = globals.Count;
			int index = Convert.ToInt32(seed.NextDouble() * multiplier);
			Console.WriteLine(index);
			return globals[index];
		}

	}
}
