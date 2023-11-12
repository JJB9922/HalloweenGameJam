namespace Assets.Scripts.Collectibles
{
    public class Memory : Collectible
    {
        public override void Initialise()
        {
            this.Name = "Memory";
            this.Description = "Can't remember what this is.";

            base.Initialise();
        }

        public override void Collect()
        {
            if (!PlayerInventory.Instance.HelmentCollected)
            {
                CollectFailed(this, "I need to find my helmet first...");

                return;
            }
            
            base.Collect();
        }
    }
}
