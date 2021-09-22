using NUnit.Framework;

namespace Winforms_Chess
{
 [TestFixture]
  public class Fen_Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase]
    public void CreateFenFromPices_Test()
    {
      var expected = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";
      var arrange = Fen.GetPices(expected);

      var result = Fen.CreateFenFromPices(pices: arrange, rank: 7);
      Assert.AreEqual(expected,result);
    }
  }
}