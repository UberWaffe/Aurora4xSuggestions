namespace Aurora.AddIns.TerraformingTargets.Models
{
    public class TerraformChangeResult
    {
        public double maxChangeLeft { get; private set; }
        public double newElementAmount { get; private set; }
        public bool targetReached { get; private set; }

        public TerraformChangeResult(double newAmount, double changeLeft, bool reached)
        {
            newElementAmount = newAmount;
            maxChangeLeft = changeLeft;
            targetReached = reached;
        }
    }
}