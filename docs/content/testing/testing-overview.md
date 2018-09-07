[google-docs-link]: https://docs.google.com/document/d/1VMK37eVnMy-CMNMjRE8tZGRniqq7SoRAbG9kZ5rIAgw/edit# (Please place reviews as comments into this document here)

**Warning:** The [alpha](https://docs.improbable.io/reference/latest/shared/release-policy#maturity-stages) release is for evaluation purposes only, with limited documentation - see the guidance on [Recommended use](../../../README.md#recommended-use).

-----

# Test overview

We use tests to validate functionality and to ensure that the SpatialOS GDK for Unity (GDK) and the framework as a whole are resilient under different conditions.

## Test categories

We have two main test categories:
- Tools tests, such as testing the linter
- Unity tests  - these test the Unity project which forms part of the GDK

The tests in both of these categories use the NUnit testing framework. NUnit is the open source library that’s included with Unity; it forms the basis of the Unity Test Runner. See the [NUnit’s documentation](https://github.com/nunit/docs/wiki/NUnit-Documentation) and Unity’s User Manual [Test Runner documentation](https://docs.unity3d.com/Manual/testing-editortestsrunner.html) for further information.

## Where to find test code

* The documentation linter tests are in  `tools\DocsLinter\Tests`.
* The code generator tests are in `code_generator\GdkCodeGenerator\src\Tests`.
* For the Unity tests, each GDK Module has its own `Tests` directory.<br/>
For example:
  - `workers\unity\Assets\Gdk\Core\Tests`
  - `workers\unity\Assets\Gdk\PlayerLifecycle\Tests`

Find out more about the GDK Unity project test directory structure and file names in [Testing guidelines](./testing-guidelines.md#test-directory-structure-and-file-names).

## Further information

* [How to run tests](./how-to-run-tests.md)
* [Testing guidelines](./testing-guidelines.md) - covers Unity tests only (contains information on the GDK Unity project test directory structure and file names).
* [Writing a new test](./writing-a-new-unit-test.md) covers Unity tests only.

[//]: # (Editorial review status: Full review 2018-07-13)
