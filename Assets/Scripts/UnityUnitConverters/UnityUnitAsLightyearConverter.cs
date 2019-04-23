namespace UnityUnitConverters
{
    public class UnityUnitAsLightyearConverter : UnityUnitAsBase
    {
        public override float FromMeters(float meters)
        {
            return meters / 9_460_730_472_580_800f;
        }

        public override float FromKilometers(float kiloMeters)
        {
            return kiloMeters / 9_460_730_472_580.800f;
        }

        public override float FromMegameters(float megaMeters)
        {
            return megaMeters / 9_460_730_472.580_800f;
        }

        public override float FromGigameters(float gigaMeters)
        {
            return gigaMeters / 9_460_730.472_580_800f;
        }

        public override float FromAstronomicalUnits(float astronomicalUnits)
        {
            return astronomicalUnits * 0.0000158120569380f;
        }

        public override float FromLightyears(float lightYears)
        {
            return lightYears;
        }
    }
}