//------------------------------------------------------------------------------
// <copyright file="ConfigXmlCDataSection.cs" company="Microsoft">
//     
//      Copyright (c) 2006 Microsoft Corporation.  All rights reserved.
//     
//      The use and distribution terms for this software are contained in the file
//      named license.txt, which can be found in the root of this distribution.
//      By using this software in any fashion, you are agreeing to be bound by the
//      terms of this license.
//     
//      You must not remove this notice, or any other, from this software.
//     
// </copyright>
//------------------------------------------------------------------------------

namespace System.Configuration
{
    using System.Configuration.Internal;
    using System.IO;
    using System.Xml;
    using System.Security.Permissions;

    internal sealed class ConfigXmlCDataSection : XmlCDataSection, IConfigErrorInfo {
        int _line;
        string _filename;

        public ConfigXmlCDataSection( string filename, int line, string data, XmlDocument doc )
            : base( data, doc) {
            _line = line;
            _filename = filename;
        }
        int IConfigErrorInfo.LineNumber {
            get { return _line; }
        }
        string IConfigErrorInfo.Filename {
            get { return _filename; }
        }
        public override XmlNode CloneNode(bool deep) {
            XmlNode cloneNode = base.CloneNode(deep);
            ConfigXmlCDataSection clone = cloneNode as ConfigXmlCDataSection;
            if (clone != null) {
                clone._line = _line;
                clone._filename = _filename;
            }
            return cloneNode;
        }
    }
}
