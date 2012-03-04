using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jigoku.Models
{
	public class Person : Jigoku.Core.Entities.Person
	{
		public string PairPassword { get; set; }
	}
}