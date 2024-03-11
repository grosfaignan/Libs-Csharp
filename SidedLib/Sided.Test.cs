using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sided;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
namespace Sided.Test
{
	[TestClass]
	public class SidedUnitaryTest
	{

		[TestMethod]
		public void TestSetLeft()
		{
			// Arrange
			var sided = new Sided<int>();
			int expectedValue = 42;

			// Act
			sided.Left.Side = expectedValue;

			// Assert
			Assert.AreEqual(expectedValue, sided.Left.Side);
		}
		[TestMethod]
		public void TestGetLeft()
		{
			// Arrange
			var sided = new Sided<int>();
			int expectedValue = 42;
			sided.Left.Side = expectedValue;

			// Act
			int actualValue = sided.Left.Side;

			// Assert
			Assert.AreEqual(expectedValue, actualValue);
		}
		[TestMethod]
		public void TestSetRight()
		{
			// Arrange
			var sided = new Sided<int>();
			int expectedValue = 42;

			// Act
			sided.Right.Side = expectedValue;

			// Assert
			Assert.AreEqual(expectedValue, sided.Right.Side);
		}

		[TestMethod]
		public void TestGetRight()
		{
			// Arrange
			var sided = new Sided<int>();
			int expectedValue = 42;
			sided.Right.Side = expectedValue;

			// Act
			int actualValue = sided.Right.Side;

			// Assert
			Assert.AreEqual(expectedValue, actualValue);
		}

		[TestMethod]
		public void TestSetBothWithTwoParameters()
		{
			// Arrange
			var leftValue = 42;
			var rightValue = 24;
			var sided = new Sided<int>();

			// Act
			sided.SetBoth(leftValue, rightValue);

			// Assert
			Assert.AreEqual(leftValue, sided.Left.Side);
			Assert.AreEqual(rightValue, sided.Right.Side);
		}

		[TestMethod]
		public void TestSetSideWithLeft()
		{
			// Arrange
			var sided = new Sided<int>();
			var left = new Left<int>();
			int expectedValue = 42;
			left.Side = expectedValue;

			// Act
			sided.SetSide(left);

			// Assert
			Assert.AreSame(left, sided.Left);
			Assert.AreEqual(expectedValue, sided.Left.Side);
		}
		[TestMethod]
		public void TestSetSideWithRight()
		{
			// Arrange
			var sided = new Sided<int>();
			var right = new Right<int>();
			int expectedValue = 42;
			right.Side = expectedValue;

			// Act
			sided.SetSide(right);

			// Assert
			Assert.AreSame(right, sided.Right);
			Assert.AreEqual(expectedValue, sided.Right.Side);
		}

		[TestMethod]
		public void TestSidedHandlesNullValues()
		{
			// Arrange
			Sided<string> sided = new Sided<string>(null, "RightValue");

			// Act
			string leftValue = sided.Left.Side;
			string rightValue = sided.Right.Side;

			// Assert
			Assert.IsNull(leftValue);
			Assert.IsNotNull(rightValue);
			Assert.AreEqual("RightValue", rightValue);
		}


		[TestMethod]
		public void TestDefaultConstructor()
		{
			// Arrange
			var sided = new Sided<int>();

			// Act
			var leftValue = sided.Left.Side;
			var rightValue = sided.Right.Side;

			// Assert
			Assert.AreEqual(default(int), leftValue);
			Assert.AreEqual(default(int), rightValue);
		}
		[TestMethod]
		public void TestConstructorWithSingleParameter()
		{
			// Arrange
			var leftExpectedValue = 42;
			var rightExpectedValue = 24;
			var sided = new Sided<int>(leftExpectedValue, rightExpectedValue);

			// Act
			var leftValue = sided.Left.Side;
			var rightValue = sided.Right.Side;

			// Assert
			Assert.AreEqual(leftExpectedValue, leftValue);
			Assert.AreEqual(rightExpectedValue, rightValue);
		}

		[TestMethod]
		public void TestConstructorWithTwoParameters()
		{
			// Arrange
			var leftValue = 42;
			var rightValue = 24;
			var sided = new Sided<int>(leftValue, rightValue);

			// Act
			var actualLeftValue = sided.Left.Side;
			var actualRightValue = sided.Right.Side;

			// Assert
			Assert.AreEqual(leftValue, actualLeftValue);
			Assert.AreEqual(rightValue, actualRightValue);
		}


