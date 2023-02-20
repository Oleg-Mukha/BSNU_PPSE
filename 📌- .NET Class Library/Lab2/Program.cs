using AutoMapper;
using FluentValidation;
using NLog;
using NLog.Config;
using NLog.Targets;
using UnitConversion;
using System.Xml;

Console.WriteLine("\t\t\t - NLog -");
var logConfig = new LoggingConfiguration();
logConfig.AddRule(LogLevel.Trace, LogLevel.Fatal, new ConsoleTarget("logconsole"));
LogManager.Configuration = logConfig;
var log = LogManager.GetCurrentClassLogger();
log.Debug("Debug message");
log.Fatal("Fatal message");
log.Error(new Exception(), "Error message");

Console.WriteLine("\t\t\t - AutoMapper -");
var config = new MapperConfiguration(cfg => { cfg.CreateMap<Person, PersonDTO>(); });
var mapper = config.CreateMapper();
var person = new Person();
person.Name = "Oleg Mukha";
var personDto = mapper.Map<PersonDTO>(person);
Console.WriteLine(personDto.Name);

Console.WriteLine("\t\t\t - UnitConversion -");
var converter = new MassConverter("kg", "lbs");
double kg = 1;
var lbs = converter.LeftToRight(kg);
Console.WriteLine(kg + " kg is equivalent to " + lbs + " lbs");

Console.WriteLine("\t\t\t - FluentValidation -");
var personValidator = new PersonValidator();
personValidator.Validate(person);
person.Name = "Oleg Mukha";
var result = personValidator.Validate(person);
Console.WriteLine(result);

Console.WriteLine("\t\t\t - System.Xml -");
XmlDocument xDoc = new XmlDocument();
xDoc.Load("C:/Users/Admin/RiderProjects/Lab1/Lab1/data.xml");
XmlElement? xRoot = xDoc.DocumentElement;
if (xRoot != null)
{
    foreach (XmlElement xnode in xRoot)
    {
        XmlNode? attr = xnode.Attributes.GetNamedItem("people");
        Console.WriteLine(attr?.Value);

        foreach (XmlNode childnode in xnode.ChildNodes)
        {
            if (childnode.Name == "name")
            {
                Console.WriteLine($"Name: {childnode.InnerText}");
            }
            if (childnode.Name == "surname")
            {
                Console.WriteLine($"Surname: {childnode.InnerText}");
            }
            if (childnode.Name == "age")
            {
                Console.WriteLine($"Age: {childnode.InnerText}");
            }
        }
        Console.WriteLine();
    }
}
internal class Person
{
    public string Name { get; set; }
}

internal class PersonDTO
{
    public string Name { get; set; }
}

internal class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Enter value");
        RuleFor(x => x.Name).Length(3, 20);
    }
}