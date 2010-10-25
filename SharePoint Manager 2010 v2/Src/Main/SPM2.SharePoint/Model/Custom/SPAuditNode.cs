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
	[Title("Audit")]
	[Icon(Small="BULLET.GIF")]
	[AttachTo("SPM2.SharePoint.Model.SPDocumentLibraryNode")]
	[AttachTo("SPM2.SharePoint.Model.SPFolderNode")]
	[AttachTo("SPM2.SharePoint.Model.SPListItemNode")]
	[AttachTo("SPM2.SharePoint.Model.SPListNode")]
	[AttachTo("SPM2.SharePoint.Model.SPWebNode")]
	[AttachTo("SPM2.SharePoint.Model.SPSiteNode")]
	[AttachTo("SPM2.SharePoint.Model.SPHealthRulesListNode")]
	[AttachTo("SPM2.SharePoint.Model.SPHealthReportsListNode")]
	public partial class SPAuditNode
	{
	}
}
