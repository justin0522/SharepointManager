/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPM2.Framework;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.Utilities;

namespace SPM2.SharePoint.Model
{
	[ExportToNode("SPM2.SharePoint.Model.SPFormCollectionNode")]
	public partial class SPFormNode
	{
        public override void Setup(object spObject)
        {
            base.Setup(spObject);

            this.Text = this.Form.Url.Substring(this.Form.Url.LastIndexOf("/") + 1);
            this.ToolTipText = this.Form.Url;
            this.Url = this.Form.ParentList.ParentWeb.Url + "/" + this.Form.Url;
            this.IconUri = SharePointContext.GetImagePath("ASPX16.GIF");

        }


        protected override void LoadChildren()
        {
            base.LoadChildren();

            SPLimitedWebPartCollectionNode webparts = new SPLimitedWebPartCollectionNode();
            SPWeb web = this.Form.ParentList.ParentWeb;

            SPLimitedWebPartManager manager = web.GetLimitedWebPartManager(this.Form.Url, System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

            webparts.Setup(manager.WebParts);

            this.Children.Add(webparts);
        }

	}
}
