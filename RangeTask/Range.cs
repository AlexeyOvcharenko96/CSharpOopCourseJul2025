namespace RangeTask
{
    internal class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range? GetIntersection(Range range)
        {
            if (range.To <= From || To <= range.From)
            {
                return null;
            }

            double maxFrom = Math.Max(From, range.From);
            double minTo = Math.Min(To, range.To);

            return new Range(maxFrom, minTo);
        }

        public Range[] GetUnion(Range range)
        {
            if (range.To < From || To < range.From)
            {
                return new Range[] { new(From, To), new(range.From, range.To) };
            }

            double minFrom = Math.Min(From, range.From);
            double maxTo = Math.Max(To, range.To);

            return new Range[] { new(minFrom, maxTo) };
        }

        public Range[] GetDifference(Range range)
        {
            if (range.From > To || range.To < From)
            {
                return new Range[] { new(From, To) };
            }

            if (range.From <= From && To <= range.To)
            {
                return new Range[] { };
            }

            if (From < range.From && To > range.To)
            {
                return new Range[] { new(From, range.From), new(range.To, To) };
            }

            if (To <= range.To)
            {
                return new Range[] { new(From, range.From) };
            }

            return new Range[] { new(range.To, To) };
        }
    }
}