using System;


class MyPair<TFirst, TSecond>
{
    private TFirst first;
    private TSecond second;

    public MyPair(TFirst first, TSecond second)
    {
        this.first = first;
        this.second = second;
    }

    public TFirst First
    {
        get { return first; }
        set { first = value; }
    }

    public TSecond Second
    {
        get { return second; }
        set { second = value; }
    }

    public object this[int index]
    {
        get
        {
            if (index == 0)
                return first;
            else if (index == 1)
                return second;
            else
                throw new IndexOutOfRangeException("Index must be 0 or 1");
        }
        set
        {
            if (index == 0)
                first = (TFirst)value;
            else if (index == 1)
                second = (TSecond)value;
            else
                throw new IndexOutOfRangeException("Index must be 0 or 1");
        }
    }
}


class MyTriple<TFirst, TSecond, TThird> : MyPair<TFirst, TSecond>
{
    private TThird third;

    public MyTriple(TFirst first, TSecond second, TThird third)
        : base(first, second)
    {
        this.third = third;
    }

    public TThird Third
    {
        get { return third; }
        set { third = value; }
    }

    public object this[int index]
    {
        get
        {
            if (index == 2)
                return third;
            else
                return base[index];
        }
        set
        {
            if (index == 2)
                third = (TThird)value;
            else
                base[index] = value;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        MyPair<string, int> pair = new MyPair<string, int>("Hello", 42);
        Console.WriteLine("{0}, {1}", pair.First, pair.Second);
        pair[0] = "World";
        pair[1] = 123;
        Console.WriteLine("{0}, {1}", pair[0], pair[1]);

        MyTriple<int, double, string> triple = new MyTriple<int, double, string>(1, 2.5, "three");
        Console.WriteLine("{0}, {1}, {2}", triple.First, triple.Second, triple.Third);
        triple[0] = 100;
        triple[1] = 3.14;
        triple[2] = "pi";
        Console.WriteLine("{0}, {1}, {2}", triple[0], triple[1], triple[2]);

        Console.ReadKey();
    }
}

