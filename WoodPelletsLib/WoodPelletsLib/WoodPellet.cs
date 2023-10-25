namespace WoodPelletsLib
{
    public class WoodPellet
    {
        #region instnce field
        private string _brand;
        private double _price;
        private int _quality;
        #endregion

        #region properties
        public int Id { get; set; }
        public string Brand
        {
            get => _brand;
            set
            {
              if (!string.IsNullOrEmpty(value) && value.Length >= 2) //checks whether the value is no null and greater than or equal to two.
                {
                    _brand = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"");
                }
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if( value > 0) //checks whether the value is positive
                {
                    _price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"");
                }
            }
        }

        public int Quality
        {
            get => _quality;
            set
            {
                if (value >= 1 && value <= 5) //checks whether the value is in the interval of [1-5]
                {
                    _quality = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"");
                }
            }
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return $"ID: {Id}, Brand: {Brand}, Price: {Price}, Quality: {Quality}";
        }
        #endregion
    }
}