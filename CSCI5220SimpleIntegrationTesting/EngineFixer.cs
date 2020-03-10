namespace MotorVehicleLib
{
   public abstract class EngineFixer
   {
      protected IRandom _random;

      public EngineFixer(IRandom random = null)
      {
         if (random == null)
         {
            random = new Random100();
         }
         _random = random;
      }

      public abstract void FixEngine(IEngine engine);
   }

   public class CheapEngineFixer : EngineFixer
   {
      public CheapEngineFixer(IRandom random = null) : base(random)
      {
      }

      public override void FixEngine(IEngine engine)
      {
         var number = _random.GetNumber();
         if (number >= 80)
         {
            engine.Fix();
         }
      }
   }
}
