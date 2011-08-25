﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlWriterBase.cs" company="OxyPlot">
//   http://oxyplot.codeplex.com, license: Ms-PL
// </copyright>
// <summary>
//   Base class for exporters that writes Xml.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Base class for exporters that writes Xml.
    /// </summary>
    public abstract class XmlWriterBase : IDisposable
    {
        #region Constants and Fields

        /// <summary>
        /// The s.
        /// </summary>
        private Stream s;

        /// <summary>
        /// The w.
        /// </summary>
        private XmlWriter w;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlWriterBase"/> class.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        protected XmlWriterBase(string path)
        {
            this.s = File.OpenWrite(path);
            this.w = XmlWriter.Create(this.s, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlWriterBase"/> class.
        /// </summary>
        /// <param name="stream">
        /// The stream.
        /// </param>
        protected XmlWriterBase(Stream stream)
        {
            this.w = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 });
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public virtual void Close()
        {
            if (this.w == null)
            {
                return;
            }

            this.w.Close();
            this.w = null;

            if (this.s != null)
            {
                this.s.Close();
                this.s = null;
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Close();
        }

        /// <summary>
        /// Flushes this instance.
        /// </summary>
        public void Flush()
        {
            this.w.Flush();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The write attribute string.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        protected void WriteAttributeString(string name, string value)
        {
            this.w.WriteAttributeString(name, value);
        }

        /// <summary>
        /// The write doc type.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="pubid">
        /// The pubid.
        /// </param>
        /// <param name="sysid">
        /// The sysid.
        /// </param>
        /// <param name="subset">
        /// The subset.
        /// </param>
        protected void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            this.w.WriteDocType(name, pubid, sysid, subset);
        }

        /// <summary>
        /// The write element string.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        protected void WriteElementString(string name, string text)
        {
            this.w.WriteElementString(name, text);
        }

        /// <summary>
        /// The write end document.
        /// </summary>
        protected void WriteEndDocument()
        {
            this.w.WriteEndDocument();
        }

        /// <summary>
        /// The write end element.
        /// </summary>
        protected void WriteEndElement()
        {
            this.w.WriteEndElement();
        }

        /// <summary>
        /// The write raw.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        protected void WriteRaw(string text)
        {
            this.w.WriteRaw(text);
        }

        /// <summary>
        /// The write start document.
        /// </summary>
        /// <param name="standalone">
        /// The standalone.
        /// </param>
        protected void WriteStartDocument(bool standalone)
        {
            this.w.WriteStartDocument(standalone);
        }

        /// <summary>
        /// The write start element.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected void WriteStartElement(string name)
        {
            this.w.WriteStartElement(name);
        }

        /// <summary>
        /// The write start element.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="ns">
        /// The ns.
        /// </param>
        protected void WriteStartElement(string name, string ns)
        {
            this.w.WriteStartElement(name, ns);
        }

        /// <summary>
        /// The write string.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        protected void WriteString(string text)
        {
            this.w.WriteString(text);
        }

        #endregion
    }
}