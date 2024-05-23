using System;

namespace Maple2.File.Parser.MapXBlock;

public class UnknownModelTypeException : SystemException {
    public UnknownModelTypeException(string model) : base($"Cannot find FlatType for {model}") { }
}

public class UnknownPropertyException : SystemException {
    public UnknownPropertyException(Type type, string method) : base($"{type.Name} does not have method {method}.") { }
}
