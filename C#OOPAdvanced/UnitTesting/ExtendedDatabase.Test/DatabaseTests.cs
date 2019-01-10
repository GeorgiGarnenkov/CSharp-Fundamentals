using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace ExtendedDatabase.Test
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private PropertyInfo propertyInfo;
        private List<Person> peoplesInDatabase;

        [SetUp]
        public void DatabaseReflection()
        {
            this.database = new Database();

            FieldInfo fieldInfo = typeof(Database)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(fi => fi.FieldType == typeof(List<Person>));

        }

        [Test]
        public void TestValidDatabaseConstructor()
        {
            //Arrange..

            //Act..

            // Assert..
        }
    }
}
