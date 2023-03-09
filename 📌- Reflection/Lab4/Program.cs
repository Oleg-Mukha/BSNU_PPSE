using System.Reflection;

public class Person
{
    public string name;
    private string surname;
    private int age;
    public string occupation;
    protected string address;
    public bool isMarried;

    public Person(string name, string surname, int age, string occupation, string address, bool isMarried)
    {
        this.name = name;
        this.surname = surname;
        this.age = age;
        this.occupation = occupation;
        this.address = address;
        this.isMarried = isMarried;
    }

    public void PrintInfo()
    {
        Console.WriteLine(
            $"Name: {name} {surname} | Age: {age} | Employment: {occupation} | Address: {address} | Married: {isMarried} ");
    }

    public int GetBirthYear()
    {
        return DateTime.Now.Year - age;
    }

    private void ChangeAddress(string newAddress)
    {
        address = newAddress;
        Console.WriteLine($"New address set to {address}.");
    }
}

public class Program
{
    public static void Main()
    {
        // Using 'Type' & 'TypeInfo'
        Console.WriteLine("\t\t\t - Type & TypeInfo -");

        Type type = typeof(Person);
        TypeInfo typeInfo = type.GetTypeInfo();

        Console.WriteLine($"Type: {type.Name}");
        Console.WriteLine($"Is class: {type.IsClass}");
        Console.WriteLine($"Is sealed: {type.IsSealed}");
        Console.WriteLine($"Is public: {type.IsPublic}");
        Console.WriteLine($"Is value type: {type.IsValueType}");

        Console.WriteLine($"Type info: {typeInfo.AssemblyQualifiedName}");
        Console.WriteLine($"Base type: {typeInfo.BaseType}");
        Console.WriteLine($"Is abstract: {typeInfo.IsAbstract}");
        Console.WriteLine($"Is enum: {typeInfo.IsEnum}");
        Console.WriteLine($"Is interface: {typeInfo.IsInterface}");

        // Using 'MemberInfo'
        Console.WriteLine("\t\t\t - MemberInfo -");
        
        MemberInfo[] members = type.GetMembers();
        foreach (var member in members)
        {
            Console.WriteLine(member.Name);
        }

        // Using 'FieldInfo'
        Console.WriteLine("\t\t\t - FieldInfo -");
        
        Person person = new Person("John", "Doe", 25, "Android Developer", "123 Main St.", false);
        FieldInfo field = type.GetField("occupation", BindingFlags.Public | BindingFlags.Instance);

        Console.WriteLine($"Field name: {field.Name}");
        Console.WriteLine($"Field type: {field.FieldType}");
        Console.WriteLine($"Field value: {field.GetValue(person)}");
        
        // Using 'MethodInfo' with Reflection
        Console.WriteLine("\t\t\t - MethodInfo (by using Reflection) -");
        
        MethodInfo method = type.GetMethod("PrintInfo");
        method.Invoke(person, null);
    }
}