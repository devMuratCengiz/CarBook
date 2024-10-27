namespace CarBook.WebUI.Areas.Admin.DTOs.CarFeaturesDtos
{
    public class CreateCarFeatureDto
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
