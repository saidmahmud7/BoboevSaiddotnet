namespace task1;

interface IRefundablePayment : IPayment
{
    void RefundPayment(decimal amount);
}