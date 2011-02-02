﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Interfaces
{
	/// <summary>
	/// Represents the Course element in the XCRI standard.
	/// </summary>
	public interface ICourse : IXmlElement, IXmlElementWithIdentifiers
	{

		/// <summary>
		/// The name of the course 
		/// </summary>
		IList<ITitle> Titles { get; }
        IList<ISubject> Subjects { get; }
		Uri Uri { get; set; }
        Image Image { get; set; }
		Dictionary<DescriptionTypes, DescriptionData> Descriptions { get; }
		IList<IQualification> Qualifications { get; }
		IList<IPresentation> Presentations { get; }
        // TODO: Credit: http://www.xcri.org/wiki/index.php/Credit
		
	}
	/// <summary>
	/// Represents the suggested terms for the description
	/// property as defined within http://www.xcri.org/wiki/index.php/XCRI_Terms_1.1
	/// </summary>
	public enum DescriptionTypes
	{
		aim,
		applicationProcedure,
		assessmentStrategy,
		careerOutcome,
		contactHours,
		contactPattern,
		events,
		indicativeResource,
		leadsTo,
		learningOutcome,
		policy,
		prerequisites,
		providedResource,
		regulations,
		requriedResource,
		specialFeature,
		support,
		structure,
		studyHours,
		teachingStrategy,
		topic
	}
}
