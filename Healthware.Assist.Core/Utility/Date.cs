using System;
using System.Globalization;
using Healthware.Assist.Core.Extensions;

namespace Healthware.Assist.Core.Utility
{
    public class Date : IComparable
    {
        public DateTime date { get; private set; }

        protected Date() : this(Clock.Now())
        {
        }

        public Date(DateTime date)
        {
            this.date = DateTime.SpecifyKind(date.Date, DateTimeKind.Utc);
        }

        public bool IsAfter(Date other)
        {
            return date.CompareTo(other.date) > 0;
        }

        public int Year
        {
            get { return date.Year; }
        }
        
        public DateTime GetPastMonthsDate(int months)
        {
            return date.AddMonths(-1*months); 
        }
        
        public static implicit operator Date(DateTime date_time)
        {
            return new Date(date_time);
        }

        public static implicit operator DateTime(Date date)
        {
            return date.date;
        }

        public static implicit operator Year(Date date)
        {
            return date.date;
        }

        public static implicit operator Date(string date_time_string)
        {
            if (date_time_string.IsNullOrEmpty())
            {
                return new Date(DateTime.MaxValue);
            }
            try
            {
                return Convert.ToDateTime(date_time_string, CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("the value of the string is: {0}".FormatWith(date_time_string),
                                            "date_time_string", e);
            }
        }

        public static implicit operator string(Date the_date)
        {
            return null == the_date ? string.Empty : the_date.ToString();
        }

        public override string ToString()
        {
            return DateTime.MaxValue.Date.Equals(date)
                       ? string.Empty
                       : date.ToString("dd'/'MM'/'yyyy");
        }

        public int CompareTo(object obj)
        {
            return date.CompareTo(obj);
        }

        public Date AddDays(int days)
        {
            return new Date(date.AddDays(days));
        }

        public Date Minus(int days)
        {
            return AddDays(-days);
        }

        public bool Equals(Date obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.date.Equals(date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Date)) return false;
            return Equals((Date) obj);
        }

        public override int GetHashCode()
        {
            return date.GetHashCode();
        }
    }
}