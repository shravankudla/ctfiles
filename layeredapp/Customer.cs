﻿namespace EntityClassesLib
{
public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }

    public string Email { get; set; }
    public CustomerAddress Address { get; set; }
}
}