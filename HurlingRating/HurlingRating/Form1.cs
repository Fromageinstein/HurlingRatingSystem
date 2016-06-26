using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HurlingRating {
	public partial class Form1 : Form {
		private List<Team> teams;
		private List<Stadium> stadia;
		private List<Match> matches;
		public Form1() {
			InitializeComponent();
		}

		private void run(object sender, EventArgs e) {
			ImportAll();
			CalculateHomeWins();
		}

		private void ImportAll() {
			teams = ObjectImporter.ImportTeams();
			stadia = ObjectImporter.ImportStadia(teams);
			matches = ObjectImporter.ImportMatches(teams, stadia);
		}

		private void OutputAllDetails() {
			foreach (Team t in teams) {
				outputText.AppendText(t.ID + "\t" + t.Name + "\t" + t.InitialRating);
				outputText.AppendText(Environment.NewLine);
			}
			outputText.AppendText(Environment.NewLine);

			foreach (Stadium s in stadia) {
				outputText.AppendText(s.ID + "\t" + s.Name + "\t" + s.HomeTeam.Name);
				outputText.AppendText(Environment.NewLine);
			}
			outputText.AppendText(Environment.NewLine);

			foreach (Match m in matches) {
				string stadiumName = stadia.Where(x => x.ID == m.MatchStadium.ID).FirstOrDefault().Name;
				outputText.AppendText(m.ID + "\t" + m.Team1.Name + "\t" + m.Team2.Name + "\t" + m.HomeTeam + "\t" + stadiumName);
				outputText.AppendText(Environment.NewLine);
			}
		}

		private void CalculateHomeWins() {
			int totalGames = 0;
			int homeGames = 0;
			int homeWins = 0;
			int homeDraws = 0;
			int homeLosses = 0;
			foreach(Match m in matches) {
				totalGames++;
				if (m.HomeTeam != 0)
					homeGames++;
				if (m.WinningTeam == 0)
					homeDraws++;
				else if ((m.HomeTeam == 1 && m.WinningTeam == 1) || (m.HomeTeam == -1 && m.WinningTeam == -1))
					homeWins ++;
				else if((m.HomeTeam == 1 && m.WinningTeam == -1) || (m.HomeTeam == -1 && m.WinningTeam == 1))
					homeLosses ++;
			}
			outputText.AppendText("Total Games = " + totalGames + Environment.NewLine + "Home Games = " + homeGames + Environment.NewLine + 
									"Home Wins = " + homeWins + Environment.NewLine + "Home Draws = " + homeDraws + Environment.NewLine + 
									"Home Losses = " + homeLosses + Environment.NewLine + "Home win % = " + (float)homeWins/(float)homeGames);
		}
	}
}
