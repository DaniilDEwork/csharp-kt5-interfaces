using System;

interface IAnimal
{
    string Name { get; set; }
    void MakeSound();
}

class Dog : IAnimal
{
    public string Name { get; set; }

    public Dog(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine(Name + ": Гав-гав");
    }
}

class Cat : IAnimal
{
    public string Name { get; set; }

    public Cat(string name)
    {
        Name = name;
    }

    public void MakeSound()
    {
        Console.WriteLine(Name + ": Мяу-мяу");
    }
}

interface IShape
{
    double Area { get; }
    double Perimeter { get; }
}

class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area
    {
        get { return Math.PI * Radius * Radius; }
    }

    public double Perimeter
    {
        get { return 2 * Math.PI * Radius; }
    }
}

class Rectangle : IShape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area
    {
        get { return Width * Height; }
    }

    public double Perimeter
    {
        get { return 2 * (Width + Height); }
    }
}

class Triangle : IShape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double Perimeter
    {
        get { return A + B + C; }
    }

    public double Area
    {
        get
        {
            double p = Perimeter / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}

class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public int CompareTo(Student other)
    {
        if (other == null)
            return 1;

        int result = string.Compare(Name, other.Name);

        if (result != 0)
            return result;

        result = Age.CompareTo(other.Age);

        if (result != 0)
            return result;

        return Grade.CompareTo(other.Grade);
    }
}

class Book : IComparable<Book>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public int CompareTo(Book other)
    {
        if (other == null)
            return 1;

        int result = string.Compare(Title, other.Title);

        if (result != 0)
            return result;

        result = string.Compare(Author, other.Author);

        if (result != 0)
            return result;

        return Price.CompareTo(other.Price);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Интерфейс IAnimal");
        Dog dog = new Dog("Шарик");
        Cat cat = new Cat("Мурка");

        dog.MakeSound();
        cat.MakeSound();

        Console.WriteLine();
        Console.WriteLine("2. Интерфейс IShape");
        Circle circle = new Circle(5);
        Rectangle rectangle = new Rectangle(4, 6);
        Triangle triangle = new Triangle(3, 4, 5);

        Console.WriteLine("Круг: площадь = " + circle.Area.ToString("F2") + ", периметр = " + circle.Perimeter.ToString("F2"));
        Console.WriteLine("Прямоугольник: площадь = " + rectangle.Area.ToString("F2") + ", периметр = " + rectangle.Perimeter.ToString("F2"));
        Console.WriteLine("Треугольник: площадь = " + triangle.Area.ToString("F2") + ", периметр = " + triangle.Perimeter.ToString("F2"));

        Console.WriteLine();
        Console.WriteLine("3. Интерфейс IComparable<T>");

        Student student1 = new Student("Иван", 18, 4.5);
        Student student2 = new Student("Иван", 19, 4.7);

        int studentResult = student1.CompareTo(student2);

        if (studentResult < 0)
            Console.WriteLine("student1 меньше student2");
        else if (studentResult > 0)
            Console.WriteLine("student1 больше student2");
        else
            Console.WriteLine("student1 равен student2");

        Book book1 = new Book("Война и мир", "Толстой", 500);
        Book book2 = new Book("Война и мир", "Толстой", 700);

        int bookResult = book1.CompareTo(book2);

        if (bookResult < 0)
            Console.WriteLine("book1 меньше book2");
        else if (bookResult > 0)
            Console.WriteLine("book1 больше book2");
        else
            Console.WriteLine("book1 равна book2");

        Console.ReadLine();
    }
}