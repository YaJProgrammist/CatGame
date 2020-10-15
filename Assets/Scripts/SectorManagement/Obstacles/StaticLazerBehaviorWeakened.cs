public class StaticLazerBehaviorWeakened : StaticLazerBehavior
{
    public override sealed void Activate(StaticLazer lazer)
    {
        lazer.gameObject.SetActive(false);
    }
}
