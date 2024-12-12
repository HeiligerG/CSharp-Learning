namespace PJ_SocietyTag;

public class SimulationStats
{
    public int Births { get; set; }
    public int Deaths { get; set; }
    public int UpgradesToMiddle { get; set; }
    public int UpgradesToRich { get; set; }
    public int DowngradesToMiddle { get; set; }
    public int DowngradesToPoor { get; set; }

    public void Reset()
    {
        Births = 0;
        Deaths = 0;
        UpgradesToMiddle = 0;
        UpgradesToRich = 0;
        DowngradesToMiddle = 0;
        DowngradesToPoor = 0;
    }

    public void AddClassChange(SocialClass from, SocialClass to)
    {
        if (from == SocialClass.POOR && to == SocialClass.MIDDLE_CLASS)
            UpgradesToMiddle++;
        else if (from == SocialClass.MIDDLE_CLASS && to == SocialClass.RICH)
            UpgradesToRich++;
        else if (from == SocialClass.RICH && to == SocialClass.MIDDLE_CLASS)
            DowngradesToMiddle++;
        else if (from == SocialClass.MIDDLE_CLASS && to == SocialClass.POOR)
            DowngradesToPoor++;
    }
}