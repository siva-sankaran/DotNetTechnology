using System;
using System.Collections;

public class PrimeNumberEnum : IEnumerator
{
    ulong _currentPrime;
    ulong _capacity;
    public PrimeNumberEnum(ulong Capacity)
    {
        _currentPrime = 1;
        _capacity = Capacity;
    }

    public bool MoveNext()
    {
        ulong next = _currentPrime, upperLimit, counter;
        do
        {
            next = next + 1;
            upperLimit = (ulong)next / 2;

            counter = 2;
            while (counter <= upperLimit)
            {
                if (next % counter == 0)
                    break;
                counter++;
            }
        } while (counter <= upperLimit);

        if (next <= _capacity)
        {
            _currentPrime = next;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Reset()
    {
        _currentPrime = 1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public ulong Current
    {
        get
        {
            return _currentPrime;
        }
    }
}

public class PrimeNumbers : IEnumerable
{
    ulong _capacity;
    public PrimeNumbers(ulong Capacity)
    {
        _capacity = Capacity;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public PrimeNumberEnum GetEnumerator()
    {
        return new PrimeNumberEnum(_capacity);
    }
}