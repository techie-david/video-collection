using MediatR;
using VideoCollection.Data;
using VideoCollection.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search;

namespace VideoCollection.Features.Search
{
    public class GetSearchResultsQuery
    {
        public class GetSearchResultsRequest : IAsyncRequest<GetSearchResultsResponse> {
            public string Query { get; set; }
        }

        public class GetSearchResultsResponse
        {
            public DocumentSearchResult Result { get; set; }
        }

        public class GetSearchResultsHandler : IAsyncRequestHandler<GetSearchResultsRequest, GetSearchResultsResponse>
        {
            public GetSearchResultsHandler(
                IDocumentsOperations documentOperations
                ) {
                _documentOperations = documentOperations;
            }

            public async Task<GetSearchResultsResponse> Handle(GetSearchResultsRequest request)
            {
                SearchParameters searchParameters = CreateSearchParameters(QueryType.Full,SearchMode.All,null,null,null,null);
                return new GetSearchResultsResponse()
                {
                    Result = await _documentOperations.SearchAsync(request.Query, searchParameters)
                };
            }

            protected virtual SearchParameters CreateSearchParameters(QueryType queryType, SearchMode searchMode, List<string> highlightFields, int? skip, string filter, int? top)
                => new SearchParameters()
                {
                    SearchMode = searchMode,
                    QueryType = queryType,
                    IncludeTotalResultCount = true,
                    HighlightFields = highlightFields,
                    Top = top,
                    Skip = skip,
                    Filter = filter,
                    Facets = new List<string>()
                };

            private IDocumentsOperations _documentOperations { get; set; }
        }
    }

}
