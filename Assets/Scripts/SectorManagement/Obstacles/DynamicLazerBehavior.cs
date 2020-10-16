public abstract class DynamicLazerBehavior
{
    //Called once when behavior should start to appear
    public abstract void Activate();

    //Called once per frame from dynamic lazer's controller
    public abstract void Update();
}