using CuttingEdge.Conditions;
using MicroserviceWebApi.SkubanaAccess.Configuration;
using SkubanaAccess.Shared;
using System;
using System.Collections.Generic;

namespace SkubanaAccess.Models.Commands
{
	public class RetrieveProductsUpdatedAfterCommand : SkubanaCommand
	{
		public RetrieveProductsUpdatedAfterCommand( SkubanaConfig config, DateTime updatedAfterUtc, int page, int limit ) : base( config, SkubanaEndpoint.RetrieveProductsUrl )
		{
			Condition.Requires( page, "page" ).IsGreaterOrEqual( 1 );
			Condition.Requires( limit, "limit" ).IsGreaterOrEqual( 1 );

			this.RequestParameters = new Dictionary< string, string >()
			{
				{ "modifiedDateFrom", updatedAfterUtc.ConvertDateTimeToStr() },
				{ "page", page.ToString() },
				{ "limit", limit.ToString() }
			};
		}
	}
}
