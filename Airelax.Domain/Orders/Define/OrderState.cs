namespace Airelax.Domain.Orders.Define
{
    public enum OrderState
    {
        Unfinished,
        Established,
        Finish,
        Cancel,
        Processing,
        BeforeAppropriation,
    }
}