		/// <summary>
		/// Immutability test
		/// </summary>
		[TestMethod]
		public void Set_ShouldCreateNewInstanceOfImmutableValue()
		{
			// Arrange
			var expectedLeftValue = "new value";
			var sided = new Sided<string>("original value", "croundave");

			// Act
			sided.Left.Side = expectedLeftValue;

			// Assert
			Assert.AreNotSame(sided.Left.Side, "original value");
			Assert.AreEqual(sided.Left.Side, expectedLeftValue);
		}

		// 
		[TestMethod]
		public void Get_ShouldReturnSameInstanceOfImmutableValue()
		{
			// Arrange
			var expectedLeftValue = "new value";
			var sided = new Sided<string>("original value", "croundave");

			// Act
			var left = sided.Left.Side;
			sided.Left.Side = expectedLeftValue;
			var left1 = sided.Left.Side;
			sided.Left.Side = expectedLeftValue;
			var left2 = sided.Left.Side;

			// Assert
			Assert.AreNotSame(left, left1);
			Assert.AreNotEqual(left, left1);
			Assert.AreSame(left1, left2);
			Assert.AreEqual(left1, expectedLeftValue);
		}

		[TestMethod]
		public void SetBoth_ShouldCreateNewInstancesOfImmutableValues()
		{
			// Arrange
			var expectedLeftValue = "new left value";
			var expectedRightValue = "new right value";
			var sided = new Sided<string>("original left value", "original right value");

			// Act
			sided.SetBoth(expectedLeftValue, expectedRightValue);

			// Assert
			Assert.AreNotSame(sided.Left.Side, "original left value");
			Assert.AreNotSame(sided.Right.Side, "original right value");
			Assert.AreEqual(sided.Left.Side, expectedLeftValue);
			Assert.AreEqual(sided.Right.Side, expectedRightValue);
		}

		/// <summary>
		/// Test over Collections type
		/// </summary>
		[TestMethod]
		public void TestSetBothWithCollection()
		{
			// Arrange
			var sided = new Sided<List<int>>();
			var left = new List<int> { 1, 2, 3, 4, 5 };
			var right = new List<int> { 2, 12, 27, 5, 4, 15 };


			// Act
			sided.SetBoth(left, right);

			// Assert
			for (int i = 0; i < left.Count; i++)
			{
				Assert.AreEqual(left[i], sided.Left.Side.ElementAt(i));
			}

			for (int i = 0; i < right.Count; i++)
			{
				Assert.AreEqual(right[i], sided.Right.Side.ElementAt(i));
			}
		}

		[TestMethod]
		public void TestSetWithCollection()
		{
			// Arrange
			var sided = new Sided<List<int>>();
			var leftValues = new List<int> { 1, 2, 3, 4, 5 };
			var rightValues = new List<int> { 6, 7, 8, 9, 10 };

			// Act
			sided.Left.Side = leftValues;
			sided.Right.Side = rightValues;

			// Assert
			for (int i = 0; i < leftValues.Count; i++)
			{
				Assert.AreEqual(leftValues[i], sided.Left.Side.ElementAt(i));
				Assert.AreEqual(rightValues[i], sided.Right.Side.ElementAt(i));
			}
		}
		[TestMethod]
		public void TestRemoveFromCollection()
		{
			// Arrange
			var sided = new Sided<List<int>>();
			var left = new List<int> { 1, 2, 3, 4, 5 };
			var right = new List<int> { 1, 2, 3, 4, 5 };
			sided.SetBoth(left, right);

			// Act
			Trace.WriteLine(sided.Right.Side.Count());
			Trace.WriteLine(sided.Left.Side.Count());
			sided.Left.Side.Remove(2);
			Trace.WriteLine(sided.Left.Side.Count());
			Trace.WriteLine(sided.Right.Side.Count());

			sided.Right.Side.Remove(4);
			Trace.WriteLine(sided.Right.Side.Count());
			Trace.WriteLine(sided.Left.Side.Count());



			// Assert
			Assert.AreEqual(1, sided.Left.Side.ElementAt(0));
			Assert.AreEqual(3, sided.Left.Side.ElementAt(1));
			Assert.AreEqual(1, sided.Right.Side.ElementAt(0));
			Assert.AreEqual(5, sided.Right.Side.ElementAt(3));
		}
	}
}