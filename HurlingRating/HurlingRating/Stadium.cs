using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Name:			Stadium
//Written by:	Cathal O'Gorman
//Descrition:	A stadium used by one of the intercounty teams. Includes which team is the home team.
//12-Jun-2016	Initial write

namespace HurlingRating {
	class Stadium {
		#region Variable declarations
		private int id;
		private string name;
		private Team homeTeam;
		#endregion

		#region Constructors
		public Stadium(int id, string name, Team homeTeam) {
			this.id = id;
			this.name = name;
			this.homeTeam = homeTeam;
		}
		#endregion

		#region Getters and setters
		public int ID { get { return id; } }
		public string Name { get { return name; } }
		public Team HomeTeam { get { return homeTeam; } }
		#endregion
	}
}
