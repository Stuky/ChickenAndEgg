using System;

namespace ChickenAndEgg
{
    // https://csharp.wekeepcoding.com/article/10868247/Chicken+and+Egg+%5Bclosed%5D

    class Program
    {
        public static void Main(string[] args)
        {
            var chicken1 = new Chicken();
            var egg = chicken1.Lay();
            var childChicken = egg.Hatch();
            var childChicken2 = egg.Hatch();
        }
    }
    public interface IBird
    {
        Egg Lay();
    }
    public class Egg
    {
        private readonly Func<IBird> _createBird;
        private bool _hatched;
        public Egg(Func<IBird> createBird)
        {
            _createBird = createBird;
        }
        public IBird Hatch()
        {
            if (_hatched) throw new InvalidOperationException("Egg already hatched.");
            _hatched = true;
            return _createBird();
        }
    }
    public class Chicken : IBird
    {
        public Egg Lay()
        {
            var egg = new Egg(() => new Chicken());
            return egg;
        }
    }
}