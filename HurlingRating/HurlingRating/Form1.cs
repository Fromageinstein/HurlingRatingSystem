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
			if (int.Parse(KValue.Text) <= 0)
				for (int i = 1; i < 128; i++)
					RunThroughMatches(i, false, false, true);
			else
				RunThroughMatches(int.Parse(KValue.Text), true, true, true);
		}

		private void RunThroughMatches(int kValue, bool outputMatches, bool outputTeamResults, bool outputKResults) {
			int matchTotal = 0;
			float matchCorrectPrediction = 0;
			foreach(Match m in matches) {
				if ((m.WinningTeam == -1 && m.Team1.CurrentRating > m.Team2.CurrentRating) || (m.WinningTeam == 1 && m.Team1.CurrentRating > m.Team2.CurrentRating))
					matchCorrectPrediction++;
				if (m.WinningTeam == 0)
					matchCorrectPrediction++;
				Calculator.UpdateRatings(m, kValue);
				if(outputMatches)
					OutputText.AppendText(String.Format("{0} {1} {2} - {3} {4}\n", m.Date, m.Team1.Name, m.Team1.CurrentRating, m.Team2.Name, m.Team2.CurrentRating));
				matchTotal++;
			}
			if (outputTeamResults) {
				OutputText.AppendText("\n");
				foreach (Team t in teams) {
					OutputText.AppendText(String.Format("{0} {1} {2}\n", t.Name, t.InitialRating, t.CurrentRating));
				}
			}
			if(outputKResults)
				OutputText.AppendText(String.Format("K value: {0} Correct: {1} Total: {2} Percent: {3}\n", kValue, matchCorrectPrediction, matchTotal, (float)matchCorrectPrediction / (float)matchTotal));
		}

		private void ImportAll() {
			teams = ObjectImporter.ImportTeams();
			stadia = ObjectImporter.ImportStadia(teams);
			matches = ObjectImporter.ImportMatches(teams, stadia);
		}

		private void OutputAllDetails() {
			foreach (Team t in teams) {
				OutputText.AppendText(t.ID + "\t" + t.Name + "\t" + t.InitialRating);
				OutputText.AppendText(Environment.NewLine);
			}
			OutputText.AppendText(Environment.NewLine);

			foreach (Stadium s in stadia) {
				OutputText.AppendText(s.ID + "\t" + s.Name + "\t" + s.HomeTeam.Name);
				OutputText.AppendText(Environment.NewLine);
			}
			OutputText.AppendText(Environment.NewLine);

			foreach (Match m in matches) {
				string stadiumName = stadia.Where(x => x.ID == m.MatchStadium.ID).FirstOrDefault().Name;
				OutputText.AppendText(m.ID + "\t" + m.Team1.Name + "\t" + m.Team2.Name + "\t" + m.HomeTeam + "\t" + stadiumName);
				OutputText.AppendText(Environment.NewLine);
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
			OutputText.AppendText("Total Games = " + totalGames + Environment.NewLine + "Home Games = " + homeGames + Environment.NewLine + 
									"Home Wins = " + homeWins + Environment.NewLine + "Home Draws = " + homeDraws + Environment.NewLine + 
									"Home Losses = " + homeLosses + Environment.NewLine + "Home win % = " + (float)homeWins/(float)homeGames);
		}

		//Prevent anything other than integers being entered
		private void KValue_KeyPress(object sender, KeyPressEventArgs e) {
			if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
				e.Handled = true;
		}
	}
}
