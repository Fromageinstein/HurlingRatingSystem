using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HurlingRating {
	class ObjectImporter {
		#region Variable declarations
		private static string teamFile = "/ImportFiles/teams.csv";
		private static string stadiumFile = "/ImportFiles/stadia.csv";
		private static string matchFile = "/ImportFiles/matches.csv";
		#endregion

		#region Constructors
		public ObjectImporter() {
		}
		#endregion

		#region Import methods
		public static List<Team> ImportTeams() {
			StreamReader reader = new StreamReader(File.OpenRead(Environment.CurrentDirectory + teamFile));
			List<Team> teams = new List<Team>();
			while (!reader.EndOfStream) {
				string[] teamDetails = reader.ReadLine().Split(',');
				try {
					teams.Add(new Team(int.Parse(teamDetails[0]), teamDetails[1], int.Parse(teamDetails[2])));
				}
				catch (Exception e) {
					Console.WriteLine("Error importing team: \n" + e.Message);
				}
			}
			return teams;
		}

		public static List<Stadium> ImportStadia(List<Team> teams) {
			StreamReader reader = new StreamReader(File.OpenRead(Environment.CurrentDirectory + stadiumFile));
			List<Stadium> stadia = new List<Stadium>();
			while (!reader.EndOfStream) {
				string[] stadiumDetails = reader.ReadLine().Split(',');
				try {
					Team homeTeam = teams.Where(x => x.ID == int.Parse(stadiumDetails[2])).FirstOrDefault();
					stadia.Add(new Stadium(int.Parse(stadiumDetails[0]), stadiumDetails[1], homeTeam??new Team(0, "no team found", 0)));
				}
				catch (Exception e) {
					Console.WriteLine("Error importing stadia: \n" + e.Message);
				}
			}
			return stadia;

		}

		public static List<Match> ImportMatches(List<Team> teams, List<Stadium> stadia) {
			StreamReader reader = new StreamReader(File.OpenRead(Environment.CurrentDirectory + matchFile));
			List<Match> matches = new List<Match>();
			while (!reader.EndOfStream) {
				string[] matchDetails = reader.ReadLine().Split(',');
				try {
					Team team1 = teams.Where(x => x.Name == matchDetails[2]).FirstOrDefault();
					Team team2 = teams.Where(x => x.Name == matchDetails[7]).FirstOrDefault();
					Stadium stadium = stadia.Where(x => x.Name == matchDetails[12]).FirstOrDefault();
					matches.Add(new Match(int.Parse(matchDetails[0]), DateTime.Parse(matchDetails[1]), team1, team2, 
						int.Parse(matchDetails[3]), int.Parse(matchDetails[5]), int.Parse(matchDetails[4]), int.Parse(matchDetails[6]), stadium));
				}
				catch (Exception e) {
					Console.WriteLine("Error importing matches: \n" + e.Message);
				}
			}
			return matches;
		}
		#endregion
	}
}
