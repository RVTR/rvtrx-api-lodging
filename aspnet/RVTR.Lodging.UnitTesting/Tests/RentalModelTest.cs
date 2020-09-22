using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{
  public class RentalModelTest
  {
    public static readonly IEnumerable<object[]> _rentals = new List<object[]>
    {
      new object[]
      {
        new RentalModel()
        {
          Id = 0,
          Status = "status",
          Price = 0.0,
          DiscountedPrice = 0.0,
          LodgingId = 0,
          Lodging = null
        }
      }
    };

    [Theory]
    [MemberData(nameof(_rentals))]
    public void Test_Create_RentalModel(RentalModel rental)
    {
      var validationContext = new ValidationContext(rental);
      var actual = Validator.TryValidateObject(rental, validationContext, null, true);

      Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(_rentals))]
    public void Test_Validate_RentalModel(RentalModel rental)
    {
      var validationContext = new ValidationContext(rental);

      Assert.Empty(rental.Validate(validationContext));
    }
  }
}
