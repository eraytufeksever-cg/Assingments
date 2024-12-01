namespace Assignments
{
    public static class MyFilter
    {
        public static IEnumerable<double> Filter(
            IEnumerable<double?> input,
            double? lowerLimit,
            double? upperLimit,
            double? divisor,
            out double average,
            out double standardDeviation)
        {
            average = double.NaN;
            standardDeviation = double.NaN;

            if (input == null || !input.Any())
                return Enumerable.Empty<double>();

            double validDivisor = divisor ?? 1;
            if (validDivisor == 0)
                return Enumerable.Empty<double>();


            try
            {
                var filtered = input
                           .Where(x => x.HasValue)
                           .Select(x => x.Value / validDivisor)
                           .Where(x => (!lowerLimit.HasValue || x >= lowerLimit.Value) &&
                                       (!upperLimit.HasValue || x <= upperLimit.Value))
                           .ToList();


                if (!filtered.Any())
                    return Enumerable.Empty<double>();

                average = filtered.Average();
                double localAverage = average;
                double sumOfSquares = filtered.Sum(x => Math.Pow(x - localAverage, 2));

                if (filtered.Count > 1)
                {
                    standardDeviation = Math.Sqrt(sumOfSquares / (filtered.Count - 1));
                }
                else
                {
                    standardDeviation = 0;
                }
                return filtered;
            }
            catch
            {
                return Enumerable.Empty<double>();
            }
        }
    }
}
