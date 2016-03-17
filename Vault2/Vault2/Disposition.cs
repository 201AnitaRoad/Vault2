using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault2 {
	class Disposition {
		//-100 to 100
		public double trust, attraction, respect;
		
		//0 to 100
		public double knowledge;

		//string description of relationship
		public string descrip;
		public Disposition() {
			trust = 0;
			attraction = 0; 
			respect = 0;
			knowledge = 0;
			descrip = "Neutral";
		}
		public Disposition(double r, double a, double t, double k) {
			trust = t;
			attraction = a;
			respect = r;
			knowledge = k;
			descrip = "Neutral";
		}

		//Weight is a scalar value:
		//Given Dispositions A and B, with a weight 0.0 -> inf
		//a factored disposition will equal ((A + (weight * B)) / 2)
		public Disposition factorDisp(Disposition other, double weight) {
			Disposition factored = new Disposition();
			factored.trust		= (trust + (other.trust * weight)) / 2;
			factored.attraction = (attraction + (other.attraction * weight)) / 2;
			factored.respect	= (respect + (other.respect * weight)) / 2;
			factored.knowledge = (knowledge + (other.knowledge * weight)) / 2;
			return factored;
		}

	}
}
