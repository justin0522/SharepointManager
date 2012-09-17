/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[Title("Files")]
    [Icon(Small = "ITS16.GIF")]
	[ExportToNode("SPM2.SharePoint.Model.SPFolderNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	public partial class SPFileCollectionNode
	{
        public override void LoadChildren()
        {
            Children.AddRange(NodeProvider.LoadCollectionChildren(this, SPExplorerSettings.Current.BatchNodeLoad));
        }
	}
}
