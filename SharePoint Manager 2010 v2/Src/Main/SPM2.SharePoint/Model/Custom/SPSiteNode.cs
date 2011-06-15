/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using System.Collections.Generic;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="Url")]
    [Icon(Small = "ITS16.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteCollectionNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPSiteSubscriptionSiteCollectionNode")]
	public partial class SPSiteNode
	{
        public override IEnumerable<SPNode> NodesToExpand()
        {
            return this.Children.OfType<SPWebNode>().Take(1).Cast<SPNode>();
        }


        public override void LoadChildren()
        {
            base.LoadChildren();

            SPWebNode webNode = this.Children.OfType<SPWebNode>().FirstOrDefault();
            if (webNode != null)
            {
                // Move the WebNode to first position
                this.Children.Move(this.Children.IndexOf(webNode), 0);
            }
        }
	}

}