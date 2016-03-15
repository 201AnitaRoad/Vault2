using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class DispositionMap {

		public Disposition[,] map;

		public DispositionMap() { }

		public DispositionMap(List<Dweller> dwellers) {
			map = new Disposition[dwellers.Count, dwellers.Count];
			for (int i = 0; i < dwellers.Count; i++) {
				for (int j = 0; j < dwellers.Count; j++) {
					map[i, j] = aggregateDisposition(dwellers[i], dwellers[j]);
				}
			}
		}

		//returns Dweller A's disposition towards Dweller B
		public Disposition aggregateDisposition(Dweller a, Dweller b) {
			Disposition d = new Disposition();
			if (a.kbase.knowsDweller(b)) {
				List<Event> messages = a.kbase.getEvents(b);
				foreach (Event m in messages){
					//d.factorDisp(m.)
				}
			}
			return d;
		}

	}
}
