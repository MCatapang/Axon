#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Axon.Models;

public class Contact
{
    public string EmailAddress { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Message { get; set; }
}