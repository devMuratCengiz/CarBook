namespace CarBook.WebUI.Areas.Admin.DTOs.CarFeaturesDtos
{
    public class ResultCarFeatureDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool Available { get; set; }
    }
}
