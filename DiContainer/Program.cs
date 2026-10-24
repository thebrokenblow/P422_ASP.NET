using DiContainer;


var constructor = typeof(Service).GetConstructors().First();
var metadataConstructor = constructor.ToString().Split(['(', ')'], StringSplitOptions.TrimEntries).ToList();

var argumentsForConstructor =  metadataConstructor[1].Split(',', StringSplitOptions.TrimEntries).ToList();

var childrenInstance = new List<object>();
foreach (var argument in argumentsForConstructor)
{
    var type = Type.GetType(argument);
    object instance = Activator.CreateInstance(type);
    childrenInstance.Add(instance);
}

var typeService = typeof(Service);
var objectService = Activator.CreateInstance(typeService, childrenInstance[0], childrenInstance[1]);

if (objectService is Service)
{
    var service = (Service)objectService;
}


Console.ReadLine();
