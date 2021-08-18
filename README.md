<h2 align="center">Adaptive Code Studies</h2>

<p align="center">
  <a href=#about>About</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href=#summary>Summary</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href=#student>Student</a>
</p>

### About
This repository was made with the intention of documenting my studies using the
[Adaptive Code: Agile coding with design patterns and SOLID principles](https://www.amazon.com.br/Adaptive-Code-coding-patterns-principles/dp/1509302581)
book.

### Summary
- PART II
  - [Interfaces and Design Patterns](#interfaces-and-design-patterns)
    - [What is an Interface](#what-is-an-interface)
    - [Polymorphism](#polymorphism)
    - [The Null Object Pattern](#the-null-object-pattern)
  - [Tests](#tests)
    - [Unit Tests](#unit-tests)
    - [More Complex Tests](#more-complex-tests)
    - [Writing tests for defect fixes](#writing-tests-for-defect-fixes)
    - [Test Setup](#test-setup)
    - [The Builder Pattern](#the-builder-pattern)
    - [Test-Driven Design](#test-driven-design)
    - [Testing for Prevention and Cure](#testing-for-prevention-and-cure)
  - [Refactoring](#refactoring)
    - [Replacing "magic numbers" with constants](#replacing-magic-numbers-with-constants)
    - [Replacing a conditional expression with polymorphism](#replacing-a-conditional-expression-with-polymorphism)
    - [Replacing a constructor with a factory method](#replacing-a-constructor-with-a-factory-method)
    - [Replacing a constructor with a factory class](#replacing-a-constructor-with-a-factory-class)

<hr>

## Interfaces and Design Patterns

### What is an Interface
An interface defines the behavior that class has, but not how this behavior is implemented, it means it will have only the signature of the methods, but its logic will be written in the class that implements that interface.
```c#
  public interface IInterface
  {
    int SomeMethod();
  }

  // Implementing the interface
  public class SomeClass : IInterface
  {
    public int SomeMethod() 
    {...}
  }
```

### Polymorphism
The ability to use an object of one type and have it implicitly act as if it were of a different type is called polymorphism.
<br>
When a class implements an interface, the client code doesn't need to know the implementation details of that specific class. All it needs is to use their functionalities.
<br>
For example, if the classes ``Motorcycle, Boat and Car`` implements a ``IVehicle`` interface, the client code can refer to the ``IVehicle`` interface and treat all concrete types as if they were the same. The implementation of how a boat accelerates compared to a car is irrelevant to the client.
```c#
  // Creating the interface
  public interface IVehicle
  {
    void Accelerate();
  }

  // Implementing the interface
  public class Boat : IVehicle
  {
    public void Accelerate()
    {...}
  }

  public class Car : IVehicle
  {
    public void Accelerate()
    {...}
  }

  // Now we can use both classes with the interface type
  IVehicle car = new Car();
  IVehicle boat = new Boat();
```

### The Null Object Pattern

The idea behind the Null Object Pattern is to avoid throwing
a NullReferenceException and rewrite tons of null object-checking code.
<br>
If, for example, a repository tries to get some user from a database but that
query returns a null object, instead of verifying in every method call for null,
the own method make this verification, and, in case of null, returns a special
subclass that implements the same interface.
<br>
All methods implemented by this special subclass should do the closest to nothing
as possible.
```c#
  // The object
  public class SomeClass : IInterface
    {
      public Guid Id { get; set; }
      public SomeClass(Guid id)
      {
          Id = id;
      }
      public void SomeMethod()
      {...}
    }

  // The null object
  public class NullObject : IInterface
  {
    public void IncrementSessionTicket()
    {
      // Do nothing
    }
  }

  public class Repository 
  {
    public IInterface GetById(Guid id)
      {
        IInterface itemFound = _repository.SingleOrDefault(obj => obj.Id == id);
        // If what you searching for is not found, return the null object
        if (itemFound == null)
        {
            itemFound = new NullObject();
        }

        return itemFound;
      }
  }
```

## Tests
Software quality is not limited to the quality of the code and how adaptive it is to change. It is also a
measure of how accurately the software fulfills its requirements. Testing is the umbrella of practices
that can be used to ensure this kind of software quality.

### Unit Tests
Testing is a way of guarantee that a function have its expected behavior.
<br>
Every unit test is composed of three distinct parts (following the AAA pattern):
- The **arrange**ment of the preconditions of the test.
- The performance of the **act** that is being  tested.
- The **assert**ion that the expected behavior occurred.
<br>
  
When working with TDD (Test-Driven Development), the idea behind is that do not exist any 
production code, what will cause an inevitable error when running the written tests.
<br>
Next, you need to <i>implement just enough of the SUT (the class you are testing) so
that test passes</i>.
<br>
Finally, you are able to refactor your SUT to pass all the new tests created.
<br> <br>
Writing tests before the real implementation and following the described steps, prevents
over-engineering the solution and also prevents breaking existing functionalities.

### More Complex Tests
When working with real applications, most of the time we well need some external 
tools like databases, web services or even more logical layers.
<br>
Testing this kind of application can be a little more tricky, and requires more 
effort when testing.
<br>
It's important to notice that depending on external services can make your test be inconsistent
because, if some of this services is not working properly, your tests neither will.
<br>
To deal with this problem we can use Test Doubles.
<br>
There are five different subcategories of Test Doubles:
- **Dummies:** The simplest of them. Made just for fulfil some parameters in our
tests and do not any special behavior.
- **Spies:** A spy records calls that have been made to its method and also
can be used to ensure that certain call were made.
- **Stubs:** Stubs are dependencies that are required for testing some piece
of the code. Instead of depending on the external service, we use use the Stub to return a 
pre-supplied answer whenever queried. Returns dummy data.
- **Fakes:** Similar to Stubs, but this one does no return dummy data. Instead,
it's closer to real production implementation, but using a simplified version of the real implementation 
and usually taking some shortcut, but needs some data to test. For example, we 
would need a custom repository class with some data, and instead of querying the real 
database, we should query this custom repository using an in memory database.
- **Mocks:** The idea of mocking is mimic the behavior of real objects in a controlled
way. Instead of calling a database, for example, you can simulate the database operations using a mock 
object.
<br><br>
  
Creating mocks can be much harder when testing more complex SUTs, that is a good reason 
to use **Mock Frameworks** like Moq.
<br>
When defining how a the mock should behave, there is some alternatives:
- **Loose Mocks:** defined by default, which means that all their return values are 
default. The default for any reference type is null.
- **Strict Mock:** throw an exception whenever it is faced with a method call or
property access that you have not already specified.
- **Setup Method:** the Setup method accepts a lambda expression that provides an 
underlying instance of the mocked type as a context parameter and can specify what
you want to happen when the method is called.
  
It's important to notice that Mocks can be over-specified, what is no good for unit
tests. A test is over-specified when it has knowledge about the SUT's implementation
rather than its expected behavior.
<br>
Over-specified mock tests can cause problems because if the method that is being
tested changes it implementation, the test will fail, even if the expected behavior
remains correct.
<br>
You have two options to avoid this kind of problem:
- **Test behavior only:** if a method accepts A, B and C inputs and return X, Y and Z,
it is irrelevant how the method arrived this output. Just test the inputs and outputs.
- **Implementing as one atomic unit:** if one changes, so must the other. I may looks
bad, but following the SOLID principles, some classes will be never altered, so it 
can be not a problem.
  
### Writing tests for defect fixes
Sometimes you can come across some exception that had been replaced with another one.
In this case, **DomainException** was replaced by **ServiceException**. It is very 
hard to understand the real cause of the problem so, to solve this problem, we need 
to wrap one exception to another.
<br>
Creating a custom exception that receives two parameters in it constructor (message and
inner) its enough to guide the information to the layer we want. We can access the 
information using **Exception.InnerException**.
<br>

### Test Setup
Instead of initialize mock objects for every unit test we make, we can create a 
method that initialize our mock objects. This method needs **[TestInitialize]** tag 
(MSTest). 
<br>

### The Builder Pattern
This pattern is useful for encapsulating and abstracting the creation of objects. If an object
can be configured in multiple ways across multiple dimensions, this pattern can simplify the
creation of code and clarify the intent.
<br>
The idea is to create a ServiceBuilder class that will have mock properties. We can use this
class to build our **Assert** when coding tests. It is important to mention that this class
is designed with fluent interface, so the methods inside returns the own builder and can be
chained.

### Test-Driven Design
Most applicable when the production code is unknown and can emerge from red, green refactor
process of writing unit tests.
**Rules:**
- Write just one test. Needs to be the simplistic as possible, enough just to point in the
direction of the solution.
- Run the test to make sure it fails.
- Make the written test pass by writing the least amount of implementation code in the test
method.
- Refactor to reduce duplication or improve design. Only introduce new abstractions when
they will help to improve the design of the code.
  
This way of writing code prevents over-engineering.

### The testing pyramid
![The testing pyramid](https://i.imgur.com/GFtZ2an.jpg)
<br> <br>
**Above the top:** Manual testing. There should be few of these,
because they need manual intervention, which is costly and time-consuming.
<br>
**The top:** Acceptance tests. Intended to replicate the interaction of a user and assert
against expectations. There should be only a few of these too, because they are large and
hard to maintain.
<br>
**The middle:** Component-level integration tests. Could take the form of API tests which
the service is treated as a black box. It means for a variety of data inputs, the tests
assert that the correct responses are returned.
<br>
**The bottom:** Unit tests.
<br><br>
The idea of the pyramid is to illustrate that one layer should be relatively smaller or larger
than another.

### Testing for Prevention and Cure
Testing gives you confidence that your application works properly, but comes with a price:
time and effort. 
<br>
If you efforts do not generate enough confidence, they are too costly.
<br>
Every project have a target confidence that calibrates their tolerance for failure.
One option to reduce the effort and increasing the confidence is deploying to multiple
environments for testing.
<br><br>
![Multiple environments deploy](https://i.imgur.com/Q8s4PPr.png)
<br><br>
Each phase of the process gives you more confidence about the software.
<br>
We could also take a shortcut and go directly to the live phase without fear of failing,
that because we should never fear failure, failure is better teacher than success.
<br>
When talking about time in development, there are two types: Mean Time Before Failure(MTBF) and
Mean Time to Recovery(MTTR).
<br>
If you need a system with high level of confidence, like a pacemaker or bank security, MTBF is 
the right choice.
<br>
However, MTTR not only allow failures but it prepares for it.
<br>
MTTR systems will fail more, but the recovery time is much faster. It makes possible to 
innovate faster too.

## Refactoring
Even when using the TDD approach to create code, sometimes this code might not be as organized
or understandable as it could be. The solution for this kind of problem is refactoring.
<br>
Refactoring is the process of improving the design of existing code, that goes from simply rename a
variable,refactor an entire class, or even bigger changes.
<br>

### Replacing "magic numbers" with constants
Instead of using numbers without context like ``something / 20``, a better approach is replace this number by a constant variable with a well descriptive name like ``something / constantVariable``.

### Replacing a conditional expression with polymorphism
Using conditional expressions like ``if/else`` and ``switch`` is problematic for two reasons: affects readability of code and introduces a maintenance burden. Everytime you need to add a new condition, the class with the conditional needs to be edited.
<br>
To avoid this problem we need to use polymorphism. Instead of using multiple conditional statements, we create one new class to every condition we need to verify. Now, instead of verifying ``Class.Type`` , we can verify the ``Class`` itself.
<br>
Initially we need to create an abstract class that our classes will extend with all methods and properties we need.
<br>
Then we need to create a class to every condition we need to supply. These classes will override our abstract class methods and implement them own.
<br>
Now, if we need to add some new condition to verify, we just create a new class that extends the abstract class.

### Replacing a constructor with a factory method
Now that we have replaced the class by a abstract class, it is not possible to instantiate the class anymore. So, how can we create a specific class type? Using a factory method.
<br>
Firstly, we need to create an static method that will return the base abstract type inside the abstract class itself. This method receives a type as parameter and, inside it, a ``switch/case`` statement will instantiate a new subclass type depending on what it received on it argument.
<br>
The advantages here are: the client doesn't need to instantiate the class anymore. As the factory method is static, it can be called by type rather than on an instance of that type. Second, the return type is the base class, allowing you to hide the subclass account from clients.

### Replacing a constructor with a factory class
There is an alternative to the factory method: the factory class. To implement the factory class, firstly we need to create an interface with the signature of the create method. This interface will be implemented by a concrete factory class. This class will have the conditional that chooses which subclass to instantiate.
<br>
Using DI and IoC, the client class will receive as constructor parameter the class that implemented the concrete factory class. This class also needs to have a create method, but instead of instantiate the subclass, it will call the create method of the factory received earlier.
```c#
// Factory interface
 public interface IFactory
  {
    AccountBase CreateAccount(AccountType accountType);
  }

// Concrete factory class that will instantiate the subclasses
public class ConcreteFactory : IFactory
  {
    public SubClassBase CreateSubClass(SubClassType type)
    {
      SubClassBase subClass = null;
      switch (type)
      {
        case SubClassType.X:
          subClass = new FooClass();
          break;
        case SubClassType.Y:
          subClass = new BarClass();
          break;
        case SubClassType.Z:
          subClass = new FooBarClass();
          break;
      }
      return subClass;
    }
  }

  // Client
  public class Client
  {
    public Client(IFactory factory)
    {
      _factory = factory;
    }
    public void CreateSubClass(SubClassType subClassType)
    {
      NewAccount = _factory.CreateAccount(subClassType);
    }
    private readonly IAccountFactory _factory;
    private SubClassBase NewAccount;
  }
```


<hr>

## Student

[Carlos Martins](https://github.com/CarlMartins)
<br>
[Linkedin](https://www.linkedin.com/in/CarlosMartinsOliveira)
