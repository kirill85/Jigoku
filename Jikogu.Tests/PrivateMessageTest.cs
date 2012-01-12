using System;
using System.Collections.Generic;
using NUnit.Framework;
using Jigoku.Core.Entities;
using Jigoku.ORM.Repository;


namespace Jigoku.Tests
{
	[TestFixture]
	public class PrivateMessageTest
	{
#region Persons
		private Person john = null;
		private Person mary = null;
#endregion
#region Repositories
		private PrivateMessage pm = null;
		private PrivateMessageRepository repository = null;
#endregion
		[SetUp]
		[Test]
		public void Init()
		{
			john = new Person { NickName = "John_Intangible", Password = "Noneeded", PrimaryMail = "john@wide.pocket", UserPhoto = null, Projects = null };
			mary = new Person { NickName = "Mary_Shoulder", Password = "Sanctum_Marcus", PrimaryMail = "mary@big.boobs", Projects = null, UserPhoto = null };
			pm = new PrivateMessage { PersonFrom = john, PersonTo = mary, Topic = "Mariage", Body = "I love you, Mary. Be my wife", DateSend = DateTime.Now, Attachment = null };
			repository = new PrivateMessageRepository();
		}

		[Test]
		public void AddPMTest()
		{
			repository.Add(pm);
		}

		[Test]
		public void RemovePMTest()
		{
			repository.Remove(pm);
			pm = null;
		}
	}
}
