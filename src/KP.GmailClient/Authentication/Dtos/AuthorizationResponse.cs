﻿namespace KP.GmailClient.Authentication.Dtos
{
    /// <summary>See https://datatracker.ietf.org/doc/html/rfc6749#section-4.1.2 for documentation.</summary>
    internal class AuthorizationResponse
    {
        /// <summary>The authorization code generated by the authorization server.</summary>
        public string Code { get; set; }

        /// <summary>Required if the "state" parameter was present in the client authorization request.</summary>
        public string State { get; set; }

        /// <summary>
        /// Returned if the request fails due to a missing, invalid, or mismatching
        /// redirection URI, or if the client identifier is missing or invalid.
        /// </summary>
        public string Error { get; set; }

        /// <summary>Optional human-readable ASCII text.</summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Optional URI identifying a human-readable web page with
        /// information about the error, used to provide the client
        /// developer with additional information about the error.
        /// </summary>
        public string ErrorUri { get; set; }

        public bool IsSuccess => string.IsNullOrWhiteSpace(Error) && !string.IsNullOrWhiteSpace(Code);

        public override string ToString()
        {
            return IsSuccess
                ? "Authorization success"
                : $"{(string.IsNullOrWhiteSpace(ErrorDescription) ? "Error" : ErrorDescription)} ({Error})";
        }
    }
}
