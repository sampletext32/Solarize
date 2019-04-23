namespace UnityUnitConverters
{
    public class UnityUnitAsGigameterConverter : UnityUnitAsBase
    {
        public override float FromMeters(float meters)
        {
            return meters / 1000_000_000f;
        }

        public override float FromKilometers(float kiloMeters)
        {
            return kiloMeters / 1000_000f;
        }

        public override float FromMegameters(float megaMeters)
        {
            return megaMeters / 1000f;
        }

        public override float FromGigameters(float gigaMeters)
        {
            return gigaMeters;
        }

        public override float FromAstronomicalUnits(float astronomicalUnits)
        {
            return astronomicalUnits * 149.597_870_700f;
        }

        public override float FromLightyears(float lightYears)
        {
            return lightYears * 9_460_730.472_580_800f;
        }
    }
}