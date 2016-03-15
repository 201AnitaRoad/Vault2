using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class Event {
		public string description;

		public struct Impression {
			public Dweller dweller;
			public Disposition disposition;
		};

		public List<Impression> impressions;

		public Event(string d, List<Impression> i) {
			description = d;
			impressions = i;
		}
	}
}
