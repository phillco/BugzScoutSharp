using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;

namespace FogBugz
{
    /// <summary>
    /// Lets you create bug reports and submit them to FogBugz. Originally by Lasse V. Karlsen (2004), lasse@vkarlsen.no; revamped by Phillip Cohen (2011), pc@phillipcohen.net.
    /// 
    /// Copyright (c) 2000-2011 Fog Creek Software, Inc. 
    /// For FogBugz support, e-mail customer-service@fogcreek.com.
    /// </summary>
    public class BugReport
    {
        /// <summary>
        /// The result of a bug report.
        /// </summary>
        [Serializable]
        public class Result
        {
            public bool Succeeded { get; set; }

            public string Message { get; set; }
        }

        public string UserName { get; set; }
        public string Project { get; set; }
        public string Area { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CustomerEmail { get; set; }
        public bool ForceNewReport { get; set; }
        public string FogBugzUrl { get; set; }
        public string DefaultMessage { get; set; }

        /// <summary>
        /// Appends some details about the user's computer to the bug report. Eg, "Opened by User, from MACHINE (56.23.124.16)"
        /// </summary>
        /// <param name="header">The starting header; customize it as you like ("Opened by", "Followup added by", "Feedback submitted by", etc.)</param>
        public void AddMachineDetails( string header )
        {
            Description += String.Format( "{0} {1}, from {2} ({3}):" + Environment.NewLine, header, Environment.UserName, Environment.MachineName, Dns.Resolve( Environment.MachineName ).AddressList[0].ToString( ) );
        }

        /// <summary>
        /// Appends the details about an exception to the bug report. (Also formats it nicely.) You can call this multiple times with different exceptions if you like.
        /// </summary>
        /// <param name="e"></param>
        public void AddExceptionDetails( Exception e )
        {
            Description += String.Format( "[code]{0}[/code]\nLocation: {1}\n", e.ToString( ), Util.GetExceptionSignature( e, true ) );
            Title = String.Format( "{0}: {1}", Util.GetExceptionSignature( e, false ), e.Message );
        }

        /// <summary>
        /// Appends a list of all loaded assemblies to the bug report.
        /// </summary>
        public void AddAssemblyList( )
        {
            Description += Util.GetAssemblyList( );
        }

        /// <summary>
        /// Converts this bug report to a list of HTTP POST parameters suitable for sending to server.
        /// </summary>
        /// <returns></returns>
        public char[] ToPostArray( )
        {
            string parameters = "Description=" + HttpUtility.UrlEncode( this.Title );
            if ( this.Description != null && this.Description.Length > 0 )
                parameters += "&Extra=" + HttpUtility.UrlEncode( this.Description );
            if ( this.CustomerEmail != null && this.CustomerEmail.Length > 0 )
                parameters += "&Email=" + HttpUtility.UrlEncode( this.CustomerEmail );
            parameters += "&ScoutUserName=" + HttpUtility.UrlEncode( this.UserName );
            parameters += "&ScoutProject=" + HttpUtility.UrlEncode( this.Project );
            parameters += "&ScoutArea=" + HttpUtility.UrlEncode( this.Area );
            parameters += "&ForceNewBug=" + ( this.ForceNewReport ? "1" : "0" );

            return parameters.ToCharArray( );
        }

        /// <summary>
        /// Submits this report to FogBugz.
        /// </summary>
        /// <returns></returns>
        public Result Submit( )
        {  
            if ( this.Title == null || this.Title.Length == 0 ) throw new ArgumentNullException( "Title" );
            if ( this.Project == null || this.Project.Length == 0 ) throw new ArgumentNullException( "Project" );
            if ( this.Area == null || this.Area.Length == 0 ) throw new ArgumentNullException( "Area" );

            return Submit( FogBugzUrl, ToPostArray( ) );
        }

        /// <summary>
        /// Submits the given array of POST parameters to the given FogBugz address.
        /// This lets you submit a bug report that saved earlier, e.g., to a file.
        /// </summary>
        /// <returns></returns>
        public static Result Submit( string url, char[] paramData )
        {
            try
            {
                // Create the request.
                WebRequest request = WebRequest.Create( url );
                request.Timeout = 15000;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";

                // Append the parameters...
                byte[] parameters = Encoding.ASCII.GetBytes( paramData );
                request.ContentLength = parameters.Length;
                using ( Stream outStream = request.GetRequestStream( ) )
                    outStream.Write( parameters, 0, parameters.Length );

                // ...and submit it!
                WebResponse response = request.GetResponse( );
                if ( response == null )
                    return new Result { Succeeded = false };

                return ParseResult( new StreamReader( response.GetResponseStream( ) ).ReadToEnd( ).Trim( ) );
            }
            catch ( WebException e ) { return new Result { Succeeded = false, Message = e.ToString() }; }
        }

        /// <summary>
        /// Deciphers the FogBugz server's XML result.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static Result ParseResult( string result )
        {
            // Check for a success result first and just return in that case
            Match ma = Regex.Match( result, "<Success>(?<message>.*)</Success>", RegexOptions.IgnoreCase );
            if ( ma.Success )
                return new Result { Succeeded = true, Message = ma.Groups["message"].Value };

            // Check for a failure result second, and throw an exception in that case
            ma = Regex.Match( result, "<Error>(?<message>.*)</Error>", RegexOptions.IgnoreCase );
            if ( ma.Success )
                return new Result { Succeeded = false, Message = ma.Groups["message"].Value };

            // Unknown format...
            return new Result { Succeeded = false, Message = result };
        }
    }
}
