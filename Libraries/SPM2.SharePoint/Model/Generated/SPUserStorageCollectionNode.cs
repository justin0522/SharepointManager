/* ---------------------------
 * SharePoint Manager 2010 v2
 * Created by Carsten Keutmann
 * ---------------------------
 */

using System;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using SPM2.Framework;

namespace SPM2.SharePoint.Model
{
	[AdapterItemType("Microsoft.SharePoint.SPUserStorageCollection, Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c")]
	public partial class SPUserStorageCollectionNode : SPNodeCollection
	{
        [XmlIgnore]
		public SPUserStorageCollection UserStorageCollection
        {
            get
            {
                return (SPUserStorageCollection)this.SPObject;
            }
            set
            {
                this.SPObject = value;
            }
        }
	}
}
