using ControleVendas.Models;

namespace ControleVendas.Items
{
    public static class DistanceCalculationUnits
    {
        private static double CalculateDistance(double x1, double y1, double x2, double y2)
            => Math.Sqrt((Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2)));

        public static Unit GetNearestUnit(double latitude, double longitude, IEnumerable<Unit> units)
        {
            var nearestUnit = units.FirstOrDefault();
            
            var distance = CalculateDistance(latitude, longitude, double.Parse(nearestUnit.Latitude), double.Parse(nearestUnit.Longitude));
            
            foreach(var unit in units)
            {
                if (unit.Id == nearestUnit.Id)
                    continue;

                var newDistance = CalculateDistance(double.Parse(nearestUnit.Latitude), double.Parse(nearestUnit.Longitude), double.Parse(unit.Latitude), double.Parse(unit.Longitude));
                if(newDistance < distance)
                {
                    distance = newDistance;
                    nearestUnit = unit;
                }
            }

            return nearestUnit;
        }
    }
}
