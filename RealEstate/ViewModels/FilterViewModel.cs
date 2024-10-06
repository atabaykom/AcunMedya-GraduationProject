using EntityLayer.Concrete;

namespace RealEstate.ViewModels
{
    public class FilterViewModel
    {
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public int? NetSquareMeters { get; set; }
        public int? priceMax { get; set; }
        public int? priceMin { get; set; }
        public int? maxm2 { get; set; }
        public int? minm2 { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Town { get; set; }
        public string? NumberOfRooms { get; set; }
        public string? ContentFrom { get; set; }
        public string? ContentType { get; set; }
        public int? AgeOfBuilding { get; set; }
        public int? FloorNumber { get; set; }
        public int? NumberOfFloors { get; set; }
        public string? Heating { get; set; }
        public int? NumberOfBathrooms { get; set; }
        public bool? Balcony { get; set; }
        public bool? Elevator { get; set; }
        public string? ParkingArea { get; set; }
        public bool? Exchangeable { get; set; }
        public int? maxDues { get; set; }
        public int? minDues { get; set; }
    }
}
