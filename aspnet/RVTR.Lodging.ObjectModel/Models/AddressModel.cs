using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  /// <summary>
  /// Represents the _Address_ model
  /// </summary>
  public class AddressModel : IValidatableObject
  {
    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public string City { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public string Country { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public LocationModel Location { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public string PostalCode { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public string StateProvince { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public string Street { get; set; }

    /// <summary>
    /// Represents the _Address_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}
