# <p align="center"> <span style="font-family:Tahoma, sans-serif;color:blue"><b>Sided</b></span> </p>
Sided is a C# library that provides a generic Sided<T> class to manage the left and right values of an object.

## Installation
To install the Sided library, you can use the SidedLib NuGet package. Open the Package Manager Console in Visual Studio and run the following command:


```csharp
Install-Package SidedLib
```
### Usage
To use the Sided library in your project, simply add a reference to SidedLib.dll and use the Sided namespace.

<u>Here is an example of using the Sided<T> class:</u>

```csharp
using Sided;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Sided<T> object with left and right values of type Color
            Sided<Color> sided = new Sided<Color>(Color.Red, Color.Blue);

            // Retrieve the left value
            Color left = sided.Left.Get();

            // Set a new right value
            sided.Right.Set(Color.Green);

            // Set both values at the same time
            sided.SetBoth(Color.Yellow, Color.Purple);

            // Create a new Left<T> object and set the left value
            Left<Color> leftSided = new Left<Color>(Color.Orange);
            sided.SetSide(leftSided);

            // Create a new Right<T> object and set the right value
            Right<Color> rightSided = new Right<Color>(Color.Brown);
            sided.SetSide(rightSided);
        }
    }
}

```


## Documentation
### Classes `Left<T>` `Right<T>`

The `Left<T>` and `Right<T>` classes represent the left and right values of a Sided<T> object. They both have the following property:

|Methods | Definitions|
|-|-|
|`public T Side` | defines the type and left or right value|

### Class `Sided<T>`

The Sided<T> class represents an object with left and right values of type T.

It has the following properties:

|Properties	| Definitions|
|-|-|
|`Left<T> Left`	|the left value of the object, of type `Left<T>`.|
|`Right<T> Right`	|the right value of the object, of type `Right<T>`.|

It also has the following methods:

|Methods | Definitions|
|-|-|
|`SetBoth(T left, T right)` | sets the left and right values at the same time.|
|`SetSide(Left<T> left)` | sets the left value from a `Left<T>` object.|
|`SetSide(Right<T> right)` | sets the right value from a `Right<T>` object.|

for more examples see the Sided.Example.cs file