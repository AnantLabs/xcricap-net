# Introduction #

There are two methods to outputting an XCRI feed:
  1. Using the [simple aggregation pattern](http://www.xcri.org/wiki/index.php/Simple_aggregation_pattern)
  1. Using the [delta update pattern](http://www.xcri.org/wiki/index.php/Delta_update_pattern)

The simple aggregation pattern involves whatever is consuming your feed (the "aggregator") reading the entire feed at the point in time at which it's requested.  When using this pattern, the XCRI feed contains a snapshot of course information at the time at which the feed was generated.

The delta update pattern involves only outputting elements which have changed since the last request by the aggregator.

More information on the delta update pattern can be found at http://www.xcri.org/wiki/index.php/Delta_update_pattern.

# Details #

The generator library - as of v0.2 - supports the output of the "recstatus" attribute by the population of the "ResourceStatus" property on classes that implement the ICatalog, ICourse, IProvider, IQualification, IPresentation and IVenue interfaces.

To implement the delta update pattern, simply populate the ResourceStatus property accordingly as you generate your object model.

# Considerations #

  1. As XCRI feeds which implement the delta update pattern are currently few and far between, aggregators are less likely to implement this standard initially.
  1. The delta update pattern requires that your course system records course modification and deletion dates - at a minimum - to be able to correctly output the current resource's status.