﻿namespace APIPayment.Domain.Contracts
{
    public interface IStrategy
    {
        double Pay(double value);
    }
}
