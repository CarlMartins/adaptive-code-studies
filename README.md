<h2 align="center">Adaptive Code Studies</h2>

<p align="center">
  <a href=#about>About</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href=#summary>Summary</a> &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  <a href=#developers>Developers</a>
</p>

### About

### Summary
- [The Null Object Pattern](#the-null-object-pattern)

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