# Introduction #

## Project aims ##

The project aim is to reduce the time required to implement an XCRI feed by an institution by allowing them to concentrate solely on their course data rather than the intrinsics of creating and managing an XML feed.  The XCRICAP-NET generator library is a .NET library that allows fast creation of [XCRI-CAP feeds](http://www.xcri.co.uk/) without the developer having to learn the [XCRI feed format(s)](http://www.xcri.org/wiki/index.php/XCRI_Wiki), manage XML namespaces and prefixes, or handle encoding.

## Project limits ##

The project currently does not - and is not planned to - validate the resultant XML feed; the object model aims to create a valid XML file but it will not validate it as XCRI-CAP compliant.

To validate whether it is compliant, use a validator tool such as http://www.craighawker.co.uk/XCRI/Validation/.

## Project updates ##

Occasionally there are blog posts by me, Craig Hawker (project owner) on my blog at http://www.craighawker.co.uk/index.php/category/xcri/.  Shorter, more informal updates can be found by following the [#xcrigenlib hashtag on twitter](http://twitter.com/#search?q=%23xcrigenlib).

# Licence #

This work is licensed under a <a href='http://creativecommons.org/licenses/by-nc-sa/3.0/'>Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License</a>.

<a href='http://creativecommons.org/licenses/by-nc-sa/3.0/'><img src='http://i.creativecommons.org/l/by-nc-sa/3.0/88x31.png' alt='Creative Commons Licence' /></a>

You may use this software library - and its source code - for free if you work directly for an educational institution (HE or FE) in a full-time capacity.  If you are a consultant, contractor, or third party who provides services to an educational institution (regardless of whether those services are free or paid), you may not use this software without additional licensing.  Please contact the [project owner](http://www.craighawker.co.uk) for further licensing information.

# How to get the library #

The library is available in two ways:
  * By downloading the latest binary (compiled) software from the [downloads](http://code.google.com/p/xcricap-net/downloads/list) page.  This contains all you need to develop using the library.
  * By connecting to the [mercurial source repository](http://code.google.com/p/xcricap-net/source/browse/).  This is only needed if you want to download the source code and either compile it yourself or make changes.

# Getting started #

A quick-start guide, walking a developer through creating an object model and outputting the feed via a page on a website, is provided on the [downloads](http://code.google.com/p/xcricap-net/downloads/list) page.

Further documentation can be found on the [GettingStarted](GettingStarted.md) wiki page.

# Release notes #

Further information on historic and planned future releases is available on the ReleaseNotes page.