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
using SPM2.Framework.ComponentModel;
using System.Collections.Generic;

namespace SPM2.SharePoint.Model
{
	[Title(PropertyName="DisplayName")]
    [Icon(Small = "SPM2.SharePoint.Properties.Resources.actionssettings", Source = IconSource.Assembly)]
	public partial class SPFarmNode
	{
        public override IEnumerable<SPNode> NodesToExpand()
        {
            return Children.OfType<SPServiceCollectionNode>().Cast<SPNode>();
        }
	}
}
