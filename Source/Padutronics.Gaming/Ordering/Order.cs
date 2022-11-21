using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Gaming.Ordering;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class Order : IComparable<Order>, IEquatable<Order>
{
    private readonly int value;

    public Order(int value)
    {
        this.value = value;
    }

    public Order After()
    {
        return new Order(value + 1);
    }

    public Order Before()
    {
        return new Order(value - 1);
    }

    public int CompareTo(Order? other)
    {
        return value.CompareTo(other?.value);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Order);
    }

    public bool Equals(Order? other)
    {
        return other is not null && value == other.value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(value);
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public static bool operator ==(Order? left, Order? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(Order? left, Order? right)
    {
        return !(left == right);
    }

    public static bool operator >=(Order? left, Order? right)
    {
        return right <= left;
    }

    public static bool operator <=(Order? left, Order? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(Order? left, Order? right)
    {
        return right < left;
    }

    public static bool operator <(Order? left, Order? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }
}