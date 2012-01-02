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
		private Person john = null;
		private Person mary = null;
		private PrivateMessage pm = null;
		private PrivateMessageRepository repository = null;

		[SetUp]
		public void Init()
		{
			john = new Person { NickName = "John_Intangible", Password = "Noneeded", PrimaryMail = "john@wide.pocket" };
			mary = new Person { NickName = "Mary_Shoulder", Password = "Sanctum_Marcus", PrimaryMail = "mary@big.boobs" };
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
		}
	}
}
