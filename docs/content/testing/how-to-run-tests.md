# How to run tests

This document describes how to run tests for the two parts of the SpatialOS GDK for Unity (GDK):

* the tools (which includes the document linter)
* the Unity project

Note that each part of the GDK project has its own separate testing.

## How to run all tests

To run tests on all elements of the GDK (the tools and the Unity project which forms part of the GDK), open a terminal window and, from the root directory of the GDK repository, run the following command: `bash ./ci/test.sh`

## Test success or failure

* A successful test run displays this message: `All tests passed!`
* A failed test run displays this message: `Tests failed! See above for more information.`

## How to test the GDK’s Unity project only

In addition to the `test.sh` script mentioned above, you can use the Test Runner Window in your Unity Editor to test the Unity Engine integration specific parts of the GDK.
The tests for the GDK are the assemblies that start with `Improbable.Gdk.`.<br>
For more information on how to use the Unity Test Runner, see Unity’s [Unity Test Runner manual page](https://docs.unity3d.com/Manual/testing-editortestsrunner.html).

[//]: # (Editorial review status: Full review 2018-07-13)
