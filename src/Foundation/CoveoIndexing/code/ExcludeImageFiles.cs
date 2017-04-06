﻿using Coveo.SearchProvider.Pipelines;
using Coveo.SearchProvider.InboundFilters;

namespace SitecoreHabitatDemo
{
    public class ExcludeImageFiles : AbstractCoveoInboundFilterProcessor
    {
        public override void Process(CoveoInboundFilterPipelineArgs args)
        {
            if (args.IndexableToIndex != null && !args.IsExcluded && ShouldExecute(args))
            {
                var extension = args.IndexableToIndex.Item.GetFieldValue("Extension");

                if ((extension == "gif") || (extension == "png") || (extension == "jpg"))
                {
                    args.IsExcluded = true;
                }
            }
        }
    }
}