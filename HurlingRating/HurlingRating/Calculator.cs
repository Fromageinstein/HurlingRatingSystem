using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurlingRating {
	class Calculator {
		public static void UpdateRatings(Match m, int k) {
			int r1 = m.Team1.CurrentRating;
			int r2 = m.Team2.CurrentRating;

			float e1 = 1f / (1f + (float)Math.Pow(10f,(r2 - r1)/400f));
			float e2 = 1f / (1f + (float)Math.Pow(10f,(r1 - r2)/400f));
			float s1 = m.WinningTeam == 1 ? 1f : m.WinningTeam == -1 ? 0f : 0.5f;
			float s2 = m.WinningTeam == -1 ? 1f : m.WinningTeam == 1 ? 0f : 0.5f;

			m.Team1.CurrentRating = (int)(r1 + (k*(s1 - e1)));
			m.Team1.AddDateRating(new DateRating(m.Date, m.Team1.CurrentRating));
			m.Team2.CurrentRating = (int)(r2 + (k*(s2 - e2)));
			m.Team2.AddDateRating(new DateRating(m.Date, m.Team2.CurrentRating));
		}
	}
}
