using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurlingRating {
	class Match {
		#region Variable declarations
		private int id;
		private DateTime date;
		private Team team1;
		private Team team2;
		private int g1;
		private int g2;
		private int p1;
		private int p2;
		private Stadium stadium;
		private int homeTeam; //1 = Team 1, -1 = Team 2, 0 = None
		private int pointDifference;
		private int win; //1 = Team 1 win, -1 = Team 2 win, 0 = Draw
		#endregion

		#region Constructors
		public Match(int id, DateTime date, Team team1, Team team2, int g1, int g2, int p1, int p2, Stadium stadium) {
			this.id = id;
			this.date = date;
			this.team1 = team1;
			this.team2 = team2;
			this.g1 = g1;
			this.g2 = g2;
			this.p1 = p1;
			this.p2 = p2;
			this.stadium = stadium;
			this.homeTeam = (team1.ID == stadium.HomeTeam.ID) ? 1 : team2.ID == stadium.HomeTeam.ID ? -1 : 0;
			this.pointDifference = (3 * (g1 - g2)) + p1 - p2;
			this.win = pointDifference > 0 ? 1 : pointDifference < 0 ? -1 : 0;
		}
		#endregion

		#region Getters and setters
		public int ID { get { return id; } }
		public Team Team1 { get { return team1; } }
		public Team Team2 { get { return team2; } }
		public int HomeTeam { get { return homeTeam; } }
		public Stadium MatchStadium { get { return stadium; } }
		public int WinningTeam { get { return win; } }
		#endregion
	}
}