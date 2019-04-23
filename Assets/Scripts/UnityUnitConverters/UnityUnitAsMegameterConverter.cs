namespace UnityUnitConverters
{
    public class UnityUnitAsMegameterConverter : UnityUnitAsBase
    {
        public override float FromMeters(float meters)
        {
            return meters / 1000_000f;
        }

        public override float FromKilometers(float kiloMeters)
        {
            return kiloMeters / 1000f;
        }

        public override float FromMegameters(float megaMeters)
        {
            return megaMeters;
        }

        public override float FromGigameters(float gigaMeters)
        {
            return gigaMeters * 1000f;
        }

        public override float FromAstronomicalUnits(float astronomicalUnits)
        {
            return astronomicalUnits * 149_597.870_700f;
        }

        public override float FromLightyears(float lightYears)
        {
            return lightYears * 9_460_730_472.580_800f;
        }
    }
}