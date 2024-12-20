using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

[TestClass]
public class WeltraumSpielTests
{
    private Spieler _spieler;
    private Galaxie _galaxie;

    [TestInitialize]
    public void Setup()
    {
        _spieler = new Spieler("TestSpieler");
        _galaxie = new Galaxie("TestGalaxie");
    }

    [TestMethod]
    public void TestSpielerInitialisierung()
    {
        // Arrange & Act done in Setup
        
        // Assert
        Assert.IsNotNull(_spieler);
        Assert.AreEqual(1000, _spieler.GetType()
            .GetField("_kredite", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(_spieler));
    }

    [TestMethod]
    public void TestGalaxieErzeugungMitSternen()
    {
        // Arrange & Act done in Setup
        
        // Assert
        Assert.IsTrue(_galaxie.Sterne.Count > 0);
        Assert.IsTrue(_galaxie.Sterne.All(s => s.Planeten.Count > 0));
    }

    [TestMethod]
    public void TestRaumschiffTreibstoffVerbrauch()
    {
        // Arrange
        var stern = _galaxie.Sterne.First();

        // Act
        _spieler.ReiseZuStern(stern);

        // Assert
        var schiffTyp = _spieler.GetType()
            .GetField("_schiff", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(_spieler) as Raumschiff;
        
        Assert.AreEqual(90, schiffTyp.Treibstoff); // 100 - 10 für die Reise
    }

    [TestMethod]
    public void TestRessourcenHandel()
    {
        // Arrange
        int startKredite = 1000;
        string ressource = "Eisen";

        // Act
        _spieler.GetType().GetMethod("KaufeRessource", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(_spieler, new object[] { ressource, 50 });

        // Assert
        var kredite = _spieler.GetType()
            .GetField("_kredite", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(_spieler);
        
        Assert.AreEqual(startKredite - 50, (int)kredite);
    }

    [TestMethod]
    public void TestPlanetRessourcenGenerierung()
    {
        // Arrange
        var planet = new Planet("TestPlanet", 1.0, (1, 1, 1));

        // Act & Assert
        Assert.IsTrue(planet.Ressourcen.ContainsKey("Eisen"));
        Assert.IsTrue(planet.Ressourcen.ContainsKey("Kristalle"));
        Assert.IsTrue(planet.Ressourcen["Eisen"] > 0);
        Assert.IsTrue(planet.Ressourcen["Kristalle"] > 0);
    }
}