using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;

namespace Genius.SDK.Common
{
    public class UriHelper
    {
        private readonly Dictionary<string, string> _queryParameters = new();

        public UriHelper(string resourceUri)
        {
            ResourceUri = resourceUri;
        }

        private string ResourceUri { get; }

        public void AddQueryParameter(string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                _queryParameters.Add(key, value);
        }

        public void AddQueryParametersCollection(IEnumerable<KeyValuePair<string, string>> queries)
        {
            foreach (var (key, value) in queries) AddQueryParameter(key, value);
        }

        /// <summary>
        ///     Based on https://github.com/dotnet/aspnetcore/blob/master/src/Http/WebUtilities/src/QueryHelpers.cs
        /// </summary>
        /// <returns> A fully qualified resource URI</returns>
        public override string ToString()
        {
            var anchorIndex = ResourceUri.IndexOf('#');
            var uriToBeAppended = ResourceUri;
            var anchorText = "";
            // If there is an anchor, then the query string must be inserted before its first occurrence.
            if (anchorIndex != -1)
            {
                anchorText = ResourceUri.Substring(anchorIndex);
                uriToBeAppended = ResourceUri.Substring(0, anchorIndex);
            }

            var queryIndex = uriToBeAppended.IndexOf('?');
            var hasQuery = queryIndex != -1;

            var sb = new StringBuilder();
            sb.Append(uriToBeAppended);
            foreach (var (key, value) in _queryParameters)
            {
                if (value == null) continue;

                sb.Append(hasQuery ? '&' : '?');
                sb.Append(UrlEncoder.Default.Encode(key));
                sb.Append('=');
                sb.Append(UrlEncoder.Default.Encode(value));
                hasQuery = true;
            }

            sb.Append(anchorText);
            return sb.ToString();
        }
    }
}