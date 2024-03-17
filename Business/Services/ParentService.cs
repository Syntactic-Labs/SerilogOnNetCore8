using Business.Interfaces;
using Entities.Responses;

namespace Business.Services;

public class ParentService : IParentService
{   /// <summary>
	///	This method is to just simulate getting data though an id and validation handling approach.
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Parent</returns>
	public async Task<Parent?> GetParent(string id)
	{
		ValidatePayload(id);

		Parent? parent = await Task.Run(() => _parentList.FirstOrDefault(p => p.Id == int.Parse(id)));

		return parent;
	}

	private static void ValidatePayload(string id)
	{
		if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("Parent Id can not be null or empty");
		if (int.TryParse(id, out _) is false) throw new ArgumentException("Parent Id must be numeric");
	}

	private List<Parent> _parentList =
	[
		new Parent
		{
			Id = 1,
			FirstName = "John",
			LastName = "Doe",
			Email = "john.doe@example.com",
			PhoneNumber = "123-456-7890",
			Address = new Address { City = "CityA", State = "StateA", Street = "1234 StreetA", PostalCode = "12345", Country = "CountryA" }
		},
		new Parent
		{
			Id = 2,
			FirstName = "Jane",
			LastName = "Smith",
			Email = "jane.smith@example.com",
			PhoneNumber = "234-567-8901",
			Address = new Address { City = "CityB", State = "StateB", Street = "2345 StreetB", PostalCode = "23456", Country = "CountryB" }
		},
		new Parent
		{
			Id = 3,
			FirstName = "Michael",
			LastName = "Johnson",
			Email = "michael.johnson@example.com",
			PhoneNumber = "345-678-9012",
			Address = new Address { City = "CityC", State = "StateC", Street = "3456 StreetC", PostalCode = "34567", Country = "CountryC" }
		},
		new Parent
		{
			Id = 4,
			FirstName = "Emily",
			LastName = "Williams",
			Email = "emily.williams@example.com",
			PhoneNumber = "456-789-0123",
			Address = new Address { City = "CityD", State = "StateD", Street = "4567 StreetD", PostalCode = "45678", Country = "CountryD" }
		},
		new Parent
		{
			Id = 5,
			FirstName = "David",
			LastName = "Brown",
			Email = "david.brown@example.com",
			PhoneNumber = "567-890-1234",
			Address = new Address { City = "CityE", State = "StateE", Street = "5678 StreetE", PostalCode = "56789", Country = "CountryE" }
		},
		new Parent
		{
			Id = 6,
			FirstName = "Olivia",
			LastName = "Davis",
			Email = "olivia.davis@example.com",
			PhoneNumber = "678-901-2345",
			Address = new Address { City = "CityF", State = "StateF", Street = "6789 StreetF", PostalCode = "67890", Country = "CountryF" }
		},
		new Parent
		{
			Id = 7,
			FirstName = "James",
			LastName = "Miller",
			Email = "james.miller@example.com",
			PhoneNumber = "789-012-3456",
			Address = new Address { City = "CityG", State = "StateG", Street = "7890 StreetG", PostalCode = "78901", Country = "CountryG" }
		},
		new Parent
		{
			Id = 8,
			FirstName = "Isabella",
			LastName = "Wilson",
			Email = "isabella.wilson@example.com",
			PhoneNumber = "890-123-4567",
			Address = new Address { City = "CityH", State = "StateH", Street = "8901 StreetH", PostalCode = "89012", Country = "CountryH" }
		},
		new Parent
		{
			Id = 9,
			FirstName = "Ethan",
			LastName = "Martinez",
			Email = "ethan.martinez@example.com",
			PhoneNumber = "901-234-5678",
			Address = new Address { City = "CityI", State = "StateI", Street = "9012 StreetI", PostalCode = "90123", Country = "CountryI" }
		},
		new Parent
		{
			Id = 10,
			FirstName = "Sophia",
			LastName = "Anderson",
			Email = "sophia.anderson@example.com",
			PhoneNumber = "012-345-6789",
			Address = new Address { City = "CityJ", State = "StateJ", Street = "0123 StreetJ", PostalCode = "01234", Country = "CountryJ" }
		}
	];
}
