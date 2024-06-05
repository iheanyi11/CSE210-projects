using System;

// Base class for all activities
    public abstract class Activity
    {
        protected DateTime _date;
        protected int _minutes;

        public Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public virtual double GetDistance()
        {
            return 0;
        }

        public virtual double GetSpeed()
        {
            return 0;
        }

        public virtual double GetPace()
        {
            return 0;
        }

        public virtual string GetSummary()
        {
            return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_minutes} min): Distance {GetDistance():F1}, Speed {GetSpeed():F1}, Pace {GetPace():F1}";
        }
    }