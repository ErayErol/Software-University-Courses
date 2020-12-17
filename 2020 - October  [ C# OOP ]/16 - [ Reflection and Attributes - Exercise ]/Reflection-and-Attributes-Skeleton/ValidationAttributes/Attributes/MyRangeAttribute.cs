namespace ValidationAttributes.Attributes
{
    using System;

    class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateRange(minValue, maxValue);

            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is Int32 value)
            {
                if (value < minValue || value > maxValue)
                {
                    return false;
                }

                return true;
            }
            else
            {
                throw new InvalidOperationException("Invalid data type!");
            }
        }

        private void ValidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
