namespace RefactoringToDesignPatterns.CH01_CodeSmells.Solutions
{
    internal class MessageChains
    {
        public class Engine
        {
            public Cylinder GetCylinder()
            {
                return new Cylinder();
            }
        }

        public class Cylinder
        {
            public string GetSize()
            {
                return "2.0L";
            }
        }

        public class Car
        {
            public string GetCylinderSize()
            {
                Engine engine = new Engine();
                return engine.GetCylinder().GetSize();
            }
        }

        // Przykład wywołania
        //Car car = new Car();
        //string cylinderSize = car.GetCylinderSize();
    }
}