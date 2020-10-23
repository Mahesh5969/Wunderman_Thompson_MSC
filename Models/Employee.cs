using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wunderman_Thompson_MSC_Assessment.Models
{
    public class Employee
    {
		[Key]
		public int EmployeeId { get; set; }

		[Column(TypeName = "nvarchar(200)")]
		[Required(ErrorMessage = "First Name is required.")]
		[MaxLength(20)]
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[Column(TypeName = "nvarchar(200)")]
		[Required(ErrorMessage = "Last Name is required.")]
		[DisplayName("Last Name")]
		[MaxLength(20)]
		public string LastName { get; set; }

		[Column(TypeName = "nvarchar(100)")]
		[Required(ErrorMessage = "Organisation is required.")]
		[MaxLength(50)]
		[DisplayName("Organisation")]
		public string Organisation { get; set; }

		[Column(TypeName = "nvarchar(100)")]
		[EmailAddress(ErrorMessage = "Not a valid email address")]
		[Required(ErrorMessage = "Work email is required.")]
		[DisplayName("Work Email")]
		public string WorkEmail { get; set; }

		[Column(TypeName = "varchar(20)")]
		[Required(ErrorMessage = "Phone Number is required.")]
		[RegularExpression(@"^(\d{10})$", ErrorMessage = " WrongPhone Number ")]
		[DisplayName("Phone Number")]
		public string PhoneNumber { get; set; }

		
		[DisplayName("Build a business case with the Microsoft Technology Center")]
		public string CheckBoxValue1 { get; set; }
		
		[DisplayName("Get hands-on with the Cutomer Immersion Experience")]
		public string CheckBoxValue2 { get; set; }

		
		[DisplayName("Skill-up your IT team")]
		public string CheckBoxValue3 { get; set; }

		
		[DisplayName("Surface trial program")]
		public string CheckBoxValue4 { get; set; }

	
		[DisplayName("Get customised advice and support for your team")]
		public string CheckBoxValue5 { get; set; }

		

		[Column(TypeName = "nvarchar(1000)")]
		[DisplayName("Optional")]
		public string Optional { get; set; }

		[Column(TypeName = "nvarchar(100)")]
		[Required(ErrorMessage = "Industry is required.")]
		[MaxLength(20)]
		[DisplayName("Industry")]
		public string Industry { get; set; }

		[NotMapped]
		public IEnumerable<CheckboxList> AllChckBox { get; set; }

		[NotMapped]
		[DisplayName("Optionl: Please provide some additional context on your organisation's current workplace situation and problems that your're looking to solve.(Max. 500 characters)")]
		public string OptionalText { get; set; }
	}
}
