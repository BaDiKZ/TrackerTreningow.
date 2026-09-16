using System;
using System.Collections.Generic;
using System.Text;

namespace TrackerTreningow_
{
    public static class BadgeList
    {
        public static readonly List<Badge> All = new()
        {
            new Badge { Code = "first",     Name = "Pierwszy krok",
                        Description = "Zapisz swój pierwszy trening" },

            new Badge { Code = "ten",       Name = "Dziesiątka",
                        Description = "Zapisz 10 treningów" },

            new Badge { Code = "fifty",     Name = "Pięćdziesiątka",
                        Description = "Zapisz 50 treningów" },

            new Badge { Code = "long",      Name = "Długi dystans",
                        Description = "Trening dłuższy niż 120 minut" },

            new Badge { Code = "streak7",   Name = "Tydzień w rytmie",
                        Description = "7 dni z rzędu z treningiem" },

            new Badge { Code = "variety",   Name = "Wszechstronny",
                        Description = "Cztery różne rodzaje aktywności" },

            new Badge { Code = "weekend",   Name = "Weekendowiec",
                        Description = "Pięć treningów w sobotę lub niedzielę" },

            new Badge { Code = "month1000", Name = "Tysiąc minut",
                        Description = "1000 minut w jednym miesiącu" }
        };
    }
}
