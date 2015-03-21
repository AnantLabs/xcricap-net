# The Object Model #

The XCRICAP-NET generator object model aims to reflect the various feed structures within the XCRI-CAP 1.1 and XCRI-CAP 1.2 standards (1.2 currently being designed).  It aims to make the differences between the standards transparent to the developer.

As an example, the XCRI.Title object should be rendered as a `<title>` element within the XCRI 1.1 namespace when generating an XCRI 1.1 file but within the Dublin Core namespace when generating an XCRI 1.2 file.  To the developer this complexity is completely hidden by the library.

## Namespaces ##

The project is split into several namespaces:
  * **XCRI** - contains default implementations of the various interfaces
  * **XCRI.Interfaces** - defines interfaces which the system uses
  * **XCRI.Vocabularies** - defines extensions to the default interface implementations for specific vocabularies
  * **XCRI.XmlBaseClasses** - defines base classes (may be removed - consider deprecated)
  * **XCRI.XmlGeneration** - defines interfaces, implementations and factory classes for dealing directly with the generation of the XML feeds.

For the purposes of generating an XCRI-CAP feed, you will only need to work with the **XCRI**, **XCRI.Vocabularies** and **XCRI.XmlGeneration** namespaces.

## Object Model Design ##

The object model has been designed to closely mimic the XCRI-CAP standard structure  Below are examples of elements within the XCRI-CAP 1.1 standard, the associated interface within the generator library, and the default implementation.

| **Element** | **Interface** | **Implementation** |
|:------------|:--------------|:-------------------|
| [Catalog](http://www.xcri.org/wiki/index.php/Catalog) | [XCRI.Interfaces.ICatalog](http://code.google.com/p/xcricap-net/source/browse/XCRI/Interfaces/ICatalog.cs) | [XCRI.Catalog](http://code.google.com/p/xcricap-net/source/browse/XCRI/Catalog.cs) |
| [Provider](http://www.xcri.org/wiki/index.php/Provider) | [XCRI.Interfaces.IProvider](http://code.google.com/p/xcricap-net/source/browse/XCRI/Interfaces/IProvider.cs) | [XCRI.Provider](http://code.google.com/p/xcricap-net/source/browse/XCRI/Provider.cs) |
| [Course](http://www.xcri.org/wiki/index.php/Course) | [XCRI.Interfaces.ICourse](http://code.google.com/p/xcricap-net/source/browse/XCRI/Interfaces/ICourse.cs) | [XCRI.Course](http://code.google.com/p/xcricap-net/source/browse/XCRI/Course.cs) |

# How to interact with XML generators #

## The principle ##

Interaction with XML generators follows a simple principle:
  * Create an instance of the objects
  * Hydrate your objects using your own existing data access methodologies
  * Call the static [XCRI.XmlGeneration.XmlGeneratorFactory](http://code.google.com/p/xcricap-net/source/browse/XCRI/XmlGeneration/XmlGeneratorFactory.cs).GetXmlGenerator method, passing the [XCRI-CAP version](http://code.google.com/p/xcricap-net/source/browse/XCRI/XCRIProfiles.cs) you wish to generate
  * Set the RootNode and optionally the Namespaces properties on the IXmlGenerator returned.
  * Call one of the .Generate overloads, depending upon what you wish to output to.

### Notes ###

Bear in mind that the XCRI-CAP 1.1 and XCRI-CAP 1.2 standards allow the root XML element to be either an Catalog, Provider or Course.  In the same vein the IXmlGenerator returned will allow you to set the RootNode property to an object that implements either ICatalog, IProvider or ICourse.  **Normally you will set it to an object that implements ICatalog.**

The object model also allows for implementation of the [Delta Update Pattern](http://www.xcri.org/wiki/index.php/Delta_update_pattern) - for more information see the DeltaUpdatePattern wiki entry.

## An example ##

### Creating an object model ###

The first step with generating a feed is to create an object model representing the courses that your institution provides.  In most circumstances you will need to:
  1. Create an instance of XCRI.Catalog
  1. Create an instance of XCRI.Provider and populate it with your institution's details
  1. Create multiple instances of XCRI.Course, one for each course that your institution offers.
  1. Within XCRI.Course, populate the Presentations IList.  A Presentation is a mode in which a user can take a specific course - e.g. there may be one presentation for a full-time mode and one for an evening-only mode.
  1. Add your courses into the provider's Courses IList.
  1. Add your provider into your catalog's Providers IList.

The exact way you implement this will be down to your existing data access layers and methodologies, but a mock is shown below.

```

XCRI.Interfaces.ICatalog catalog = new XCRI.Catalog();
XCRI.Interfaces.IProvider provider = new XCRI.Provider()
{
	// ... <- to complete
};
XCRI.Interfaces.ICourse course = new XCRI.Course()
{
	// ... <- to complete
}
XCRI.Interfaces.IPresentation presentation = new XCRI.Presentation()
{
	// ... <- to complete
};
course.Presentations.Add(presentation);
provider.Courses.Add(course);
catalog.Providers.Add(provider);

```

### Rendering the object model as an XCRI 1.1 feed ###

To render the object model, you first need to get a reference to an appropriate implementation of XCRI.XmlGeneration.Interfaces.!IXmlGenerator.  The simplest method is to use the XmlGeneratorFactory's GetXmlGenerator method.

Then simply provide the generator with your object model and call the relevant Generate method.

```

XCRI.XmlGeneration.Interfaces.IXmlGenerator
	gen = XCRI.XmlGeneration.XmlGeneratorFactory.GetXmlGenerator(XCRI.XCRIProfiles.XCRI_v1.1;
gen.RootNode = catalog; // Populated above
StringBuilder sb = new StringBuilder();
gen.Generate(sb);
// sb will now contain a valid XCRI-CAP 1.1 feed.

```

### Rendering the object model as an XCRI 1.1 feed on an ASP.NET (WebForms) web page ###

The Generate method also has an overload which can take a HtmlTextWriter to generate directly to the output stream of an ASP.NET WebForms page.

Please note that you should - prior to the Render method being called - set the HTTP response object's ContentType to "text/xml".

```

protected override void Render(HtmlTextWriter writer)
{
	XCRI.XmlGeneration.Interfaces.IXmlGenerator
		gen = XCRI.XmlGeneration.XmlGeneratorFactory.GetXmlGenerator(XCRI.XCRIProfiles.XCRI_v1_1);
	gen.RootElement = catalog; // Populated above
	// Force generation
	gen.Generate(writer);
}

```

# Further information #

## Vocabularies ##

The [Vocabularies](Vocabularies.md) page describes implementations of specific recommended vocabularies (e.g. XCRI-CAP 1.1's Terms vocabulary).