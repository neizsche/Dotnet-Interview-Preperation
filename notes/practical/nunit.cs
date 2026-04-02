using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq; // Requires Moq library

namespace TestingLab
{
	// ==========================================
	// 1. THE BUSINESS LOGIC (Code to be tested)
	// ==========================================
	// We use an interface so we can "Mock" the database
	public interface IDatabase
	{
		bool SaveUser(string name);
	}

	public class UserManager
	{
		private readonly IDatabase _db;
		public UserManager(IDatabase db) => _db = db;
		public string CreateUser(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Name cannot be empty");
			bool success = _db.SaveUser(name);
			return success ? $"User {name} Created" : "Save Failed";
		}
	}

	// ==========================================
	// 2. THE UNIT TESTS (NUnit + Moq)
	// ==========================================
	[TestFixture]
	public class UserManagerTests
	{
		private Mock<IDatabase> _mockDb;
		private UserManager _userManager;
		[SetUp]
		public void Setup()
		{
			// Create a "Fake" version of the database
			_mockDb = new Mock<IDatabase>();
			// Inject the fake database into our real class (Dependency Injection)
			_userManager = new UserManager(_mockDb.Object);
		}

		[Test]
		public void CreateUser_ValidName_ReturnsSuccessMessage()
		{
			// ARRANGE
			string testName = "Jordan";
			// Tell the mock exactly how to behave: "When SaveUser is called with any string, return true"
			_mockDb.Setup(db => db.SaveUser(It.IsAny<string>())).Returns(true);
			// ACT
			var result = _userManager.CreateUser(testName);
			// ASSERT
			Assert.That(result, Is.EqualTo("User Jordan Created"));
			// VERIFY: This proves the code actually called the database!
			_mockDb.Verify(db => db.SaveUser(testName), Times.Once);
		}

		[Test]
		public void CreateUser_EmptyName_ThrowsException()
		{
			// Asserting that an error is thrown for bad input
			Assert.Throws<ArgumentException>(() => _userManager.CreateUser(""));
		}

		[Test]
		public void CreateUser_DatabaseFails_ReturnsFailureMessage()
		{
			// ARRANGE: Simulate a database crash/failure
			_mockDb.Setup(db => db.SaveUser(It.IsAny<string>())).Returns(false);
			// ACT
			var result = _userManager.CreateUser("Alex");
			// ASSERT
			Assert.That(result, Is.EqualTo("Save Failed"));
		}
	}
}