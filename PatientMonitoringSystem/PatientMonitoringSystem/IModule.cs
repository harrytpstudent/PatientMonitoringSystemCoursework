using System;

namespace PatientMonitoringSystem
{
	/* Originally, we created multiple implementations of this interface to demonstrate that we know how interfaces work and that implementations can differ.
	 * However, this wasn't scalable, and the classes were almost identical, so we opted for a single implementation which allows a name and behaviour to be injected.
	 * This way, on application startup, we can have a loop which instantiates modules and dynamically assigns random names and behaviours (we don't plan to create a management UI).
	 * By using the strategy pattern (abstracting out the 'how'), we can demonstrate that each module can be customised and behave differently, while still having some things in common, such as the ability to get the current reading.
	 * "Use the Strategy when you have a lot of similar classes that only differ in the way they execute some behavior." ~ https://refactoring.guru/design-patterns/strategy
	 * Factors considered:
	 * 1. How much do the modules differ from each other?
	 * 2. How often are new types of modules created?
	 * 3. How much does it cost to write new classes as opposed to injecting modules in?
	 * 4. Do any of the classes have too much responsibility?
	 * 5. Do we want to reuse some of the behaviour?
	 * 6. Is the end goal to make modules configuration-driven, so that we can delegate the responsibility of creating modules to the customer, or make it quicker and easier to implement features and fix mistakes?
	*/

	/* Always use composition ('has-a' relationsips) over inheritance ('is-a' relationships).
	 * Do this to avoid the pitfalls of inheritance, such as overcomplexity, unmaintainability, wastage of resources and the diamond problem.
	 * Read this article: https://codingdelight.com/tag/composition-over-inheritance/
	 * If you find yourself duplicating logic, you can always extract it. */

	/* Also, you can use dependency injection if you:
	 * 1. Want to reuse classes and control their lifecycles in a more sophisticated way.
	 * 2. Don't want to write a lot of boilerplate code for instantiating all of the class's dependencies in the class itself.
	 * 3. Want to make unit testing very easy by mocking out the dependencies, as opposed to shimming (changing a program's behaviour at runtime).
	 * 4. Are afraid of making things static (single instance) in case you need multiple instances in the future (e.g. for scalability, performance, and to avoid asynchronous locking). */

	/* TODO: Consider whether MinValue and MaxValue should be extracted into a struct.
	 * The values are related, and in the UI we may want to validate after both have been set by the user.
	 * Currently, there are scenarios where you have to reduce MinValue before you can reduce MaxValue. */
	public interface IModule
	{
		Guid Id { get; }

		string Name { get; }

		int MinValue { get; set; }

		int MaxValue { get; set; }

		int GetCurrentReading();
	}
}
