using NUnit.Framework;

[TestFixture]
public class SpielerTests
{
    private Spieler _spieler;

    [SetUp]
    public void Setup()
    {
        _spieler = new Spieler("TestSpieler");
    }

    [Test]
    public void NeuerSpieler_HatKorrektesStartkapital()
    {
        _spieler.ZeigeInventar();

        Assert.That(_spieler.Kredite, Is.EqualTo(1000));
    }

    [Test]
    public void NeuerSpieler_HatEineGalaxie()
    {
        var sterne = _spieler.HoleVerfuegbareSterne();

        Assert.That(sterne, Is.Not.Empty);
        Assert.That(sterne.Count, Is.GreaterThan(0));
    }
    
    // Diese Methode wurde von der KI erstellet, da ich keine Ahnung von Unit Testing hatte.
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