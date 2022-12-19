internal class Person
{
    public int Age { get; set; }
    
    public Person(int age)
    { 
        Age = age;
    }

    public override string ToString() => $"Person with Age={Age}";    
}





