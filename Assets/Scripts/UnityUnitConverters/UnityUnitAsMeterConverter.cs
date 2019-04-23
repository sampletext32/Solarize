namespace UnityUnitConverters
{
    public class UnityUnitAsMeterConverter : UnityUnitAsBase
    {
        public override float FromMeters(float meters)
        {
            return meters;
        }

        public override float FromKilometers(float kiloMeters)
        {
            return kiloMeters * 1000f;
        }

        public override float FromMegameters(float megaMeters)
        {
            return megaMeters * 1000_000f;
        }

        public override float FromGigameters(float gigaMeters)
        {
            return gigaMeters * 1000_000_000f;
        }

        public override float FromAstronomicalUnits(float astronomicalUnits)
        {
            return astronomicalUnits * 149_597_870_700f;
        }

        public override float FromLightyears(float lightYears)
        {
            return lightYears * 9_460_730_472_580_800f;
        }
    }
}