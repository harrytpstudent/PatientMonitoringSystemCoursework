using System;

namespace PatientMonitoringSystem
{
	// We are using two implementations this interface to show that we know how interfaces work, and that implementations can differ.
	// However, in this application, modules are simple entities, and you could get away with having only one implementation, which allows the Name property to be assigned any value.

	// Always use composition (has-a relationsips) over inheritance (is-a relationships).
	// Do this to avoid the pitfalls of inheritance, such as overcomplexity, unmaintainability, wastage of resources and the diamond problem.
	// Read this article: https://codingdelight.com/tag/composition-over-inheritance/
	// If you find yourself duplicating logic, you can always extract it.

	// Also, you can use dependency injection if you:
	// * Want to reuse classes and control their lifecycles in a more sophisticated way.
	// * Don't want to write a lot of boilerplate code for instantiating all of the class's dependencies.
	// * Want to make unit testing very easy by using mocks instead of shims.
	// * Are afraid of making things static (single instance) in case you want there to be multiple instances later (e.g. for scalability and asynchronicity).

	// TODO: Consider whether Min and MaxValue should be extracted into a struct.
	// The values are related, and in the UI we may want to validate after both have been specified.
	// Currently, there are scenarios where you have to reduce Min before you can reduce MaxValue.
	public interface IModuleStrategy
	{
		int GetCurrentReading(int min, int max);
	}
}
