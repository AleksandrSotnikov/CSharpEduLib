using NUnit.Framework;
using CSharpEduLib.Exercises.Tests.Helpers;

namespace CSharpEduLib.Exercises.Tests.Module_1.Lecture_1_2
{
    [TestFixture] public class Exercise_6_Test { [Test] public void Should_Diff_Ints(){ var (ok,stdout,err)=Runner.Run("using System; class Program{ static void Main(){ int a=10,b=3; Console.WriteLine(a-b); } }"); Assert.IsTrue(ok,err); StringAssert.Contains("7",stdout);} }
    [TestFixture] public class Exercise_7_Test { [Test] public void Should_Mul_Doubles(){ var (ok,stdout,err)=Runner.Run("using System; class Program{ static void Main(){ double a=1.5,b=2; Console.WriteLine(a*b); } }"); Assert.IsTrue(ok,err); StringAssert.Contains("3",stdout);} }
    [TestFixture] public class Exercise_8_Test { [Test] public void Should_Truncate(){ var (ok,stdout,err)=Runner.Run("using System; class Program{ static void Main(){ double x=3.9; Console.WriteLine((int)x); } }"); Assert.IsTrue(ok,err); StringAssert.Contains("3",stdout);} }
    [TestFixture] public class Exercise_9_Test { [Test] public void Should_Round(){ var (ok,stdout,err)=Runner.Run("using System; class Program{ static void Main(){ double x=2.49; Console.WriteLine(Math.Round(x)); } }"); Assert.IsTrue(ok,err); StringAssert.Contains("2",stdout);} }
    [TestFixture] public class Exercise_10_Test { [Test] public void Should_Compare_Bool(){ var (ok,stdout,err)=Runner.Run("using System; class Program{ static void Main(){ int a=5,b=3; Console.WriteLine(a>b); } }"); Assert.IsTrue(ok,err); StringAssert.Contains("True",stdout);} }
    [TestFixture] public class Exercise_11_Test { [Test] public void Should_Char_Code(){ var (ok,stdout,err)=Runner.Run("using System; class Program{ static void Main(){ char c='A'; Console.WriteLine((int)c); } }"); Assert.IsTrue(ok,err); StringAssert.Contains("65",stdout);} }
    [TestFixture] public class Exercise_12_Test { [Test] public void Should_Format_String_Number(){ var (ok,stdout,err)=Runner.Run("using System; class Program{ static void Main(){ string s=\"Hello\"; int n=7; Console.WriteLine($\"str={s}, N={n}\"); } }"); Assert.IsTrue(ok,err); StringAssert.Contains("str=Hello, N=7",stdout);} }
}