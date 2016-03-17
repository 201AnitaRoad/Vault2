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

		public Impression impressions;

		public Event(string d, Impression i) {
			description = d;
			impressions = i;
		}
	}
}
