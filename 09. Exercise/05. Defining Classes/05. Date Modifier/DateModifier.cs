namespace _02._Date_Modifier
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DateModifier
    {
        public DateModifier(string firstDate, string secondDate)
        {
            this.firstDate = firstDate;
            this.secondDate = secondDate;
        }

        private string firstDate;
        private string secondDate;

        public string FirstDate
        {
            get => firstDate;
            set => firstDate = value;
        }

        public string SecondDate
        {
            get => secondDate;
            set => secondDate = value;
        }

        public int DaysBetweenDates()
        {
            var tokens = this.FirstDate
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var dateYears = int.Parse(tokens[0]);
            var dateMonts = int.Parse(tokens[1]);
            var dateDays = int.Parse(tokens[2]);

            var currentFirstDate = new DateTime(dateYears, dateMonts, dateDays);

            tokens = this.SecondDate
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            dateYears = int.Parse(tokens[0]);
            dateMonts = int.Parse(tokens[1]);
            dateDays = int.Parse(tokens[2]);

            var currentSeconDate = new DateTime(dateYears, dateMonts, dateDays);

            return (int)Math.Floor(Math.Abs((currentFirstDate - currentSeconDate).TotalDays));
        }
    }   
}
