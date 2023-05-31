namespace Common.DTOs.AddressDto
{
    public class AddressGet
    {

        public int Id { get; set; }
        public string Street { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string? Phone { get; set; }

    }
}