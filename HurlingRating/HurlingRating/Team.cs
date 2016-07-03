using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Name:			Team
//Written by:	Cathal O'Gorman
//Descrition:	A hurling team, with an elo rating
//12-Jun-2016	Initial write

namespace HurlingRating {
	class Team {
		#region Variable declarations
		private int id;
		private string name;
		private int initialRating;
		private int currentRating;
		private List<DateRating> dateRating;
		#endregion

		#region Constructors
		public Team(int id, string name, int initialRating) {
			this.id = id;
			this.name = name;
			this.initialRating = initialRating;
			this.currentRating = initialRating;
			this.dateRating = new List<DateRating>();
		}
		#endregion

		#region Getters and setters
		public int ID { get { return id; } }
		public string Name { get { return name; } }
		public int InitialRating { get { return initialRating; } }
		public int CurrentRating { get { return currentRating; } set { currentRating = value; } }
		#endregion

		public void AddDateRating(DateRating dr) {
			dateRating.Add(dr);
		}
	}
}
