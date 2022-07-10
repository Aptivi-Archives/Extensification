using Extensification.Legacy.StringExts;
using NUnit.Framework;

namespace Extensification.Legacy.Tests.Extensification.Legacy.Tests
{

    [TestFixture]
    public class StringTests
    {

        /// <summary>
        /// Tests splitting a string with double quotes enclosed
        /// </summary>
        [Test]
        public void TestSplitEncloseDoubleQuotes()
        {
            string TargetString = "First \"Second Third\" Fourth";
            var TargetArray = TargetString.SplitEncloseDoubleQuotes(" ");
            Assert.IsTrue(TargetArray.Length == 3);
        }

        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If NET45 Then
        *//* TODO ERROR: Skipped DisabledTextTrivia
                ''' <summary>
                ''' Tests removing letters from a string
                ''' </summary>
                <Test> Public Sub TestEvaluate()
                    Dim TargetString As String = "2 + 5"
                    Dim ExpectedEvaluated As Integer = 7
                    Assert.AreEqual(ExpectedEvaluated, TargetString.Evaluate)
                End Sub
        *//* TODO ERROR: Skipped EndIfDirectiveTrivia
        #End If
        */
    }

}