<h2 align="center">Adaptive Code Studies</h2>

<p align="center">
  <a href=#about>About</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href=#summary>Summary</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href=#developers>Developers</a>
</p>

### About

### Summary
- [The Null Object Pattern](#the-null-object-pattern)
- [Unit Tests](#unit-tests)

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
- The <strong>arrange</strong>ment of the preconditions of the test.
- The performance of the <strong>act</strong> that is being  tested.
- The <strong>assert</strong>ion that the expected behavior occurred.
<br>
  
When working with TDD (Test-Driven Development), the idea behind is that do not exist any 
production code, what will cause inevitable an error when running the written tests.
<br>
Next, you need to <i>implement just enough of the SUT (the class you are testing) so
that test passes</i>. 
<br>
Finally, you are able to refactor your SUT to pass all the new tests created.
<br> <br>
Writing tests before the real implementation and following the described steps, prevents
over-engineering the solution and also prevents breaking existing functionalities.
