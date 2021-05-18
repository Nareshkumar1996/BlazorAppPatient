using System;
using System.Globalization;

namespace Healthware.Assist.Core.Utility
{
    public class Year
    {
        public int year { get; private set; }

        protected Year() : this(Clock.Now())
        {
        }

        public Year(Date date)
        {
            year = date.Year;
        }

        public Year Minus(int years)
        {
            return new Year(new DateTime(year - years, 01, 01));
        }

        public bool IsBefore(Year other_year)
        {
            return year.CompareTo(other_year.year) < 0;
        }

        public static implicit operator Year(DateTime date)
        {
            return new Year(date);
        }

        public static implicit operator Year(int year)
        {
            return new Year(new DateTime(year, 1, 1));
        }

        public static implicit operator Date(Year the_year)
        {
            return new DateTime(the_year.year, 1, 1);
        }

        public override string ToString()
        {
            return year.ToString(CultureInfo.InvariantCulture);
        }

        public bool Equals(Year obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.year == year;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Year)) return false;
            return Equals((Year) obj);
        }

        public override int GetHashCode()
        {
            return year;
        }
    }
}