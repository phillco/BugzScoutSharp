// Copyright 2000-2004 Fog Creek Software, Inc.

#region credits
//*********************************************************************************************
// The original BugReportSubmitException.cs file was created by Lasse V. Karlsen, 14. Apr 2004. 
// Email: lasse@vkarlsen.no
// For FogBugz support, send emails to customer-service@fogcreek.com
//*********************************************************************************************
#endregion

using System;
using System.Reflection;
using System.Resources;
using System.Runtime.Serialization;


namespace FogBugz{

    /// <summary>
    /// Represents errors that occur during submission of <see cref="BugReport"/> reports.
    /// </summary>
    [Serializable]
    public class BugReportSubmitException : SystemException, ISerializable
    {
        #region Construction & Destruction

        /// Initializes a new instance of the <see cref="BugReportSubmitException">BugReportSubmitException</see>
        /// class with serialized data.
        protected BugReportSubmitException(SerializationInfo info, StreamingContext context) : base(info, context){
            // Nothing here
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BugReportSubmitException"/> class with an exception message
        /// loaded from a resource.
        public BugReportSubmitException(Type resourceSource, String resourceName, Exception innerException) 
			: base(new System.Resources.ResourceManager(resourceSource).GetString(resourceName), innerException) {
            // Nothing here
        }
    
        public BugReportSubmitException(Type resourceSource, String resourceName)
            : base(new System.Resources.ResourceManager(resourceSource).GetString(resourceName)){
            // Nothing here
        }

        public BugReportSubmitException(String message, Exception innerException)
            : base(message, innerException){
            // Nothing here
        }

        public BugReportSubmitException(String message)
            : base(message){
            // Nothing here
        }

        public BugReportSubmitException()
            : base(){
            // Nothing here
        }

        #endregion
    }
}
#region Source Control History
//
// $History: /VS.NET/LVK/Debugging/FogBugz/BugReportSubmitException.cs $
//  
//  ****************** Version 3 ****************** 
//  User: lassevk   Date: 2004-04-16   Time: 08:54:38+02:00 
//  Updated in: /VS.NET/LVK/Debugging/FogBugz 
//  - Added static methods for submitting bug reports 
//  - Added unique id creation from exception 
//  - Added string return value to submit method 
//  - Fixed various minor documentation issues 
//  
//  ****************** Version 2 ****************** 
//  User: lassevk   Date: 2004-04-15   Time: 00:59:31+02:00 
//  Updated in: /VS.NET/LVK/Debugging/FogBugz 
//  Made FogBugz name properly cased 
//  Added some minor documentation 
//  
//  ****************** Version 1 ****************** 
//  User: lassevk   Date: 2004-04-15   Time: 01:02:02+02:00 
//  Updated in: /VS.NET/LVK/Debugging/FogBugz 
//  Added FogBugz utility classes 
//
#endregion