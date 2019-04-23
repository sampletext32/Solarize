namespace UnityUnitConverters
{
    public class UnityUnitAsAstronomicalUnitConverter : UnityUnitAsBase
    {
        public override float FromMeters(float meters)
        {
            return meters / 149_597_870_700f;
        }

        public override float FromKilometers(float kiloMeters)
        {
            return kiloMeters / 149_597_870.700f;
        }

        public override float FromMegameters(float megaMeters)
        {
            return megaMeters / 149_597.870_700f;
        }

        public override float FromGigameters(float gigaMeters)
        {
            return gigaMeters / 149.597_870_700f;
        }

        public override float FromAstronomicalUnits(float astronomicalUnits)
        {
            return astronomicalUnits;
        }

        public override float FromLightyears(float lightYears)
        {
            return lightYears * 63_241.077f;
        }
    }
}