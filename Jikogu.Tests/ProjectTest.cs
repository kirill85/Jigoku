using NUnit.Framework;
using Jigoku.Core.Entities;
using Jigoku.ORM.Repository;
using System;
using System.Collections.Generic;

namespace Jigoku.Tests
{
	[TestFixture]
	public class ProjectTest
	{
		private Person johnDoe = null;
		private Project stubProject = null;
		private ProjectRepository repository = null;

		[SetUp]
		public void Init()
		{
			johnDoe = new Person { NickName = "JohnDoe", Password = "john" + DateTime.Now.Ticks.ToString(), PrimaryMail = "john@doe.foo", UserPhoto = null };
			repository = new ProjectRepository();
			stubProject = new Project { Name = "SuperDuper", Description = "Super-puper-giga-cool", License = "Beer license", SiteUrl = @"http://foo.site", Tags = "C Python HTML5 jQuery", TrackerUrl = @"http://tracker.foo.site" };
			johnDoe.Projects = new HashSet<Project>();
			johnDoe.Projects.Add(stubProject);
		}

		[Test]
		public void AddProject()
		{
			repository.Add(stubProject);
		}

		[Test]
		public void UpdateProject()
		{
			stubProject.Description = "Minor shkololo project";
			repository.Update(stubProject);
		}

		[Test]
		public void RemoveProject()
		{
			repository.Remove(stubProject);
		}
	}
}
