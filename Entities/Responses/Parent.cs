﻿namespace Entities.Responses;

public class Parent
{
	public int Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public Address? Address { get; set; }
	public string? Email { get; set; }
	public string? PhoneNumber { get; set; }
}
