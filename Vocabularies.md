# Introduction #

XCRI-CAP aims to provide a base structure for course information but recommends that the types of various elements are - where possible - defined within existing published Vocabularies.  Vocabularies within the library are held within the [XCRI.Vocabularies](http://code.google.com/p/xcricap-net/source/browse/#hg%2FXCRI%2FVocabularies) namespace.

An example of a published Vocabulary is the [XCRI-CAP 1.1 Terms vocabulary](http://www.xcri.org/wiki/index.php/XCRI_Terms_1.1), an implementation of which is available at [XCRI.Vocabularies.XCRICAP11.Terms](http://code.google.com/p/xcricap-net/source/browse/#hg%2FXCRI%2FVocabularies%2FXCRICAP11%2FTerms).

# XCRI-CAP 1.1 Terms #

The [XCRI-CAP 1.1 Terms vocabulary](http://www.xcri.org/wiki/index.php/XCRI_Terms_1.1) provides suggested terms for use within sections of a XCRI-CAP 1.1 document.  This aims to provide structure for sections where the use of free-text data may not be useful for aggregators.

## Details ##

Implementations are provided of the XCRI-CAP 1.1 Terms vocabulary for:
  1. AttendanceMode
  1. AttendancePattern
  1. Description
  1. StudyMode

## Example ##

A standard provision of a studyMode element may look like the following:
```
XCRI.Interfaces.IStudyMode studyMode = new XCRI.StudyMode()
{
	Value = "Full time"
};
myPresentation.StudyMode = studyMode;
```

The problem with this approach is that any system consuming the feed needs to understand all the various permutations of specifying "full time".  For example as well as handling capitalisation issues it would also need to handle the words being hyphenated or, potentially, concatenated into a single word, possibly in camel case.  All of these are methods of exposing the fact that the presentation is full time and none of these in themselves are wrong by definition.

The XCRI-CAP 1.1 Terms vocabulary instead provides an enumeration of possible values to help any aggregators read your feed.  An example of using the XCRI-CAP 1.1 Terms vocabulary is below:
```
XCRI.Interfaces.IStudyMode studyMode = new XCRI.Vocabularies.XCRICAP11.Terms.StudyMode()
{
	Value = XCRI.Vocabularies.XCRICAP11.Terms.StudyModeTypes.FullTime
};
myPresentation.StudyMode = studyMode;
```