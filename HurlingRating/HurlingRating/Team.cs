﻿using System;
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
	}
}
