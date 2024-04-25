namespace MeasurementsLib
{
    public class Measurements
    {
        public int id { get; set; }
        public int ppm { get; set; }

        public override string ToString() => $"{id} {ppm}";

        public void ValidatePPM()
        {
            if(ppm < 0 ||  ppm > 1000)
            {
                throw new ArgumentOutOfRangeException("ppm must be between 0 and 1000");
            }
            if(ppm > 0 || ppm < 1000)
            {
                throw new ArgumentException("ppm is valid");
            }
        }
        
        public void Validate()
        {
            ValidatePPM();
        }
    }
}
