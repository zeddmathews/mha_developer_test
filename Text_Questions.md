# mha_developer_test
Solutions to the MHA Developer test

# Question 2

What is the purpose of these snippets?

It is a palindrome check.
Both snippets take the string, convert it to an array, and reverses the second instance of the the conversion.
It then compares the original string to the conversion, and if they match, returns true.

Will both snippets return "true"? Why / Why not?
In the first snippet, it will return false, as it compares each character match and the capital R of the palindrome will throw off the check.
As there is no ToLower() method used in either case, only the second snippet will return true as the characters are all using the same casing.

Is the comparison of time and null in the if statement below valid or not? Why or why not?

It is not valid.
It is a comparison between a two different types (value type (the time variable) vs reference type (the null check))
It can never be null as value types always have a default value, and is therefore and invalid check.

Explain the concept of dependency injection in C# using code examples for constructor injection, property injection, and method injection.

Dependency injection is a design pattern in C#. It works on Loose Coupling. It is in place to make it easier to future proof your applications, similar to how React components are made independent of one another.
Constructor injection: When the dependencies are passed to the object through the constructor, much like a React component.

    public class HouseClass
    {
        private readonly Base _base;
        private readonly Door _door;
        private readonly Wall _wall;
    
        public HouseClass(Base _base, Door _door, Wall _wall)
        {
            _base = base;
            _door = door;
            _wall = wall;
        }
    
        public void Build()
        {
            Base.Assemble("Base");
            Door.Assemble("Door");
            Wall.Assemble("Wall");
        }
    }

    public class Base
    {
        public void Assemble(string buildingBlock)
        {
            Console.WriteLine($"Assembling the {buildingBlock}");
        }
    }

Property injection: Using get and set methods on the public properties of an object, and it expects the properties to be set before the method is called.

    public class HouseClass
    {
        public Base Base { get; set };
        public Door Door { get; set };
        public Wall Wall { get; set };
    
        public void Build()
        {
            Base.Assemble("Base");
            Door.Assemble("Door");
            Wall.Assemble("Wall");    
        }
    }
    
    public class Base
    {
        public void Assemble(string buildingBlock)
        {
            Console.WriteLine($"Assembling the {buildingBlock}");
        }
    }
Method injection: The method of the class accepts the required parameters. It doesn't store the parameters, but it needs them to be provided whenever the method is called.

    public class HouseClass
    {
        public void Build(Base base, Door door, Wall wall)
        {
            base.Assemble("Base");
            door.Assemble("Door");
            wall.Assemble("Wall");
        }
    }
    
    public class Base
    {
        public void Assemble(string buildingBlock)
        {
            Console.WriteLine($"Assembling the {buildingBlock}");
        }
    }

How does C# manage multiple inheritance for classes, and what is an alternative mechanism for acheiving similar functionality? Show us through a code example.

Technically speaking, C# doesn't manage multiple inheritance at base. What it does instead is use interfaces to handle inheritance from multiple base classes

    using System;
    
    public interface IBase
    {
        void ConstructBase();
        void TileBase();
    }
    
    public interface IWall
    {
        void BuildWall(string side);
        void PaintWall(string colour);
    }
    
    public interface IDoor
    {
        void InstallDoor();
        void PaintDoor(string colour);
    }
    
    public class House: IBase, IWall, IDoor
    {
        public void ConstructBase()
        {
            Console.WriteLine("Constructing the base");
        }
        public void TileBase()
        {
            Console.WriteLine("Tiling the base");
        }
        public void BuildWall()
        {
            Console.WriteLine("Building the wall");
        }
        public void PaintWall(string colour)
        {
            Console.WriteLine($"Painting the wall {colour}");
        }
        public void InstallDoor()
        {
            Console.WriteLine("Installing the door");
        }
        public void PaintDoor(string colour)
        {
            Console.WriteLine($"Painting the door {colour}");
        }
    }

Describe and show a code example of how asynchronous programming is used in C#
Asynchronous programming is acheived through using async and await to mimic synchronous behaviour, without the drawback of having things pop up out of order.

    public async Task <int> GetDataAsync()
    {
        await Task.Delay(2000); //this could be replaced with any kind of query whether it be to your own database, or an online http request to a different website
        return 0;
    }

# Question 3

A windowless room contains three identical light fixtures, each containing an identical light bulb or light 
globe. Each light is connected to one of three switches outside of the room. Each bulb is switched off at
present. You are outside the room, and the door is closed. Before opening the door you may play around
with the light switches as many times as you like. But once you've opened the door, you may no longer 
touch a switch. After this, you go into the room and examine the lights. How can you tell which switch goes 
to which light?

Pick any of the switches, turn the light on, and wait a few minutes.
Now flip your selected switch off, and switch a separate switch on and open the door.
The currently on switch will link to the lit bulb, while the bulb we previously left on will be warm and thus link to the switch we used earlier.
The remaining off switch links to the bulb that is off

# Question 4

Please compose a SQL query to accomplish the specified outcome in each of the following 
scenarios.
Select “Beneficiaries” where the “Surname” is alphabetically between (and including) “Lodewyks” and
“Smit”

Assuming "Beneficiaries" is the table name

    SELECT
    *
    FROM Beneficiaries
    WHERE [Surname] BETWEEN 'Lodewyks' AND 'Smit'
    ORDER BY [Surname] ASC;

Select “Beneficiaries” sorted descending by “Surname” then “Name”

    SELECT
    *
    FROM Beneficiaries
    ORDER BY [Surname] DESC, [Name] DESC;

Change all “Policies” where the “PlanId” is 934 to “PlanId” 16 

    UPDATE Policies
    SET PlanId = 16
    WHERE PlanId = 934;

Get the sum (“Amount”) of all “Transactions” made in December 2018

    SELECT
    SUM(Amount) AS TotalAmount
    FROM Transactions
    WHERE TransDT BETWEEEN '2018-12-01' AND '2018-12-31';

Create a new table with the name “Asset” containing an auto incremented unique identifier (“AssetId”), a
description of the asset (“AssetDescription”), and the owner (“Owner”).

    CREATE TABLE Asset (
        AssetId INT AUTO_INCREMENT PRIMARY KEY,
        Owner VARCHAR(255) NOT NULL,
        AssetDescription VARCHAR(MAX) NOT NULL
    );

# Question 5

Explain the difference between the below HTTP verbs in the instance of REST API.

GET:
    Fetch data from the server.

POST:
    Used to create/submit data on the server. 

DELETE:
    Deletes data/resources from the server.

PUT:
    Update/replace existing data on the server.