using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class Disposition {
		//-10 to 10
		public int value;
		//string description of relationship
		string descrip;
		public Disposition() {
			value = 0;
			descrip = "Neutral";
		}
	}
}
