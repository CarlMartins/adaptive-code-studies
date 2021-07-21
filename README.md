<h2 align="center">Adaptive Code Studies</h2>

<p align="center">
  <a href=#about>About</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href=#summary>Summary</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href=#developers>Developers</a>
</p>

### About
This repository was made with the intention of documenting my studies using the
[Adaptive Code: Agile coding with design patterns and SOLID principles](https://www.amazon.com.br/Adaptive-Code-coding-patterns-principles/dp/1509302581)
book.

### Summary
- [The Null Object Pattern](#the-null-object-pattern)
- [Unit Tests](#unit-tests)
- [More Complex Tests](#more-complex-tests)
- [Writing tests for defect fixes](#writing-tests-for-defect-fixes)

<hr>

#### The Null Object Pattern

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

#### Unit Tests
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

#### More Complex Tests
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
<<<<<<< HEAD
<br>
  
#### Writing tests for defect fixes
Sometimes you can come across some exception that had been replaced with another one.
In this case, **DomainException** was replaced by **ServiceException**. It is very 
hard to understand the real cause of the problem so, to solve this problem, we need 
to wrap one exception to another.
<br>
Creating a custom exception that receives two parameters in it constructor (message and
inner) its enough to guide the information to the layer we want. We can access the 
information using **Exception.InnerException**.
<br>
=======
>>>>>>> 153b494d93ff9e967f13ce1af20bd82b956f66a4
