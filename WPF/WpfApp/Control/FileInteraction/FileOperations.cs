//-----------------------------------------------------------------------
// <copyright file="FileOperations.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------

namespace WpfApp
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Windows;
    using System.Xml.Serialization;

    /// <summary>
    /// Performs interaction with files
    /// </summary>
    public class FileOperations
    {
        /// <summary>
        /// Serializes list of <see cref="EllipseInfo"/> and saves to file
        /// </summary>
        /// <param name="ellipses">List of <see cref="EllipseInfo"/> to serialize</param>
        /// <param name="path">Specifies a location in a file system</param>
        public static void Serialize(List<EllipseInfo> ellipses, string path)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<EllipseInfo>));
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                try
                {
                    xmlFormat.Serialize(stream, ellipses);
                }
                catch (SerializationException e)
                {
                    MessageBox.Show("Failed to serialize. Reason: " + e.Message);
                }
            }
        }

        /// <summary>
        /// Deserializes list of <see cref="EllipseInfo"/>
        /// </summary>
        /// <param name="fileName">name of file in which information is stored</param>
        /// <returns>List of <see cref="EllipseInfo"/></returns>
        public static List<EllipseInfo> Deserialize(string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<EllipseInfo>));
            List<EllipseInfo> ellipses = new List<EllipseInfo>();
            using (Stream stream = File.OpenRead(fileName))
            {
                try
                {
                    ellipses = (List<EllipseInfo>)xmlFormat.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    MessageBox.Show("Failed to deserialize. Reason: " + e.Message);
                }
            }

            return ellipses;
        }
    }
}
