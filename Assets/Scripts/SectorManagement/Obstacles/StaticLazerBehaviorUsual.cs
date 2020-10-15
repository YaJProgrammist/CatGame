public class StaticLazerBehaviorUsual : StaticLazerBehavior
{
    public override sealed void Activate(StaticLazer lazer)
    {
        lazer.gameObject.SetActive(true);
    }
}
