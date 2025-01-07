using NUnit.Framework;

[TestFixture]
public class SpielerTests
{
    private Spieler _spieler;

    [SetUp]
    public void Setup()
    {
        // Vor jedem Test wird ein neuer Spieler erstellt
        _spieler = new Spieler("TestSpieler");
    }

    [Test]
    public void NeuerSpieler_HatKorrektesStartkapital()
    {
        // Arrange (wird bereits im Setup gemacht)

        // Act
        _spieler.ZeigeInventar(); // Diese Methode müssen wir anpassen, um die Kredite zurückzugeben

        // Assert
        Assert.That(_spieler.Kredite, Is.EqualTo(1000));
    }

    [Test]
    public void NeuerSpieler_HatEineGalaxie()
    {
        // Act
        var sterne = _spieler.HoleVerfuegbareSterne();

        // Assert
        Assert.That(sterne, Is.Not.Empty);
        Assert.That(sterne.Count, Is.GreaterThan(0));
    }

    [Test]
    public void ReparierSchiff_MitGenugKrediten_ReduziertKredite()
    {
        // Arrange
        int urspruenglicheKredite = _spieler.Kredite;

        // Act
        _spieler.ReparierSchiff();

        // Assert
        Assert.That(_spieler.Kredite, Is.EqualTo(urspruenglicheKredite - 100));
    }
}