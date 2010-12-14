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
	[Icon(Small="BULLET.GIF")]
	//[ExportToNode("SPM2.SharePoint.Model.SPFileNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPFolderCollectionNode")]
	//[ExportToNode("SPM2.SharePoint.Model.SPListItemNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPMobileContextNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPWebNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthRulesListNode")]
	[ExportToNode("SPM2.SharePoint.Model.SPHealthReportsListNode")]
	public partial class SPFolderNode
	{
        public override void Setup(object spObject)
        {
            base.Setup(spObject);

            this.Text = this.Folder.Name;
        }
	}

}
