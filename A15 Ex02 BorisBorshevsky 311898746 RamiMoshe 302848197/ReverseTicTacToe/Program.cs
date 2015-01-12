
using System;


public class prog
{
    public static void Main()
    {
        C a = new A();
        a.p();
        ((A)a).p();
        ((B)a).p();
        ((C)a).p();

        Console.ReadKey();
    
    }

}


public class C
{
    public virtual void p(){
        Console.WriteLine("C");
    }
}

public class B : C
{
    public override void p()
    {
        Console.WriteLine("B");
    }
}


public class A :B
{
    public new virtual void p(){
        Console.WriteLine("A");
    }
}
