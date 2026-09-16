using System;
using System.Collections.Generic;
using System.Text;
using TrackerTreningow;

namespace TrackerTreningow_.Managers
{
    public class BadgeService
    {
        private readonly JsonStore<Badge> _store;
        private List<Badge> _earned;

        public BadgeService(JsonStore<Badge> store)
        {
            _store = store;
            _earned = _store.Load();
        }

        public List<Badge> Earned { get { return _earned; } }

        public List<Badge> Check(List<Training> trainings)
        {
            List<Badge> fresh = new();

            foreach (Badge badge in BadgeList.All)
            {       
                if (_earned.Any(b => b.Code == badge.Code))
                {
                    continue;
                }

                if (!IsEarned(badge.Code, trainings))
                {
                    continue;
                }

                Badge zdobyta = new()
                {
                    Code = badge.Code,
                    Name = badge.Name,
                    Description = badge.Description,
                    EarnedAt = DateTime.Now
                };

                _earned.Add(zdobyta);
                fresh.Add(zdobyta);
            }

            if (fresh.Count > 0)
            {
                _store.Save(_earned);
            }

            return fresh;
        }

        private static bool IsEarned(string code, List<Training> trainings)
        {
            switch (code)
            {
                case "first":
                    return trainings.Count >= 1;

                case "ten":
                    return trainings.Count >= 10;

                case "fifty":
                    return trainings.Count >= 50;

                case "long":
                    return trainings.Any(t => t.Minutes > 120);

                case "streak7":
                    return StatsCalculator.LongestStreak(trainings) >= 7;

                case "variety":
                    return trainings.Select(t => t.Type).Distinct().Count() >= 4;

                case "weekend":
                    return trainings.Count(t =>
                        t.Date.DayOfWeek == DayOfWeek.Saturday ||
                        t.Date.DayOfWeek == DayOfWeek.Sunday) >= 5;

                case "month1000":
                    return StatsCalculator.BestMonthMinutes(trainings) >= 1000;

                default:
                    return false;
            }
        }
    
    
    }
}
