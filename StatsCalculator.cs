using System;
using System.Collections.Generic;
using System.Text;
using TrackerTreningow;

namespace TrackerTreningow_
{
    public class StatsCalculator
    {
        /// Suma minut wszystkich treningów.
        public static int TotalMinutes(List<Training> list)
        {
            return list.Sum(t => t.Minutes);
        }

        /// Liczba różnych dni, w których był jakikolwiek trening.
        public static int ActiveDays(List<Training> list)
        {
            return list.Select(t => t.Date.Date).Distinct().Count();
        }

        /// Średni czas jednego treningu.
        public static int AverageMinutes(List<Training> list)
        {
            if (list.Count == 0)
            {
                return 0;
            }

            return TotalMinutes(list) / list.Count;
        }

        /// Najdłuższy trening albo null, gdy lista jest pusta.
        public static Training? Longest(List<Training> list)
        {
            return list.OrderByDescending(t => t.Minutes).FirstOrDefault();
        }

        /// Najkrótszy trening albo null, gdy lista jest pusta.
        public static Training? Shortest(List<Training> list)
        {
            return list.OrderBy(t => t.Minutes).FirstOrDefault();
        }

        /// Najczęściej wybierany rodzaj aktywności.
        public static string FavouriteType(List<Training> list)
        {
            if (list.Count == 0)
            {
                return "—";
            }

            return list
                .GroupBy(t => t.Type)
                .OrderByDescending(group => group.Count())
                .First()
                .Key;
        }

        /// Suma minut w każdym dniu, od najstarszego.
        public static List<DayTotal> MinutesPerDay(List<Training> list)
        {
            List<DayTotal> result = new();

            foreach (var group in list.GroupBy(t => t.Date.Date))
            {
                result.Add(new DayTotal
                {
                    Day = group.Key,
                    Minutes = group.Sum(t => t.Minutes)
                });
            }

            return result.OrderBy(d => d.Day).ToList();
        }

        /// Dzień z największą liczbą minut albo null, gdy nie ma danych.
        public static DayTotal? BestDay(List<Training> list)
        {
            return MinutesPerDay(list).OrderByDescending(d => d.Minutes).FirstOrDefault();
        }

        /// Najdłuższa seria następujących po sobie dni z treningiem.
        public static int LongestStreak(List<Training> list)
        {
            List<DateTime> days = list
                .Select(t => t.Date.Date)
                .Distinct()
                .OrderBy(d => d)
                .ToList();

            if (days.Count == 0)
            {
                return 0;
            }

            int best = 1;
            int current = 1;

            for (int i = 1; i < days.Count; i++)
            {
                if (days[i] == days[i - 1].AddDays(1))
                {
                    current = current + 1;
                }
                else
                {
                    current = 1;
                }

                if (current > best)
                {
                    best = current;
                }
            }

            return best;
        }
    }
}