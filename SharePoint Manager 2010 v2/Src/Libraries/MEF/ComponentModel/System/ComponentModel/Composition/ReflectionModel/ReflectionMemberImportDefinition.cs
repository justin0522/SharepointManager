﻿// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition.ReflectionModel;
using System.Globalization;
using System.Reflection;
using Microsoft.Internal;
using Microsoft.Internal.Collections;
using System.ComponentModel.Composition.Primitives;

namespace System.ComponentModel.Composition.ReflectionModel
{
    internal class ReflectionMemberImportDefinition : ReflectionImportDefinition
    {
        private LazyMemberInfo _importingLazyMember;

        public ReflectionMemberImportDefinition(
            LazyMemberInfo importingLazyMember,
            string contractName, 
            string requiredTypeIdentity,
            IEnumerable<string> requiredMetadata,
            ImportCardinality cardinality, 
            bool isRecomposable, 
            CreationPolicy requiredCreationPolicy,
            ICompositionElement origin) 
            : base(contractName, requiredTypeIdentity, requiredMetadata, cardinality, isRecomposable, false, requiredCreationPolicy, origin)
        {
            Assumes.NotNull(contractName);

            this._importingLazyMember = importingLazyMember;
        }

        public override ImportingItem ToImportingItem()
        {
            ReflectionWritableMember member = this.ImportingLazyMember.ToReflectionWriteableMember();
            return new ImportingMember(this, member, new ImportType(member.ReturnType, this.Cardinality));
        }

        public LazyMemberInfo ImportingLazyMember
        {
            get { return this._importingLazyMember; } 
        }

        protected override string GetDisplayName()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0} (ContractName=\"{1}\")",    // NOLOC
                this.ImportingLazyMember.ToReflectionMember().GetDisplayName(),
                this.ContractName);
        }
    }
}
