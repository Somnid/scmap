using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using scmap.Extensions;
using scmap.Helpers;

namespace scmap
{
    public class SitecoreModelBuilder
    {
        public string BuildModel(dynamic item, List<dynamic> fields)
        {
            var itemName = ((string)item.Name).Replace(" ", string.Empty);

            using (var stringWriter = new StringWriter())
            {
                using (var indentedTextWriter = new IndentedTextWriter(stringWriter))
                {
                    indentedTextWriter.WriteLine("namespace {0}", ConfigHelper.Read().GetStringProperty("namespace") ?? "default");
                    indentedTextWriter.WriteLine("{");
                    indentedTextWriter.Indent++;
                    indentedTextWriter.WriteLine("public class {0}", itemName);
                    indentedTextWriter.WriteLine("{");
                    indentedTextWriter.Indent++;
                    foreach (var field in fields)
                    {
                        indentedTextWriter.WriteLine("public string {0} {{ get; set; }}", ((string)field.Name).Replace(" ", string.Empty));
                    }
                    indentedTextWriter.Indent--;
                    indentedTextWriter.WriteLine("}");
                    indentedTextWriter.Indent--;
                    indentedTextWriter.WriteLine("}");
                }

                stringWriter.Flush();
                return stringWriter.ToString();
            }
        }
    }
}
