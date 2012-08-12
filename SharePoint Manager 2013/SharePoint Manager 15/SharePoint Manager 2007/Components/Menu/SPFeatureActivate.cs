﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keutmann.SharePointManager.ViewModel.TreeView;
using SPM2.SharePoint.Model;

namespace Keutmann.SharePointManager.Components.Menu
{
    [Export("SPM2.SharePoint.Model.SPFeatureNode", typeof(ToolStripItem))]
    [ExportMetadata("Order", 100)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SPFeatureActivate : ToolStripMenuItem, ISPMenuItem
    {
        public SPTreeNode TreeNode { get; set; }

        public SPFeatureActivate()
        {
            Text = "Activate";
        }

        public override bool CanSelect
        {
            get
            {
                Enabled = !((SPFeatureNode)TreeNode.Model).Activated;
                return Enabled;
            }
        }


        protected override void OnClick(EventArgs e)
        {
            var feature = (SPFeatureNode)TreeNode.Model;
            feature.ActivateFeature();
            feature.UpdateIconUri();
            TreeNode.ImageIndex = Program.Window.Explorer.AddImage(feature.IconUri);
        }
    }
}
