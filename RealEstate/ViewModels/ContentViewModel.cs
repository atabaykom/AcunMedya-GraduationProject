
using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RealEstate.ViewModels
{
    public class ContentViewModel
    {
		public int ID { get; set; }
		public int CategoryID { get; set; }
		public int ContentOwnerID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int NetSquareMeters { get; set; }
		public int GrossSquareMeters { get; set; }
		public int Price { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Town { get; set; }
		public string Adress { get; set; }
		public string NumberOfRooms { get; set; }
		public string ContentFrom { get; set; }
		public string ContentType { get; set; }
		public int AgeOfBuilding { get; set; }
		public int FloorNumber { get; set; }
		public int NumberOfFloors { get; set; }
		public string Heating { get; set; }
		public int NumberOfBathrooms { get; set; }
		public bool Balcony { get; set; }
		public bool Elevator { get; set; }
		public string ParkingArea { get; set; }
		public bool Exchangeable { get; set; }
		public int Dues { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsActive { get; set; }
        public List<FirmDoc> firmDocs { get; set; }
        public List<FilterViewModel> filterViewModels { get; set; }
    }
}
