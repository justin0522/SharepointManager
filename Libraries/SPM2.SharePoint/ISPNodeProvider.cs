using System;
using System.Collections.Generic;
using SPM2.SharePoint.Model;

namespace SPM2.SharePoint
{
    public interface ISPNodeProvider
    {
        string View { get; set; }

        IEnumerable<ISPNode> LoadChildren(ISPNode node);
        IEnumerable<ISPNode> LoadUnorderedChildren(ISPNode sourceNode);
        Dictionary<Type, ISPNode> GetChildrenTypes(ISPNode parentNode);
        ISPNode FindDefaultNode(ISPNode node);
        IEnumerable<ISPNode> LoadCollectionChildren(ISPNodeCollection parentNode);
        ISPNode LoadFarmNode();
        string Serialize(ISPNode node);
        ISPNode Deserialize(string xml);
    }
}