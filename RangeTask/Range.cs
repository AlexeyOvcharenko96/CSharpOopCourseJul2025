using static System.Collections.Specialized.BitVector32;

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

        public Range GetIntersection(Range range)
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
                Range range1 = new(From, To);
                Range range2 = new(range.From, range.To);

                return new Range[2] { range1, range2 };
            }

            double minFrom = Math.Min(From, range.From);
            double maxTo = Math.Max(To, range.To);
            Range rangesUnion = new(minFrom, maxTo);

            return new Range[1] { rangesUnion };
        }

        public Range[] GetDiffirence(Range range)
        {
            if (range.To <= From || To <= range.From)
            {
                Range rangesDifference = new(From, To);

                return new Range[1] { rangesDifference };
            }

            if ((range.From < To && range.From != From) && range.To >= To)
            {
                Range rangesDifference = new(From, range.From);

                return new Range[1] { rangesDifference };
            }

            if (range.From <= From && (range.To > From && range.To != To))
            {
                Range rangesDifference = new(range.To, To);

                return new Range[1] { rangesDifference };
            }

            if ((range.From > From && range.From < To) && (range.To > From && range.To < To))
            {
                Range rangesDifference1 = new(From, range.From);
                Range rangesDifference2 = new(range.To, To);

                return new Range[2] { rangesDifference1, rangesDifference2 };
            }

            return null;
        }
    }
}