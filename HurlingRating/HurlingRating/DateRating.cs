using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Name:			Team
//Written by:	Cathal O'Gorman
//Descrition:	The rating of a team at a particular time.
//12-Jun-2016	Initial write

namespace HurlingRating {
	class DateRating {
		#region Variable declarations
		private DateTime date;
		private int rating;
		#endregion

		#region Constructors
		public DateRating(DateTime date, int rating) {
			this.date = date;
			this.rating = rating;
		}
		#endregion
	}
}
