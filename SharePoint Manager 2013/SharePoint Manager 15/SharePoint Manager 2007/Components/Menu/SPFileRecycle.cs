﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keutmann.SharePointManager.ViewModel.TreeView;
using SPM2.SharePoint.Model;

namespace Keutmann.SharePointManager.Components.Menu
{
    [Export("SPM2.SharePoint.Model.SPFileNode", typeof(ToolStripItem))]
    [ExportMetadata("Order", 200)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SPFileRecycle : ToolStripMenuItem, ISPMenuItem
    {
        public SPTreeNode TreeNode { get; set; }

        public SPFileRecycle()
        {
            Text = "Recycle";
        }


        protected override void OnClick(EventArgs e)
        {
            var model = (SPFileNode)TreeNode.Model;
            model.File.Recycle();

        }
    }
}
