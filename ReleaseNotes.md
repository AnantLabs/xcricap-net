# Future Releases #

The next planned release is **version 0.3**.  This release will bring compatibility with the [XCRI-CAP 1.2 specification](http://www.xcri.org/wiki/index.php/XCRI_CAP_1.2) which was announced [on the 17 February 2011](http://www.xcri.org/forum/topic.php?id=133).

Depending upon community feedback, existing modifications may be made to the 0.2 branch where required.  Please report any issues using the [issue tracking](http://code.google.com/p/xcricap-net/issues/list) system at the top of the page.

# Current Release #

## ALPHA Version 0.3.0a (9 April 2011) ##

  * Initial version with compatibility with XCRI-CAP 1.2.  Please note that the 1.2 standard is still undergoing some tweaks, with the XSD files expected to take a number of weeks to be finalised.  Object model and XML structure is indicative of the current near-final working draft but changes are expected before 0.3 is released.
  * Modification to object model to allow compatibility with both XCRI-CAP 1.1 and XCRI-CAP 1.2 standards.  For example, `XCRI.Interfaces.IPresentation` now inherits from `XCRI.Interfaces.XCRICAP11.IPresentation` and `XCRI.Interfaces.XCRICAP12.IPresentation`, allowing both sets of properties to be populated.
  * Interface structure re-organised to more closely replicate the existing XCRICAP XSD file structures.  The aim is to ensure that bugs for missing common data structures (e.g. title/subject/description) that were common in the 0.1/0.2 releases are removed permanently.

Please feel free to report any issues back to [@CraigHawker](http://www.twitter.com/CraigHawker/).

## STABLE Version 0.2.2 (25 February 2011) ##

  * Fixed [issue 1](http://code.google.com/p/xcricap-net/issues/detail?id=1&can=1) relating to `<subject>` nodes not being correctly output within ICatalog elements for XCRI-CAP 1.1
  * Fixed [issue 2](http://code.google.com/p/xcricap-net/issues/detail?id=2&can=1) relating to @recstatus attribute not being correctly output within ICatalog elements for XCRI-CAP 1.1

# Previous releases #

## Version 0.2.1 (19 February 2011) ##

  * Description node could not support plain-text content as per http://www.xcri.org/wiki/index.php/Description.

## Version 0.2 (16 February 2011) ##

  * Initial unit tests completed, all fixes bundled into this release.
  * Links passed within the XCRI community for feedback.

## Version 0.1 (9 February 2011) ##

  * Object models reasonably complete, sample XCRI documents produced and validated.
  * Links passed to alpha testers.