using NUnit.Framework;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_1_DeclaringVariables;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_2_TypeConversions;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_3_ParseTryParse;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_4_MinMax;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_5_CharBasics;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_6_Constants;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_7_BoolLogic;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_8_Defaults;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_9_Overflow;
using CSharpEduLib.Content.Lectures.Module_1_Basics.Lecture_1_2_Variables.Exercises.Exercise_10_CombiningTypes;

namespace CSharpEduLib.Exercises.Tests.Module1.Lecture12
{
    [TestFixture]
    public class Lecture12_StudentSolution_Tests
    {
        [Test]
        public void Ex1_DeclaringVariables()
        {
            var s = Exercise_1_DeclaringVariables.StudentSolution.Run();
            StringAssert.StartsWith("10|3.14|text|True|A", s);
        }

        [Test]
        public void Ex2_TypeConversions()
        {
            var (implicitDouble, explicitInt) = Exercise_2_TypeConversions.StudentSolution.Run();
            Assert.AreEqual(42d, implicitDouble);
            Assert.AreEqual(42, explicitInt);
        }

        [TestCase("10","5", ExpectedResult=15)]
        [TestCase("abc","5", ExpectedResult=5)]
        [TestCase("","", ExpectedResult=0)]
        public int Ex3_ParseTryParse(string a, string b)
        {
            return Exercise_3_ParseTryParse.StudentSolution.Run(a, b);
        }

        [Test]
        public void Ex4_MinMax()
        {
            var (imin, imax, lmin, lmax) = Exercise_4_MinMax.StudentSolution.Run();
            Assert.AreEqual(int.MinValue, imin);
            Assert.AreEqual(int.MaxValue, imax);
            Assert.AreEqual(long.MinValue, lmin);
            Assert.AreEqual(long.MaxValue, lmax);
        }

        [Test]
        public void Ex5_CharBasics()
        {
            var c = Exercise_5_CharBasics.StudentSolution.Run(65);
            Assert.AreEqual('A', c);
        }

        [Test]
        public void Ex6_Constants()
        {
            var pi = Exercise_6_Constants.StudentSolution.Run();
            Assert.That(pi, Is.GreaterThan(3.14).And.LessThan(3.142));
        }

        [Test]
        public void Ex7_BoolLogic()
        {
            Assert.IsTrue(Exercise_7_BoolLogic.StudentSolution.Run(true, false));
            Assert.IsFalse(Exercise_7_BoolLogic.StudentSolution.Run(false, false));
        }

        [Test]
        public void Ex8_Defaults()
        {
            var (i, b) = Exercise_8_Defaults.StudentSolution.Run();
            Assert.AreEqual(0, i);
            Assert.IsFalse(b);
        }

        [Test]
        public void Ex9_Overflow()
        {
            int wrap = Exercise_9_Overflow.StudentSolution.Run();
            Assert.Less(wrap, 0);
        }

        [Test]
        public void Ex10_CombiningTypes()
        {
            var s = Exercise_10_CombiningTypes.StudentSolution.Run(10, 2.5);
            Assert.AreEqual("10-2.5", s);
        }
    }
}
