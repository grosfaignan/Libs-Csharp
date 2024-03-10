# <p align="center"> <span style="font-family:Tahoma, sans-serif;color:blue"><b>Sided</b></span> </p>


Sided est une bibliothèque C# qui fournit une classe générique Sided<T> pour gérer les valeurs gauche et droite d'un objet.

## Installation
Pour installer la bibliothèque Sided, vous pouvez utiliser le package NuGet SidedLib. Ouvrez la console du gestionnaire de packages dans Visual Studio et exécutez la commande suivante :


```
Install-Package SidedLib
```

## Utilisation
Pour utiliser la bibliothèque Sided dans votre projet, ajoutez simplement une référence à SidedLib.dll et utilisez l'espace de noms Sided.

<u>Voici un exemple d'utilisation de la classe Sided<T> </u>:


```csharp
using Sided;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Créez un nouvel objet Sided<T> avec une valeur gauche et droite de type Color
            Sided<Color> sided = new Sided<Color>(Color.Red, Color.Blue);

            // Récupérez la valeur gauche
            Color left = sided.Left.Get();

            // Définissez une nouvelle valeur droite
            sided.Right.Set(Color.Green);

            // Définissez les deux valeurs en même temps
            sided.SetBoth(Color.Yellow, Color.Purple);

            // Créez un nouvel objet Left<T> et définissez la valeur gauche
            Left<Color> leftSided = new Left<Color>(Color.Orange);
            sided.SetSide(leftSided);

            // Créez un nouvel objet Right<T> et définissez la valeur droite
            Right<Color> rightSided = new Right<Color>(Color.Brown);
            sided.SetSide(rightSided);
        }
    }
}
```

## Documentation

### Classes `Left<T>` `Right<T>` 
Les classes Left<T> et Right<T> représente les valeurs gauche et droite d'un objet Sided<T>. Elles disposent toutes deux de la propriété suivante :

|    Methodes    |        Definitions       |
|---------------|--------------------------|
|`public T Side` | définit le type et la valeur gauche ou droite |

### Classe `Sided<T>`
La classe Sided<T> représente un objet avec une valeur gauche et droite de type T.

Elle dispose des propriétés suivantes :


|  Propriétés  |                Définitions                   |
|--------------|----------------------------------------------|
|`Left` | la valeur gauche de l'objet, de type Left<T>.       |
|`Right` | la valeur droite de l'objet, de type Right<T>.     |


Elle dispose également des méthodes suivantes :

|Methodes| Définitions |
|-|-|
|`SetBoth(T left, T right)` | définit les valeurs gauche et droite en même temps.|
|`SetSide(Left<T> left)` | définit la valeur gauche à partir d'un objet Left<T>.|
|`SetSide(Right<T> right)`|: définit la valeur droite à partir d'un objet Right<T>.|

pour plus d'examples vois le fichier Example.cs