using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DatabaseExercise;
using NUnit.Framework;

[TestFixture]
public class DatabaseTests
{
    [Test]
    [TestCase(new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 4, 5, 2, 2 })]
    [TestCase(new int[] { })]
    [TestCase(new int[] { -2, -6, -20, 5, 9, 8 })]
    public void TestValidConstructor(int[] values)
    {
        // Arrange..
        Database database = new Database(values);

        // Act..
        FieldInfo fieldInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int[]));

        int[] fieldValues = (int[])fieldInfo.GetValue(database);
        int[] buffer = new int[fieldValues.Length - values.Length];

        // Assert..
        Assert.That(fieldValues, Is.EquivalentTo(values.Concat(buffer)));

    }

    [Test]
    public void TestInvalidConstructor()
    {
        // Arrange..
        int[] values = new int[17];

        // Assert..
        Assert.That(() => new Database(values), Throws.InvalidOperationException);
    }

    [Test]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    [TestCase(-20)]
    [TestCase(500)]
    [TestCase(0)]
    public void TestAddMethodValid(int value)
    {
        // Arrange..
        Database db = new Database();

        // Act..
        db.Add(value);

        FieldInfo valuesInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int[]));
        FieldInfo currentIndexInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int));

        int firstValue = ((int[])valuesInfo.GetValue(db)).First();
        int valuesCount = (int)currentIndexInfo.GetValue(db);

        // Assert..
        Assert.That(firstValue, Is.EqualTo(value));
        Assert.That(valuesCount, Is.EqualTo(1));
    }

    [Test]
    public void TestAddMethodInvalid()
    {
        Database db = new Database();

        FieldInfo currentIndexInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int));

        currentIndexInfo.SetValue(db, 16);

        Assert.That(() => db.Add(1), Throws.InvalidOperationException);
    }

    [Test]
    [TestCase(new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 4, 5, 2, 2 })]
    [TestCase(new int[] { -2, -6, -20, 5, 9, 8 })]
    public void TestRemoveMethodValid(int[] values)
    {
        Database db = new Database();

        FieldInfo fieldInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int[]));

        fieldInfo.SetValue(db, values);

        FieldInfo currentIndexInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int));

        currentIndexInfo.SetValue(db, values.Length);

        db.Remove();

        int[] actualValues = (int[])fieldInfo.GetValue(db);
        int[] buffer = new int[actualValues.Length - (values.Length - 1)];

        values = values
            .Take(values.Length - 1)
            .Concat(buffer)
            .ToArray();

        Assert.That(actualValues, Is.EquivalentTo(values));
    }

    [Test]
    public void TestRemoveMethodInvalid()
    {
        Database db = new Database();

        FieldInfo currentIndexInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int));

        currentIndexInfo.SetValue(db, 0);

        Assert.That(() => db.Remove(), Throws.InvalidOperationException);
    }

    [Test]
    [TestCase(new int[] { 1, 2, 3, 4, 5 })]
    [TestCase(new int[] { 4, 5, 2, 2 })]
    [TestCase(new int[] { -2, -6, -20, 5, 9, 8 })]
    public void TestFetchMethodValid(int[] values)
    {
        Database db = new Database();

        FieldInfo fieldInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(fi => fi.FieldType == typeof(int[]));

        fieldInfo.SetValue(db, values);

        db.Fetch();

        int[] actualValues = (int[])fieldInfo.GetValue(db);
    
        Assert.That(actualValues, Is.EquivalentTo(values));
    }
}